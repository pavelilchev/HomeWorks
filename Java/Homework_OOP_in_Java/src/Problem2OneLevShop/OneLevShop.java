package Problem2OneLevShop;

import Problem2OneLevShop.Products.FoodProduct;

public class OneLevShop {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.Adult);
        Customer pecata = new Customer("Pecata", 17, 30.00);
        PurchaseManager.processPurchase(pecata, cigars);
        Customer gopeto = new Customer("Gopeto", 18, 0.44);
        PurchaseManager.processPurchase(gopeto, cigars);
    }
}
