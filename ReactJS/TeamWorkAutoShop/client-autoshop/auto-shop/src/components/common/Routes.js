import React from 'react'
import { Switch, Route } from 'react-router-dom'
import HomePage from '../home/HomePage'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import LogoutPage from '../users/LogoutPage'
import PrivateRoute from './PrivateRoute'
import AdminRoute from './AdminRoute'
import ReviewsPage from '../reviews/ReviewsPage'
import AddReviewPage from '../reviews/AddReviewPage'
import AppointmentPage from '../appointments/AppointmentPage'
import AdminPage from '../admins/AdminPage'
import ReviewEditPage from '../admins/ReviewEditPage'

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
        <Route path='/appointment/create' component={AppointmentPage} />
        <AdminRoute path='/admin/all' component={AdminPage} />
        <AdminRoute path='/reviews/edit/:id' component={ReviewEditPage} />
      </Switch>
    )
  }
}
