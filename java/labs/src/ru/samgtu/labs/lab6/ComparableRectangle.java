package ru.samgtu.labs.lab6;

import ru.samgtu.labs.lab4.figure.rectangle.Rectangle;

public class ComparableRectangle extends Rectangle implements Comparable<Rectangle> {
	public ComparableRectangle(Rectangle rectangle) {
		super(rectangle.getA(), rectangle.getB());
	}

	@Override
	public int compareTo(Rectangle o) {
		return Double.compare(square(), o.square());
	}
}
