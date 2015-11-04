package Problem1Geometry.Shapes;

import java.awt.*;
import java.util.ArrayList;

public class Triangle extends PlaneShape {
    private int x1;
    private int y1;
    private int x2;
    private int y2;
    private int x3;
    private int y3;
    private double a;
    private double b;
    private double c;

    public Triangle(int x1, int y1, int x2, int y2, int x3, int y3) {
        super();
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
        initVertices();
        calculateSideLength();
    }

    private ArrayList<Point> initVertices() {
        verticles.add(new Point(x1, y1));
        verticles.add(new Point(x2, y2));
        verticles.add(new Point(x3, y3));
        return verticles;
    }

    private void calculateSideLength() {
        this.c = Math.sqrt(Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2));
        this.a = Math.sqrt(Math.pow((x2 - x3), 2) + Math.pow((y2 - y3), 2));
        this.b = Math.sqrt(Math.pow((x3 - x1), 2) + Math.pow((y3 - y1), 2));
    }

    @Override
    public double getArea() {
        double p = getPerimeter()/2;
        double area = Math.sqrt(p*(p-a)*(p-b)*(p-c));
        return area;
    }

    @Override
    public double getPerimeter() {
        return this.a + this.b + this.c;
    }

    @Override
    public String toString() {
        return "Triangle" + "\n"+
                "Vertices " + verticles.toString() + "\n"+
                "Perimeter: " + getPerimeter() +"\n"+
                "Area: " + getArea() ;
    }
}
