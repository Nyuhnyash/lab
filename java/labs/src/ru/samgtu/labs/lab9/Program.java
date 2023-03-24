package ru.samgtu.labs.lab9;

import ru.samgtu.labs.lab9.dao.file.SingerFileDaoFactory;
import ru.samgtu.labs.lab9.dao.jdbc.SingerJdbcDaoFactory;

import java.util.List;

public class Program {
    public static void main(String[] args) {
        for (var factory : List.of(new SingerJdbcDaoFactory(), new SingerFileDaoFactory())) {
            var singerDao = factory.createSingerDao();

            var singers = singerDao.findSingers();

            var filtered = SingerService.filterByGenre(singers, "Hard Rock");
            singerDao.saveSingers(filtered);
        }
    }
}
