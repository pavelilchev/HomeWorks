import { Component, Injectable } from '@angular/core';

import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { User } from '../models/User';

const baseUrl = 'http://localhost:5000';
const registerEndPoint = '/auth/signup';

@Injectable()
export class UsersService {
    constructor(private http: Http) { }

    registerUser(user: User) {
        return this.http
            .post(baseUrl + registerEndPoint, JSON.stringify(user))
            .toPromise()
            .then(resp => resp.json())
            .catch(err => { console.log(err); });
    }
}