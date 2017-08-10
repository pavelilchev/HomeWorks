import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutesModule } from './routes/routes.module';
import { CarsModule } from './components/cars/cars.module';
import { NgReduxModule, NgRedux } from 'ng2-redux';
import { store } from './components/store/store';
import { IAppState } from './components/store/application.state';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavigationComponent } from './components/navigation/navigation.component';

import { CarsService } from './services/cars.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutesModule,
    CarsModule,
    FormsModule,
    NgReduxModule
  ],
  providers: [CarsService],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(ngRedux: NgRedux<IAppState>) {
    ngRedux.provideStore(store);
  }
}
