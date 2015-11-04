package Problem1Geometry.Shapes;

public class Point {
    private double x;
    private double y;
    private double z;
   private boolean is3D;

    public Point(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z;
        this.is3D = true;
    }

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    @Override
    public String toString() {
        String result = String.format("Point{" + "x=" + x +  ", y=" + y );
        if (this.is3D) {
            result += String.format(", z=" + z + '}');
        } else {
            result += '}';
        }

        return result;
    }
}
