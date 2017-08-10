import { Component, OnInit } from '@angular/core';
import { CarsService } from '../../services/cars.service'
import { Car } from '../../models/Car';

@Component({
    selector: 'cars',
     providers: [CarsService],
    templateUrl: './cars.all.component.html'
})

export class CarsAllComponent {
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
