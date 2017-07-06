import React from 'react'
import { Link } from 'react-router-dom'

export default class Book extends React.Component {
  render () {
    return (
      <div className='col-md-6'>
        <div className='single-book'>
          <h3>{this.props.book.title}</h3>
          <p>
            author:
            <Link to={`/authors/${this.props.book.authorId}`}>
              <b>{this.props.book.author}</b>
            </Link>
          </p>
          <span><i>{this.props.book.date}</i></span>
          <br />
          <Link to={`/books/${this.props.book.id}`}> Details
          </Link>
        </div>
      </div>
    )
  }
}
