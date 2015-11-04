package Problem2OneLevShop;

import Problem2OneLevShop.Products.Product;

public class PurchaseManager {

    public static void processPurchase(Customer customer, Product product) {

       if (product.getRestriction().ordinal() == 2 && customer.getAge() < 18){
           System.out.println("You are too young to buy this product!");
           return;
       } else if (product.getRestriction().ordinal() == 1 && customer.getAge() >= 18){
           System.out.println("You are too old to buy this product!");
           return;
       }

        if (customer.getBalance() - product.getPrice() < 0){
            System.out.println("You do not have enough money to buy this product!");
            return;
        }
    }
}


