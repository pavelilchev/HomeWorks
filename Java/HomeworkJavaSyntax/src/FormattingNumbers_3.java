import java.util.Scanner;

public class FormattingNumbers_3 {
    public static void main(String[] args) {
        System.out.println("Enter 3 numbers in single line");
        Scanner scanner = new Scanner(System.in);
        int a = scanner.nextInt();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        String aBinary = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');

        System.out.printf("|%-10S|%10s|%10.2f|%-10.3f|", Integer.toHexString(a), aBinary, b, c);

    }
}
