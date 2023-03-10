package ru.samgtu.labs.lab9;

import ru.samgtu.labs.lab9.model.Singer;

import java.util.List;

public class SingerService {
    public static List<Singer> filterByGenre(List<Singer> singers, String genre) {
        return singers.stream()
                .filter(s -> s.albums.stream()
                        .anyMatch(a -> a.genre.equals(genre))
                )
                .toList();
    }

    public static List<Singer> filterByMinAlbumsCount(List<Singer> singers, int minAlbums) {
        return singers.stream()
                .filter(s -> minAlbums <= s.albums.size())
                .toList();
    }
}
