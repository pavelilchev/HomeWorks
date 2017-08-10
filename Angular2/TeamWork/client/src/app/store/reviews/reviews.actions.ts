import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { IAppState } from '../'
import { ReviewsService } from '../../reviews/reviews.service';

export const LOAD_REVIEWS = 'load/REVIEWS';

@Injectable()
export class ReviewsActions {
    constructor(
        private reviewsService: ReviewsService,
        private ngRedux: NgRedux<IAppState>
    ) { }

    loadReviews() {
        this.reviewsService
            .getReviews()
            .subscribe(reviews => {
                this.ngRedux.dispatch({
                    type: LOAD_REVIEWS,
                    reviews
                })
            })
    }
}