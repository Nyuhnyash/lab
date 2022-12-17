package ru.samgtu.labs.lab7;

import java.util.UUID;

public class Task1 {
    public static void main(String[] args) {
        var list = new LinkList<String>();

        for (var i = 0; i < 10; i++) {
            list.add(UUID.randomUUID().toString());
        }

        for (var e: list) {
            System.out.println(e);
        }

        list.forEach(System.out::println);
    }
}
