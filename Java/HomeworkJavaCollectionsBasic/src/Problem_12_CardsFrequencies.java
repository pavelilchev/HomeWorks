import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem_12_CardsFrequencies {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int count = input.length;
        LinkedHashMap<String, Integer> cards = new LinkedHashMap<>();

        for (int i = 0; i < count; i++) {
            String key = input[i].substring(0, input[i].length() - 1);
            if (!cards.containsKey(key)){
                cards.put(key, 1);
            } else {
                int currentCount = cards.get(key);
                cards.put(key, 1 + currentCount);
            }
        }

        for (Map.Entry<String, Integer> card : cards.entrySet()){
            double percentage = card.getValue()/(double)count*100.00;
            System.out.printf("%s -> %.2f%%\n", card.getKey(), percentage);
        }
    }
}
