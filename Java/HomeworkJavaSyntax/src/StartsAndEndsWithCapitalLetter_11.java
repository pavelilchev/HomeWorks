import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class StartsAndEndsWithCapitalLetter_11 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        Pattern pattern = Pattern.compile("\\b([A-Z][A-Za-z]*[A-Z])\\b");
        Matcher matcher = pattern.matcher(input);
        while (matcher.find()){
            System.out.printf("%s ", matcher.group());
        }
    }
}
