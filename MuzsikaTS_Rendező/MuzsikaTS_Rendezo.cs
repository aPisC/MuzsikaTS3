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
    public partial class MuzsikaTS_Rendezo : Form
    {
        List<MusicFile> _songs = new List<MusicFile>();
        List<MusicFile> _filteredSongs = new List<MusicFile>();
        List<Rule> _rules = new List<Rule>();
        public MuzsikaTS_Rendezo()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) tbSearch.Focus(); 
            else if (keyData == Keys.F2) playToolStripMenuItem.PerformClick();
            else if (keyData == Keys.F3) btnAddRule.PerformClick();
            else if (keyData == Keys.F4) fileTaggerToolStripMenuItem.PerformClick();
            else if (keyData == Keys.F5) nameToolStripMenuItem.PerformClick();
            else if (keyData == Keys.F6) randomToolStripMenuItem.PerformClick();

            else return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }

        private void MuzsikaTS_Rendezo_Load(object sender, EventArgs e)
        {
            Directory.EnumerateFiles(Program.MusicLib, "*.mp3", SearchOption.AllDirectories).ForEach(x => _songs.Add(new MusicFile(x)));
            _songs = _songs.OrderBy(x => x.ToString()).ToList() ;
            AllowRules();
            lbSongs.DataSource = _filteredSongs;
            lbRules.DataSource = _rules;
            
            
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "") ShowSongs();
           else lbSongs.DataSource=_filteredSongs.Where(x => ((MusicFile)x).Searcher(tbSearch.Text)).ToList<MusicFile>();
        }
        private void fileTaggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedItems.Count > 0)
            {
                FileTagger fTagger = new FileTagger(lbSongs.SelectedItems.ToIEnumerable<MusicFile>().ToList());
                fTagger.ShowDialog();
                AllowRules();
            }
        }
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            _rules.Add(new Rule("", Rule.RuleMode.Allow, Rule.RuleTarget.Any));
            RuleEditor rEdit = new RuleEditor(_rules[_rules.Count-1]);
            rEdit.ShowDialog();
            lbRules.DataSource = _rules.Clone();
            AllowRules();
        }
        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if(lbRules.SelectedIndices.Count>0)
            {
                _rules.RemoveAt(lbRules.SelectedIndex);
                lbRules.DataSource = _rules.Clone();
                AllowRules();
            }
        }
        private void lbRules_DoubleClick(object sender, EventArgs e)
        {
            if(lbRules.SelectedIndices.Count>0)
            {
                RuleEditor rEdit = new RuleEditor(_rules[lbRules.SelectedIndex]);
                rEdit.ShowDialog();
                lbRules.DataSource = _rules.Clone();
                AllowRules();
            }
        }

        private void ShowSongs()
        {
            if(tbSearch.Text != "") tbSearch.Text = "";
            else
            {
                lbSongs.DataSource = _filteredSongs.Clone();
        
            }
        }
        private void AllowRules()
        {
            _filteredSongs = _songs.AllowRules(lbRules.Items.OfType<Rule>()).ToList();
            ShowSongs();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Mode = ((ToolStripItem)sender).Text;
            if (Mode == "Name")
            {
                _songs = _songs.OrderBy(x => x.ToString()).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.ToString()).ToList();
            }
            else if (Mode == "Title")
            {
                _songs = _songs.OrderBy(x => x.Tag.Title).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Title).ToList();
            }
            else if (Mode == "Artist")
            {
                _songs = _songs.OrderBy(x => x.Tag.Performers.ToStringLine()).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Performers.ToStringLine()).ToList();
            }
            else if (Mode == "Title")
            {
                _songs = _songs.OrderBy(x => x.Tag.Title).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Title).ToList();
            }
            else if (Mode == "Album")
            {
                _songs = _songs.OrderBy(x => x.Tag.Album).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Album).ToList();
            }
            else if (Mode == "Genre")
            {
                _songs = _songs.OrderBy(x => x.Tag.Genres.ToStringLine()).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Genres.ToStringLine()).ToList();
            }
            else if (Mode == "File")
            {
                _songs = _songs.OrderBy(x => x.FileName).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.FileName).ToList();
            }
            else if (Mode == "Directory")
            {
                _songs = _songs.OrderBy(x => x.DirectoryName).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.DirectoryName).ToList();
            }
            else if (Mode == "Year")
            {
                _songs = _songs.OrderBy(x => x.Tag.Year).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Year).ToList();
            }
            else if (Mode == "Track")
            {
                _songs = _songs.OrderBy(x => x.Tag.Track).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => x.Tag.Track).ToList();
            }
            else if (Mode == "Reverse")
            {
                _songs.Reverse();
                _filteredSongs.Reverse(); ;
            }
            else if (Mode == "Random")
            {
                Random r = new Random();
                _songs = _songs.OrderBy(x=> r.Next(0, _songs.Count*2)).ToList();
                _filteredSongs = _filteredSongs.OrderBy(x => r.Next(0, _filteredSongs.Count*2)).ToList(); ;
            }
            ShowSongs();
        }

        private void lbSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count > 0) lbInfo.Text = ((MusicFile)lbSongs.SelectedItem).AllInfo;
            else lbInfo.Text = "";
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filteredSongs.Count>0)
            {
                Player2 player = new Player2(_filteredSongs);
                player.Show();
            }
        }

        private void lbInfo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lbInfo_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string path in FileList)
            {
                if (Directory.Exists(path))
                {
                    Directory.EnumerateFiles(path, "*.mp3", SearchOption.AllDirectories).ForEach(x => _songs.Add(new MusicFile(x)));
                }
                else if (File.Exists(path) && Path.GetExtension(path) == ".mp3")
                {
                    _songs.Add(new MusicFile(path));
                }
            }
            AllowRules();

        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _songs.Clear();
            AllowRules();

        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (MusicFile file in lbSongs.SelectedItems)
            {
                _songs.Remove(file);
            }
            AllowRules();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sel = lbSongs.SelectedIndices.Count > 0 ? lbSongs.SelectedIndex : -1;
            for (int i = 0; i < lbSongs.Items.Count; i++)
            {
                lbSongs.SetSelected(i, true);
            }
            if (sel != -1) lbSongs.SetSelected(sel, true);
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbSongs.Items.Count; i++)
            {
                lbSongs.SetSelected(i, false);
            }
        }

        private void reverseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sel = lbSongs.SelectedIndices.Count > 0 ? lbSongs.SelectedIndex : -1;
            for (int i = 0; i < lbSongs.Items.Count; i++)
            {
                lbSongs.SetSelected(i, !lbSongs.SelectedIndices.Contains(i));
            }
            if (sel != -1) { lbSongs.SetSelected(sel, true); lbSongs.SetSelected(sel, false); }
        }


        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && tbSearch.Text != "")
            {
                _rules.Add(new Rule(tbSearch.Text.ToUpperFirstLetter(), Rule.RuleMode.Allow, Rule.RuleTarget.Any) { Enabled = true });
                lbRules.DataSource = _rules.Clone();
                AllowRules();
            }
            else if ((int)e.KeyChar == 27)
                tbSearch.Text = "";
        }

        private void btnTrackMin_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count > 0)
            {
                if (((MusicFile)lbSongs.SelectedItem).Tag.Track > 0)
                {
                    ((MusicFile)lbSongs.SelectedItem).Tag.Track--;
                    try { ((MusicFile)lbSongs.SelectedItem).File.Save(); }
                    catch { MessageBox.Show("A file használatban van. Próbáld újra később!", "File elérési hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    ((MusicFile)lbSongs.SelectedItem).Tag.Track++;}
                    lbInfo.Text = ((MusicFile)lbSongs.SelectedItem).AllInfo;
                }
            }
        }

        private void btnTrackPlus_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count > 0)
            {
                ((MusicFile)lbSongs.SelectedItem).Tag.Track++;
                try { ((MusicFile)lbSongs.SelectedItem).File.Save(); }
                catch
                {
                    MessageBox.Show("A file használatban van. Próbáld újra később!", "File elérési hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((MusicFile)lbSongs.SelectedItem).Tag.Track--;
                }
                lbInfo.Text = ((MusicFile)lbSongs.SelectedItem).AllInfo;
            }
        }

        private void deleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count == 0) return;
            if(MessageBox.Show("Valóban törlöd a kijelölt fájlokat?", "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            foreach (MusicFile mFile in lbSongs.SelectedItems)
            {
                string path = mFile.File.Name;
                try
                {
                    mFile.File = null;
                    System.IO.File.Delete(path);
                    _songs.Remove(mFile);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); mFile.File = TagLib.File.Create(path); }
            }
            AllowRules();
        }

        private void renameFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbSongs.SelectedIndices.Count == 0) return;
            if (MessageBox.Show("Valóban átnevezed a kijelölt fájlokat?", "Átnevezés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            foreach (MusicFile mFile in lbSongs.SelectedItems)
            {
                try
                {
                    string path = mFile.File.Name;
                    string newPath = System.IO.Directory.GetParent(path) + "\\" + mFile.ToString() + ".mp3";
                    mFile.File = null;
                    System.IO.File.Move(path, newPath);
                    mFile.File = TagLib.File.Create(newPath);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            lbInfo.Text = ((MusicFile)lbSongs.SelectedItem).AllInfo;
        }

        private void importFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "MP3 Files (*.mp3)|*.mp3";
            ofd.ShowDialog();
            if (ofd.FileNames.Length == 0) return;
            List<MusicFile> mFiles = new List<MusicFile>();
            ofd.FileNames.ForEach(x=> mFiles.Add(new MusicFile(x)));
            FileTagger ft = new FileTagger(mFiles, true);
            ft.ShowDialog();
            foreach (MusicFile File in mFiles)
            {
                try
                {
                    string oldP = File.File.Name, newP = File.DataDelivery1.Trim() == "" ? (Program.MusicLib + "\\" + File.ToString() + ".mp3") : (Program.MusicLib + "\\" + File.DataDelivery1.Trim() + "\\" + File.ToString() + ".mp3");
                    File.File = null;
                    if (!System.IO.Directory.Exists(System.IO.Directory.GetParent(newP).ToString())) System.IO.Directory.CreateDirectory(System.IO.Directory.GetParent(newP).ToString());
                    System.IO.File.Move(oldP, newP);
                    _songs.Add(new MusicFile(newP));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            AllowRules();
        }


    }
}
