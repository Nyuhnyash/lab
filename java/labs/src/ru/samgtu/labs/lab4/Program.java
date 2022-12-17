package ru.samgtu.labs.lab4;

import ru.samgtu.labs.lab4.figure.rectangle.Rectangle;
import ru.samgtu.labs.lab4.figure.rectangle.Square;
import ru.samgtu.labs.lab4.figure.triangle.EquilateralTriangle;
import ru.samgtu.labs.lab4.figure.triangle.RightTriangle;

public class Program {
    public static void main(String[] args) {
        System.out.printf("%s\n%s\n%s\n%s\n",
                new Rectangle(1, 2),
                new Square(1),
                new RightTriangle(1, 2),
                new EquilateralTriangle(1).perimeter()
        );
    }
}
