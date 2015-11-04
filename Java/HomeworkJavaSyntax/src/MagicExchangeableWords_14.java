import java.util.HashMap;
import java.util.Scanner;

public class MagicExchangeableWords_14 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("\\s+");
        String firstWord = input[0];
        String secondWord = input[1];

        boolean areExchangeable = checkWordsAreExchangeable(firstWord, secondWord);

        System.out.println(areExchangeable);
    }

    private static boolean checkWordsAreExchangeable(String firstWord, String secondWord) {
        boolean areExchange = true;

        HashMap<Character, Character> dictionary = new HashMap<>();

        for (int i = 0; i < firstWord.length(); i++) {
            if (!dictionary.containsKey(firstWord.charAt(i))) {
                dictionary.put(firstWord.charAt(i), secondWord.charAt(i));
            } else {
                if (dictionary.get(firstWord.charAt(i)) != secondWord.charAt(i)){
                    areExchange = false;
                    break;
                }
            }
        }


        return areExchange;
    }
}
