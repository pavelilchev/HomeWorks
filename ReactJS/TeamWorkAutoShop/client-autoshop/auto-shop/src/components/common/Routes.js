import React from 'react'
import { Switch, Route } from 'react-router-dom'
import HomePage from '../HomePage'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import LogoutPage from '../users/LogoutPage'
import PrivateRoute from '../common/PrivateRoute'
import ReviewsPage from '../reviews/ReviewsPage'
import AddReviewPage from '../reviews/AddReviewPage'

export default class Routes extends React.Component {
  render () {
    return (
      <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/home' component={HomePage} />
        <Route path='/users/register' component={RegisterPage} />
        <Route path='/users/login' component={LoginPage} />
        <PrivateRoute path='/users/logout' component={LogoutPage} />
        <Route path='/reviews/all' component={ReviewsPage} />
        <PrivateRoute path='/reviews/create' component={AddReviewPage} />
      </Switch>
    )
  }
}
