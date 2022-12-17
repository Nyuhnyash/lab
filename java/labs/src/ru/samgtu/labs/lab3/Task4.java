package ru.samgtu.labs.lab3;

import java.time.Duration;
import java.time.LocalTime;
import java.util.Arrays;
import java.util.UUID;
import java.util.stream.Stream;

public class Task4 {
    public static void main(String[] args) {
        var stringArray = new String[1_000_000];
        for (int i = 0; i < stringArray.length; i++) {
            stringArray[i] = UUID.randomUUID().toString();
        }

        var startUnixTime = System.currentTimeMillis();
        new MergeSortAlgorithm().sort(stringArray);
        System.out.println(System.currentTimeMillis() - startUnixTime);

        for (int i = 0; i < stringArray.length; i++) {
            stringArray[i] = UUID.randomUUID().toString();
        }

        var startLocalTime = LocalTime.now();
        new MergeSortAlgorithm().sort(stringArray);
        System.out.println(Duration.between(startLocalTime, LocalTime.now()).toMillis());


    }

    public interface SortAlgorithm {
        String[] sort(String[] array);
    }

    public static class DefaultSortAlgorithm implements SortAlgorithm {
        @Override
        public String[] sort(String[] array) {
            Arrays.sort(array);
            return array;
        }
    }
    public static class MergeSortAlgorithm implements SortAlgorithm {
        @Override
        public String[] sort(String[] array) {
//			if (array.length == 1 || array.length == 0) {
//				return array;
//			}
//			var l = sort(Arrays.copyOfRange(array, 0, array.length / 2));
//			var r = sort(Arrays.copyOfRange(array, array.length / 2, array.length));
//			var m = 0;
//			var n = 0;
//			var k = 0;
//
//			var c = new String[l.length + r.length];
////			while (n )
//			return array;
            var buffer1 = Arrays.copyOf(array, array.length);
            var buffer2 = new String[array.length];
            return sortInner(buffer1, buffer2, 0, array.length);
        }

        private static String[] sortInner(String[] buffer1, String[] buffer2, int startIndex, int endIndex) {
            if (startIndex >= endIndex - 1) {
                return buffer1;
            }

            var middle = startIndex + (endIndex - startIndex) / 2;
            var sorted1 = sortInner(buffer1, buffer2, startIndex, middle);
            var sorted2 = sortInner(buffer1, buffer2, middle, endIndex);

            var index1 = startIndex;
            var index2 = middle;
            var destIndex = startIndex;
            var result = sorted1 == buffer1 ? buffer2 : buffer1;
            while (index1 < middle && index2 < endIndex) {
                result[destIndex++] = sorted1[index1].compareTo(sorted2[index2]) < 0
                        ? sorted1[index1++] : sorted2[index2++];
            }
            while (index1 < middle) {
                result[destIndex++] = sorted1[index1++];
            }
            while (index2 < endIndex) {
                result[destIndex++] = sorted2[index2++];
            }
            return result;
        }
    }
}
