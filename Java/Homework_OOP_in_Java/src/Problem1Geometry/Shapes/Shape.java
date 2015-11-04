package Problem1Geometry.Shapes;

public abstract class Shape {
    protected Vertex[] vertices;

    protected Shape() {
        this.vertices = new Vertex[1];
    }

    public Vertex[] getVertices() {
        return this.vertices;
    }

    @Override
    public String toString() {
        return this.vertices[0].toString();
    }

    protected String getClassName() {
        String fullClassName = this.getClass().toString();
        int indexOfLastDot = fullClassName.lastIndexOf('.');
        String className = fullClassName.substring(indexOfLastDot + 1, fullClassName.length());

        return className;
    }
}