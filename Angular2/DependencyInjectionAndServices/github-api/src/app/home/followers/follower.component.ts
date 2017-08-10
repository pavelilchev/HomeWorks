import { Component, Input } from '@angular/core';

@Component({
    selector: 'follower',
    templateUrl: './follower.component.html'
})

export class FollowerComponent {
    @Input() follower;
}