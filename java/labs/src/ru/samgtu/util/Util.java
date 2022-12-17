package ru.samgtu.util;

import java.util.Arrays;
import java.util.List;
import java.util.UUID;
import java.util.stream.Stream;

public final class Util {
    private final static int testCount = 100;
    public static void testList(List<String> list) {
		System.out.println("Тест " + list.getClass().getSimpleName());
		Stream.of(
				"Добавление в начало: " + measureAverageNano(() -> list.add(0, UUID.randomUUID().toString())              ),
				"Добавление в центр: "  + measureAverageNano(() -> list.add(list.size() / 2, UUID.randomUUID().toString())),
				"Добавление в конец: "  + measureAverageNano(() -> list.add(list.size() - 1, UUID.randomUUID().toString())),
				"Удаление из начала: "  + measureAverageNano(() -> list.remove(0)                                         ),
				"Удаление из центра: "  + measureAverageNano(() -> list.remove(list.size() / 2)                           ),
				"Удаление из конца: "   + measureAverageNano(() -> list.remove(list.size() - 1)                           ),
				"Получение из начала: " + measureAverageNano(() -> list.get(0)                                            ),
				"Получение из центра: " + measureAverageNano(() -> list.get(list.size() / 2)                              ),
				"Получение из конца: "  + measureAverageNano(() -> list.get(list.size() - 1)                              )
				).forEach(System.out::println);
	}

	private static double measureAverageNano(Runnable action) {
		var res = new long[testCount];
		var start = System.nanoTime();
		for (int i = 0; i < testCount; i++) {
			action.run();
			res[i] = System.nanoTime() - start;
		}
		return Arrays.stream(res).average().getAsDouble();
	}
}
