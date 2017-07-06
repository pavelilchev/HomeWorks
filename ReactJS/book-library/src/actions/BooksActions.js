import dispatcher from '../dispatcher.js'

let booksActions = {
  actionTypes: {
    GET_ALL: 'GET_ALL'
  },
  all: () => {
    dispatcher.dispatch({
      type: this.actionTypes.GET_ALL
    })
  }
}

export default booksActions
