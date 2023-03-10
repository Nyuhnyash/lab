package ru.samgtu.labs.lab9.model;

import java.util.ArrayList;
import java.util.List;

public class Singer {
    public final String name;
    public final List<Album> albums = new ArrayList<>();

    public Singer(String name) {
        this.name = name;
    }

    public Singer withAlbums(Album... albums) {
        this.albums.addAll(List.of(albums));
        return this;
    }
}
