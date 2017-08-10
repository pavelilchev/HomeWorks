import { Component, OnInit } from '@angular/core';

import { HomeService } from '../services/home.service';

import { GithubProfile } from '../models/github.profile';
import { GithubFollower } from '../models/github.follower';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    providers: [HomeService]
})

export class HomeComponent implements OnInit {
    private githubInfo: GithubProfile;
    private followers: GithubFollower;
    private repos;

    constructor(private homeService: HomeService) { }

    ngOnInit() {
        this.homeService
            .getProfileData()
            .then(data => {
                this.githubInfo = data;
                console.log(data)
            })
            .catch(err => console.log(err));
    }

    getFollowers() {
        this.homeService
            .getFollowersData()
            .then(data => {
                this.followers = data;
            })
            .catch(err => console.log(err));
    }

    getRepos() {
        this.homeService
            .getReposData()
            .then(data => {
                this.repos = data;
            })
            .catch(err => console.log(err));
    }
}