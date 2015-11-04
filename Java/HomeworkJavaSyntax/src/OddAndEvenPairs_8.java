import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class OddAndEvenPairs_8 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = new ArrayList<>();

        String[] line = scanner.nextLine().split("\\s+");

        for (int i = 0; i < line.length; i++) {
            numbers.add(Integer.parseInt(line[i]));
        }

        if (numbers.size() % 2 != 0) {
            System.out.println("Invalid length");
            return;
        }

        for (int i = 0; i < numbers.size(); i += 2) {
            boolean firstIsEven = numbers.get(i) % 2 == 0;
            boolean secondIsEven = numbers.get(i + 1) % 2 == 0;

            if (firstIsEven && secondIsEven) {
                System.out.printf("%d, %d -> both are even\n", numbers.get(i), numbers.get(i+1));
            } else if (!firstIsEven && !secondIsEven) {
                System.out.printf("%d, %d -> both are odd\n", numbers.get(i), numbers.get(i+1));
            } else {
                System.out.printf("%d, %d -> different\n", numbers.get(i), numbers.get(i+1));
            }

        }
    }
}
