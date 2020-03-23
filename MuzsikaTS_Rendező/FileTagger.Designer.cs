namespace MuzsikaTS_Rendező
{
    partial class FileTagger
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmiMultipleFiller = new System.Windows.Forms.ToolStripMenuItem();
            this.multiFillerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGenreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.módosításokEldobásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSongs = new System.Windows.Forms.ListBox();
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.lbSong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAlbum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbGenres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTrack = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.lbItemNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiMultipleFiller,
            this.multiFillerOptionsToolStripMenuItem,
            this.módosításokEldobásaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tmiMultipleFiller
            // 
            this.tmiMultipleFiller.Name = "tmiMultipleFiller";
            this.tmiMultipleFiller.Size = new System.Drawing.Size(72, 20);
            this.tmiMultipleFiller.Text = "MultiFiller";
            this.tmiMultipleFiller.Click += new System.EventHandler(this.tmiMultipleFiller_Click);
            // 
            // multiFillerOptionsToolStripMenuItem
            // 
            this.multiFillerOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.selectedToolStripMenuItem,
            this.addGenreToolStripMenuItem});
            this.multiFillerOptionsToolStripMenuItem.Name = "multiFillerOptionsToolStripMenuItem";
            this.multiFillerOptionsToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.multiFillerOptionsToolStripMenuItem.Text = "MultiFiller Options";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            this.selectedToolStripMenuItem.Click += new System.EventHandler(this.selectedToolStripMenuItem_Click);
            // 
            // addGenreToolStripMenuItem
            // 
            this.addGenreToolStripMenuItem.Name = "addGenreToolStripMenuItem";
            this.addGenreToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.addGenreToolStripMenuItem.Text = "Add Genre";
            this.addGenreToolStripMenuItem.Click += new System.EventHandler(this.addGenreToolStripMenuItem_Click);
            // 
            // módosításokEldobásaToolStripMenuItem
            // 
            this.módosításokEldobásaToolStripMenuItem.Name = "módosításokEldobásaToolStripMenuItem";
            this.módosításokEldobásaToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.módosításokEldobásaToolStripMenuItem.Text = "Módosítások eldobása";
            this.módosításokEldobásaToolStripMenuItem.Click += new System.EventHandler(this.módosításokEldobásaToolStripMenuItem_Click);
            // 
            // lbSongs
            // 
            this.lbSongs.FormattingEnabled = true;
            this.lbSongs.Location = new System.Drawing.Point(12, 27);
            this.lbSongs.Name = "lbSongs";
            this.lbSongs.Size = new System.Drawing.Size(280, 303);
            this.lbSongs.TabIndex = 1;
            this.lbSongs.SelectedIndexChanged += new System.EventHandler(this.lbSongs_SelectedIndexChanged);
            // 
            // tbArtist
            // 
            this.tbArtist.Location = new System.Drawing.Point(298, 89);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(344, 20);
            this.tbArtist.TabIndex = 2;
            this.tbArtist.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // lbSong
            // 
            this.lbSong.AutoSize = true;
            this.lbSong.Location = new System.Drawing.Point(298, 30);
            this.lbSong.Name = "lbSong";
            this.lbSong.Size = new System.Drawing.Size(32, 13);
            this.lbSong.TabIndex = 3;
            this.lbSong.Text = "Song";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Album";
            // 
            // tbAlbum
            // 
            this.tbAlbum.Location = new System.Drawing.Point(298, 127);
            this.tbAlbum.Name = "tbAlbum";
            this.tbAlbum.Size = new System.Drawing.Size(344, 20);
            this.tbAlbum.TabIndex = 2;
            this.tbAlbum.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(298, 166);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(344, 20);
            this.tbTitle.TabIndex = 2;
            this.tbTitle.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // tbGenres
            // 
            this.tbGenres.Location = new System.Drawing.Point(298, 205);
            this.tbGenres.Name = "tbGenres";
            this.tbGenres.Size = new System.Drawing.Size(344, 20);
            this.tbGenres.TabIndex = 2;
            this.tbGenres.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Genres";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Year";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(330, 231);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(130, 20);
            this.tbYear.TabIndex = 2;
            this.tbYear.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Track";
            // 
            // tbTrack
            // 
            this.tbTrack.Location = new System.Drawing.Point(507, 231);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Size = new System.Drawing.Size(135, 20);
            this.tbTrack.TabIndex = 2;
            this.tbTrack.TextChanged += new System.EventHandler(this.TagTextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatus,
            this.lbItemNum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(657, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            this.pbStatus.Value = 100;
            // 
            // lbItemNum
            // 
            this.lbItemNum.Name = "lbItemNum";
            this.lbItemNum.Size = new System.Drawing.Size(118, 17);
            this.lbItemNum.Text = "toolStripStatusLabel1";
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(353, 310);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(289, 20);
            this.tbDir.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Directory";
            // 
            // FileTagger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 362);
            this.Controls.Add(this.tbDir);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTrack);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbGenres);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbAlbum);
            this.Controls.Add(this.lbSong);
            this.Controls.Add(this.tbArtist);
            this.Controls.Add(this.lbSongs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileTagger";
            this.Text = "FileTagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileTagger_FormClosing);
            this.Load += new System.EventHandler(this.FileTagger_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox lbSongs;
        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.Label lbSong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAlbum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbGenres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTrack;
        private System.Windows.Forms.ToolStripMenuItem tmiMultipleFiller;
        private System.Windows.Forms.ToolStripMenuItem módosításokEldobásaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbItemNum;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.ToolStripMenuItem multiFillerOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGenreToolStripMenuItem;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Label label7;


    }
}