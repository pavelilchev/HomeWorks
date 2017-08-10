import { Car } from '../models/Car';

export class Data {
    private static cars: Array<Car> = [
        { 'id': 1, 'make': 'Audi', 'model': 'A8', 'image': 'http://o.aolcdn.com/commerce/autodata/images/USC50AUC041B021001.jpg' },
        { 'id': 2, 'make': 'Audi', 'model': 'A4', 'image': 'https://upload.wikimedia.org/wikipedia/commons/6/6e/Audi_A4_2.0_TFSI_quattro.jpg' },
        { 'id': 3, 'make': 'BMW', 'model': '645i', 'image': 'http://www.ezauto.lv/uploads/cars/3078_IMG_0209_original.jpg?1331244349' },
        { 'id': 4, 'make': 'BMW', 'model': 'M35', 'image': 'https://s-media-cache-ak0.pinimg.com/736x/6c/09/cb/6c09cb923b6852be4b4da71ac53fd58f--e-m-bmw-e.jpg' },
        { 'id': 5, 'make': 'Mercedes', 'model': 'CLK', 'image': 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c0/CLK_209_%28Cabriolet%29.jpg/1200px-CLK_209_%28Cabriolet%29.jpg' },
        { 'id': 6, 'make': 'Opel', 'model': 'Insignia', 'image': 'http://i2.offnews.bg/auto/galleries/13429/20161207_54229abfcfa5649e7003b83dd4755294_13432.jpg' }
    ];

    static getCars() {
        var result = [];
        for (let car of this.cars) {
            result.unshift(car);
        }
        
        return result;
    }

    static getById(id) {
        let car = new Car();
        for (let c of this.cars) {
            if (c.id == id) {
                car = c;
                break;
            }
        }

        return car;
    }

    static addCar(car: Car) {
        let id = this.cars.length + 1;
        car.id = id;
        this.cars.push(car);

        return 'Car is Added';
    }
}