import { Route, Switch } from 'react-router-dom'
import React from 'react'

import BooksPage from './components/BooksPage'
import NotFoundPage from './components/NotFoundPage'
import HomePage from './components/HomePage'

const Routes = () => (
  <Switch>
    <Route exact path='/' component={HomePage} />
    <Route path='/home' component={HomePage} />
    <Route path='/books/all' component={BooksPage} />
    {/* <Route path='/books/:id' component={BooksDetail} />
    <Route path='/authors/all' component={AuthorsPage} />
    <Route path='/authors/:id' component={AuthorDetails} /> */}
    <Route component={NotFoundPage} />
  </Switch>
)

export default Routes
