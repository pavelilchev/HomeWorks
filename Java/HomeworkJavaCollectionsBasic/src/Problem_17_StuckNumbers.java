import java.util.Scanner;

public class Problem_17_StuckNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String[] numbers = scanner.nextLine().split(" ");
        boolean have = false;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    for (int l = 0; l < n; l++) {
                        if (i != j && i != k && i != l && j != k && j != l && k != l) {
                            String one = numbers[i] + numbers[j];
                            String two = numbers[k] + numbers[l];
                            if (one.equals(two)) {
                                System.out.printf("%s|%s==%s|%s\n", numbers[i], numbers[j], numbers[k], numbers[l]);
                                have = true;
                            }
                        }

                    }
                }
            }
        }

        if (!have) {
            System.out.println("No");
        }
    }
}
