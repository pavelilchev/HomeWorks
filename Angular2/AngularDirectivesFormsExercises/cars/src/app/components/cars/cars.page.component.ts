import { Component, OnInit } from '@angular/core';

import { Car } from '../../../models/Car';
import { CarsActions, IAppState } from '../store';
import { NgRedux, select } from 'ng2-redux';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'cars',
    providers: [CarsActions],
    templateUrl: './cars.page.component.html'
})


export class CarsPageComponent implements OnInit {
    search: string = '';

    @select('searchedCars') cars: Observable<Car>;

    constructor(
        private ngRedux: NgRedux<IAppState>,
        private carsActions: CarsActions) { }

    handleSearch() {
        this.carsActions.searchCars(this.search);
    }

    ngOnInit() {
        this.carsActions.getCourses();
    }
}
