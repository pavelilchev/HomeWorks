package com.company;

import java.io.*;

public class CopyJpgFile_4 {
    public static void main(String[] args) {
        try (FileInputStream fis = new FileInputStream("resources/picture.jpg");
       FileOutputStream fos = new FileOutputStream("resources/my-copied-picture.jpg")){
            byte[] buffer = new byte[4096];
            int i;
            while ((i = fis.read(buffer)) != -1) {
                fos.write(buffer);
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
