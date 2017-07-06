import React from 'react'
import { Link } from 'react-router-dom'

export default class Book extends React.Component {
  render () {
    let author = this.props.author
    return (
      <div className='col-md-6'>
        <div className='single-book'>
          <h3>{author.name}</h3>
          <img src={author.image} alt={author.name} />
          <Link to={`/authors/${author.id}`}> Details
          </Link>
        </div>
      </div>
    )
  }
}
