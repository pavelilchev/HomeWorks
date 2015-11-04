package Problem2OneLevShop.Products;

import Problem2OneLevShop.AgeRestriction;

public abstract class ElectonicsProduct extends Product {

    public ElectonicsProduct(String name, double price, int quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction);
    }
}
