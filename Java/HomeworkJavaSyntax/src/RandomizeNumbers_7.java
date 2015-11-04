import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class RandomizeNumbers_7 {
    public static void main(String[] args) {
        System.out.println("Enter 2 integers");
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int m = scanner.nextInt();
        int lenth = Math.abs(n - m) + 1;

        int start = Math.min(n, m);
        int end = Math.max(n, m);
        List<Integer> numbers = new ArrayList<>();
        Random random = new Random();

        for (int i = start; i <= end; i++) {
            int position = random.nextInt(numbers.size() + 1);
            numbers.add(position, i);
        }

        System.out.println(numbers);
    }
}
