using System;

namespace FinalChessProject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killedpiecesofblackplayer = new System.Windows.Forms.PictureBox();
            this.killedpiecesofwhiteplayer = new System.Windows.Forms.PictureBox();
            this.boardBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.hardDiff = new System.Windows.Forms.Button();
            this.medDiff = new System.Windows.Forms.Button();
            this.easyDiff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.killedpiecesofblackplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.killedpiecesofwhiteplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.highScoreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.playToolStripMenuItem.Text = "play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // highScoreToolStripMenuItem
            // 
            this.highScoreToolStripMenuItem.Name = "highScoreToolStripMenuItem";
            this.highScoreToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.highScoreToolStripMenuItem.Text = "high score";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "exit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 24);
            this.panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.highScoreToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "file ";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "new game ";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // highScoreToolStripMenuItem1
            // 
            this.highScoreToolStripMenuItem1.Name = "highScoreToolStripMenuItem1";
            this.highScoreToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.highScoreToolStripMenuItem1.Text = "high score";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem1.Text = "exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // usToolStripMenuItem
            // 
            this.usToolStripMenuItem.Name = "usToolStripMenuItem";
            this.usToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.usToolStripMenuItem.Text = "us";
            this.usToolStripMenuItem.Click += new System.EventHandler(this.usToolStripMenuItem_Click);
            // 
            // killedpiecesofblackplayer
            // 
            this.killedpiecesofblackplayer.BackColor = System.Drawing.Color.Transparent;
            this.killedpiecesofblackplayer.Location = new System.Drawing.Point(31, 136);
            this.killedpiecesofblackplayer.Name = "killedpiecesofblackplayer";
            this.killedpiecesofblackplayer.Size = new System.Drawing.Size(192, 397);
            this.killedpiecesofblackplayer.TabIndex = 5;
            this.killedpiecesofblackplayer.TabStop = false;
            this.killedpiecesofblackplayer.Visible = false;
            // 
            // killedpiecesofwhiteplayer
            // 
            this.killedpiecesofwhiteplayer.BackColor = System.Drawing.Color.Transparent;
            this.killedpiecesofwhiteplayer.Location = new System.Drawing.Point(832, 136);
            this.killedpiecesofwhiteplayer.Name = "killedpiecesofwhiteplayer";
            this.killedpiecesofwhiteplayer.Size = new System.Drawing.Size(192, 397);
            this.killedpiecesofwhiteplayer.TabIndex = 4;
            this.killedpiecesofwhiteplayer.TabStop = false;
            this.killedpiecesofwhiteplayer.Visible = false;
            // 
            // boardBox
            // 
            this.boardBox.Image = global::FinalChessProject.Properties.Resources.chessboard512__2_;
            this.boardBox.Location = new System.Drawing.Point(267, 59);
            this.boardBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boardBox.Name = "boardBox";
            this.boardBox.Size = new System.Drawing.Size(510, 512);
            this.boardBox.TabIndex = 2;
            this.boardBox.TabStop = false;
            this.boardBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 586);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick_1);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button1.Location = new System.Drawing.Point(393, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "Two Players";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button2.Location = new System.Drawing.Point(393, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 49);
            this.button2.TabIndex = 8;
            this.button2.Text = "exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button3.Location = new System.Drawing.Point(393, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 50);
            this.button3.TabIndex = 9;
            this.button3.Text = "One Player";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.hardDiff);
            this.panel2.Controls.Add(this.medDiff);
            this.panel2.Controls.Add(this.easyDiff);
            this.panel2.Location = new System.Drawing.Point(393, 196);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 192);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Difficulty ";
            // 
            // hardDiff
            // 
            this.hardDiff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hardDiff.BackgroundImage")));
            this.hardDiff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hardDiff.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardDiff.ForeColor = System.Drawing.Color.SaddleBrown;
            this.hardDiff.Location = new System.Drawing.Point(64, 104);
            this.hardDiff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hardDiff.Name = "hardDiff";
            this.hardDiff.Size = new System.Drawing.Size(83, 32);
            this.hardDiff.TabIndex = 2;
            this.hardDiff.Text = "Hard";
            this.hardDiff.UseVisualStyleBackColor = true;
            this.hardDiff.Click += new System.EventHandler(this.button6_Click);
            // 
            // medDiff
            // 
            this.medDiff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("medDiff.BackgroundImage")));
            this.medDiff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.medDiff.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medDiff.ForeColor = System.Drawing.Color.SaddleBrown;
            this.medDiff.Location = new System.Drawing.Point(64, 73);
            this.medDiff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.medDiff.Name = "medDiff";
            this.medDiff.Size = new System.Drawing.Size(83, 27);
            this.medDiff.TabIndex = 1;
            this.medDiff.Text = "Medium";
            this.medDiff.UseVisualStyleBackColor = true;
            this.medDiff.Click += new System.EventHandler(this.button5_Click);
            // 
            // easyDiff
            // 
            this.easyDiff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("easyDiff.BackgroundImage")));
            this.easyDiff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.easyDiff.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyDiff.ForeColor = System.Drawing.Color.SaddleBrown;
            this.easyDiff.Location = new System.Drawing.Point(64, 41);
            this.easyDiff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.easyDiff.Name = "easyDiff";
            this.easyDiff.Size = new System.Drawing.Size(83, 28);
            this.easyDiff.TabIndex = 0;
            this.easyDiff.Text = "Easy";
            this.easyDiff.UseVisualStyleBackColor = true;
            this.easyDiff.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("French Script MT", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ImageKey = "(none)";
            this.label2.Location = new System.Drawing.Point(205, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(607, 109);
            this.label2.TabIndex = 11;
            this.label2.Text = "PURE CHESS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 563);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.killedpiecesofblackplayer);
            this.Controls.Add(this.killedpiecesofwhiteplayer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boardBox);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Chess Game";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.killedpiecesofblackplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.killedpiecesofwhiteplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox boardBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highScoreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.PictureBox killedpiecesofwhiteplayer;
        private System.Windows.Forms.PictureBox killedpiecesofblackplayer;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hardDiff;
        private System.Windows.Forms.Button medDiff;
        private System.Windows.Forms.Button easyDiff;
        private System.Windows.Forms.Label label2;
    }
}