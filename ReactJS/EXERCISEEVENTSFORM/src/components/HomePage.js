import React from 'react'
import BooksList from './books/BooksList'

export default class HomePage extends React.Component {
  render () {
    return (
      <div>
        <h2>Wellcome to Book Library</h2>
        <BooksList
          count='6'
          hasPagination='false' />
      </div>
    )
  }
}
