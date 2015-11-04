import java.util.Scanner;

public class Problem_6_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] words = scanner.nextLine().split("[^a-zA-Z]+");
        String wantedWord = scanner.nextLine();
        int count = 0;
        for (int i = 0; i < words.length; i++) {
            if (words[i].equalsIgnoreCase(wantedWord)){
                count++;
            }
        }
        System.out.println(count);
    }
}

