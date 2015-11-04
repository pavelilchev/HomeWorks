package Problem1Geometry.Shapes;
public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(double x, double y, double z,
                  double width, double height, double depth) {
        super(x, y, z);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
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

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        if (width < 0) {
            throw new IllegalArgumentException("width cannot be negative");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (height < 0) {
            throw new IllegalArgumentException("height cannot be negative");
        }

        this.height = height;
    }

    public double getDepth() {
        return this.depth;
    }

    public void setDepth(double depth) {
        if (depth < 0) {
            throw new IllegalArgumentException("depth cannot be negative");
        }

        this.depth = depth;
    }
}
