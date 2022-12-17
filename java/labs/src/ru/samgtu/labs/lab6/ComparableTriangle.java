package ru.samgtu.labs.lab6;

import ru.samgtu.labs.lab4.figure.triangle.Triangle;

import java.util.Comparator;

public class ComparableTriangle extends Triangle implements Comparable<Triangle> {
	public ComparableTriangle(Triangle triangle) {
		super(triangle.getA(), triangle.getB(), triangle.getAngle());
	}

	@Override
	public int compareTo(Triangle o) {
		return Double.compare(perimeter(), o.perimeter());
	}

	static class BySquareCamparator implements Comparator<Triangle> {
		@Override
		public int compare(Triangle o1, Triangle o2) {
			return Double.compare(o1.square(), o2.square());
		}
	}
}
