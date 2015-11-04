package com.company;

import java.io.*;

public class SaveCustomObject_6 {
    public static void main(String[] args) {
        Course course = new Course("Java", 400);

        try (ObjectOutputStream oos =
                     new ObjectOutputStream(new BufferedOutputStream(
                             new FileOutputStream(new File("resources/course.save"))))) {
            oos.writeObject(course);

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (ObjectInputStream ois = new ObjectInputStream(new FileInputStream("resources/course.save"))) {
            Course read = (Course) ois.readObject();
            System.out.println(read);

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }


    }

    private static class Course implements Serializable {
        private String name;
        private int studentsCount;

        public Course(String name, int studentsCount) {
            this.name = name;
            this.studentsCount = studentsCount;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public int getStudentsCount() {
            return studentsCount;
        }

        public void setStudentsCount(int studentsCount) {
            this.studentsCount = studentsCount;
        }

        @Override
        public String toString() {
            return "Course{" +
                    "name='" + name + '\'' +
                    ", studentsCount=" + studentsCount +
                    '}';
        }
    }
}
