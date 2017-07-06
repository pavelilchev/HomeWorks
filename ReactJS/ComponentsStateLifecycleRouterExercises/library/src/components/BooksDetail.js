import React from 'react'
import Data from '../database/Data'
import Comment from './Comment'
import { Link } from 'react-router-dom'

export default class BooksDetail extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {},
      comments: []
    }
  }

  componentDidMount () {
    let id = this.props.match.params.id
    Data.getBookById(id)
      .then(book => {
        this.setState({
          book: book
        })
      })

    Data.getCommentsById(id)
      .then(comments => {
        this.setState({
          comments: comments
        })
      })
  }

  render () {
    let comments = this.state.comments.map(comment => (
      <Comment comment={comment} key={comment.id} />
    ))

    return (
      <div className='col-md-4'>
        <div className='single-book'>
          <h3>{this.state.book.title}</h3>
          <img src={this.state.book.image} alt={this.state.book.title} />
          <p>
            author:
            <Link to={`/authors/${this.state.book.authorId}`}>
              <b>{this.state.book.author}</b>
            </Link>
          </p>
          <span><i>{this.state.book.date}</i></span>
          <div className='comments-wrapper'>
            <h2>Comments:</h2>
            {comments}
          </div>
        </div>
      </div>
    )
  }
}
