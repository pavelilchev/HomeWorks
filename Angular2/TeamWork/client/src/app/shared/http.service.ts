import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import 'rxjs/add/operator/map';

const baseUrl = 'http://localhost:1317';

@Injectable()
export class HttpService {
    constructor(private http: Http) { }

    get(url) {
        return this.http
            .get(`${baseUrl}${url}`)
            .map(res => res.json());
    }

    post(url, data, authorize = false) {
        const headers = new Headers({
            'Content-Type': 'application/json'
        });

        const requestOptions = new RequestOptions({
            headers: headers
        });

        return this.http
            .post(`${baseUrl}${url}`, JSON.stringify(data))
            .map(res => res.json());
    }
}