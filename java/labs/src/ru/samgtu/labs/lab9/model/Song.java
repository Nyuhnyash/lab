package ru.samgtu.labs.lab9.model;

import java.time.Duration;
import java.time.LocalTime;

public class Song {
    public final String title;
    public final Duration duration;

    public Song(String title, String duration) {
        this.title = title;
        var minSec = duration.split(":");
        this.duration = Duration.between(LocalTime.MIN,
                LocalTime.of(0, Integer.parseInt(minSec[0]),Integer.parseInt(minSec[1]))
        );
    }

}
