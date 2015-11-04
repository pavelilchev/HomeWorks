package com.company;

import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class CreateZipArhive_7 {
    public static void main(String[] args) {
        String zipFile = "resources/text-files.zip";
        String[] srcFiles = {"resources/words.txt", "resources/lines.txt", "resources/count-chars.txt"};

        try (ZipOutputStream zos = new ZipOutputStream(new FileOutputStream(zipFile))) {
            byte[] buffer = new byte[4096];

            for (int i = 0; i < srcFiles.length; i++) {
                File srcFile = new File(srcFiles[i]);

                try (FileInputStream fis = new FileInputStream(srcFile)) {
                    zos.putNextEntry(new ZipEntry(srcFile.getName()));
                    int length;
                    while ((length = fis.read(buffer)) > 0) {
                        zos.write(buffer, 0, length);
                        zos.closeEntry();
                    }
                }


            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}