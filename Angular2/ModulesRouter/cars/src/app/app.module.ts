import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutesModule } from '../modules/shared/routes.module';
import { CarModule } from '../modules/core/cars.module';

import { HomeComponent } from '../components/home.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutesModule,
    CarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
