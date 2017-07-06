import React from 'react'
import BooksList from './BooksList'

export default class BooksPage extends React.Component {
  render () {
    return (
      <div>
        <h2>Our Books</h2>
        <BooksList count='5' hasPagination='true' sorting='true' />
      </div>
    )
  }
}
