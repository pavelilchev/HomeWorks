import { Component } from '@angular/core';

import Auth from '../Utils/Auth';

@Component({
    selector: 'navigation',
    templateUrl: './navigation.component.html'
})

export class NavigationComponent {
    isLoggedIn: boolean;

    constructor () {
        this.isLoggedIn = Auth.isUserAuthenticated();
    }
}