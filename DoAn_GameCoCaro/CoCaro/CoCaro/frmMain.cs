using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro
{
    public partial class frmCoCaro : Form
    {
        private Graphics grs;
        private CaroChess caroChess;
        public frmCoCaro()
        {
            InitializeComponent();
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOCo();
            grs = pnlBanCo.CreateGraphics();
            playerVsComToolStripMenuItem.Click += new EventHandler(PvsC_Click);
            btnPlayerVsCom.Click += new EventHandler(PvsC_Click);
        }

        private void timerChuChay_Tick(object sender, EventArgs e)
        {
            lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, lblChuoiChu.Location.Y - 1);
            if (lblChuoiChu.Location.Y + lblChuoiChu.Height < 0)
            {
                lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, pnlChuChay.Height);
            }
        }

        private void frmCoCaro_Load(object sender, EventArgs e)
        {
            lblChuoiChu.Text = "Người chơi lần lượt đặt\nquân cờ vào ô trống.\n\nNgười thắng là người\nđầu tiên có được một\nchuỗi liên tục gồm 5\nquân hàng ngang,\nhoặc dọc, hoặc chéo.\n\nChú ý: Nếu bị chặn \n2 đầu sẽ không\nđược tính thắng!\n\nChọn chế độ chơi ở\ndưới để bắt đầu chơi!";
            timerChuChay.Enabled = true;
            label4.Text = "O : 0";
            label5.Text = "X : 0";
            label6.Visible = false;
            label7.Visible = false;
            btnChoiMoi.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
            {
                MessageBox.Show("Vui lòng chọn chế độ chơi!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (caroChess.DanhCo(e.X, e.Y, grs))
            {
                label5.Text = "X : " + caroChess.X;
                label4.Text = "O : " + caroChess.O;
                if (caroChess.KiemTraChienThang())
                    caroChess.KetThucTroChoi();
                else if (caroChess.CheDoChoi == 2)
                {
                    caroChess.KhoiDongComputer(grs);
                    if (caroChess.KiemTraChienThang())
                        caroChess.KetThucTroChoi();
                }
            }
            label2.Text = caroChess.lbl.Text;
            if (caroChess.CheDoChoi == 1)
            {
                label6.Text = "Player 1 : " + caroChess.P1;
                label7.Text = "Player 2 : " + caroChess.P2;
            }
            else
            {
                label6.Text = "Com : " + caroChess.C;
                label7.Text = "Player : " + caroChess.P;
            }
        }

        private void PvsP(object sender, EventArgs e)
        {
            btnChoiMoi.Enabled = true;
            label5.Text = "X : 0";
            label6.Text = "Player 1 : " + caroChess.P1;
            label7.Text = "Player 2 : " + caroChess.P2;
            label6.Visible = true;
            label7.Visible = true;
            label2.Text = "Bắt đầu chế độ chơi 2 người - X đi trước";
            lblCheDoChoi.Location = new Point(12, 594);
            lblCheDoChoi.Text = "Mode: Player vs Player";
            grs.Clear(pnlBanCo.BackColor);
            btnPlayerVsPlayer.Enabled = false;
            btnPlayerVsCom.Enabled = false;
            caroChess.StartPlayerVsPlayer(grs);
            MessageBox.Show("Trận đấu Bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(pnlBanCo.BackColor);
            if (caroChess.CheDoChoi == 1)
            {
                if (caroChess.LuotDi == 1)
                    label2.Text = "Đến lượt O đi";
                else
                    label2.Text = "Đến lượt X đi";
            }
            label4.Text = "O : " + caroChess.O;
            label5.Text = "X : " + caroChess.X;
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "O : " + caroChess.O;
            label5.Text = "X : " + caroChess.X;
            caroChess.Redo(grs);
        }
        private void PvsC_Click(object sender, EventArgs e)
        {
            btnChoiMoi.Enabled = true;
            label5.Text = "X : 1";
            label6.Text = "Com : " + caroChess.C;
            label7.Text = "Player : " + caroChess.P;
            label6.Visible = true;
            label7.Visible = true;
            lblCheDoChoi.Text = "Mode: Player vs Com";
            lblCheDoChoi.Location = new Point(12, 594);
            label2.Text = "Bắt đầu chế độ chơi với máy - Đến lượt bạn đi";
            grs.Clear(pnlBanCo.BackColor);
            btnPlayerVsCom.Enabled = false;
            btnPlayerVsPlayer.Enabled = false;
            caroChess.StartPlayerVsCom(grs);
            MessageBox.Show("Trận đấu Bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChoiMoi_Click(object sender, EventArgs e)
        {
            label4.Text = "O : 0";
            if (caroChess.CheDoChoi == 1)
            {
                label2.Text = "Bắt đầu chế độ chơi 2 người - X đi trước";
                btnPlayerVsCom.Enabled = true;
                grs.Clear(pnlBanCo.BackColor);
                caroChess.VeBanCo(grs);
                caroChess.StartPlayerVsPlayer(grs);
                label5.Text = "X : 0";
            }
            else
            {
                label2.Text = "Bắt đầu chế độ chơi với máy - Đến lượt bạn đi";
                btnPlayerVsPlayer.Enabled = true;
                grs.Clear(pnlBanCo.BackColor);
                caroChess.VeBanCo(grs);
                caroChess.StartPlayerVsCom(grs);
                label5.Text = "X : 1";
            }            
        }

        private void frmCoCaro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
                e.Cancel = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
