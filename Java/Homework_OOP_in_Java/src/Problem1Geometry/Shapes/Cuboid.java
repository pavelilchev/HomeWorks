package Problem1Geometry.Shapes;

import java.util.ArrayList;

public class Cuboid extends SpaceShapes {

    private double x;
    private double y;
    private double z;
    private double width;
    private double height;
    private double depth;

    public Cuboid(double x, double y, double z, double width, double height, double depth) {
        super();
        this.x = x;
        this.y = y;
        this.z = z;
        this.width = width;
        this.height = height;
        this.depth = depth;
        initVertices();
    }

    private ArrayList<Point> initVertices() {
        this.verticles.add(new Point(this.x, this.y, this.z));
        this.verticles.add(new Point(this.x + this.width, this.y, this.z));
        this.verticles.add(new Point(this.x, this.y + this.height, this.z));
        this.verticles.add(new Point(this.x + this.width, this.y + this.height, this.z));
        this.verticles.add(new Point(this.x, this.y, this.z + this.depth));
        this.verticles.add(new Point(this.x + this.width, this.y, this.z + this.depth));
        this.verticles.add(new Point(this.x, this.y + this.height, this.z + this.depth));
        this.verticles.add(new Point(this.x + this.width, this.y + this.height, this.z + this.depth));

        return verticles;
    }

    @Override
    public double getArea() {
        return (this.width * this.depth +
                this.width * this.height +
                this.height * this.depth);
    }

    @Override
    public double getVolume() {
        return this.width * this.height * this.depth;
    }

    @Override
    public String toString() {
        return "Cuboid" + "\n"+
                "Vertices " + verticles.toString() + "\n"+
                "Volume: " + getVolume() +"\n"+
                "Area: " + getArea() ;
    }
}

