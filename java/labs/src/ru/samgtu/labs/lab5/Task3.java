package ru.samgtu.labs.lab5;

public class Task3 {
    private final static int ARRAY_SUPPORTED_SIZE = 4;

    public static void main(String[] args) {
        var array = new String[][] {
                {"1", "2", "3", "4"},
                {"5", "6", "7", "8"},
                {"9", "10", "11", "12"},
                {"13", "14", "15", "16"},
        };

        var array2 = new String[][] {
                {"1", "2", "3", "4"},
                {"5", "6", "7", "8"},
                {"9", "10", "eleven", "12"},
                {"13", "14", "15", "16"},
        };

        try {
            printStringSquareArray(array);
            printStringSquareArray(array2);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static void printStringSquareArray(String[][] array) throws WrongArrayDataException, UnsupportedArraySizeException {
        if (array.length != ARRAY_SUPPORTED_SIZE) {
            throw new UnsupportedArraySizeException();
        }

        for (var e : array) {
            if (e.length != ARRAY_SUPPORTED_SIZE) {
                throw new UnsupportedArraySizeException();
            }

        }

        var sum = 0d;
        for (var i = 0; i < ARRAY_SUPPORTED_SIZE; i++) {
            for (var j = 0; j < ARRAY_SUPPORTED_SIZE; j++) {
                try {
                    sum += Double.parseDouble(array[i][j]);
                } catch (NumberFormatException e) {
                    throw new WrongArrayDataException(i, j);
                }
            }
        }
    }
    static class UnsupportedArraySizeException extends RuntimeException { }
    static class WrongArrayDataException extends Exception {
        public WrongArrayDataException(int i, int j) {
            super("Wrong data in array at %d, %d".formatted(i, j));
        }
    }
}
