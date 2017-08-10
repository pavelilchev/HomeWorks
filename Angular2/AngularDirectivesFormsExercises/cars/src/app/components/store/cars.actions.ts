import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';
import { Injectable } from '@angular/core';
import { CarsService } from '../../services/cars.service';

export const SEARCH_CARS = 'cars/SEARCH';
export const LOAD_CARS = 'cars/LOAD';

@Injectable()
export class CarsActions {
    constructor(
        private ngRedux: NgRedux<IAppState>,
        private carsService: CarsService) { }

    searchCars(searchText: string) {
        this.ngRedux.dispatch({
            type: SEARCH_CARS,
            searchText
        });
    }

    getCourses() {
        this.carsService
            .getCars()
            .then(cars => {
                this.ngRedux.dispatch({
                    type: LOAD_CARS,
                    cars
                })
            })
    }
}