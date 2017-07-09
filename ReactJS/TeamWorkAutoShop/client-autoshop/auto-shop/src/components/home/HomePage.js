import React from 'react'
import reviewsStore from '../../stores/ReviewsStore'
import HomeReview from './HomeReview'
import GoogleMapReact from 'google-map-react'
import Marker from '../common/Marker'

const defaultProps = {
  center: {lat: 43.209952, lng: 27.920765},
  zoom: 16
}

export default class HomePage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      reviews: [],
      review: {
        author: {},
        tetx: ''
      },
      index: 0
    }

    this.changeReview = this.changeReview.bind(this)
  }

  componentDidMount () {
    reviewsStore
      .all(this.state.page)
      .then(reviews => {
        this.setState({reviews})
        if (reviews.length > 0) {
          let review = reviews[this.state.index]
          this.setState({review})
          this.interval = setInterval(this.changeReview, 3000)
        }
      })
  }

  componentWillUnmount () {
    clearInterval(this.interval)
  }

  changeReview () {
    let nextIndex = (this.state.index + 1) % this.state.reviews.length
    this.setState({
      index: nextIndex,
      review: this.state.reviews[nextIndex]
    })
  }

  render () {
    let apiKey = {'key': 'AIzaSyClyU8DuKbc5qLkBwBe40rfgklUubIZav0'}
    return (
      <div>
        <div className='slideshow'>
          <img src={require('../../images/slideshow/slideshow-1.jpg')} alt='Slideshow' className='img-responsive' />
        </div>
        <HomeReview review={this.state.review} />
        <div className='home-services'>
          <h2>What services we offer</h2>
          <ul>
            <li>
              Air Conditioning
            </li>
            <li>
              Alternator's
            </li>
            <li>
              Axles
            </li>
            <li>
              Ball Joints
            </li>
          </ul>
          <ul>
            <li>
              Batteries
            </li>
            <li>
              Belts
            </li>
            <li>
              Brakes
            </li>
            <li>
              Check Engine Light
            </li>
          </ul>
        </div>
        <div className='google-map'>
          <GoogleMapReact
            bootstrapURLKeys={apiKey}
            defaultCenter={defaultProps.center}
            defaultZoom={defaultProps.zoom}
            zoom={defaultProps.zoom}>
            <Marker lat={defaultProps.center.lat} lng={defaultProps.center.lng} text={'Auto Shop'} />
          </GoogleMapReact>
        </div>
      </div>
    )
  }
}
