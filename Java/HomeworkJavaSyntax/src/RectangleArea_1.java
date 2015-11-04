import java.util.Scanner;

public class RectangleArea_1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter sides of a rectangle separated whit space");

        String[] line = scanner.nextLine().split("\\s+");

        double a = Double.parseDouble(line[0]);
        double b = Double.parseDouble(line[1]);

        double area = calculateRehtangleArea(a, b);
        System.out.printf("Rechtangle area: %.2f", area);
    }

    private static double calculateRehtangleArea(double a, double b) {
        return a * b;
    }
}
