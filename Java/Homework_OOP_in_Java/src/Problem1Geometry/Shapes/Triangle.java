package Problem1Geometry.Shapes;

public class Triangle extends PlaneShape {
    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3) {
        super(x1, y1);
        this.vertices[1] = new Vertex2D(x2, y2);
        this.vertices[2] = new Vertex2D(x3, y3);

        this.isValidTriangle();
    }

    @Override
    public double getArea() {
        double s = this.getPerimeter();
        double a = this.getDistanceAB();
        double b = this.getDistanceBC();
        double c = this.getDistanceAC();

        double area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getDistanceAB() + this.getDistanceBC() + this.getDistanceAC();

        return perimeter;
    }

    @Override
    public String toString() {
        return super.toString() +
                this.vertices[1].toString() +
                this.vertices[2].toString();
    }

    private void isValidTriangle() {
        boolean sideABtoC = (this.getDistanceAB() + this.getDistanceBC()) > this.getDistanceAC();
        boolean sideBCtoA = (this.getDistanceBC() + this.getDistanceAC()) > this.getDistanceAB();
        boolean sideACtoB = (this.getDistanceAC() + this.getDistanceAB()) > this.getDistanceBC();

        boolean isTriangle = sideABtoC && sideBCtoA && sideACtoB;

        if (!isTriangle) {
            throw new IllegalArgumentException("Cannot create a valid triangle with this data");
        }
    }

    public double getDistanceAB() {
        double distanceAB = Vertex.getDistanceBetweenPoints(this.vertices[0], this.vertices[1]);

        return distanceAB;
    }

    public double getDistanceBC() {
        double distanceBC = Vertex.getDistanceBetweenPoints(this.vertices[1], this.vertices[2]);

        return distanceBC;
    }

    public double getDistanceAC() {
        double distanceAC = Vertex.getDistanceBetweenPoints(this.vertices[2], this.vertices[0]);

        return distanceAC;
    }
}