import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem_2_SequencesOfEqualStrings {
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

        for (Map.Entry<String, Integer> word : data.entrySet()){
            for (int i = 0; i < word.getValue(); i++) {
                System.out.print(word.getKey() + " ");
            }
            System.out.println();
        }
    }
}
