import java.util.Arrays;
import java.util.Scanner;

public class GetFirstOddOrEvenElements_13 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] numbersAsString = scanner.nextLine().split("\\s+");
        int[] numbers = Arrays.stream(numbersAsString).mapToInt(Integer::parseInt).toArray();
        String[] comandArgs = scanner.nextLine().split("\\s+");
        int neededElements = Integer.parseInt(comandArgs[1]);
        String oddOrEven = comandArgs[2];
        int count = 0;

        if (oddOrEven.equals("odd")) {
            for (int i = 0; i < numbers.length; i++) {
                if (numbers[i] % 2 != 0 && count < neededElements) {
                    System.out.printf("%d ", numbers[i]);
                    count++;
                }
            }

        } else {
            for (int i = 0; i < numbers.length; i++) {
                if (numbers[i] % 2 == 0 && count < neededElements) {
                    System.out.printf("%d ", numbers[i]);
                    count++;
                }
            }
        }
    }
}
