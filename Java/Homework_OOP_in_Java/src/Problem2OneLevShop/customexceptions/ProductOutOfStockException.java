package Problem2OneLevShop.customexceptions;

public class ProductOutOfStockException extends ProductManagementException {
	public ProductOutOfStockException() {
		super("We`re sorry, this product is out of stock");
	}
}
