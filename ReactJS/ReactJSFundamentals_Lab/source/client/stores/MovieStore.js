import alt from '../alt'
import MovieActions from '../actions/MovieActions'

class MovieStore {
  constructor () {
    this.bindActions(MovieActions)
    this.topTenMovies = []
    this.mostRecentMovies = []
  }

  onAddCommentSuccess (data) {
    let comment = data.comment
    let movieId = data.comment.movie
    for (let i = 0, n = this.topTenMovies.length; i < n; i++) {
      if (this.topTenMovies[i]._id === movieId) {
        this.topTenMovies[i].comments.unshift(comment)
      }
    }
  }

  onAddCommentFail (err) {
    console.log('Could connect to DB', err)
  }

  onAddMovieToTopTen (movie) {
    this.topTenMovies.push(movie)
  }

  onEmptyTopTenMovies () {
    this.topTenMovies = []
  }

  onGetTopTenMoviesSuccess (movies) {
    this.topTenMovies = movies
  }

  onGetTopTenMoviesFail (err) {
    console.log('Could connect to DB', err)
  }

  onGetFiveRecentMoviesSuccess (data) {
    this.mostRecentMovies = data
  }

  onGetFiveRecentMoviesFail (err) {
    console.log('Could connect to DB', err)
  }
}

export default alt.createStore(MovieStore)
