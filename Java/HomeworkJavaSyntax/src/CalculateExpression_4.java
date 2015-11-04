import java.util.Scanner;

public class CalculateExpression_4 {
    public static void main(String[] args) {
        System.out.println("Enter 3 floating point numbers");
        Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        double rootOne = (a + b + c) / Math.sqrt(c);
        double expresionOne = ((a * a + b * b) / (a * a - b * b));
        double formulaOneResult = Math.pow(expresionOne, rootOne);

        double rootTwo = a - b;
        double expressionTwo = a * a + b * b - Math.pow(c, 3);
        double formulaTwoResult = Math.pow(expressionTwo, rootTwo);

        double numbersAverage = (a + b + c) / 3;
        double formulaAverage = (formulaOneResult + formulaTwoResult) / 2;
        double diffrence = Math.abs(numbersAverage - formulaAverage);

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f"
                , formulaOneResult, formulaTwoResult, diffrence);
    }
}
