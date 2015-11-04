import java.util.Scanner;

public class Problem_18_SumCards {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] line = scanner.nextLine().split("([SDHC\\s]+)");
        int[] numbers = new int[line.length];

        for (int i = 0; i < line.length; i++) {
            if (line[i].equals("J")) {
                numbers[i] = 12;
            } else if (line[i].equals("Q")) {
                numbers[i] = 13;
            } else if (line[i].equals("K")) {
                numbers[i] = 14;
            } else if (line[i].equals("A")) {
                numbers[i] = 15;
            } else {
                numbers[i] = Integer.parseInt(line[i]);
            }
        }
        int sum = 0;
        int groupSum = 0;
        boolean haveGroup = false;
        for (int i = 0; i < numbers.length; i++) {
            if (i < numbers.length - 1 && numbers[i] == numbers[i + 1]) {
                haveGroup = true;
            }
            if (i == numbers.length - 1 && i > 0 && numbers[i] == numbers[i - 1]) {
                haveGroup = true;
            }
            if (haveGroup) {
                groupSum += numbers[i];
            } else if (!haveGroup && i > 0 && numbers[i] == numbers[i - 1]) {
                groupSum += numbers[i];
            } else {
                sum += numbers[i];
            }

            if (!haveGroup && groupSum != 0) {
                sum += groupSum * 2;
                groupSum = 0;
            }
            haveGroup = false;
        }

        if (groupSum != 0) {
            sum += groupSum * 2;
        }

        System.out.println(sum);
    }
}

