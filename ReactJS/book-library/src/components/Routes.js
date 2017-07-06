import React from 'react'
import { Switch, Route } from 'react-router-dom'
import HomePage from './HomePage'
import RegisterPage from './users/RegisterPage'
import LoginPage from './users/LoginPage'
import BooksPage from './books/BooksPage'
import BookDetailsPage from './books/BookDetailsPage'
import AuthorsPage from './authors/AuthorsPage'
import AuthorDetailsPage from './authors/AuthorDetailsPage'

export default class Routes extends React.Component {
  render () {
    return (
      <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/home' component={HomePage} />
        <Route path='/user/register' component={RegisterPage} />
        <Route path='/user/login' component={LoginPage} />
        <Route path='/books/all' component={BooksPage} />
        <Route path='/books/:id' component={BookDetailsPage} />
        <Route path='/authors/all' component={AuthorsPage} />
        <Route path='/authors/:id' component={AuthorDetailsPage} />
      </Switch>
    )
  }
}
