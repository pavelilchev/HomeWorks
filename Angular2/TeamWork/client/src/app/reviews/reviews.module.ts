import { NgModule, ApplicationRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReviewsService } from './reviews.service';
import { ReviewsActions } from '../store/reviews/reviews.actions';

import { ReviewsComponent } from './reviews.component';
import { ReviewComponent } from './review.component';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
      ReviewsComponent,
      ReviewComponent,
  ],
  providers: [
      ReviewsService,
      ReviewsActions
  ],
  exports: [
  ]
})
export class ReviewsModule { }
