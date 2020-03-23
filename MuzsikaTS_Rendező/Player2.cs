using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace MuzsikaTS_Rendező
{
    public partial class Player2 : Form
    {   
        List<MusicFile> _musicFiles;
        MusicFile _currentMusic;
        private MusicPlayer FirstPlayer
        { get { return (MusicPlayer)ltbPlayers.Items[0]; } }

        private MusicPlayer SelectedPlayer
        { get { return (MusicPlayer)ltbPlayers.SelectedItem; } }

        private MusicFile SelectedFile
        {
            get { return (MusicFile)ltbSongs.SelectedItem; }
        }

        private List<MusicPlayer> _musicPlayers
        { 
            get { return ltbPlayers.Items.OfType<MusicPlayer>().ToList(); }
            set { ltbPlayers.Items.Add(value); }
        }
        public Player2(List<MusicFile> musicFiles)
        {
            InitializeComponent();
            int waveOutDevices = WaveOut.DeviceCount;
            for (int waveOutDevice = 0; waveOutDevice < waveOutDevices; waveOutDevice++)
            {
                WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveOutDevice);
                cbAudio.Items.Add(deviceInfo.ProductName);
            }
            _musicFiles = musicFiles;
            if (_musicFiles.Count == 0) this.Dispose();
            ltbPlayers.Items.Add(new MusicPlayer());
            if (cbAudio.Items.Contains("Muzsika TS (Virtual Audio Cable")) ((MusicPlayer)ltbPlayers.Items[0]).DeviceId = cbAudio.Items.IndexOf("Muzsika TS (Virtual Audio Cable");
            ltbPlayers.SelectedIndex = 0;
            ltbSongs.DataSource = _musicFiles;
            tmRefreshing.Start();
        }

        private void PlaySelected()
        {
            if (_musicFiles == null) return;
            if (ltbSongs.Items.IndexOf(_currentMusic) < ltbSongs.Items.Count - 2) ltbSongs.SelectedIndex = ltbSongs.Items.IndexOf(_currentMusic) + 2;
            ltbSongs.SelectedIndex = ltbSongs.Items.IndexOf(_currentMusic);
            _musicPlayers.ForEach(p => p.Play(_currentMusic.File.Name));
        }

        private void NextSong()
        {
            if (_currentMusic == null) return;
            int index = ltbSongs.Items.IndexOf(_currentMusic);
            if (index != ltbSongs.Items.Count - 1) _currentMusic = (MusicFile)ltbSongs.Items[index + 1]; else _currentMusic = (MusicFile)ltbSongs.Items[0];
            PlaySelected();
        }
        private void Player_Load(object sender, EventArgs e)
        {

        }

        private void trbVol_Scroll(object sender, EventArgs e)
        {

            if (ltbPlayers.SelectedIndices.Count == 0) return;
            SelectedPlayer.Volume = trbVol.Value / 100f;
        }

        private void trbCuttentTime_Scroll(object sender, EventArgs e)
        {
            _musicPlayers.ForEach(p => p.CurrentTime = new TimeSpan(0, 0, trbCuttentTime.Value));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (ltbSongs.SelectedIndices.Count == 0) return;
            _currentMusic = (MusicFile)ltbSongs.SelectedItem;
            PlaySelected();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            _musicPlayers.ForEach(p => p.Stop());
        }

        private void Player_FormClosed(object sender, FormClosedEventArgs e)
        {
            _musicPlayers.ForEach(p => p.Dispose());
        }

        private void tmRefreshing_Tick(object sender, EventArgs e)
        {
            if (!trbCuttentTime.Enabled) trbCuttentTime.Enabled = true;
            if (trbCuttentTime.Maximum != (int)FirstPlayer.TotalTime.TotalSeconds) trbCuttentTime.Maximum = (int)FirstPlayer.TotalTime.TotalSeconds;
            trbCuttentTime.Value = (int)FirstPlayer.CurrentTime.TotalSeconds;
            tbTime.Text = FirstPlayer.CurrentTime.Hours.ToString().PadLeft(2, '0') + ":" + FirstPlayer.CurrentTime.Minutes.ToString().PadLeft(2, '0') + ":" + FirstPlayer.CurrentTime.Seconds.ToString().PadLeft(2, '0');
            if (FirstPlayer.CurrentTime >= FirstPlayer.TotalTime - new TimeSpan(0, 0, 0, 0, 250)) NextSong();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentMusic == null) return;
            int index = ltbSongs.Items.IndexOf(_currentMusic);
            if (index != 0) _currentMusic = (MusicFile)ltbSongs.Items[index - 1];
            PlaySelected();
        }

        private void cbAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbPlayers.SelectedIndices.Count == 0) return;
            SelectedPlayer.DeviceId = cbAudio.SelectedIndex;
            trbVol.Value = (int)SelectedPlayer.Volume * 100;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            MusicPlayer p = new MusicPlayer();
            if (_currentMusic != null)
            {
                p.Play(_currentMusic.File.Name);
                p.CurrentTime = FirstPlayer.CurrentTime;
                if (!FirstPlayer.Playing) p.Stop();
            }
            ltbPlayers.Items.Add(p);
            ltbPlayers.SelectedItem = p;
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (ltbPlayers.SelectedIndices.Count == 0 || ltbPlayers.Items.Count <= 1) return;
            SelectedPlayer.Dispose();
            ltbPlayers.Items.Remove(SelectedPlayer);
        }

        private void btnMutePlayer_Click(object sender, EventArgs e)
        {
            if (ltbPlayers.SelectedIndices.Count == 0) return;
            SelectedPlayer.Volume = 0;
            trbVol.Value = 0;
        }

        private void ltbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbPlayers.SelectedItems.Count == 0)
            {
                trbVol.Enabled = false;
                cbAudio.Enabled = false;
            }
            else
            {
                trbVol.Enabled = true;
                cbAudio.Enabled = true;
                trbVol.Value = (int)(SelectedPlayer.Volume * 100);
                cbAudio.SelectedIndex = SelectedPlayer.DeviceId;
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            if (tbSearch.Text == "" && _currentMusic != null)
            {
                if (ltbSongs.Items.IndexOf(_currentMusic) < ltbSongs.Items.Count - 2) ltbSongs.SelectedIndex = ltbSongs.Items.IndexOf(_currentMusic) + 2;
                ltbSongs.SelectedIndex = ltbSongs.Items.IndexOf(_currentMusic);
            }
            else
            {
                int startIndex;
                bool found = false;
                if (ltbSongs.SelectedIndices.Count == 0 || !SelectedFile.Searcher(tbSearch.Text)) startIndex = 0;
                else startIndex = ltbSongs.SelectedIndex+1;
                for (int i = startIndex; i < ltbSongs.Items.Count; i++)
                {
                    if(((MusicFile)ltbSongs.Items[i]).Searcher(tbSearch.Text))
                    {
                        ltbSongs.SelectedIndex = i;
                        found = true;
                        break;
                    }
                }
                if(startIndex != 0 && !found)
                {
                    for (int i = 0; i <= startIndex; i++)
                    {
                        if (((MusicFile)ltbSongs.Items[i]).Searcher(tbSearch.Text))
                        {
                            ltbSongs.SelectedIndex = i;
                            found = true;
                            break;
                        }
                    }
                }
                if (!found) ltbSongs.SelectedItem = null;
            }

        }
    }

    class MusicPlayer
    {
        static int ID = 1;
        WaveOut _waveOut;
        Mp3FileReader _reader;
        bool _playing = false;
        int _id;

        public bool Playing
        {
            get { return _playing && CurrentTime < TotalTime - new TimeSpan(0, 0, 0, 0, 250); }
        }

        public override string ToString()
        {
            return _id.ToString() + ". Player";
        }

        public int DeviceId
        {
            get { return _waveOut.DeviceNumber; }
            set 
            {
                if (value == DeviceId) return;
                if (value >= WaveOut.DeviceCount) return;
                
                _waveOut.Dispose();
                _waveOut = new WaveOut();
                _waveOut.DeviceNumber = value;
                if (_reader != null)
                {
                    _waveOut.Init(_reader);
                    _waveOut.Play();
                }
            }
        }
        public MusicPlayer(int deviceId = 0)
        {
            _id = ID++;
            _waveOut = new WaveOut();
            if (deviceId < WaveOut.DeviceCount) _waveOut.DeviceNumber = deviceId;
        }

        public float Volume
        {
            get { return _waveOut.Volume; }
            set { _waveOut.Volume = value <= 1 ? value : 1f; }
        }

        public void Play()
        {
            if(_reader != null)_waveOut.Play();
            _playing = true;
        }

        public void Play(string path)
        {
            _waveOut.Stop();
            if (_reader != null) _reader.Dispose();
            _reader = new Mp3FileReader(path);
            _waveOut.Init(_reader);
            _waveOut.Play();
            _playing = true;
        }

        public void Stop()
        {
            _waveOut.Stop();
            _playing = false;
        }

        public TimeSpan CurrentTime
        {
            get { return _reader != null?_reader.CurrentTime : new TimeSpan(0); }
            set { if (_reader != null)_reader.CurrentTime = value <= _reader.TotalTime ? value : _reader.TotalTime; Play(); }
        }

        public void Dispose()
        {
            _waveOut.Dispose();
            if(_reader != null)_reader.Dispose();
        }
        public TimeSpan TotalTime
        {
            get { return _reader != null?_reader.TotalTime:new TimeSpan(0); }
        }

    }
}
