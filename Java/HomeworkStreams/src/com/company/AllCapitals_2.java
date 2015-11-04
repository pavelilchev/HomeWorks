package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.List;


public class AllCapitals_2 {
    public static void main(String[] args) {
        List<String> data = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader(new File("resources/lines1.txt")))) {

            while (true) {
                String line = br.readLine();
                if (line == null) break;
                data.add(line);
            }

            try ( PrintWriter pw = new PrintWriter(new FileWriter(new File("resources/lines1.txt")))) {

                for (String row : data) {
                    pw.println(row.toUpperCase());
                }
            }
        } catch (FileNotFoundException e) {
            System.out.println("File not found!");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
