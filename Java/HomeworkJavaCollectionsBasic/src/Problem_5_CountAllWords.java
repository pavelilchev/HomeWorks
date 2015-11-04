import java.util.Scanner;

public class Problem_5_CountAllWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] words = scanner.nextLine().split("[^a-zA-Z]+");
        System.out.println(words.length);
    }
}
