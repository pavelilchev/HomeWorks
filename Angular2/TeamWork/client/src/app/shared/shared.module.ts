import { NgModule, ApplicationRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { AgmCoreModule } from '@agm/core';
import { RoutesModule } from '../routes.module';

import { HttpService } from './http.service';

import { HomeComponent } from './home.component';
import { FooterComponent } from './footer.component';
import { NavigationComponent } from './navigation.component';

@NgModule({
  imports: [
    CommonModule,
    RoutesModule,
    HttpModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyClyU8DuKbc5qLkBwBe40rfgklUubIZav0'
    })
  ],
  declarations: [
    FooterComponent,
    NavigationComponent,
    HomeComponent
  ],
  providers: [
    HttpService
  ],
  exports: [
    FooterComponent,
    NavigationComponent
  ]
})
export class SharedModule { }
