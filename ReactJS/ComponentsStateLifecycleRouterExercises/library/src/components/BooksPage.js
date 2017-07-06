import React from 'react'
import ReactPaginate from 'react-paginate'
import Book from './sub-components/Book'
import Data from '../database/Data'

export default class BooksPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      books: [],
      page: 1,
      itemPerPage: 5,
      pageCount: 0
    }

    this.handlePageClick = this.handlePageClick.bind(this)
    this.loadBooks = this.loadBooks.bind(this)
  }

  componentDidMount () {
    this.loadBooks()
  }

  loadBooks () {
    Data.allBooks()
      .then(books => {
        let skip = this.state.itemPerPage * (this.state.page - 1)
        this.setState({
          books: books.slice(skip, skip + this.state.itemPerPage),
          pageCount: Math.ceil(books.length / this.state.itemPerPage)
        })
      })
  }

  handlePageClick (data) {
    this.setState({page: data.selected + 1}, () => {
      this.loadBooks()
    })
  }

  render () {
    let books = this.state.books.map((book, index) => {
      return <Book key={book.id} book={book} />
    })

    return (
      <div className='container'>
        <div className='row'>
          {books}
        </div>
        <div className='row'>
          <ReactPaginate
            previousLabel={'previous'}
            nextLabel={'next'}
            breakLabel={<a href=''>...</a>}
            breakClassName={'break-me'}
            pageCount={this.state.pageCount}
            marginPagesDisplayed={2}
            pageRangeDisplayed={5}
            onPageChange={this.handlePageClick}
            containerClassName={'pagination'}
            subContainerClassName={'pages pagination'}
            activeClassName={'active'} />
        </div>
      </div>
    )
  }
}
