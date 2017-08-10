import { Car } from '../../../models/Car';
import { IAppState } from './application.state';

import { SEARCH_CARS, LOAD_CARS } from './cars.actions';

const cars = [];

const initialState: IAppState = {
    cars: cars,
    searchedCars: cars
}

export function reducer(state = initialState, action) {
    switch (action.type) {
        case LOAD_CARS:
            return loadCars(state, action);
        case SEARCH_CARS:
            return searchCars(state, action);
        default:
            return state;
    }
}

function loadCars(state, action): IAppState {
    return Object.assign({}, state, {
        cars: action.cars,
        searchedCars: action.cars
    })
}

function searchCars(state, action): IAppState {
    return Object.assign({}, state, {
        searchedCars: state.cars.filter(c => {
            return c.make.toLowerCase().indexOf(action.searchText.toLowerCase()) > -1
                || c.model.toLowerCase().indexOf(action.searchText.toLowerCase()) > -1;
        })
    })
}