import React from 'react'
import { Switch, Route } from 'react-router-dom'
import HomePage from '../home/HomePage'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import LogoutPage from '../users/LogoutPage'
import PrivateRoute from './PrivateRoute'

export default class Routes extends React.Component {
  render () {
    return (
      <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/home' component={HomePage} />
        <Route path='/users/register' component={RegisterPage} />
        <Route path='/users/login' component={LoginPage} />
        <PrivateRoute path='/users/logout' component={LogoutPage} />
      </Switch>
    )
  }
}
