package Problem2OneLevShop.Products;

import Problem2OneLevShop.AgeRestriction;

public class Appliance extends ElectonicsProduct{
    public Appliance(String name, double price, int quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction);
    }
}
