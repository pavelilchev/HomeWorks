import Auth from '../components/users/Auth'

const baseURL = 'http://localhost:1317'
const request = (method, body, isAuthorize) => {
  let request = {
    method: method,
    mode: 'cors',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  }

  if (body) {
    request.body = JSON.stringify(body)
  }

  if (isAuthorize) {
    let token = Auth.getToken()
    request.headers['Authorization'] = `bearer ${token}`
  }

  return request
}

const postRequest = (body, isAuthorize) => request('POST', body, isAuthorize)
const getRequest = (body, isAuthorize) => request('GET', body, isAuthorize)
const handleResponseJSON = () => response => response.json()

class Data {
  static registerUser (user) {
    let request = postRequest(user)
    return window
      .fetch(`${baseURL}/users/register`, request)
      .then(handleResponseJSON())
  }

  static loginUser (user) {
    let request = postRequest(user)
    return window
      .fetch(`${baseURL}/users/login`, request)
      .then(handleResponseJSON())
  }

  static logoutUser () {
    let request = postRequest(null, true)
    return window
      .fetch(`${baseURL}/users/logout`, request)
      .then(handleResponseJSON())
  }

  static getAllReviews (page) {
    let request = getRequest()
    return window
      .fetch(`${baseURL}/reviews/all?page=${page}`, request)
      .then(handleResponseJSON())
  }

  static getReviewById (id) {
    let request = getRequest(null, true)
    return window
      .fetch(`${baseURL}/reviews/get/${id}`, request)
      .then(handleResponseJSON())
  }

  static editReview (review) {
    let request = postRequest(review, true)
    return window
      .fetch(`${baseURL}/reviews/edit/${review._id}`, request)
      .then(handleResponseJSON())
  }

  static getSelectedReviews (options) {
    let request = getRequest(null, true)
    return window
      .fetch(`${baseURL}/reviews/allSelected?options=${options}`, request)
      .then(handleResponseJSON())
  }

  static addReview (review) {
    let request = postRequest(review, true)

    return window
      .fetch(`${baseURL}/reviews/add`, request)
      .then(handleResponseJSON())
      .catch(handleResponseJSON())
  }

  static getReviewsCount () {
    let request = getRequest()
    return window
      .fetch(`${baseURL}/reviews/count`, request)
      .then(handleResponseJSON())
  }

  static deleteReviewById (id) {
    let request = postRequest(null, true)

    return window
      .fetch(`${baseURL}/reviews/delete/${id}`, request)
      .then(handleResponseJSON())
      .catch(handleResponseJSON())
  }

  static addAppointment (appointment) {
    let request = postRequest(appointment)
    return window
      .fetch(`${baseURL}/appointment/add`, request)
      .then(handleResponseJSON())
  }

  static getAllAppointments (option) {
    let request = postRequest(null, true)
    return window
      .fetch(`${baseURL}/appointment/all?option=${option}`, request)
      .then(handleResponseJSON())
  }

  static confirmAppointment (id) {
    let body = {
      id: id
    }
    let request = postRequest(body, true)
    return window
      .fetch(`${baseURL}/appointment/confirm`, request)
      .then(handleResponseJSON())
  }
}

export default Data
