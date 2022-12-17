package ru.samgtu.labs.lab4.figure.rectangle;

import ru.samgtu.labs.lab4.figure.Figure;

public class Rectangle extends Figure {
    private double a;
    private double b;

    public Rectangle(double a, double b) {
        this.a = a;
        this.b = b;
    }

    public double getA() {
        return a;
    }

    public void setA(double a) {
        this.a = a;
    }

    public double getB() {
        return b;
    }

    public void setB(double b) {
        this.b = b;
    }

    @Override
    public double perimeter() {
        return 2 * (a + b);
    }

    @Override
    public double square() {
        return a * b;
    }

    @Override
    public String toString() {
        return "%s: %s x %s".formatted(getClass().getSimpleName(), a, b);
    }
}

