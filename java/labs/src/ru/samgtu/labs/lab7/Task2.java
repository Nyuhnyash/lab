package ru.samgtu.labs.lab7;

import ru.samgtu.util.Util;

import java.util.LinkedList;
import java.util.UUID;

public class Task2 {
    public static void main(String[] args) {
        var linkList = new LinkList<String>();
        var linkedList = new LinkedList<String>();

        for (var i = 0; i < 1_000_000; i++) {
            linkList.add(UUID.randomUUID().toString());
            linkedList.add(UUID.randomUUID().toString());
        }


//        Util.testList(linkList); // List in not implemented
        Util.testList(linkedList);
    }
}
