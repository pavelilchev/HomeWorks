import { Component, OnInit } from '@angular/core';

import { CarsService } from '../services/cars.service'
import { Car } from '../models/Car';

@Component({
    selector: 'home',
    providers: [CarsService],
    templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {
    private cars: Array<Car>;

    constructor(private carsService: CarsService){  
    }

    ngOnInit(): void {
        this.carsService
        .getCars()
        .then(data => {
            this.cars = data;
        })
        .catch(err => console.log(err));
    }
}