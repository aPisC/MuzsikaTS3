namespace MuzsikaTS_Rendező
{
    partial class Player2
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
            this.cbAudio = new System.Windows.Forms.ComboBox();
            this.trbCuttentTime = new System.Windows.Forms.TrackBar();
            this.ltbSongs = new System.Windows.Forms.ListBox();
            this.trbVol = new System.Windows.Forms.TrackBar();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tmRefreshing = new System.Windows.Forms.Timer(this.components);
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.ltbPlayers = new System.Windows.Forms.ListBox();
            this.btnMutePlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbCuttentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVol)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAudio
            // 
            this.cbAudio.FormattingEnabled = true;
            this.cbAudio.Location = new System.Drawing.Point(285, 151);
            this.cbAudio.Name = "cbAudio";
            this.cbAudio.Size = new System.Drawing.Size(141, 21);
            this.cbAudio.TabIndex = 0;
            this.cbAudio.SelectedIndexChanged += new System.EventHandler(this.cbAudio_SelectedIndexChanged);
            // 
            // trbCuttentTime
            // 
            this.trbCuttentTime.Location = new System.Drawing.Point(12, 234);
            this.trbCuttentTime.Maximum = 1000;
            this.trbCuttentTime.Name = "trbCuttentTime";
            this.trbCuttentTime.Size = new System.Drawing.Size(379, 45);
            this.trbCuttentTime.TabIndex = 1;
            this.trbCuttentTime.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbCuttentTime.Scroll += new System.EventHandler(this.trbCuttentTime_Scroll);
            // 
            // ltbSongs
            // 
            this.ltbSongs.FormattingEnabled = true;
            this.ltbSongs.Location = new System.Drawing.Point(12, 38);
            this.ltbSongs.Name = "ltbSongs";
            this.ltbSongs.Size = new System.Drawing.Size(267, 134);
            this.ltbSongs.TabIndex = 2;
            // 
            // trbVol
            // 
            this.trbVol.Location = new System.Drawing.Point(438, 151);
            this.trbVol.Maximum = 100;
            this.trbVol.Name = "trbVol";
            this.trbVol.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbVol.Size = new System.Drawing.Size(45, 72);
            this.trbVol.TabIndex = 1;
            this.trbVol.Value = 50;
            this.trbVol.Scroll += new System.EventHandler(this.trbVol_Scroll);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 178);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(50, 50);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(229, 178);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 50);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(68, 178);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 50);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(149, 178);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 50);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tmRefreshing
            // 
            this.tmRefreshing.Interval = 500;
            this.tmRefreshing.Tick += new System.EventHandler(this.tmRefreshing_Tick);
            // 
            // tbTime
            // 
            this.tbTime.Enabled = false;
            this.tbTime.Location = new System.Drawing.Point(397, 246);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(63, 20);
            this.tbTime.TabIndex = 4;
            this.tbTime.Text = "00:00:00";
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(267, 20);
            this.tbSearch.TabIndex = 6;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(285, 12);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(62, 23);
            this.btnAddPlayer.TabIndex = 7;
            this.btnAddPlayer.Text = "Add";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.Location = new System.Drawing.Point(421, 12);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(62, 23);
            this.btnDeletePlayer.TabIndex = 7;
            this.btnDeletePlayer.Text = "Remove";
            this.btnDeletePlayer.UseVisualStyleBackColor = true;
            this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
            // 
            // ltbPlayers
            // 
            this.ltbPlayers.FormattingEnabled = true;
            this.ltbPlayers.Location = new System.Drawing.Point(285, 38);
            this.ltbPlayers.Name = "ltbPlayers";
            this.ltbPlayers.Size = new System.Drawing.Size(198, 108);
            this.ltbPlayers.TabIndex = 2;
            this.ltbPlayers.SelectedIndexChanged += new System.EventHandler(this.ltbPlayers_SelectedIndexChanged);
            // 
            // btnMutePlayer
            // 
            this.btnMutePlayer.Location = new System.Drawing.Point(353, 12);
            this.btnMutePlayer.Name = "btnMutePlayer";
            this.btnMutePlayer.Size = new System.Drawing.Size(62, 23);
            this.btnMutePlayer.TabIndex = 7;
            this.btnMutePlayer.Text = "Mute";
            this.btnMutePlayer.UseVisualStyleBackColor = true;
            this.btnMutePlayer.Click += new System.EventHandler(this.btnMutePlayer_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(285, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 2);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Player2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 279);
            this.Controls.Add(this.btnMutePlayer);
            this.Controls.Add(this.btnDeletePlayer);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.ltbPlayers);
            this.Controls.Add(this.ltbSongs);
            this.Controls.Add(this.trbVol);
            this.Controls.Add(this.trbCuttentTime);
            this.Controls.Add(this.cbAudio);
            this.Name = "Player2";
            this.Text = "Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Player_FormClosed);
            this.Load += new System.EventHandler(this.Player_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbCuttentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAudio;
        private System.Windows.Forms.TrackBar trbCuttentTime;
        private System.Windows.Forms.ListBox ltbSongs;
        private System.Windows.Forms.TrackBar trbVol;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Timer tmRefreshing;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnDeletePlayer;
        private System.Windows.Forms.ListBox ltbPlayers;
        private System.Windows.Forms.Button btnMutePlayer;
        private System.Windows.Forms.Label label1;

    }
}