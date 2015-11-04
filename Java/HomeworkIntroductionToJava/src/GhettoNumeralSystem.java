import java.util.Queue;
import java.util.Scanner;
import java.util.*;

public class GhettoNumeralSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long number = scanner.nextLong();
        String ghettoNumber = convertToGhetto(number);
        System.out.println(ghettoNumber);
    }

    private static String convertToGhetto(long number) {

        Stack<String> ghettoNumber = new Stack<>();

        while (true) {
            int next = (int)(number % 10);
            number /= 10;

            switch (next) {
                case 0:
                    ghettoNumber.push("Gee");
                    break;
                case 1:
                    ghettoNumber.push("Bro");
                    break;
                case 2:
                    ghettoNumber.push("Zuz");
                    break;
                case 3:
                    ghettoNumber.push("Ma");
                    break;
                case 4:
                    ghettoNumber.push("Duh");
                    break;
                case 5:
                    ghettoNumber.push("Yo");
                    break;
                case 6:
                    ghettoNumber.push("Dis");
                    break;
                case 7:
                    ghettoNumber.push("Hood");
                    break;
                case 8:
                    ghettoNumber.push("Jam");
                    break;
                case 9:
                    ghettoNumber.push("Mack");
                    break;
            }

            if (number == 0) break;
        }

        StringBuilder sb = new StringBuilder();

       while (!ghettoNumber.isEmpty()) {
           sb.append(ghettoNumber.pop());
       }

        return sb.toString();
    }
}

