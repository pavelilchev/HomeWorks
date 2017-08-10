import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutesModule } from '../shared/routes.module';

import { CarComponent } from '../../components/cars/car.component';
import { CarsAllComponent } from '../../components/cars/cars.all.component';
import { CarDetailsComponent } from '../../components/cars/car.details.component';

@NgModule({
    imports: [
        CommonModule,
        AppRoutesModule
    ],
    declarations: [
        CarComponent,
        CarsAllComponent,
        CarDetailsComponent
    ],
    exports: [
        CarComponent,
        CarsAllComponent,
        CarDetailsComponent
    ]
})

export class CarModule { }