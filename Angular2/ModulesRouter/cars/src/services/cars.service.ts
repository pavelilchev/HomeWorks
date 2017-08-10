import { Component, Injectable } from '@angular/core';
import { Data } from '../data/Data';

import { Car } from '../models/Car';

@Injectable()
export class CarsService {
    constructor() {
    }

    getCars() {
        return new Promise<Array<Car>>(resolve => {
            resolve(Data.getCars());
        })
    }
}