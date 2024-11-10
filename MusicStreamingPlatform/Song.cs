﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

public abstract class Song
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
            if (value.Length < 2 || value.Length > 100)
            {
                throw new ArgumentException("Title should be between 2 and 100 characters!");
            }
            title = value;
        }
    }

    private int duration;

    public int Duration
    {
        get
        {
            return duration;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Duration should be positive!");
            }
            duration = value;
        }
    }

    private string artist;

    public string Artist
    {
        get
        {
            return artist;
        }
        set
        {
            if (value.Length < 3 || value.Length > 50)
            {
                throw new ArgumentException("Artist name should be between 3 and 50 characters!");
            }
            artist = value;
        }
    }

    private string genre;

    public string Genre
    {
        get
        {
            return genre;
        }
        set
        {
            genre = value;
        }
    }

    public Song(string title, int duration, string artist, string genre)
    {
        this.Title = title;
        this.Duration = duration;
        this.Artist = artist;
        this.Genre = genre;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Duration: {Duration} seconds");
        sb.AppendLine($"Artist: {Artist}");
        return sb.ToString();
    }
}