using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    private string username;

    public string Username
    {
        get
        {
            return username;
        }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Username should be between 3 and 30 characters!");
            }
            username = value;
        }
    }

    private int age;

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 13)
            {
                throw new ArgumentException("User must be at least 13 years old!");
            }
            age = value;
        }
    }

    private List<Playlist> playlists;

    public User(string username, int age)
    {
        this.Username = username;
        this.Age = age;
        this.playlists = new List<Playlist>();
    }

    public void AddPlaylist(Playlist playlist)
    {
        playlists.Add(playlist);
    }

    public Playlist GetPlaylistByTitle(string title)
    {
        var playlist = playlists.FirstOrDefault(x => x.Title == title);
        return playlist;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Username: {Username}");
        sb.AppendLine($"Age: {Age}");
        sb.AppendLine($"Total Playlists: {playlists.Count}");
        return sb.ToString();
    }
}
