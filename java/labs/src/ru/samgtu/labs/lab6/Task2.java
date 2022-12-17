package ru.samgtu.labs.lab6;

import ru.samgtu.util.Util;

import java.util.*;

public class Task2 {
	public static void main(String[] args) {
		var len = 1_000_000;
		var arrayList = new ArrayList<String>(len + 10000);
		var linkedList = new LinkedList<String>();
		var synchronizedList = Collections.synchronizedList(arrayList);
		for (int i = 0; i < len; i++) {
			var uuid = UUID.randomUUID().toString();
			arrayList.add(uuid);
			linkedList.add(uuid);
		}

		Util.testList(synchronizedList);
		Util.testList(arrayList);
		Util.testList(linkedList);
	}
}
