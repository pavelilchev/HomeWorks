import dispatcher from '../dispatcher.js'

let booksActions = {
  actionTypes: {
    DELETE: 'DELETE',
    ADD: 'ADD'
  },
  delete: (id) => {
    dispatcher.dispatch({
      type: booksActions.actionTypes.DELETE,
      id: id
    })
  },
  add: (book) => {
    dispatcher.dispatch({
      type: booksActions.actionTypes.ADD,
      book
    })
  }
}

export default booksActions
