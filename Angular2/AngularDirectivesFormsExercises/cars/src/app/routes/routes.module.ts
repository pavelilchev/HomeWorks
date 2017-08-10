import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../components/home/home.component';
import { CarsPageComponent } from '../components/cars/cars.page.component';
import { CarDetailsComponent } from '../components/cars/car.details.component';
import { AddCarComponent } from '../components/cars/add.car.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cars/all', component: CarsPageComponent },    
    { path: 'cars/add', component: AddCarComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }