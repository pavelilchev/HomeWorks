import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './shared/home.component';
import { ReviewsComponent } from './reviews/reviews.component';
 
const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'reviews/all', component: ReviewsComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class RoutesModule { }