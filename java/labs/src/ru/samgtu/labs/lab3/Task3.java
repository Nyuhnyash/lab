package ru.samgtu.labs.lab3;

import java.time.LocalTime;
import java.time.ZoneId;
import java.time.temporal.ChronoField;

public class Task3 {
    public static void main(String[] args) {
        System.out.println(toMidnight());
    }
    static long toMidnight() {
        return 24 * 60 * 60 - LocalTime.now(ZoneId.systemDefault()).get(ChronoField.SECOND_OF_DAY);
    }
}
