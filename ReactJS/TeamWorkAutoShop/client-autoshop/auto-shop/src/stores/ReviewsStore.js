import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import Data from '../data/Data'
import reviewsActions from '../actions/ReviewsActions'

class ReviewsStore extends EventEmitter {
  all (page) {
    return new Promise((resolve, reject) => {
      Data
        .getAllReviews(page)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  count () {
    return new Promise((resolve, reject) => {
      Data
        .getReviewsCount()
        .then(respone => {
          resolve(respone)
        })
    })
  }

  create (review) {
    Data
      .addReview(review)
      .then(response => {
        this.emit(this.events.REVIEW_ADDED, response)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case reviewsActions.actionTypes.CREATE:
        this.create(action.review)
        break
      default:
        break
    }
  }
}

let reviewsStore = new ReviewsStore()
reviewsStore.events = {
  REVIEW_ADDED: 'review_added'
}

dispatcher.register(reviewsStore.handleAction.bind(reviewsStore))
export default reviewsStore
