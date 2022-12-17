package ru.samgtu.labs.lab5;

import java.lang.management.ManagementFactory;

public class Task1 {
    public static void main(String[] args) {
        var os = System.getProperty("os.name");
        var cpu = System.getProperty("os.arch");

        var ramAmount = ((com.sun.management.OperatingSystemMXBean) ManagementFactory
                .getOperatingSystemMXBean())
                .getTotalMemorySize() / 1024 / 1024 / 1024;

        var computer = new Computer(os, cpu, (int) ramAmount);
        System.out.println(computer.getComputerInfo());
    }
}
