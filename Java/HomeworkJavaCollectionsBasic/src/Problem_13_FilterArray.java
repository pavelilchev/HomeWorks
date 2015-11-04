import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class Problem_13_FilterArray {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] line = scanner.nextLine().split(" ");

        if (!Arrays.stream(line).anyMatch(x -> x.length() > 3)) {
            System.out.println("(empty)");
        } else {
            Arrays.stream(line).filter(x -> x.length() > 3).forEach(word -> System.out.print(word + " "));
        }
    }
}
