import React from 'react'
import Book from './sub-components/Book'

import BooksStore from '../stores/BooksStore'

export default class HomePage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      books: []
    }

    BooksStore.on('change', () => {
      this.getAllBooks()
    })
  }
  createTodo (event) {
    event.preventDefault()
    BooksStore.createTodo(this.state.title)
    this.setState({ title: '' })
  }

  componentDidMount () {
    this.getAllBooks()
  }

  getAllBooks () {
    BooksStore
      .getAll()
      .then(books => this.setState({books}))
  }

  render () {
    let books = this.state.books.map((book, index) => {
      return <Book key={book.id} book={book} />
    })

    return (
      <div className='container'>
        <h3 className='text-center'>Welcome to <strong>Library</strong></h3>
        <div className='row'>
          {books}
        </div>
      </div>
    )
  }
}
