import dispatcher from '../dispatcher.js'

let userActions = {
  actionTypes: {
    LOGIN: 'LOGIN',
    REGISTER: 'REGISTER',
    LOGOUT: 'LOGOUT'
  },
  login: (user) => {
    dispatcher.dispatch({
      type: userActions.actionTypes.LOGIN,
      user: user
    })
  },
  register: (user) => {
    dispatcher.dispatch({
      type: userActions.actionTypes.REGISTER,
      user: user
    })
  },
  logout: () => {
    dispatcher.dispatch({
      type: userActions.actionTypes.LOGOUT
    })
  }
}

export default userActions

