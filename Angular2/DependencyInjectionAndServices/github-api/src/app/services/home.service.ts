import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { GithubProfile } from '../models/github.profile'
import { GithubFollower } from '../models/github.follower'

const username: string = 'nakov';
const url: string = `https://api.github.com/users/${username}`;
const urlFollowers: string = `https://api.github.com/users/${username}/followers`;
const urlRepos: string = `https://api.github.com/users/${username}/repos`

@Injectable()
export class HomeService {
    constructor(private http: Http) { }

    getProfileData(): Promise<GithubProfile> {
        return this.http
            .get(url)
            .toPromise()
            .then(resp => resp.json() as GithubProfile)
            .catch(err => {
                console.log(err); return new GithubProfile()
            });
    }

    getFollowersData(): Promise<GithubFollower> {
        return this.http
            .get(urlFollowers)
            .toPromise()
            .then(resp => resp.json() as GithubFollower)
            .catch(err => {
                console.log(err); return new GithubFollower();
            });
    }

    getReposData() {
        return this.http
            .get(urlRepos)
            .toPromise()
            .then(resp => resp.json())
            .catch(err => {
                console.log(err);
            });
    }

    getContributorsData(fullName) {
        let urlContributors = `https://api.github.com/repos/${fullName}/contributors`;
        return this.http
            .get(urlContributors)
            .toPromise()
            .then(resp => resp.json())
            .catch(err => {
                console.log(err);
            });
    }
}