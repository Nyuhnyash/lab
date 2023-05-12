package ru.samgtu.labs.lab11;

import ru.samgtu.labs.lab9.dao.AbstractSingerDaoFactory;
import ru.samgtu.labs.lab9.dao.SingerDao;

public class SingerJdbcDaoFactory implements AbstractSingerDaoFactory {
    private static SingerDao INSTANCE;

    public SingerDao createSingerDao() {
        return INSTANCE == null ? INSTANCE = new SingerJdbcDao() : INSTANCE;
    }
}
