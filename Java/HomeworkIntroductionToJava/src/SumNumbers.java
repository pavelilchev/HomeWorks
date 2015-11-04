import java.util.Scanner;

public class SumNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        long sum = sumNumbersFromOneToN(n);
        System.out.println(sum);
    }

    private static long sumNumbersFromOneToN(int n) {
        long sum = 0;

        for (int i = 1; i <= n; i++) {
            sum += i;
        }
        return sum;
    }
}
