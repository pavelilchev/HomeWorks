import { User } from '../models/User';
import { IAppState } from './application.state';
import { REGISTER_USER } from './users.actions';

const initialState: IAppState = {
    registeredUser: ''
}

export function reducer(state = initialState, action) {
    switch (action.type) {
        case REGISTER_USER:
            registerUser(state, action);
        default:
            return state;
    }
}

function registerUser(state, action): IAppState {
    return Object.assign({}, state, {
        registeredUser: action.success
    })
}