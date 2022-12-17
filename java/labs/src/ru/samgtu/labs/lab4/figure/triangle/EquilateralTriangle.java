package ru.samgtu.labs.lab4.figure.triangle;

public class EquilateralTriangle extends Triangle {

    public EquilateralTriangle(double a) {
        super(a, a, 60);
    }

    @Override
    public double perimeter() {
        return 3 * getA();
    }

    @Override
    public String toString() {
        return "Equilateral rectangle with side = %s".formatted(getA());
    }
}
