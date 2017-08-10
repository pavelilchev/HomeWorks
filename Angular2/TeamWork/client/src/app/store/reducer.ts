import { combineReducers } from 'redux';

import { IAppState } from './application.state';

import { reviewsReducer } from './reviews/reviews.reducer';

export const reducer = combineReducers<IAppState>({
    reviews: reviewsReducer
})