package ru.samgtu.labs.lab5;

public class Airline {
    private String destination;
    private int flightNumber;
    private FlightType flightType;
    private String departureTime;
    private String daysOfWeek;

    enum FlightType {
        CHARTER,
        REGULAR
    }

    public Airline(String destination, int flightNumber, FlightType flightType, String departureTime, String daysOfWeek) {
        this.destination = destination;
        this.flightNumber = flightNumber;
        this.flightType = flightType;
        this.departureTime = departureTime;
        this.daysOfWeek = daysOfWeek;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public int getFlightNumber() {
        return flightNumber;
    }

    public void setFlightNumber(int flightNumber) {
        this.flightNumber = flightNumber;
    }

    public FlightType getFlightType() {
        return flightType;
    }

    public void setFlightType(FlightType flightType) {
        this.flightType = flightType;
    }

    public String getDepartureTime() {
        return departureTime;
    }

    public void setDepartureTime(String departureTime) {
        this.departureTime = departureTime;
    }

    public String getDaysOfWeek() {
        return daysOfWeek;
    }

    public void setDaysOfWeek(String daysOfWeek) {
        this.daysOfWeek = daysOfWeek;
    }

    @Override
    public String toString() {
        return "Airline{" +
                "destination='" + destination + '\'' +
                ", flightNumber=" + flightNumber +
                ", aircraftType='" + flightType + '\'' +
                ", departureTime='" + departureTime + '\'' +
                ", daysOfWeek='" + daysOfWeek + '\'' +
                '}';
    }
}
