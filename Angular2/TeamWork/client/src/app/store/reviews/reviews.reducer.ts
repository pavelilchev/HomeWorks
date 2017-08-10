import { initialState } from './reviews.state';
import { LOAD_REVIEWS } from './reviews.actions';

function loadReviews(state, action) {
    return Object.assign({}, state, {
        reviews: action.reviews
    })
}

export function reviewsReducer(state = initialState, action) {
    switch (action.type) {
        case LOAD_REVIEWS:
            return loadReviews(state, action);
        default:
            return state;
    }
}