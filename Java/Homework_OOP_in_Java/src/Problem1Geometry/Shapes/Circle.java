package Problem1Geometry.Shapes;

import java.awt.*;
import java.util.ArrayList;

public class Circle extends PlaneShape {

   private int x;
   private int y;
    private double radius;

    public Circle(int x, int y, double radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        initVertices();
    }

    private ArrayList<Point> initVertices() {
        verticles.add(new Point(this.x, this.y));
        return verticles;
    }

    @Override
    public double getArea() {
        return Math.PI*this.radius*this.radius;
    }

    @Override
    public double getPerimeter() {
        return 2*Math.PI*this.radius;
    }

    @Override
    public String toString() {
        return "Circle" + "\n"+
                "Vertex " + verticles.toString() + "\n"+
                "Perimeter: " + getPerimeter() +"\n"+
                "Area: " + getArea() ;
    }
}
