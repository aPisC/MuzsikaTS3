using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MuzsikaTS_Rendező
{
    public partial class FileTagger : Form
    {
        public List<MusicFile> MusicFiles = new List<MusicFile>();
        bool MultiMode = false, ListeningChange = true, AllowSave = true, Importer;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) módosításokEldobásaToolStripMenuItem.PerformClick();
            else return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }

        public FileTagger(List<MusicFile> musicFiles, bool importer = false)
        {
            InitializeComponent();
            Importer = importer;
            if (musicFiles.Count == 0) this.Close();
            if (!importer) { label7.Visible = false; tbDir.Visible = false; }
            else { módosításokEldobásaToolStripMenuItem.Visible = false; }
            MusicFiles = musicFiles;
        }

        private void FileTagger_Load(object sender, EventArgs e)
        {
            multiFillerOptionsToolStripMenuItem.Visible = false;
            lbSongs.DataSource = MusicFiles;
            pbStatus.Value = 0;
        }

        public void SaveAll()
        {
            lbItemNum.Text = "";
            int cnt = 0;
            foreach (MusicFile item in MusicFiles)
            {
                if (AllowSave) item.File.Save();
                else item.Reload();
                pbStatus.Value = (int)((cnt++*100.0)/MusicFiles.Count);
            }
        }

        private void lbSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!MultiMode && ListeningChange)
            {
                ListeningChange = false;
                lbSong.Text = ((MusicFile)lbSongs.SelectedItem).FileName;
                tbAlbum.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Album;
                tbArtist.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Performers.ToStringLine("; ");
                tbGenres.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Genres.ToStringLine("; ");
                tbTitle.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Title;
                tbTrack.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Track.ToString();
                tbYear.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Year.ToString();
                if (Importer) tbDir.Text = ((MusicFile)lbSongs.SelectedItem).DataDelivery1;
                ListeningChange = true;
            }
            if (lbSongs.SelectedIndices.Count == 0) lbItemNum.Text = MusicFiles.Count + " db.";
            else if (lbSongs.SelectedIndices.Count == 1) lbItemNum.Text =  lbSongs.SelectedIndex + 1 + "/" +MusicFiles.Count + " db.";
            else if (lbSongs.SelectedIndices.Count > 1) lbItemNum.Text = lbSongs.SelectedIndices.Count + " db / "+MusicFiles.Count + " db.";
        }

        private void tmiMultipleFiller_Click(object sender, EventArgs e)
        {
            if(MultiMode)
            {
                MultiMode = false;
                tmiMultipleFiller.Text = "MultiFiller";

                for (int i = 0; i < lbSongs.SelectedItems.Count; i++)
                {
                    MusicFile File = (MusicFile)lbSongs.SelectedItems[i];
                    if (tbArtist.Text != "") File.Tag.Performers = tbArtist.Text.Replace("{count}", (i + 1).ToString()).Replace("{old}", File.Tag.Performers.ToStringLine("; ")).Replace("{auto}", File.ArtistFromFile).Split(';').Where(s => s.Trim() != "").Select(s => s.Trim()).ToArray();
                    if (tbTitle.Text != "") File.Tag.Title = tbTitle.Text.Trim().Replace("{count}", (i + 1).ToString()).Replace("{old}", File.Tag.Title).Replace("{auto}", File.TitleFromFile);
                    if (tbAlbum.Text != "") File.Tag.Album = tbAlbum.Text.Trim().Replace("{count}", (i + 1).ToString()).Replace("{old}", File.Tag.Album).Replace("{auto}", File.DirectoryName);
                    try { if (tbYear.Text != "") File.Tag.Year = uint.Parse(tbYear.Text.Replace("{count}", (i + 1).ToString())); } catch { }
                    try { if (tbTrack.Text != "") File.Tag.Track = uint.Parse(tbTrack.Text.Replace("{count}", (i + 1).ToString()));} catch { }
                    if (tbGenres.Text != "") File.Tag.Genres = new HashSet<string>(tbGenres.Text.Replace("{count}", (i+1).ToString()).Replace("{old}", File.Tag.Genres.ToStringLine("; ")).Split(';').Where(s=> s.Trim() != "").Select(s => s.Trim())).ToArray();
                    if (Importer) File.DataDelivery1 = tbDir.Text.Replace("{album}", File.Tag.Album).Replace("{artist}", File.Tag.Performers.ToStringLine()).Trim();
                }
                lbSongs.SelectionMode = SelectionMode.One;
                multiFillerOptionsToolStripMenuItem.Visible = false;
                lbSongs.SetSelected(0, true);
                lbSongs.DataSource = MusicFiles.Clone();
            }
            else
            {
                MultiMode = true;
                multiFillerOptionsToolStripMenuItem.Visible = true;
                tmiMultipleFiller.Text = "MultiFiller OK";
                lbSongs.SelectionMode = SelectionMode.MultiExtended;
            }
        }

        private void TagTextChanged(object sender, EventArgs e)
        {
            if(!MultiMode && ListeningChange)
            {
                try
                {
                    TextBox Sender = (TextBox)sender;
                    string Mode = Sender.Name.Substring(2);
                    MusicFile File = (MusicFile)lbSongs.SelectedItem;
                    if (Mode == "Artist")
                    {
                        File.Tag.Performers = Sender.Text.Split(';').Select(s => s.Trim()).ToArray();
                    }
                    else if (Mode == "Album")
                    {
                        File.Tag.Album = Sender.Text.Trim();
                    }
                    else if (Mode == "Title")
                    {
                        File.Tag.Title = Sender.Text.Trim();
                    }
                    else if (Mode == "Genres")
                    {
                        File.Tag.Genres = Sender.Text.Split(';').Select(s => s.Trim()).ToArray();
                    }
                    else if (Mode == "Year")
                    {
                        File.Tag.Year = uint.Parse(Sender.Text);
                    }
                    else if (Mode == "Track")
                    {
                        File.Tag.Track = uint.Parse(Sender.Text);
                    }
                    else if (Mode == "Dir")
                    {
                        File.DataDelivery1 = Sender.Text.Trim();
                    }
                }
                catch { }
                ListeningChange = false;
                int sel = lbSongs.SelectedIndex;
                lbSongs.DataSource = MusicFiles.Clone();
                lbSongs.SetSelected(sel, true);
                ListeningChange = true;
            }
        }

        private void módosításokEldobásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowSave = false;
            this.Close();
        }

        private void FileTagger_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAll();
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbArtist.Text = "{auto}";
            tbAlbum.Text = "{auto}";
            tbTitle.Text = "{auto}";
            tbGenres.Text = "";
            tbTrack.Text = "";
            tbYear.Text = "";
            if (Importer) tbDir.Text = "{album}";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbArtist.Text = "";
            tbAlbum.Text = "";
            tbTitle.Text = "";
            tbGenres.Text = "";
            tbTrack.Text = "";
            tbYear.Text = "";
            if (Importer) tbDir.Text = "";
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count > 0)
            {
                lbSong.Text = ((MusicFile)lbSongs.SelectedItem).FileName;
                tbAlbum.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Album;
                tbArtist.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Performers.ToStringLine("; ");
                tbGenres.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Genres.ToStringLine("; ");
                tbTitle.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Title;
                tbTrack.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Track.ToString();
                tbYear.Text = ((MusicFile)lbSongs.SelectedItem).Tag.Year.ToString();
                if (Importer) tbDir.Text = ((MusicFile)lbSongs.SelectedItem).DataDelivery1;
            }
        }

        private void addGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tbArtist.Text = "";
            tbAlbum.Text = "";
            tbTitle.Text = "";
            tbGenres.Text = "{old}; ";
            tbTrack.Text = "";
            tbYear.Text = "";
            if (Importer) tbDir.Text = "";
        }
    }
}
