import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Problem_9_CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        ArrayList<Character> first = new ArrayList<>();
        for (int i = 0; i < input.length(); i++) {
            if (input.charAt(i) != ' ') {
                first.add(input.charAt(i));
            }
        }

        input = scanner.nextLine();
        ArrayList<Character> second = new ArrayList<>();
        for (int i = 0; i < input.length(); i++) {
            if (input.charAt(i) != ' ') {
                second.add(input.charAt(i));
            }
        }
        ArrayList<Character> result = new ArrayList<>(first);


        for (int i = 0; i < second.size(); i++) {
            if (!first.contains(second.get(i))) {
                result.add(second.get(i));
            }
        }

        for (int i = 0; i < result.size(); i++) {
            System.out.print(result.get(i) + " ");
        }
    }
}
