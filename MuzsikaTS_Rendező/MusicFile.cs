using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzsikaTS_Rendező
{
    public class MusicFile
    {
        TagLib.File _source;
        public object[] DataDelivery2 { get; set; }
        public string DataDelivery1 { get; set; }
        public MusicFile(string path)
        {
            _source = TagLib.File.Create(path);
        }

        public MusicFile(TagLib.File tFile)
        {
            _source = tFile;
        }

        public void Reload()
        {
            this._source = TagLib.File.Create(File.Name);
        }

        public string ArtistFromFile
        { get { return System.IO.Path.GetFileNameWithoutExtension(FileName).Split('-')[0].Trim(); } }


        public string TitleFromFile
        { get { return System.IO.Path.GetFileNameWithoutExtension(FileName).Split('-')[System.IO.Path.GetFileNameWithoutExtension(FileName).Split('-').Length - 1].Trim(); } }

        public TagLib.File File
        {
            get { return _source; }
            set { _source = value; }
        }

        public TagLib.Tag Tag
        {
            get { return _source.Tag; }
        }

        public override string ToString()
        {
            if ((Tag.Album + Tag.Performers.ToStringLine() + Tag.Title).Length != 0)
                return Program.MusicFormat.Replace("{artist}", Tag.Performers.ToStringLine("; ")).Replace("{album}", Tag.Album).Replace("{title}", Tag.Title).Replace("{file}", FileName).Replace("{dir}", DirectoryName);
            return FileName;
        }

        public string FileName { get { return System.IO.Path.GetFileName(File.Name); } }
        public string DirectoryName { get { return System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(File.Name)); } }
        public bool Searcher(string line1)
        {
            bool Found = false;
            Found |= this.ToString().ToStringNull().Equals2(line1);
            foreach (string item in Tag.Performers) Found |= item.ToStringNull().Equals2(line1);
            if (Tag.Performers.Length == 0)Found|= "".ToStringNull().Equals2(line1);
            Found |= Tag.Album.ToStringNull().Equals2(line1);
            Found |= Tag.Title.ToStringNull().Equals2(line1);
            Found |= FileName.Equals2(line1);
            Found |= FileName.Equals2(line1);
            foreach (string genre in Tag.Genres) if (genre != "" && genre != null) Found |= genre.Equals2(line1);
            return Found;
        }

        public static implicit operator MusicFile(TagLib.File tFile)
        {
            return new MusicFile(tFile);
        }

        public string AllInfo
        {
            get
            {
                return DirectoryName + "/" + FileName + "\n \nTitle:" + Tag.Title + "\n Artist: " + Tag.Performers.ToStringLine() + "\nAlbum: " + Tag.Album + "\nGenres: " + Tag.Genres.ToStringLine() + "\nYear: " + Tag.Year.ToString() + " \nTrack: " + Tag.Track.ToString();
            }
        }
    }
}
