import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgReduxModule, NgRedux } from 'ng2-redux';
import { IAppState, store } from './store'

import { SharedModule } from './shared/shared.module';
import { ReviewsModule } from './reviews/reviews.module';
import { RoutesModule } from './routes.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    NgReduxModule,
    RoutesModule,
    SharedModule,
    ReviewsModule,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(private ngRedux: NgRedux<IAppState>){
    this.ngRedux.provideStore(store);
  }
}
