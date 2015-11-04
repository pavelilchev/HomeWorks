package Problem1Geometry.Shapes;

public class Vertex3D extends Vertex {
    private double z;

    public Vertex3D(double x, double y, double z) {
        super(x, y);
        this.z = z;
    }

    @Override
    public String toString() {
        return "[x = " + this.x + ", y = " + this.y + ", z = " + this.z + "]\n";
    }

    public double getZ() {
        return this.z;
    }

    public void setZ(double z) {
        this.z = z;
    }
}