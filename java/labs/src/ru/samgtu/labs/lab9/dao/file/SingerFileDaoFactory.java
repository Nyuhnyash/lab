package ru.samgtu.labs.lab9.dao.file;

import ru.samgtu.labs.lab9.dao.AbstractSingerDaoFactory;
import ru.samgtu.labs.lab9.dao.SingerDao;

public class SingerFileDaoFactory implements AbstractSingerDaoFactory {
   private static SingerDao INSTANCE;

    @Override
    public SingerDao createSingerDao() {
        return INSTANCE == null ? INSTANCE = new SingerFileDao() : INSTANCE;
    }
}
