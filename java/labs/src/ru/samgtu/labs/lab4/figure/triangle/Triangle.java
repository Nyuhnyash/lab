package ru.samgtu.labs.lab4.figure.triangle;

import ru.samgtu.labs.lab4.figure.Figure;

public class Triangle extends Figure {
	private double a;
	private double b;
	private double angle;

	public Triangle(double a, double b, double angle) {
		this.a = a;
		this.b = b;
		this.angle = angle;
	}

	public double getA() {
		return a;
	}

	public double getB() {
		return b;
	}

	public double getAngle() {
		return angle;
	}

	@Override
	public double square() {
		return .5 * a * b * Math.sin(Math.toRadians(angle));
	}

	@Override
	public double perimeter() {
		return a + b * Math.sqrt(a * a + b * b - 2 * a * b * Math.cos(Math.toRadians(angle)));
	}

	@Override
	public String toString() {
		return "%s: %s, %s, angle = %s".formatted(getClass().getSimpleName(), a, b, angle);
	}
}
