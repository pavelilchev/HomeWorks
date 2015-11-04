import java.util.Scanner;

public class GetAverage {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter 3 number");
        float first = scanner.nextFloat();
        float second = scanner.nextFloat();
        float third = scanner.nextFloat();
        float average = calculateAverage(first, second, third);
        System.out.printf("Average is %f", average);
    }

    private  static float calculateAverage(float f, float s, float t) {
        return (f + s + t)/3.0f;
    }
}
