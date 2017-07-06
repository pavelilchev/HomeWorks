import React from 'react'
import { Link } from 'react-router-dom'
import booksStore from '../../stores/BooksStore'
import commentStore from '../../stores/CommentStore'
import Comments from './Comments'

export default class BookDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {},
      comments: []
    }
  }

  componentDidMount () {
    let id = this.props.match.params.id
    booksStore
      .getById(id)
      .then(book => {
        this.setState({book})
        commentStore.getByBookId(book.id)
          .then(comments => {
            this.setState({comments})
          })
      })
  }
  render () {
    let book = this.state.book
    return (
      <div>
        <div className='row book-details-wrapper'>
          <h3>{book.title}</h3>
          <div className='col-md-4'>
            <img src={book.img} alt={book.title} />
          </div>
          <div className='col-md-4 text-left'>
            <p>
              Resume:
              <br />
              {book.description}
            </p>
          </div>
          <div className='col-md-4 text-left'>
            <p>
              Author:
              <Link to={`/authors/${book.authorId}`}>
                <b>&nbsp;{book.author}</b>
              </Link>
            </p>
            <p>
              Price: $
              {book.price}
            </p>
          </div>
        </div>
        <h3>Comments:</h3>
        <Comments comments={this.state.comments} />
      </div>
    )
  }
}
