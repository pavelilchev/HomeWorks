import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ExtractWords_10 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter string");
        String input = scanner.nextLine();

        Pattern pattern =  Pattern.compile("([a-zA-Z]{2,})");
        Matcher matcher = pattern.matcher(input);

        while (matcher.find()){
            System.out.printf("%s ", matcher.group());
        }
    }
}
