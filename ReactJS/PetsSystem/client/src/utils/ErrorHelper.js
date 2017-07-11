class ErrorHelper {
  static parse (errorObj) {
    let keys = Object.keys(errorObj)
    let result = []
    for (let key of keys) {
      result.push(errorObj[key])
    }

    return result
  }
}

export default ErrorHelper
