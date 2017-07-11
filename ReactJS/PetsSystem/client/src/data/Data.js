import Auth from '../components/users/Auth'

const baseURL = 'http://localhost:5000'
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
      .fetch(`${baseURL}/auth/signup`, request)
      .then(handleResponseJSON())
  }

  static loginUser (user) {
    let request = postRequest(user)
    return window
      .fetch(`${baseURL}/auth/login`, request)
      .then(handleResponseJSON())
  }

  static logoutUser () {
    let request = postRequest(null, true)
    return window
      .fetch(`${baseURL}/auth/logout`, request)
      .then(handleResponseJSON())
  }

  static createPet (pet) {
    let request = postRequest(pet, true)
    return window
      .fetch(`${baseURL}/pets/create`, request)
      .then(handleResponseJSON())
  }

  static getAllPets (page) {
    let request = getRequest()
    return window
      .fetch(`${baseURL}/pets/all?page=${page}`, request)
      .then(handleResponseJSON())
  }

  static getPetById (id) {
    let request = getRequest(null, true)
    return window
      .fetch(`${baseURL}/pets/details/${id}`, request)
      .then(handleResponseJSON())
  }
}

export default Data
