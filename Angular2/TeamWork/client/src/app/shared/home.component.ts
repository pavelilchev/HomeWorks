import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {
    lat: number = 43.209952;
    lng: number = 27.920765;
    zoom: number = 15;
    scrollwheel: boolean = false;
}