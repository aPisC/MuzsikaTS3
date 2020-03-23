using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzsikaTS_Rendező
{
    public class Rule
    {
        public enum RuleMode { Allow, Deny, Force };
        public enum RuleTarget {Any, Album, Artist,Directory, File, Genres, Title, Track, TrackMin, Year, YearMin  };
        public bool Enabled { get; set; }
        private string _value;
        private RuleMode _mode;
        private RuleTarget _target;
        public override string ToString()
        {
            return (Enabled?"": "// ")+_mode.ToString()+": "+_target.ToString()+": \"" + _value +"\"";
        }

        public Rule(string value, RuleMode mode, RuleTarget target)
        {
            _value = value;
            _mode = mode;
            _target = target;
        }

        public bool TestRule(MusicFile file)
        {
            if (_target == Rule.RuleTarget.Artist)
            {
                bool Found = false;
                foreach (string item in file.Tag.Performers) Found |= item.ToStringNull().Equals2(_value);
                if (file.Tag.Performers.Length == 0) Found |= "".ToStringNull().Equals2(_value);
                return Found;
            }
            else if (_target == Rule.RuleTarget.Album) return file.Tag.Album.ToStringNull().Equals2(_value);
            else if (_target == Rule.RuleTarget.Title) return file.Tag.Title.ToStringNull().Equals2(_value);
            else if (_target == Rule.RuleTarget.File) return file.FileName.Equals2(_value);
            else if (_target == Rule.RuleTarget.Directory) return file.DirectoryName.Equals2(_value);
            else if (_target == Rule.RuleTarget.Any) return file.Searcher(_value);
            else if (_target == Rule.RuleTarget.Track) return file.Tag.Track.ToString().Equals2(_value);
            else if (_target == Rule.RuleTarget.Year) return file.Tag.Year.ToString().Equals2(_value);
            else if (_target == Rule.RuleTarget.TrackMin) try { return int.Parse(_value) <=file.Tag.Track; }
                catch { return false; }
            else if (_target == Rule.RuleTarget.YearMin) try { return int.Parse(_value) <= file.Tag.Year; }
                catch { return false; }
            else if (_target == Rule.RuleTarget.Genres) foreach (string genre in file.Tag.Genres) if (genre != "" && genre != null) if (genre.Equals2(_value)) return true; 
            return false;
 
        }
        public string Value { get { return _value; } set { _value = value; } }
        public RuleMode Mode { get { return _mode; } set { _mode = value; } }
        public RuleTarget Target { get { return _target; } set { _target = value; } }
    }
}
