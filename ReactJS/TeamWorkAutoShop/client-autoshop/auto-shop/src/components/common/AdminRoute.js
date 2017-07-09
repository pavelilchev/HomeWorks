import React from 'react'
import { Route, Redirect } from 'react-router-dom'
import Auth from '../users/Auth'

const AdminRoute = ({ component: Component, ...rest }) => (
  <Route {...rest} render={props => (
    Auth.isAdmin() ? (
      <Component {...props} />
    ) : (
      <Redirect to={{
        pathname: '/users/login',
        state: { from: props.location }
      }} />
      )
  )
  } />
)

export default AdminRoute
