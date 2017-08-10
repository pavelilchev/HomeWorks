import { Car } from '../../../models/Car';

export interface IAppState{
    cars: Car[],
    searchedCars: Car[]
}
