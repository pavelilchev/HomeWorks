import java.util.Scanner;

public class PrintACharacterTriangle {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int triangleSize = scanner.nextInt();
        printTriangle(triangleSize);
    }

    static void printTriangle(int size) {

        for (int i = 1; i <= size; i++) {
            char ch = 'a';

            for (int j = 0; j < i; j++) {
                System.out.print(ch++ + " ");
            }

            System.out.println();
        }

        for (int i = size - 1; i >= 1; i--) {
            char ch = 'a';

            for (int j = i; j > 0; j--) {
                System.out.print(ch++ + " ");
            }

            System.out.println();
        }
    }
}
