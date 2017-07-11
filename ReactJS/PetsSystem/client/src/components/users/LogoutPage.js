import React from 'react'
import Auth from '../users/Auth'
import UserActions from '../../actions/UserActions'

export default class LogoutPage extends React.Component {
  componentWillMount () {
    UserActions.logout()
    Auth.deauthenticateUser()
    Auth.removeUser()
    this.props.history.push('/')
  }

  render () {
    return null
  }
}
