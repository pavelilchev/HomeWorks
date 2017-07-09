import React from 'react'
import BookForm from './BookForm'
import booksStore from '../../stores/BooksStore'
import booksActions from '../../actions/BooksActions'
import toastr from 'toastr'

export default class AddBookPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {
        title: '',
        author: '',
        date: '',
        img: '',
        description: '',
        price: ''
      },
      errors: []
    }

    this.handleBookAdded = this.handleBookAdded.bind(this)
    booksStore.on(
      booksStore.events.BOOK_ADDED,
      this.handleBookAdded)
  }

  handleBookAdded (data) {
    toastr.success(data)
    this.props.history.push('/books/all')
  }

  handleSubmitBook (event) {
    event.preventDefault()
    let book = this.state.book
    let errors = []
    if (!book.title) {
      errors.push('Title is required')
    }
    if (!book.author) {
      errors.push('Author is required')
    }
    if (!book.date) {
      errors.push('Date is required')
    }
    if (!book.img) {
      errors.push('Image is required')
    }
    if (!book.description) {
      errors.push('Description is required')
    }
    if (!book.price) {
      errors.push('Price is required')
    }

    if (errors.length > 0) {
      this.setState({errors})
      return
    }

    booksActions.add(this.state.book)
  }

  handleInputChange (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let book = this.state.book
    book[field] = value
    this.setState({ book })
  }

  render () {
    return (
      <div className='row'>
        <div className='col-md-6'>
          <h1>Add book:</h1>
          <BookForm
            book={this.state.book}
            errors={this.state.errors}
            onSubmit={this.handleSubmitBook.bind(this)}
            onChange={this.handleInputChange.bind(this)} />
        </div>
      </div>
    )
  }
}
