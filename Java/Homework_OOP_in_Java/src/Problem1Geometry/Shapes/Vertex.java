package Problem1Geometry.Shapes;

public abstract class Vertex {
    protected double x;
    protected double y;

    protected Vertex(double x, double y) {
        this.x = x;
        this.y = y;
    }

    @Override
    public String toString() {
        return "[x = " + this.x + ", y = " + this.y + "]\n";
    }

    public static double getDistanceBetweenPoints(Vertex... vertices) {
        double accumulatePointSum = 0;

        for (int i = 1; i < vertices.length; i++) {
            double differenceBetweenTwoPoints =
                    Math.pow(vertices[i].getX() - vertices[i-1].getX() , 2) +
                            Math.pow(vertices[i].getY() - vertices[i-1].getY() , 2);

            accumulatePointSum += differenceBetweenTwoPoints;
        }

        double distance = Math.sqrt(accumulatePointSum);

        return distance;
    }

    public double getX() {
        return this.x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return this.y;
    }

    public void setY(double y) {
        this.y = y;
    }
}