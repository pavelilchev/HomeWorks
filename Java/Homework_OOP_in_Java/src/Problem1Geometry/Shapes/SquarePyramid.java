package Problem1Geometry.Shapes;

import java.util.ArrayList;

public class SquarePyramid extends SpaceShapes {

    private double x;
    private double y;
    private double z;
    private double width;
    private double height;
    private double slantHeight;

    public SquarePyramid(double x, double y, double z, double width, double height, double slantHeight) {
        super();
        this.x = x;
        this.y = y;
        this.z = z;
        this.width = width;
        this.height = height;
        this.slantHeight = slantHeight;
        initVertices();
    }

    private ArrayList<Point> initVertices() {
        this.verticles.add(new Point(this.x, this.y, this.z));

        return verticles;
    }

    @Override
    public double getArea() {
        double faceArea = (1.0 / 2.0) * (4 * this.width) * this.height;
        double baseArea = this.getBaseArea();

        return faceArea + baseArea;
    }

    @Override
    public double getVolume() {
        return (1.0 / 3.0) * this.getBaseArea() * this.height;
    }

    private double getBaseArea() {
        return this.width * this.width;
    }

    public String toString() {
        return "SquarePyramid" + "\n"+
                "Vertices " + verticles.toString() + "\n"+
                "Volume: " + getVolume() +"\n"+
                "Area: " + getArea() ;
    }
}