import java.util.Scanner;

public class ConvertFromDecimalToBase7_5 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter decimal number");
        int decimal = scanner.nextInt();
        StringBuilder sb = new StringBuilder();

        while (true){
            sb.append(decimal % 7);
            decimal /= 7;

            if (decimal == 0) break;
        }

        System.out.println(sb.reverse());
    }
}
