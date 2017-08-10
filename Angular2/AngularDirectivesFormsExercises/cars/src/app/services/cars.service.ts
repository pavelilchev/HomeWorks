import { Component, Injectable } from '@angular/core';

import { Data } from '../../data/Data';
import { Car } from '../../models/Car';

@Injectable()
export class CarsService {
    getCars() {
        return new Promise<Array<Car>>(resolve => {
            resolve(Data.getCars());
        })
    }

    getById(id: string) {
        return new Promise<Car>((resolve, reject) => {
            resolve(Data.getById(id));
        })
    }

    addCar(car: Car) {
        return new Promise<string> ((resolve, reject) => {
            resolve(Data.addCar(car));
        })
    }
}