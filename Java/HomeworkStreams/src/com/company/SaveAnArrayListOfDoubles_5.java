package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class SaveAnArrayListOfDoubles_5 {
    public static void main(String[] args) {
        List<Double> myList = new ArrayList<>();
        myList.add(5.5);
        myList.add(6.6);
        myList.add(7.7);

        try (ObjectOutputStream ous = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(new File("resources/doubles.list"))))) {
            ous.writeDouble(myList.get(0));
            ous.writeDouble(myList.get(1));
            ous.writeDouble(myList.get(2));
            ous.writeObject(myList);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (ObjectInputStream ois = new ObjectInputStream(new BufferedInputStream(new FileInputStream(new File("resources/doubles.list"))))) {
            System.out.println("First: " + ois.readDouble());
            System.out.println("Second: " + ois.readDouble());
            System.out.println("Third: " + ois.readDouble());
            System.out.println("List: " + ois.readObject());
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}