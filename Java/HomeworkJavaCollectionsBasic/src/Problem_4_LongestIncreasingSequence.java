import java.util.Arrays;
import java.util.Scanner;

public class Problem_4_LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");

        int[] numbers = Arrays.stream(input).mapToInt(Integer::parseInt).toArray();

        int maxCount = 0;
        int startIndexOfLongestSequence = 0;
        int currentCount = 1;
        System.out.print(numbers[0] + " ");
        for (int i = 1; i < numbers.length; i++) {
            if (numbers[i] > numbers[i - 1]) {
                currentCount++;
                System.out.print(numbers[i] + " ");
            } else {
                System.out.println();
                System.out.print(numbers[i]+ " ");
                if (currentCount > maxCount){
                    maxCount = currentCount;
                    startIndexOfLongestSequence = i - maxCount;
                }
                currentCount = 1;

            }
            if (i == numbers.length - 1 && currentCount > maxCount){
                if (currentCount > maxCount){
                    maxCount = currentCount;
                    startIndexOfLongestSequence = i - maxCount + 1;
                }
            }
        }
        System.out.println();
        System.out.printf("Longest: ");
        for (int i = startIndexOfLongestSequence; i < startIndexOfLongestSequence + maxCount; i++) {
            System.out.print(numbers[i] + " ");
        }
    }
}
