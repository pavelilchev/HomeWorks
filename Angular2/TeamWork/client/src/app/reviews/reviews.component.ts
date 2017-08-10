import { Component, OnInit } from '@angular/core';

import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store'
import { ReviewsActions } from '../store/reviews/reviews.actions';

import { Review } from './review';

@Component({
    selector: 'reviews',
    templateUrl: './reviews.component.html',
    styleUrls: ['./reviews.component.css']
})

export class ReviewsComponent implements OnInit {
    reviews: Array<Review>;

    constructor(
        private ngRedux: NgRedux<IAppState>,
        private reviewsActions: ReviewsActions) { }

    ngOnInit() {
        this.reviewsActions
            .loadReviews();

        this.ngRedux
            .select(state => state.reviews)
            .subscribe(state => this.reviews = state.reviews);
    }
}