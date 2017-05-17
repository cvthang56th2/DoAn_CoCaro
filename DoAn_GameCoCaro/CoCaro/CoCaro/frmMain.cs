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
            lblChuoiChu.Text = "Đây là chuỗi chữ chạy\nlà luật chơi\nChọn chế độ chơi ở\ndưới để bắt đầu chơi!";
            timerChuChay.Enabled = true;
            
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

        private void ẽitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (caroChess.KiemTraChienThang())
                    caroChess.KetThucTroChoi();
                else if (caroChess.CheDoChoi == 2)
                {
                    caroChess.KhoiDongComputer(grs);
                    if (caroChess.KiemTraChienThang())
                        caroChess.KetThucTroChoi();
                }
            }
            
        }

        private void PvsP(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayerVsPlayer(grs);
            MessageBox.Show("Trận đấu Bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(pnlBanCo.BackColor);
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }
        private void PvsC_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayerVsCom(grs);
            MessageBox.Show("Trận đấu Bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChoiMoi_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.VeBanCo(grs);
            caroChess.KhoiTaoMangOCo();
            caroChess.SanSang = false;
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
    }
}
