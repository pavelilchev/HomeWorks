import { Component, Input } from '@angular/core';
import { HomeService } from '../../services/home.service';

@Component({
    selector: 'repo',
    providers: [],
    templateUrl: './repo.component.html'
})

export class RepoComponent {
    @Input() repo;
    private contributors;

    constructor(private homeService: HomeService){}

    getContributors(){
        this.homeService
        .getContributorsData(this.repo.full_name)
        .then(data => {
            this.contributors = data;
        })
        .catch(err => console.log(err));
    }
}