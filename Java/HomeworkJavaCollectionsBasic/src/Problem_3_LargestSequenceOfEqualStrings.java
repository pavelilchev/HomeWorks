import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem_3_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        LinkedHashMap<String, Integer> data = new LinkedHashMap<>();

        for (String word : input){
            if (!data.containsKey(word)){
                data.put(word, 1);
            } else {
                int currentCount = data.get(word);
                data.put(word, currentCount + 1);
            }
        }

        int maxCount = 0;
        String mostPopularWord = null;
        for (Map.Entry<String, Integer> word : data.entrySet()){
           if (word.getValue() > maxCount){
               maxCount = word.getValue();
               mostPopularWord = word.getKey();
           }
        }

        for (int i = 0; i < maxCount; i++) {
            System.out.print(mostPopularWord + " ");
        }
    }
}
