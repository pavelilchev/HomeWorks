import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CarsService } from '../../services/cars.service';

import { Car } from '../../../models/Car';

@Component({
    selector: 'cardetails',
    providers: [CarsService],
    templateUrl: './car.details.component.html'
})

export class CarDetailsComponent implements OnInit {
    private id: string;
    private car: Car;

    constructor(
        private route: ActivatedRoute,
        private carsService: CarsService) {
        this.id = this.route.snapshot.paramMap.get('id');
    }

    ngOnInit() {
        this.carsService
        .getById(this.id)
        .then(data => this.car = data)
        .catch(err => console.log(err));
    }
}