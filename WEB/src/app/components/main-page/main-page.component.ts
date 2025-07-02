import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss'
})
export class MainPageComponent {
  firstName: string = 'John';
  lastName: string = 'Doe';
  
  jobs = [
    { id: 1, title: 'Programmer', company: 'Tech Ltd', description: 'Develop web apps' },

  ];

  constructor(private router: Router) {}

  viewDetails(jobId: number) {
    this.router.navigate(['/job', jobId]);
  }

  signOut() {
    // Add actual sign-out logic here (e.g., clear tokens/session)
    this.router.navigate(['/']);
  }
}