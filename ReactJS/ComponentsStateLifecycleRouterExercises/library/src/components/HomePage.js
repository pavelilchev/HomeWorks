import React from 'react'
import Book from './sub-components/Book'
import Data from '../database/Data'

export default class HomePage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      books: []
    }
  }

  componentDidMount () {
    Data.allBooks()
      .then(books => {
        books = books
        .sort((a, b) => a.date < b.date)
        .slice(0, 3)

        this.setState({
          books: books
        })
      })
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
