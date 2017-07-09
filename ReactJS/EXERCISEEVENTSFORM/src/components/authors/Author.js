import React from 'react'
import { Link } from 'react-router-dom'

export default class Author extends React.Component {
  render () {
    let author = this.props.author
    return (
      <div className='col-md-3'>
        <Link to={`/authors/${author.id}`}>
        <h3>{author.name}</h3>
        </Link>
        <img src={author.img} alt={author.name} />
      </div>
    )
  }
}
