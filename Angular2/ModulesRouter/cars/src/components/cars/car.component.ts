import { Component, Input } from '@angular/core';

@Component({
    selector: 'car',
    templateUrl: './car.component.html',
    styleUrls: ['./car.component.css'],
})

export class CarComponent {
    @Input() car;
}