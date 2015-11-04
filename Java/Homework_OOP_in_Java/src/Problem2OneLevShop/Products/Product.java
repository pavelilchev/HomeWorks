package Problem2OneLevShop.Products;

import Problem2OneLevShop.AgeRestriction;
import Problem2OneLevShop.Interfaces.Buyable;


public abstract class Product implements Buyable {
    private String name;
    private double price;
    private int quantity;
    AgeRestriction restriction;

    public Product(String name, double price, int quantity, AgeRestriction restriction) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.restriction = restriction;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public AgeRestriction getRestriction() {
        return restriction;
    }

    public void setRestriction(AgeRestriction restriction) {
        this.restriction = restriction;
    }
}
