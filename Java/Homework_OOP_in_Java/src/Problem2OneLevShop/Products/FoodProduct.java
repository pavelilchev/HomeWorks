package Problem2OneLevShop.Products;

import Problem2OneLevShop.AgeRestriction;
import Problem2OneLevShop.Interfaces.Expirable;

import java.util.Date;

public class FoodProduct extends Product implements Expirable {

    private Date expirationDate;

    public FoodProduct(String name, double price, int quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction);

    }



    public void setExperationDate(Date experationDate) {
        this.expirationDate = experationDate;
    }

    @Override
    public Date getExpirationDate() {
        return expirationDate;
    }
}
