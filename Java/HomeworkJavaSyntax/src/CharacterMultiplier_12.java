import java.util.Scanner;

public class CharacterMultiplier_12 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter 2 strings");
        String[] input = scanner.nextLine().split("\\s+");
        long pseudoHashCode = calculatePseudoHashCode(input[0], input[1]);

        System.out.println(pseudoHashCode);
    }

    private static long calculatePseudoHashCode(String first, String second) {
        long sum = 0L;
        int lengthFirst = first.length();
        int lengthSecond = second.length();
        int iterations = Math.max(lengthFirst, lengthSecond);
        int shortes = Math.min(lengthFirst, lengthSecond);
        String longest;

        if (lengthFirst > lengthSecond) {
            longest = first;
        } else {
            longest = second;
        }

        for (int i = 0; i < iterations; i++) {
            if (i < shortes) {
                sum += first.charAt(i) * second.charAt(i);
            } else {
                sum += longest.charAt(i);
            }
        }

        return sum;
    }
}
