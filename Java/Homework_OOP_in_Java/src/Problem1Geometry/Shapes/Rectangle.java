package Problem1Geometry.Shapes;

import java.awt.*;
import java.util.ArrayList;

public class Rectangle extends PlaneShape {

    private int x;
    private int y;
    private int width;
    private int height;

    public Rectangle(int x, int y, int width, int height) {
        super();
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        initVertices();
    }

    private ArrayList<Point> initVertices() {
        this.verticles.add(new Point(this.x, this.y));
        this.verticles.add(new Point(this.x + this.width, this.y));
        this.verticles.add(new Point(this.x, this.y + this.height));
        this.verticles.add(new Point(this.x + this.width, this.y + this.height));
        return verticles;
    }

    @Override
    public double getArea() {
        return this.width * this.height;
    }

    @Override
    public double getPerimeter() {
        return 2 * this.width + 2 * this.height;
    }

    @Override
    public String toString() {
        return "Rectangle" + "\n"+
                "Vertices " + verticles.toString() + "\n"+
                 "Perimeter: " + getPerimeter() +"\n"+
                "Area: " + getArea() ;
    }
}
