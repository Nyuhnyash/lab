package ru.samgtu.labs.lab8;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.Comparator;
import java.util.function.Predicate;
import java.util.stream.Collectors;

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


        names.stream().filter(name -> name
                .chars()
                .mapToObj(i -> (char) i)
                .filter(Program::isVowel)
                .count() == 3
        );

        names.stream().filter(name -> name
                .chars()
                .mapToObj(i -> (char)i)
                .filter(Program::isVowel)
                .count() == 4
        );


        names.stream().filter(name -> name
                .chars()
                .mapToObj(i -> (char)i)
                .filter(Program::isVowel)
                .count() == 5
        );

        names.stream().min(Comparator.comparing(String::length));
        names.stream().max(Comparator.comparing(String::length));

        names.stream()
                .filter(name -> name.startsWith("Е"))
                .findFirst();

        names.stream().allMatch(s -> s
                .chars()
                .mapToObj(i -> (char) i)
                .anyMatch(Program::isVowel)
        );

        names.stream().collect(Collectors.toMap(s -> s, String::length));

        names.stream().collect(Collectors.groupingBy(String::length));

        names.stream().collect(Collectors.partitioningBy(s -> isVowel(s.charAt(0))));
    }

    private static boolean isVowel(char c) {
        return "аеёиоуыэюя".contains(String.valueOf(c).toLowerCase());
    }
}
