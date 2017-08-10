import { Component, OnInit } from '@angular/core';

import { Car } from '../../../models/Car';
import { CarsActions, IAppState } from '../store';
import { NgRedux, select } from 'ng2-redux';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'home',
    providers: [CarsActions],
    templateUrl: './home.component.html'
})


export class HomeComponent implements OnInit {
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
