import { Review } from '../../reviews/review';

export interface IReviewsState{
    reviews: Array<Review>
}

export const initialState: IReviewsState = {
    reviews: new Array<Review>()
}