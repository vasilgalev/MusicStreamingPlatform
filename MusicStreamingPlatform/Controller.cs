using System;
using System.Collections.Generic;

public class Controller
{
    private Dictionary<string, User> users;

    public Controller()
    {
        users = new Dictionary<string, User>();
    }

    public string AddUser(List<string> args)
    {
        string username = args[0];
        int age = int.Parse(args[1]);
        var user = new User(username, age);
        users.Add(username, user);
        return $"Created User {username}!";
    }

    public string AddPlaylist(List<string> args)
    {
        string username = args[0];
        string title = args[1];
        var playlist = new Playlist(title);
        users[username].AddPlaylist(playlist);
        return $"Created Playlist {title} for User {username}!";
    }
    public string AddSongToPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string songTitle = args[2];
        int duration = int.Parse(args[3]);
        string artist = args[4];
        string genre = args[5];
        string type = args[6];
        Song song;
        if (type == "single")
        {
            DateTime releaseDate = DateTime.Parse(args[7]);
            song = new Single(songTitle, duration, artist, genre, releaseDate);
        }
        else
        {
            string albumName = args[7];
            song = new AlbumSong(songTitle, duration, artist, genre, albumName);
        }

        var user = users[username];
        var playlist = user.GetPlaylistByTitle(playlistTitle);
        playlist.AddSong(song);

        return $"Added song {songTitle} to Playlist {playlistTitle}!";
    }

    public string GetTotalDurationOfPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        var playlist = users[username].GetPlaylistByTitle(playlistTitle);
        int totalDuration = playlist.TotalDuration();
        return $"Total duration of {playlistTitle}: {totalDuration} seconds";
    }

    public string GetSongsByArtistFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string artist = args[2];
        var playlist = users[username].GetPlaylistByTitle(playlistTitle);
        var songs = playlist.GetSongsByArtist(artist);
        return string.Join("\n", songs);
    }

    public string GetSongsByGenreFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string genre = args[2];
        var playlist = users[username].GetPlaylistByTitle(playlistTitle);
        var songs = playlist.GetSongsByGenre(genre);
        return string.Join("\n", songs);
    }

    public string GetSongsAboveDurationFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        int duration = int.Parse(args[2]);
        var playlist = users[username].GetPlaylistByTitle(playlistTitle);
        var songs = playlist.GetSongsAboveDuration(duration);
        return string.Join("\n", songs);
    }
}