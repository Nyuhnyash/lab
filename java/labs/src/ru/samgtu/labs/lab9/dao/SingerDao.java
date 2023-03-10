package ru.samgtu.labs.lab9.dao;

import ru.samgtu.labs.lab9.model.Singer;

import java.util.List;

public interface SingerDao {
    List<Singer> findSingers();
    void saveSingers(List<Singer> signers);
}
