import java.util.Scanner;

public class Problem_7_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().toLowerCase();
        String wantedSubstring = scanner.nextLine().toLowerCase();

        int indexOfOccurrence = input.indexOf(wantedSubstring);
        int count = 0;

        while (indexOfOccurrence >= 0){
            count++;
            indexOfOccurrence = input.indexOf(wantedSubstring, indexOfOccurrence + 1);
        }

        System.out.println(count);
    }
}
