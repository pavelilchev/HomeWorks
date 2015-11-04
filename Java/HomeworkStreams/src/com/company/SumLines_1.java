package com.company;

import java.io.*;

public class SumLines_1 {

    public static void main(String[] args) {
        try (BufferedReader bf =
                     new BufferedReader(new FileReader(new File("resources/lines.txt")))) {

            while (true) {
                String line = bf.readLine();

                if (line == null) break;
                int sum = 0;
                for (int i = 0; i < line.length(); i++) {
                    sum += line.charAt(i);
                }
                System.out.println(sum);
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found!");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
