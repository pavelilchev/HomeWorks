import React from 'react'
import { Link } from 'react-router-dom'
import booksStore from '../../stores/BooksStore'
import booksActions from '../../actions/BooksActions'
import commentStore from '../../stores/CommentStore'
import commentsActions from '../../actions/CommentsActions'
import Comments from './Comments'
import AddComment from './AddComment'
import toastr from 'toastr'

export default class BookDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {},
      comments: [],
      comment: {
        text: ''
      }
    }

    this.habdleBookDeleted = this.habdleBookDeleted.bind(this)
    this.handleCommentDeleted = this.handleCommentDeleted.bind(this)
    this.handleCommentsAdded = this.handleCommentsAdded.bind(this)
    this.loadData = this.loadData.bind(this)

    booksStore.on(
      booksStore.events.BOOK_DELETED,
      this.habdleBookDeleted)

    commentStore.on(
      commentStore.events.COMMENT_DELETED,
      this.handleCommentDeleted)

    commentStore.on(
        commentStore.events.COMMENT_ADDED,
        this.handleCommentsAdded)
  }

  habdleBookDeleted (data) {
    this.props.history.push('/books/all')
  }

  handleCommentDeleted (data) {
    commentStore.getByBookId(this.state.book.id)
      .then(comments => {
        this.setState({comments})
      })
  }

  handleCommentsAdded (data) {
    toastr.success(data)
    let comment = this.state.comment
    comment.text = ''
    this.setState({comment})

    this.loadData()
  }

  componentDidMount () {
    this.loadData()
  }

  loadData () {
    let id = this.props.match.params.id
    booksStore
      .getById(id)
      .then(book => {
        if (!book) {
          this.props.history.push('/')
          return
        }

        this.setState({book})
        commentStore.getByBookId(book.id)
          .then(comments => {
            this.setState({comments})
          })
      })
  }

  deleteBook () {
    booksActions.delete(this.state.book.id)
  }

  handleCommentChange (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let comment = this.state.comment
    comment[field] = value
    this.setState({ comment })
  }

  handleCommentSubmit (event) {
    event.preventDefault()
    if (!this.state.comment.text) {
      return
    }

    commentsActions.add(this.state.comment, this.state.book.id)
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
                <b>{book.author}</b>
              </Link>
            </p>
            <p>
              Price: $
              {book.price}
            </p>
            <p>
              <Link to={`/books/edit/${book.id}`} className='btn btn-primary'>
                Edit Book
              </Link>
            </p>
            <p>
              <button className='btn btn-danger' onClick={this.deleteBook.bind(this)}>
                Delete Book
              </button>
            </p>
          </div>
        </div>
        <h3>Comments:</h3>
        <Comments comments={this.state.comments} />
        <AddComment
          comment={this.state.comment}
          onChange={this.handleCommentChange.bind(this)}
          onSubmit={this.handleCommentSubmit.bind(this)} />
      </div>
    )
  }
}
