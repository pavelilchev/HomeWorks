import java.util.Arrays;
import java.util.Scanner;

public class Problem_15_ImplementRecursiveBinarySearch {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int element = Integer.parseInt(scanner.nextLine());
        String[] input = scanner.nextLine().split(" ");
        int[] sortedSequence = Arrays.stream(input).mapToInt(Integer::parseInt).toArray();

        int indexOfElementInSequence = binarySearch(sortedSequence, element, 0, sortedSequence.length - 1);

        System.out.println(indexOfElementInSequence);
    }

    private static int binarySearch(int[] arr, int element, int low, int high) {
        if (low > high) return -1;
        int mid = (low + high) / 2;
        if (arr[mid] == element) {
            return mid;
        } else if (arr[mid] < element) {
            return binarySearch(arr, element, mid + 1, high);
        } else {
            return binarySearch(arr, element, low, mid - 1);
        }
    }
}
