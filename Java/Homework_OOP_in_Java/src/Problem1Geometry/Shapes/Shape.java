package Problem1Geometry.Shapes;

import Problem1Geometry.Contracts.AreaMeasurable;
import java.util.ArrayList;

public abstract class Shape implements AreaMeasurable {

    public ArrayList<Point> verticles;

    public Shape() {
        this.verticles = new ArrayList<>();
    }

}
