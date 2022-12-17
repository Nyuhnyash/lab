package ru.samgtu.labs.lab5;

public class Computer {
    private ComputerInfo computerInfo;

    public ComputerInfo getComputerInfo() {
        return computerInfo;
    }

    public void setComputerInfo(ComputerInfo computerInfo) {
        this.computerInfo = computerInfo;
    }

    public Computer(String os, String cpu, Integer ramAmount) {
        computerInfo = new ComputerInfo(os, cpu, ramAmount);
    }

    class ComputerInfo {
        private final String os;
        private final String cpu;
        private final Integer ramAmount;

        private ComputerInfo(String os, String cpu, Integer ramAmount) {
            this.os = os;
            this.cpu = cpu;
            this.ramAmount = ramAmount;
        }

        @Override
        public String toString() {
            return "ComputerInfo{" +
                    "os='" + os + '\'' +
                    ", cpu='" + cpu + '\'' +
                    ", ramAmount=" + ramAmount +
                    '}';
        }
    }
}
