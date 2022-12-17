package ru.samgtu.labs.lab3;

import java.util.Objects;

public class Task2 {

    public static void main(String[] args) {

    }
    public class Student {
        private Integer id;
        private String name;
        private Double studentship;

        public Integer getId() {
            return id;
        }
        public void setId(Integer id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }
        public void setName(String name) {
            this.name = name;
        }

        public Double getStudentship() {
            return studentship;
        }
        public void setStudentship(Double studentship) {
            this.studentship = studentship;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Student student = (Student) o;
            return Objects.equals(id, student.id) && Objects.equals(name, student.name);
        }

        @Override
        public int hashCode() {
            return id.hashCode() + name.hashCode();
        }

        @Override
        public String toString() {
            return "Student{%s}".formatted(name);
        }

        public void printArray(Student[] array) {
            for(var student : array) {
                System.out.println(student);
            }
        }
    }
}
