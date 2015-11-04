import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class Problem_14_SortArrayWithStreamAPI {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] line = scanner.nextLine().split(" ");
        String order = scanner.nextLine();
        Integer[] arr = new Integer[line.length];

        for (int i = 0; i < line.length; i++) {
            arr[i] = Integer.parseInt(line[i]);
        }

        if (order.equals("Ascending")) {
            Arrays.sort(arr);
            System.out.println(Arrays.asList(arr));
        } else {
            Arrays.sort(arr, Collections.reverseOrder());
            System.out.println(Arrays.asList(arr));
        }
    }
}
