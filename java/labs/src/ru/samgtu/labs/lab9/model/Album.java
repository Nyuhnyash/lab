package ru.samgtu.labs.lab9.model;

import java.util.ArrayList;
import java.util.List;

public class Album {
    public final String title;
    public final String genre;
    public final List<Song> songlist = new ArrayList<>();

    public Album(String title, String genre) {
        this.title = title;
        this.genre = genre;
    }

    public Album withSonglist(Song... songs) {
        this.songlist.addAll(List.of(songs));
        return this;
    }
}
