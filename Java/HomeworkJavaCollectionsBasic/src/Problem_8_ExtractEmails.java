import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem_8_ExtractEmails {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        Pattern pattern = Pattern.compile("\\b([a-zA-Z0-0][-\\w.]+[a-zA-Z0-0]@[a-zA-Z0-0][-\\w.]+[a-zA-Z0-0])\\b");
        Matcher matcher = pattern.matcher(input);

        while (matcher.find()){
            System.out.println(matcher.group(1));
        }
    }
}
