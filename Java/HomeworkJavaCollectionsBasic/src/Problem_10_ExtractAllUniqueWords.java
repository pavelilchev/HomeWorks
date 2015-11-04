import java.util.Scanner;
import java.util.TreeSet;

public class Problem_10_ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] text = scanner.nextLine().split("[^a-zA-Z]");
        TreeSet<String> words = new TreeSet<>();

        for (int i = 0; i < text.length; i++) {
            words.add(text[i].toLowerCase());
        }

        for (String word : words){
            System.out.print(word + " ");
        }
    }
}
