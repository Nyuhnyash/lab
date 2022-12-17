package ru.samgtu.labs.lab2;

public class Task3 {
    public static void main(String[] args) {
        var a = new int[] {2, 1, 4, 5};
        System.out.println(MinIndex(a));
        System.out.println(MaxIndex(a));
    }

     private static int MinIndex(int[] data) {
        var min = data[0];
        var result = 1;
        for (int i = 1; i < data.length; i++) {
            if (data[i] < min) {
                min = data[i];
                result = i;
            }
        }
        return result;
    }

    private static int MaxIndex(int[] data) {
        var max = data[0];
        var result = 1;
        for (int i = 1; i < data.length; i++) {
            if (data[i] > max) {
                max = data[i];
                result = i;
            }
        }
        return result;
    }
}
