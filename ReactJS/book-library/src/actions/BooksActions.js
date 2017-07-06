import dispatcher from '../dispatcher.js'

let booksActions = {
  actionTypes: {
    DELETE: 'DELETE'
  },
  delete: (id) => {
    dispatcher.dispatch({
      type: booksActions.actionTypes.DELETE,
      id: id
    })
  }
}

export default booksActions
