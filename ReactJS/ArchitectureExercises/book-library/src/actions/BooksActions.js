import dispatcher from '../dispatcher'

let booksActions = {
  getAll: () => {
    dispatcher.dispatch({
      type: 'GET_ALL'
    })
  }

}

export default booksActions
