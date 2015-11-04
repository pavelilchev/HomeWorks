import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem_11_MostFrequentWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] text = scanner.nextLine().split("[^a-zA-Z]+");
        TreeMap<String, Integer> wordCounter = new TreeMap<>();

        for (int i = 0; i < text.length; i++) {
            String current = text[i].toLowerCase();
            if (!wordCounter.containsKey(current)){
                wordCounter.put(current, 1);
            } else {
                int curentCount = wordCounter.get(current);
                wordCounter.put(current, curentCount + 1);
            }
        }
        int mostFrequenceCount = 0;
        for (Map.Entry<String, Integer> pair : wordCounter.entrySet()){
           if (pair.getValue()> mostFrequenceCount){
               mostFrequenceCount = pair.getValue();
           }
        }

        for (Map.Entry<String, Integer> pair : wordCounter.entrySet()){
            if (pair.getValue() == mostFrequenceCount) {
                System.out.printf("%s -> %d times\n", pair.getKey(), pair.getValue());
            }
        }
    }
}
