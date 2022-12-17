package ru.samgtu.labs.lab3;

import java.lang.reflect.Type;
import java.text.MessageFormat;

public class Task1 {
    public static void main(String[] args) {
        System.out.println(makeGetter(String.class, "fieldName"));
        System.out.println(makeSetter(char.class, "charField"));
    }

    static String makeGetter(Type type, String fieldName) {
        var typeName = type.getTypeName();
        var fieldNameUpperCamelcase = Character.toUpperCase(fieldName.charAt(0)) + fieldName.substring(1);
        return "public %s get%s() {\n\treturn this.%s;\n}".formatted(typeName, fieldNameUpperCamelcase, fieldName);
    }

    static String makeSetter(Type type, String fieldName) {
        var typeName = type.getTypeName();
        var fieldNameUpperCamelcase = Character.toUpperCase(fieldName.charAt(0)) + fieldName.substring(1);
        return MessageFormat.format("public void set{1}({0} {2}) '{'\n\tthis.{2} = {2};\n'}'", typeName, fieldNameUpperCamelcase, fieldName);
    }
}
