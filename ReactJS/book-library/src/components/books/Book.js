import React from 'react'
import {Link} from 'react-router-dom'

export default class Book extends React.Component {
  render () {
    let book = this.props.book
    return (
      <div className='col-md-4'>
        <h3>{book.title}</h3>
        <span>from <i>{book.author}</i></span>
        <div><Link to={`/books/${book.id}`}>Details</Link>
        </div>
      </div>
    )
  }
}
