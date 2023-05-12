package ru.samgtu.labs.lab11;

import ru.samgtu.labs.lab9.model.Album;
import ru.samgtu.labs.lab9.model.Singer;
import ru.samgtu.labs.lab9.dao.SingerDao;
import ru.samgtu.labs.lab9.model.Song;

import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class SingerJdbcDao implements SingerDao {


    private final Connection connection;

    public SingerJdbcDao() {
        try {
            connection = DriverManager.getConnection("jdbc:sqlite:src/ru/samgtu/labs/lab11/db.sqlite");
            var statement = connection.createStatement();
            statement.addBatch("CREATE TABLE IF NOT EXISTS genres (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE);");

            for (var suffix : new String[] {"", "_filtered"}) {
                statement.addBatch("CREATE TABLE IF NOT EXISTS singers%s (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT);".formatted(suffix));
                statement.addBatch("CREATE TABLE IF NOT EXISTS albums%s (".formatted(suffix) +
                        "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "title TEXT, " +
                        "genreId INTEGER, " +
                        "singerId INTEGER, " +
                        "CONSTRAINT genres_FK FOREIGN KEY (genreId) REFERENCES genres(id), " +
                        "CONSTRAINT singers_FK FOREIGN KEY (singerId) REFERENCES singers%s(id)".formatted(suffix) +
                        ");"
                );
                statement.addBatch("CREATE TABLE IF NOT EXISTS songs%s (id INTEGER PRIMARY KEY AUTOINCREMENT, ".formatted(suffix) +
                        "title TEXT, " +
                        "duration INTERVAL," +
                        "albumId INTEGER," +
                        "CONSTRAINT album_FK FOREIGN KEY (albumId) REFERENCES albums%s(id));".formatted(suffix));
            }

            statement.executeBatch();


        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<Singer> findSingers() {
        var singers = new ArrayList<Singer>();

        try {
            var statement = connection.createStatement();

            var resultSet = statement.executeQuery("SELECT * FROM genres;");
            var genresRaw = new HashMap<Integer, String>();
            while (resultSet.next()) {
                var id = resultSet.getInt("id");
                var name = resultSet.getString("name");
                genresRaw.put(id, name);
            }

            resultSet = statement.executeQuery("SELECT * FROM singers;");
            HashMap<Integer, Singer> singersRaw = new HashMap<>();
            while (resultSet.next()) {
                var id = resultSet.getInt("id");
                var name = resultSet.getString("name");

                var singer = new Singer(name);
                singers.add(singer);
                singersRaw.put(id, singer);
            }

            resultSet = statement.executeQuery("SELECT * FROM albums;");
            var albumsRaw = new HashMap<Integer, Album>();
            while (resultSet.next()) {
                var id = resultSet.getInt("id");
                var title = resultSet.getString("title");
                var genreId = resultSet.getInt("genreId");
                var singerId = resultSet.getInt("singerId");

                var album = new Album(title, genresRaw.get(genreId));
                singersRaw.get(singerId).albums.add(album);
                albumsRaw.put(id, album);
            }

            resultSet = statement.executeQuery("SELECT * FROM songs;");
            while (resultSet.next()) {
                var title = resultSet.getString("title");
                var duration = resultSet.getString("duration");
                var albumId = resultSet.getInt("albumId");

                albumsRaw.get(albumId).songlist.add(new Song(title, duration));
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        return singers;
    }

    @Override
    public void saveSingers(List<Singer> signers) {
        try {
            var truncateSt = connection.createStatement();
            truncateSt.addBatch("DELETE FROM singers_filtered;");
            truncateSt.addBatch("DELETE FROM albums_filtered;");
            truncateSt.addBatch("DELETE FROM songs_filtered;");
            truncateSt.addBatch("UPDATE sqlite_sequence SET seq = 0 WHERE name LIKE '%_filtered';");
            truncateSt.executeBatch();

            var singerSt = connection.prepareStatement("INSERT INTO singers_filtered (name) VALUES (?);");
            var albumSt = connection.prepareStatement("INSERT INTO albums_filtered (title, genreId, singerId) VALUES (?, ?, ?);");
            var songSt = connection.prepareStatement("INSERT INTO songs_filtered (title, duration, albumId) VALUES (?, ?, ?);");
            var genreStSelect = connection.prepareStatement("SELECT id FROM genres WHERE name =?;");
            var genreStInsert = connection.prepareStatement("INSERT OR IGNORE INTO genres(name) VALUES (?);");

            for (var singer : signers) {

                singerSt.setString(1, singer.name);
                singerSt.executeUpdate();

                var singerId = singerSt.getGeneratedKeys().getInt(1);

                for (var album : singer.albums) {

                    albumSt.setString(1, album.title);

                    genreStSelect.setString(1, album.genre);
                    var resultSet = genreStSelect.executeQuery();
                    int genreId;
                    if (resultSet.next()) {
                        genreId = resultSet.getInt("id");
                    } else {
                        genreStInsert.setString(1, album.genre);
                        genreStInsert.executeUpdate();
                        genreId = genreStInsert.getGeneratedKeys().getInt(1);
                    }


                    albumSt.setInt(2, genreId);
                    albumSt.setInt(3, singerId);
                    albumSt.executeUpdate();

                    var albumId = albumSt.getGeneratedKeys().getInt(1);

                    for (var song : album.songlist) {
                        songSt.setString(1, song.title);
                        songSt.setString(2, "%02d:%02d".formatted(song.duration.toMinutesPart(), song.duration.toSecondsPart()));
                        songSt.setInt(3, albumId);

                        songSt.executeUpdate();
                    }
                }
            }

        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
}
