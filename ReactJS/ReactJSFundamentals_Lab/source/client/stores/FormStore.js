import alt from '../alt'
import FormActions from '../actions/FormActions'
import UserActions from '../actions/UserActions'
import MovieActions from '../actions/MovieActions'

class FormStore {
  constructor () {
    this.bindActions(FormActions)
    this.bindListeners({
      onRegisterUserFail: UserActions.registerUserFail,
      onRegisterUserSuccess: UserActions.registerUserSuccess,
      onLoginUserSuccess: UserActions.loginUserSuccess,
      onLoginUserFail: UserActions.loginUserFail,
      onAddCommentFail: MovieActions.addCommentFail,
      onAddVoteSuccess: MovieActions.addVoteSuccess,
      onAddVoteFail: MovieActions.addVoteFail
    })

    this.username = ''
    this.password = ''
    this.confirmedPassword = ''
    this.firstName = ''
    this.lastName = ''
    this.age = ''
    this.gender = ''
    this.formSubmitState = ''
    this.usernameValidationState = ''
    this.passwordValidationState = ''
    this.message = ''
    this.commentValidationState = ''
    this.comment = ''
    this.score = ''
    this.scoreValidationState = ''
  }

  onHandleCommentChange (e) {
    this.comment = e.target.value
  }

  onRegisterUserSuccess () {
    console.log('FromStore register success')
    this.formSubmitState = 'has-success'
    this.usernameValidationState = ''
    this.passwordValidationState = ''
    this.message = 'User register successful'
  }

  onRegisterUserFail (err) {
    console.log('FormStore register error', err)
    if (err.code === 11000) {
      this.usernameValidationState = 'has-error'
      this.message = 'Username already exist'
      return
    }

    this.formSubmitState = 'has-error'
    this.message = err.message
  }

  onUsernameValidationFail () {
    this.usernameValidatioState = 'has-error'
    this.passwordValidationState = ''
    this.formSubmitState = ''
    this.message = 'Enter username'
  }

  onPasswordValidationFail () {
    this.passwordValidationState = 'has-error'
    this.usernameValidatioState = ''
    this.formSubmitState = ''
    this.message = 'Invalid password, or passwords do not match'
  }

  onLoginUserSuccess () {
    this.formSubmitState = 'has-success'
    this.usernameValidationState = ''
    this.passwordValidationState = ''
    this.message = 'User login successful'
  }

  onLoginUserFail (err) {
    this.formSubmitState = 'has-error'
    this.usernameValidationState = 'has-error'
    this.passwordValidationState = 'has-error'
    this.message = err.message
  }

  onHandleUsernameChange (e) {
    this.username = e.target.value
  }

  onHandlePasswordChange (e) {
    this.password = e.target.value
  }

  onHandleConfirmedPasswordChange (e) {
    this.confirmedPassword = e.target.value
  }

  onHandleFirstNameChange (e) {
    this.firstName = e.target.value
  }

  onHandleLastNameChange (e) {
    this.lastName = e.target.value
  }

  onHandleAgeChange (e) {
    this.age = e.target.value
  }

  onHandleGenderChange (e) {
    this.gender = e.target.value
  }

  onUnauthorizedAccessAttempt () {
    this.formSubmitState = 'has-error'
    this.usernameValidationState = ''
    this.passwordValidationState = ''
    this.message = 'Please login'
  }

  onAddCommentFail (err) {
    this.commentValidationState = 'has-error'
    this.message = err.message
  }

  onCommentValidationFail () {
    this.commentValidationState = 'has-error'
    this.message = 'Please enter comment text'
  }

  handleScoreChange (e) {
    this.score = e.target.value
  }

  onScoreValidationFail () {
    this.scoreValidationState = 'has-error'
    this.message = 'Valid score is between 0 and 10'
  }

  onAddVoteSuccess () {
    this.scoreValidationState = ''
    this.message = ''
  }

  onAddVoteFail (err) {
    this.scoreValidationState = 'has-error'
    this.message = err.message
  }
}

export default alt.createStore(FormStore)
