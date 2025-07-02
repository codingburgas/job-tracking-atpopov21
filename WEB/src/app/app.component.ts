import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { HomeComponent } from "./components/home/home.component";
import {
  trigger,
  transition,
  style,
  animate
} from '@angular/animations';

@Component({
    selector: 'app-root',
    imports: [CommonModule, RouterOutlet, TranslateModule, HomeComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    standalone: true,
    animations: [
    trigger('routeFadeAnimation', [
      transition('* <=> *', [
          style({ opacity: 0 }),
          animate('300ms ease-in', style({ opacity: 1 }))
        ])
      ])
    ]
})
export class AppComponent {
  constructor() {}
  title = 'Jobber';

  getRouterOutletState(outlet: any) {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
