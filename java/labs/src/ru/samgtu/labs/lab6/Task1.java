package ru.samgtu.labs.lab6;

import ru.samgtu.labs.lab4.figure.Perimetrable;
import ru.samgtu.labs.lab4.figure.Squarable;
import ru.samgtu.labs.lab4.figure.rectangle.Rectangle;
import ru.samgtu.labs.lab4.figure.rectangle.Square;
import ru.samgtu.labs.lab4.figure.triangle.EquilateralTriangle;
import ru.samgtu.labs.lab4.figure.triangle.RightTriangle;
import ru.samgtu.labs.lab4.figure.triangle.Triangle;

import java.util.*;
import java.util.stream.Collectors;

public class Task1 {
	public static void main(String[] args) {
		List<ComparableRectangle> rectangles = new ArrayList<>(List.of(
				new ComparableRectangle(new Rectangle(2, 4)),
				new ComparableRectangle(new Rectangle(2, 3)),
				new ComparableRectangle(new Square(5))
		));

		var triangles = new ArrayList<>(List.of(
				new ComparableTriangle(new RightTriangle(5, 12)),
				new ComparableTriangle(new Triangle(10, 10, 1)),
				new ComparableTriangle(new EquilateralTriangle(7))
		));

		printHeader("Initial rectangle list");
		rectangles.forEach(Task1::printSquare);

		Collections.sort(rectangles);
		printHeader("Sorted rectangle list");
		rectangles.forEach(Task1::printSquare);

		printHeader("Initial triangle list");
		triangles.forEach(Task1::printPerimeter);

		Collections.sort(triangles);
		printHeader("Sorted by perimeter triangle list");
		triangles.forEach(Task1::printPerimeter);

		printHeader("Triangle list with squares");
		triangles.forEach(Task1::printSquare);

		triangles.sort(new ComparableTriangle.BySquareCamparator());
		printHeader("Sorted by square triangle list");
		triangles.forEach(Task1::printSquare);


		var rectanglesMap = rectangles.stream().collect(Collectors.toMap(
				Rectangle::perimeter,
				rectangle -> rectangle,
				(rectangle1, rectangle2) -> rectangle1,
				TreeMap::new
		));

		rectanglesMap.entrySet().forEach(System.out::println);
	}


	private static void printHeader(String header) {
		System.out.printf("\n\t%s:\n", header);
	}

	private static void printSquare(Squarable x) {
		System.out.printf("%s with square %.1f\n", x, x.square());
	}

	private static void printPerimeter(Perimetrable x) {
		System.out.printf("%s with perimeter %.1f\n", x, x.perimeter());
	}
}
