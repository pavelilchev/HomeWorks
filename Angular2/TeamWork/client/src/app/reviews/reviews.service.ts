import { Component, Injectable } from '@angular/core';

import { HttpService } from '../shared/http.service';

const baseUrl = 'http://localhost:5000';
const registerEndPoint = '/auth/signup';

@Injectable()
export class ReviewsService {
    constructor(private httpService: HttpService) { }

    getReviews() {
        return this.httpService
            .get('/reviews/all');
    }
}