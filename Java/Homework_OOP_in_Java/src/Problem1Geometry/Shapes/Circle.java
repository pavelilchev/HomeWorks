package Problem1Geometry.Shapes;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(double x, double y, double radius) {
        super(x, y);
        this.setRadius(radius);
    }

    @Override
    public double getArea() {
        return Math.PI * (this.radius * this.radius);
    }

    @Override
    public double getPerimeter() {
        return 2.0 * Math.PI * this.radius;
    }

    public double getRadius() {
        return this.radius;
    }

    public void setRadius(double radius) {
        if(radius < 0) {
            throw new IllegalArgumentException("radius cannot be negative");
        }

        this.radius = radius;
    }
}