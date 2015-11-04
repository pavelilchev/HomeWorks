import java.util.Scanner;

public class ConvertFromBase7ToDecimal_6 {
    public static void main(String[] args) {
        System.out.println("Enter number in base-7");
        Scanner scanner = new Scanner(System.in);
        int sevenBaseNumber = scanner.nextInt();
        int position = 0;
        int decimalNumber = 0;

        while (true){
            int num = sevenBaseNumber % 10;
            sevenBaseNumber /= 10;
            decimalNumber += num * Math.pow(7, position);
            position++;

            if (sevenBaseNumber == 0) break;
        }

        System.out.println(decimalNumber);
    }
}
