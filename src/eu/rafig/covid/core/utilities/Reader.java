package eu.rafig.covid.core.utilities;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Reader {

    public static String readLine(String message){
        System.out.println(message);
        return new Scanner(System.in).nextLine();
    }

    public static int readInt(String message){
        System.out.println(message);
        return new Scanner(System.in).nextInt();
    }

    public static ScannedInteger advancedIntScanner(String message) {
        return new ScannedInteger(readLine(message));
    }

    public static class ScannedInteger {
        private ScannedStatus status;
        private int value;

        public ScannedInteger(String value) {
            try {
                this.value = Integer.parseInt(value);
                this.status = ScannedStatus.SUCCESS;
            } catch (NumberFormatException e) {
                this.value = 0;
                this.status = ScannedStatus.ERROR;
            }
        }

        public ScannedStatus getStatus() {
            return status;
        }

        public int getValue() {
            return value;
        }
    }

    public enum ScannedStatus {
        SUCCESS, ERROR
    }
}
