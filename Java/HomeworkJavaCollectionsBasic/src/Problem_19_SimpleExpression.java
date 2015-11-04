import java.math.BigDecimal;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem_19_SimpleExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        BigDecimal sum = BigDecimal.ZERO;
        boolean isDigit = true;
        BigDecimal next = new BigDecimal("0");
        Pattern digitPattern = Pattern.compile("([\\d.]+)");
        Pattern signPattern = Pattern.compile("([+-])");
        Matcher digitMatcher = digitPattern.matcher(input);
        Matcher signMatcher = signPattern.matcher(input);
        String sign = "add";

        while (digitMatcher.find()){

            if (sign.equals("add")){
                next = new BigDecimal(digitMatcher.group(1));
                sum = sum.add(next);
            } else {
                next = new BigDecimal(digitMatcher.group(1));
                sum = sum.subtract(next);
            }
            if (signMatcher.find()){
                if (signMatcher.group().equals("+")){
                    sign = "add";
                } else {
                    sign = "substract";
                }
            }

        }

        System.out.println(sum);
    }
}
