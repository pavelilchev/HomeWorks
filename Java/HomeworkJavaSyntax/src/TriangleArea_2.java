import java.util.Scanner;

public class TriangleArea_2 {
    public static void main(String[] args) {
        System.out.println("Enter triangle's coordinate, every point on separated line");
        Scanner scanner = new Scanner(System.in);
        Point[] points = new Point[3];

        for (int i = 0; i < 3; i++) {
            String[] line = scanner.nextLine().split("\\s+");
            double x = Double.parseDouble(line[0]);
            double y =Double.parseDouble(line[1]);
            points[i] = new Point(x, y);
        }

        Point A = points[0];
        Point B = points[1];
        Point C = points[2];

        double area = Math.abs((A.getX() * (B.getY() - C.getY())
                + B.getX() * (C.getY() - A.getY())
                + C.getX() * (A.getY() - B.getY())) / 2);

        System.out.printf("Area of triangle: %.0f", area);
    }

    private static class Point {
        private double x;
        private double y;

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double getX() {
            return x;
        }

        public void setX(double x) {
            this.x = x;
        }

        public double getY() {
            return y;
        }

        public void setY(double y) {
            this.y = y;
        }
    }
}
