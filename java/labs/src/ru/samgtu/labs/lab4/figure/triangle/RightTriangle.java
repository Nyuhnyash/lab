package ru.samgtu.labs.lab4.figure.triangle;

public class RightTriangle extends Triangle {

    public RightTriangle(double a, double b) {
        super(a, b, 90);
    }

    @Override
    public double perimeter() {
        var a = getA();
        var b = getB();
        return 2 * a + Math.sqrt(a *a + b *b);
    }

    @Override
    public String toString() {
        return "Right rectangle with sides %s and %s".formatted(getA(), getB());
    }
}
