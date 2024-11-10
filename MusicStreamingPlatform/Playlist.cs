using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private string title;

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            if (value.Length < 3 || value.Length > 50)
            {
                throw new ArgumentException("Playlist title should be between 3 and 50 characters!");
            }
            title = value;
        }
    }

    private List<Song> songs;

    public Playlist(string title)
    {
        this.Title = title;
        this.songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    public int TotalDuration()
    {
        return songs.Sum(x => x.Duration);

    }

    public List<Song> GetSongsByArtist(string artist)
    {
        
        return songs.Where(a => a.Artist == artist).OrderBy(s=>s.Title).ToList();
    }

    public List<Song> GetSongsByGenre(string genre)
    {
        List<Song> songGenre = songs.Where(g => g.Genre == genre).ToList();
        return songGenre.OrderByDescending(x => x.Title).ToList();
    }

    public List<Song> GetSongsAboveDuration(int duration)
    {
        List<Song> songDuration = songs.Where(d => d.Duration >= duration).ToList();
        return songDuration.OrderByDescending(x => x.Duration).ToList();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Playlist: {Title}");
        sb.AppendLine($"Total Songs: {songs.Count}");
        return sb.ToString();
    }
}