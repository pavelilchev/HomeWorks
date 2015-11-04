package com.company;

import java.io.*;
import java.util.ArrayList;

public class CountCharacterTypes_3 {
    public static void main(String[] args) {
        int vowels = 0;
        int consonants = 0;
        int punctuation = 0;
        ArrayList<Character> vowelsArr = new ArrayList<>();
        vowelsArr.add('a');
        vowelsArr.add('e');
        vowelsArr.add('i');
        vowelsArr.add('o');
        vowelsArr.add('u');

        try (BufferedReader br = new BufferedReader(new FileReader(new File("resources/words.txt")))) {
            int i;
            while ((i = br.read()) != -1) {
                if (Character.isLetter((char) i) && vowelsArr.contains((char) i)) {
                    vowels++;
                } else if (Character.isLetter((char) i) && !vowelsArr.contains((char) i)) {
                    consonants++;
                } else if (!Character.isSpaceChar((char) i)) {
                    punctuation++;
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        System.out.println("Vowels" + ": " + vowels);
        System.out.println("Consonants" + ": " + consonants);
        System.out.println("Punctuation" + ": " + punctuation);
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(new File("resources/count-chars.txt")))) {
            bw.write("Vowels" + ": " + vowels);
            bw.newLine();
            bw.write("Consonants" + ": " + consonants);
            bw.newLine();
            bw.write("Punctuation" + ": " + punctuation);
            bw.newLine();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
