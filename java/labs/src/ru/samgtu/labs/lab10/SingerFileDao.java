package ru.samgtu.labs.lab10;

import ru.samgtu.labs.lab9.model.*;
import ru.samgtu.labs.lab9.dao.SingerDao;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

public class SingerFileDao implements SingerDao {

    private final Path input;
    private final Path output;

    public SingerFileDao(String input, String output) {
        this.input = Path.of(input);
        this.output = Path.of(output);

    }
    @Override
    public List<Singer> findSingers() {
        var singers = new ArrayList<Singer>();
        try (var reader = Files.newBufferedReader(input, StandardCharsets.UTF_8)) {

            String line;
            Singer currentSinger = null;
            Album currentAlbum = null;
            while ((line = reader.readLine()) != null) {
                var typeAndContent = line.split(": ", 2);
                final var content = typeAndContent[1];
                switch (typeAndContent[0]) {
                    case "Singer" -> singers.add(currentSinger = new Singer(content));
                    case "\tAlbum" -> {
                        var nameAndGenre = content.split(", ", 2);
                        currentSinger.albums.add(currentAlbum = new Album(nameAndGenre[0], nameAndGenre[1]));
                    }
                    case "\t\tSong" -> {
                        var nameAndDuration = content.split(", ", 2);
                        currentAlbum.songlist.add(new Song(nameAndDuration[0], nameAndDuration[1]));
                    }
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        return singers;
    }

    @Override
    public void saveSingers(List<Singer> signers){
        try (var writer = Files.newBufferedWriter(output, StandardCharsets.UTF_8)) {
            for (var singer : signers) {
                writer.write("Singer: %s\n".formatted(singer.name));
                for (var album : singer.albums) {
                    writer.write("\tAlbum: %s, %s\n".formatted(album.title, album.genre));
                    for (var song : album.songlist) {
                        writer.write("\t\tSong: %s, %s\n".formatted(song.title, song.duration));
                    }
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}