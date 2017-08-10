import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component'
import { FollowerComponent } from './home/followers/follower.component'
import { RepoComponent } from './home/repos/repo.component'
import { ContributorComponent } from './home/repos/contributor.component'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FollowerComponent,
    RepoComponent,
    ContributorComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
