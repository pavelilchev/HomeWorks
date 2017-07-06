import { Route, Redirect } from 'react-router-dom'
import Auth from '../users/Auth'

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route {...rest} render={props => (
    Auth.isAuthenticated ? (
      <Component {...props} />
    ) : (
      <Redirect to={{
        pathname: '/user/login',
        state: { from: props.location }
      }} />
      )
  )
  } />
)

export default PrivateRoute
