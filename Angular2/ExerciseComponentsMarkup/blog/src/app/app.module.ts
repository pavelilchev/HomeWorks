import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { Home }  from './components/main/home.component';
import { Sidebar } from './components/sidebar/sidebar.component'

@NgModule({
  declarations: [
    AppComponent,
    Home,
    Sidebar
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
