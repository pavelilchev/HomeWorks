import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import userActions from '../actions/UserActions'
import Data from '../data/Data'

class UserStore extends EventEmitter {
  login (user) {
    Data
      .loginUser(user)
      .then(respone => {
        this.emit(this.events.LOGGEDIN, respone)
      })
  }

  register (user) {
    Data
      .registerUser(user)
      .then(response => {
        this.emit(this.events.REGISTER, response)
      })
  }

  logout () {
    Data
      .logoutUser()
      .then(response => {
        this.emit(this.events.LOGET_OUT, response)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case userActions.actionTypes.LOGIN:
        this.login(action.user)
        break
      case userActions.actionTypes.REGISTER:
        this.register(action.user)
        break
      case userActions.actionTypes.LOGOUT:
        this.logout()
        break
      default:
        break
    }
  }
}

let userStore = new UserStore()
userStore.events = {
  LOGGEDIN: 'loggedin_user',
  REGISTER: 'register_user',
  LOGET_OUT: 'logged_out'
}

dispatcher.register(userStore.handleAction.bind(userStore))
export default userStore
