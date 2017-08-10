import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppRoutesModule } from '../../routes/routes.module';


import { CarsPageComponent } from './cars.page.component';
import { CarComponent } from './car.component';
import { CarDetailsComponent } from './car.details.component';
import { AddCarComponent } from './add.car.component';

@NgModule({
    imports: [
        CommonModule,
        AppRoutesModule,
        FormsModule
    ],
    declarations: [
        CarsPageComponent,
        CarComponent,
        CarDetailsComponent,
        AddCarComponent
    ],
    exports: [
        CarComponent,
    ]
})

export class CarsModule { }