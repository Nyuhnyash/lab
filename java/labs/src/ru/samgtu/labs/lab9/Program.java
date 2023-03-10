package ru.samgtu.labs.lab9;

import ru.samgtu.labs.lab9.dao.file.SingerFileDaoFactory;
import ru.samgtu.labs.lab9.dao.jdbc.SingerJdbcDaoFactory;
import ru.samgtu.labs.lab9.model.Album;
import ru.samgtu.labs.lab9.model.Singer;
import ru.samgtu.labs.lab9.model.Song;

import java.util.List;

public class Program {
    public static void main(String[] args) {
        var singers = List.of(
                new Singer("Queen").withAlbums(
                        new Album("Queen", "Hard Rock").withSonglist(
                                new Song("Keep Yourself Alive", "3:15"),
                                new Song("Doing All Right", "4:09"),
                                new Song("Great King Rat", "5:42"),
                                new Song("My Fairy King", "4:07"),
                                new Song("Liar", "6:25"),
                                new Song("The Night Comes Down", "4:23"),
                                new Song("Modern Times Rock 'N' Roll", "1:48"),
                                new Song("Son And Daughter", "3:18"),
                                new Song("Jesus", "3:45"),
                                new Song("Seven Seas Of Rhye", "1:08")
                        ),
                        new Album("Queen II", "Art Rock"),
                        new Album("Sheer Heart Attack", "Hard Rock"),
                        new Album("A Night at the Opera", "Progressive Rock"),
                        new Album("A Day at the Races", "Hard Rock"),
                        new Album("News of the World", "Hard Rock"),
                        new Album("Jazz", "Hard Rock"),
                        new Album("The Game", "Rock"),
                        new Album("Flash Gordon", "Rock"),
                        new Album("Hot Space", "Pop Rock"),
                        new Album("The Works", "Pop Rock"),
                        new Album("A Kind of Magic", "Hard Rock"),
                        new Album("The Miracle", "Rock"),
                        new Album("Innuendo", "Hard Rock"),
                        new Album("Made in Heaven", "Rock")
                ),
                new Singer("The Beatles").withAlbums(
                        new Album("Abbey Road", "Rock")
                )
        );

        for (var factory : List.of(new SingerJdbcDaoFactory(), new SingerFileDaoFactory())) {
            var singerDao = factory.createSingerDao();

            singerDao.saveSingers(singers);
            var signersFromDao = singerDao.findSingers();

            SingerService.filterByGenre(signersFromDao, "Rock");
            SingerService.filterByMinAlbumsCount(signersFromDao, 2);
        }
    }
}
