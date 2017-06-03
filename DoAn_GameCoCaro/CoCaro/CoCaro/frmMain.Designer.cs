namespace CoCaro
{
    partial class frmCoCaro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoCaro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ẽitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayerVsPlayer = new System.Windows.Forms.Button();
            this.btnPlayerVsCom = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnChoiMoi = new System.Windows.Forms.Button();
            this.pnlBanCo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerChuChay = new System.Windows.Forms.Timer(this.components);
            this.pnlChuChay = new System.Windows.Forms.Panel();
            this.lblChuoiChu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlChuChay.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1237, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.ẽitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.PvsP);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.playerVsComToolStripMenuItem.Text = "Player vs Com";
            // 
            // ẽitToolStripMenuItem
            // 
            this.ẽitToolStripMenuItem.Name = "ẽitToolStripMenuItem";
            this.ẽitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.ẽitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ẽitToolStripMenuItem.Text = "Exit";
            this.ẽitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnPlayerVsPlayer
            // 
            this.btnPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsPlayer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(25, 427);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(160, 33);
            this.btnPlayerVsPlayer.TabIndex = 3;
            this.btnPlayerVsPlayer.Text = "Player VS Player";
            this.btnPlayerVsPlayer.UseVisualStyleBackColor = true;
            this.btnPlayerVsPlayer.Click += new System.EventHandler(this.PvsP);
            // 
            // btnPlayerVsCom
            // 
            this.btnPlayerVsCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsCom.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnPlayerVsCom.Location = new System.Drawing.Point(25, 470);
            this.btnPlayerVsCom.Name = "btnPlayerVsCom";
            this.btnPlayerVsCom.Size = new System.Drawing.Size(160, 33);
            this.btnPlayerVsCom.TabIndex = 4;
            this.btnPlayerVsCom.Text = "Player VS Com";
            this.btnPlayerVsCom.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Blue;
            this.btnThoat.Location = new System.Drawing.Point(25, 516);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 31);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChoiMoi
            // 
            this.btnChoiMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoiMoi.ForeColor = System.Drawing.Color.Blue;
            this.btnChoiMoi.Location = new System.Drawing.Point(110, 516);
            this.btnChoiMoi.Name = "btnChoiMoi";
            this.btnChoiMoi.Size = new System.Drawing.Size(75, 31);
            this.btnChoiMoi.TabIndex = 6;
            this.btnChoiMoi.Text = "Chơi mới";
            this.btnChoiMoi.UseVisualStyleBackColor = true;
            this.btnChoiMoi.Click += new System.EventHandler(this.btnChoiMoi_Click);
            // 
            // pnlBanCo
            // 
            this.pnlBanCo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlBanCo.Location = new System.Drawing.Point(220, 46);
            this.pnlBanCo.Name = "pnlBanCo";
            this.pnlBanCo.Size = new System.Drawing.Size(1001, 626);
            this.pnlBanCo.TabIndex = 7;
            this.pnlBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanCo_Paint);
            this.pnlBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBanCo_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CoCaro.Properties.Resources.Caro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(25, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 149);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timerChuChay
            // 
            this.timerChuChay.Interval = 25;
            this.timerChuChay.Tick += new System.EventHandler(this.timerChuChay_Tick);
            // 
            // pnlChuChay
            // 
            this.pnlChuChay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChuChay.Controls.Add(this.lblChuoiChu);
            this.pnlChuChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChuChay.ForeColor = System.Drawing.Color.Navy;
            this.pnlChuChay.Location = new System.Drawing.Point(25, 220);
            this.pnlChuChay.Name = "pnlChuChay";
            this.pnlChuChay.Size = new System.Drawing.Size(160, 196);
            this.pnlChuChay.TabIndex = 8;
            // 
            // lblChuoiChu
            // 
            this.lblChuoiChu.AutoSize = true;
            this.lblChuoiChu.Location = new System.Drawing.Point(4, 170);
            this.lblChuoiChu.Name = "lblChuoiChu";
            this.lblChuoiChu.Size = new System.Drawing.Size(0, 17);
            this.lblChuoiChu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(61, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Luật chơi";
            // 
            // frmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1237, 690);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlChuChay);
            this.Controls.Add(this.pnlBanCo);
            this.Controls.Add(this.btnChoiMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPlayerVsCom);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1253, 729);
            this.MinimumSize = new System.Drawing.Size(1253, 729);
            this.Name = "frmCoCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCoCaro_FormClosing);
            this.Load += new System.EventHandler(this.frmCoCaro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlChuChay.ResumeLayout(false);
            this.pnlChuChay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ẽitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlayerVsPlayer;
        private System.Windows.Forms.Button btnPlayerVsCom;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChoiMoi;
        private System.Windows.Forms.Panel pnlBanCo;
        private System.Windows.Forms.Timer timerChuChay;
        private System.Windows.Forms.Panel pnlChuChay;
        private System.Windows.Forms.Label lblChuoiChu;
        private System.Windows.Forms.Label label1;
    }
}

