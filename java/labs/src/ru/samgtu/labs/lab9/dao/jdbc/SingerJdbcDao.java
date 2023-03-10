package ru.samgtu.labs.lab9.dao.jdbc;

import ru.samgtu.labs.lab9.model.Singer;
import ru.samgtu.labs.lab9.dao.SingerDao;

import java.util.List;

public class SingerJdbcDao implements SingerDao {
    @Override
    public List<Singer> findSingers() {
        return null;
    }

    @Override
    public void saveSingers(List<Singer> signers) {
    }
}
