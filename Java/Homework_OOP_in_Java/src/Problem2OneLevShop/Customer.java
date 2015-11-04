package Problem2OneLevShop;

public class Customer {
    private String name;
    private int age;
    private double balance;

    public Customer(String name, int age, double balance) {
        this.name = name;
        this.age = age;
        this.balance = balance;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        if (this.name == null || this.name.equals("")){
            throw new IllegalArgumentException("Name can't be null or empty");
        }
        if (this.name.length() < 2){
            throw new IllegalArgumentException("Name must be more than 2 letters");
        }
        if (this.name.contains("\\d")){
            throw new IllegalArgumentException("Name cannot contains digit");
        }
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        if (this.age < 0){
            throw new IllegalArgumentException("Age must be positive");
        }
        this.age = age;
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        if (this.balance < 0){
            throw new IllegalArgumentException("Balance must be positive");
        }
        this.balance = balance;
    }
}
