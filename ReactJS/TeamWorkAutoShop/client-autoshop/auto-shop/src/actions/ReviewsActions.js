import dispatcher from '../dispatcher.js'

let reviewsActions = {
  actionTypes: {
    CREATE: 'CREATE'
  },
  create: (review) => {
    dispatcher.dispatch({
      type: reviewsActions.actionTypes.CREATE,
      review: review
    })
  }
}

export default reviewsActions
