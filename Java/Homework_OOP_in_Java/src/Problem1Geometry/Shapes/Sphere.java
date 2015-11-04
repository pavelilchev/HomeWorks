package Problem1Geometry.Shapes;

import java.util.ArrayList;

public class Sphere extends SpaceShapes {
private double vortexX;
private double vortexY;
private double vortexZ;
    private double radius;

    public Sphere(int vortexX, int vortexY, int vortexZ, double radius) {
        super();
        this.vortexX = vortexX;
        this.vortexY = vortexY;
        this.vortexZ = vortexZ;
        this.radius = radius;
        initVertices();
    }

    private ArrayList<Point> initVertices() {
        verticles.add(new Point(vortexX, vortexY, vortexZ));
        return verticles;
    }

    @Override
    public double getArea() {
        return 4*Math.PI*radius*radius;
    }

    @Override
    public double getVolume() {
        return 4/3*Math.PI*radius*radius*radius;
    }

    @Override
    public String toString() {
        return "Sphere" + "\n"+
                "Vertices " + verticles.toString() + "\n"+
                "Volume: " + getVolume() +"\n"+
                "Area: " + getArea() ;
    }
}
