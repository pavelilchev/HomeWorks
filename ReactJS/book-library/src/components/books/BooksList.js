import React from 'react'
import booksStore from '../../stores/BooksStore'
import Book from './Book'
import ReactPaginate from 'react-paginate'
import Sorting from './Sorting'

export default class BooksList extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      books: [],
      perPage: 5,
      offset: 0,
      pageCount: 0,
      sort: {
        sortBy: 'date',
        order: 'desc'
      }
    }
  }

  componentDidMount () {
    this.getBooks()
  }

  getBooks () {
    booksStore.getAll()
      .then(books => {
        let pageCount = Math.ceil(books.length / this.state.perPage)
        this.setState({pageCount: pageCount})
        books = this.sortBooks(books)
        books = books.splice(this.state.offset, this.props.count)
        this.setState({books})
      })
  }

  sortBooks (books) {
    if (this.state.sort.sortBy === 'date') {
      return this.sortByDate(books)
    } else if (this.state.sort.sortBy === 'author') {
      return this.sortByAuthor(books)
    } else if (this.state.sort.sortBy === 'title') {
      return this.sortByTitle(books)
    }

    return books
  }

  sortByDate (books) {
    if (this.state.sort.order === 'asc') {
      return books.sort(function (a, b) {
        let firstDate = new Date(a.date)
        let secondDate = new Date(b.date)

        return firstDate > secondDate
      })
    } else {
      return books.sort(function (a, b) {
        let firstDate = new Date(a.date)
        let secondDate = new Date(b.date)

        return firstDate < secondDate
      })
    }
  }

  sortByAuthor (books) {
    if (this.state.sort.order === 'asc') {
      return books.sort(function (a, b) {
        return a.author.localeCompare(b.author)
      })
    } else {
      return books.sort(function (a, b) {
        return b.author.localeCompare(a.author)
      })
    }
  }

  sortByTitle (books) {
    if (this.state.sort.order === 'asc') {
      return books.sort(function (a, b) {
        return a.title.localeCompare(b.title)
      })
    } else {
      return books.sort(function (a, b) {
        return b.title.localeCompare(a.title)
      })
    }
  }

  handlePageClick (data) {
    let selected = data.selected
    let offset = Math.ceil(selected * this.state.perPage)

    this.setState({offset: offset}, this.getBooks())
  }

  handleCriteriaChnage (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let sort = this.state.sort
    sort[field] = value
    this.setState({sort})
    this.getBooks()
  }

  render () {
    let books = this.state.books.map(b => {
      return <Book key={b.id} book={b} />
    })
    let paging = null
    if (this.props.hasPagination === 'true') {
      paging = (
        <ReactPaginate
          previousLabel={'previous'}
          nextLabel={'next'}
          breakLabel={<a href=''>...</a>}
          breakClassName={'break-me'}
          pageCount={this.state.pageCount}
          marginPagesDisplayed={2}
          pageRangeDisplayed={5}
          onPageChange={this.handlePageClick.bind(this)}
          containerClassName={'pagination'}
          subContainerClassName={'pages pagination'}
          activeClassName={'active'} />)
    }

    let sorting = null
    if (this.props.sorting === 'true') {
      sorting = <Sorting onChange={this.handleCriteriaChnage.bind(this)} />
    }

    return (
      <div>
        {sorting}
        <div className='row'>
          {books}
        </div>
        {paging}
      </div>
    )
  }
}
