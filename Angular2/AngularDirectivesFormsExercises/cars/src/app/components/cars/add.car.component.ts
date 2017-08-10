import { Component } from '@angular/core';

import { CarsService } from '../../services/cars.service';
import {Router} from '@angular/router';

import { Car } from '../../../models/Car';

@Component({
    selector: 'add-car',
    providers: [CarsService],
    templateUrl: './add.car.component.html',
})

export class AddCarComponent {
    car = new Car();

    constructor(private carsService: CarsService, private router: Router){}

    onSubmit() {
        this.carsService
        .addCar(this.car)
        .then(data => {
            this.router.navigate(['./cars/all']);
        })
        .catch(err => {
            console.log(err);
        })
    }
} 