import React from 'react'
import { Link } from 'react-router-dom'
import ReactPaginate from 'react-paginate'
import reviewsStore from '../../stores/ReviewsStore'
import ReviewsList from './ReviewsList'

export default class Name extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      reviews: [],
      pageCount: 1,
      perPage: 7,
      page: 1
    }
  }

  componentDidMount () {
    reviewsStore
      .all(this.state.page)
      .then(reviews => {
        this.setState({reviews})
      })

    reviewsStore
      .count()
      .then(data => {
        let pageCount = Math.ceil(data.count / this.state.perPage)
        this.setState({pageCount})
      })
  }

  handleReviewsLoad (reviews) {
    this.setState({reviews})
  }

  handlePageClick (event) {
    let selected = event.selected
    let page = selected + 1
    this.setState({page}, this.loadReviews(page))
  }

  loadReviews (page) {
    let nextPage = page || this.state.page
    reviewsStore
      .all(nextPage)
      .then(reviews => {
        this.setState({reviews})
      })
  }

  render () {
    return (
      <div>
        <h2>Reviews</h2>
        <ReviewsList reviews={this.state.reviews} />
        <div className='row'>
          <div className='col-xs-12'>
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
              activeClassName={'active'} />
          </div>
        </div>
        <Link to='/reviews/create' className='leave-review'> Leave a Review
        </Link>
      </div>
    )
  }
}
