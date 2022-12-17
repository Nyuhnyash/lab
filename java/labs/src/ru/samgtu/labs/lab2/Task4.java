package ru.samgtu.labs.lab2;


import java.util.Arrays;
import java.util.Locale;

public class Task4 {
    public static void main(String[] args) {
        var count = 10;
        var x = 2;
        var factorials = getFactorials(count);
        System.out.printf("Первые %d факториалов: %s\n", count, Arrays.toString(factorials));
        var pows = getPows(x, count);
        System.out.printf("Первые %d степеней числа %d: %s\n", count, x, Arrays.toString(pows));
        var delta = getMaclaren(x, count) - Math.exp(x);
        System.out.printf(Locale.US,"Разница между разложением числа %d в ряд Макларена и экспонентой: %f\n", x, delta);
    }

    private static int[] getFactorials(int n) {

        var result = new int[n];
        var f = 1;
        for (int i = 0; i < n; i++) {
            result[i] = f *= (i + 1);
        }
        return result;
    }

    private static double[] getPows(double x, int n) {
        var result = new double[n];
        for (int i = 0; i < n; i++) {
            result[i] = Math.pow(x, i + 1);
        }

        return result;
    }

    private static double getMaclaren(double x, int n) {
        var result = 1d;
        var pows = getPows(x, n);
        var factors = getFactorials(n);
        for (int i = 0; i < n; i++) {
            result += pows[i] / factors[i];
        }

        return result;
    }
}
