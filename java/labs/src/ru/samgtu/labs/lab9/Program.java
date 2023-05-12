package ru.samgtu.labs.lab9;

import ru.samgtu.labs.lab10.SingerFileDaoFactory;
import ru.samgtu.labs.lab11.SingerJdbcDaoFactory;

import java.util.List;

public class Program {
    public static void main(String[] args) {
        var factory = args.length > 0 && args[0].equals("jdbc")
                ? new SingerJdbcDaoFactory()
                : new SingerFileDaoFactory();

        var singerDao = factory.createSingerDao();

        var singers = singerDao.findSingers();

        var filtered = SingerService.filterByGenre(singers, "Hard Rock");
        singerDao.saveSingers(filtered);
    }
}
