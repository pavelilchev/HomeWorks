import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { RegisterComponent } from './register.component';

@NgModule({
  imports: [
    CommonModule,   
    FormsModule,
    HttpModule
  ],
  declarations: [
      RegisterComponent
  ],
  providers: [],
  exports: []
})
export class UsersModule { }
