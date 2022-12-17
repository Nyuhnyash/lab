package ru.samgtu.labs.lab5;

public class Task2 {
    public static void main(String[] args) {
        var airline = new Airline("Moscow", 123, Airline.FlightType.REGULAR, "12:00", "Monday");
        System.out.println(airline.getDestination());
        System.out.println(airline.getFlightNumber());
        System.out.println(airline.getFlightType());
        System.out.println(airline.getDepartureTime());
        System.out.println(airline.getDaysOfWeek());
    }
}
