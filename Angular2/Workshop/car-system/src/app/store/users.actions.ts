import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';
import { Injectable } from '@angular/core';

import { UsersService } from '../services/user.service';

import { User } from '../models/User';

export const REGISTER_USER = 'users/REGISTER';

@Injectable()
export class UsersActions {
    constructor(
        private ngRedux: NgRedux<IAppState>,
        private usersService: UsersService) { }

    registerUser(user: User) {
        this.usersService
            .registerUser(user)
            .then(response => {
                this.ngRedux.dispatch({
                    type: REGISTER_USER,
                    response
                });
            })
    }
}