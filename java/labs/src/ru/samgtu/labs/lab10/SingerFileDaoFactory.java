package ru.samgtu.labs.lab10;

import ru.samgtu.labs.lab9.dao.AbstractSingerDaoFactory;
import ru.samgtu.labs.lab9.dao.SingerDao;

public class SingerFileDaoFactory implements AbstractSingerDaoFactory {
   private static SingerDao INSTANCE;

    @Override
    public SingerDao createSingerDao() {
        var dir = "src/ru/samgtu/labs/lab10/";
        if (INSTANCE == null)
            INSTANCE = new SingerFileDao(dir + "singers.txt", dir + "output_singers.txt");
        return INSTANCE;
    }
}
