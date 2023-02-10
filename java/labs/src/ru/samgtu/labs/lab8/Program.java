package ru.samgtu.labs.lab8;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.function.Predicate;

public class Program {
    public static void main(String[] args) throws IOException {
        var names = Files.readAllLines(Path.of("src/ru/samgtu/labs/lab8/names.txt"))
                .stream()
                .filter(Predicate.not(String::isEmpty))
                .filter(Predicate.not(s -> s.startsWith("Имена для девочки на букву ")))
                .map(s -> s.split(" —", 2)[0])
                .map(s -> s.split(" |[,()]"))
                .flatMap(Arrays::stream)
                .filter(Predicate.not(String::isEmpty))
                .map(String::trim)
                .distinct()
                .sorted()
                .toList();
    }
}
