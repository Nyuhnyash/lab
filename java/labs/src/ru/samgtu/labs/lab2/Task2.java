package ru.samgtu.labs.lab2;

import java.util.Scanner;

public class Task2 {
    public static void main(String[] args) {
        var n = 0;
        var k = 0;
        var scanner = new Scanner(System.in);
        n = scanner.nextInt();
        k = scanner.nextInt();


        for (int i = 1; n > 0; i++) {
            if (i % k == 0) {
                System.out.println(i);
                n--;
            }
        }
    }
}
