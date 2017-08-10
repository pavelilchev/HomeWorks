import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../../components/home.component';
import { CarsAllComponent } from '../../components/cars/cars.all.component';
import { CarComponent } from '../../components/cars/car.component';
import { CarDetailsComponent } from '../../components/cars/car.details.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cars/all', component: CarsAllComponent },
    { path: 'cars/:id', component: CarDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }