import React from 'react'
import Auth from '../users/Auth'
import { Link } from 'react-router-dom'
import UserStore from '../../stores/UserStore'

export default class UserMenu extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      username: ''
    }

    this.handleUserLoggedin = this.handleUserLoggedin.bind(this)

    UserStore.on(
      UserStore.events.LOGGEDIN,
      this.handleUserLoggedin)
  }

  componentDidMount () {
    let user = Auth.getUser()
    if (user && user.username) {
      this.setState({username: user.username})
    }
  }

  handleUserLoggedin (data) {
    if (data.success) {
      this.setState({username: data.user.username})
    }
  }

  render () {
    let userMenu = ''
    Auth.isUserAuthenticated()
      ? userMenu = (
        <ul className='nav navbar-nav navbar-right' id='menu-links'>
          <li className='header-greeting'>
            Hello,
            {this.state.username}
          </li>
          <li>
            <Link to='/users/logout'> Logout
            </Link>
          </li>
        </ul>)
      : userMenu = (
        <ul className='nav navbar-nav navbar-right' id='menu-links'>
          <li>
            <Link to='/users/register'> Register
            </Link>
          </li>
          <li>
            <Link to='/users/login'> Login
            </Link>
          </li>
        </ul>)
    return (
      userMenu
    )
  }
}
