package Problem1Geometry;

import Problem1Geometry.Contracts.PerimeterMeasurable;
import Problem1Geometry.Contracts.VolumeMeasurable;
import Problem1Geometry.Shapes.*;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Geometry {
    public static void main(String[] args) {
        Rectangle rectangle = new Rectangle(1, 1, 5, 4);
        //System.out.println(rectangle);
        Triangle triangle = new Triangle(1,1,2,2,1,2);
        //System.out.println(triangle);
        Circle circle = new Circle(0,0, 3);
       // System.out.println(circle);
        Sphere sphere = new Sphere(1, 1, 2, 3);
       // System.out.println(sphere);
        Cuboid cuboid = new Cuboid(0,0,0,2,3,4);
       // System.out.println(cuboid);
        SquarePyramid squarePyramid = new SquarePyramid(0,0,0,2,3,4);
       // System.out.println(squarePyramid);

        Shape[] shapeCollection = new Shape[6];
        shapeCollection[0] = triangle;
        shapeCollection[1] = circle;
        shapeCollection[2] = rectangle;
        shapeCollection[3] = squarePyramid;
        shapeCollection[4] = cuboid;
        shapeCollection[5] = sphere;

        for (Shape shape : shapeCollection) {
            //System.out.println(shape);
        }

        List<Shape> largeVolumeShapes = Arrays.asList(shapeCollection)
                .stream()
                .filter(s -> s instanceof VolumeMeasurable)
                .filter(v -> ((VolumeMeasurable) v)
                        .getVolume() > 40)
                .collect(Collectors.toList());

        for (Shape shape : largeVolumeShapes) {
            //System.out.println(shape);
        }

        Comparator<Shape> byPerimeter = (s1, s2) -> {
            PerimeterMeasurable Shape1 = (PerimeterMeasurable) s1;
            PerimeterMeasurable Shape2 = (PerimeterMeasurable) s2;
            double perimeterShape1 = Shape1.getPerimeter();
            double perimeterShape2 = Shape2.getPerimeter();

            return perimeterShape1 < perimeterShape2 ? -1 :
                    perimeterShape1 > perimeterShape2 ? 1 : 0;
        };

        List<Shape> planeShapesByPerimeter = Arrays.asList(shapeCollection)
                .stream()
                .filter(p -> p instanceof PlaneShape)
                .sorted(byPerimeter)
                .collect(Collectors.toList());

        for (Shape shape : planeShapesByPerimeter) {
            System.out.println(shape);
        }
    }
}
