import { Component } from '@angular/core';

import { User } from '../models/User';

import { UsersActions, IAppState } from '../store';
import { NgRedux, select } from 'ng2-redux';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'register',
    providers: [UsersActions],
    templateUrl: './register.component.html',
})

export class RegisterComponent {
    user: User = new User('', '', '', '');

    @select('registeredUser') registeredUser: Observable<string>;

    constructor(
        private ngRedux: NgRedux<IAppState>,
        private usersActions: UsersActions
    ) { }

    onRegisterUser() {
        debugger
        this.usersActions.registerUser(this.user);
    }
}