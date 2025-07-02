import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { LoginRequest } from '../../models/login-request.dto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,  // Add this if your component is standalone
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.invalid) return;

    const loginData: LoginRequest = this.loginForm.value;

    this.authService.login(loginData).subscribe({
      next: (res) => {
        this.authService.saveToken(res.token); // Ensure saveToken() is implemented
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        this.errorMessage = 'Невалидни данни. Моля, опитайте отново.';
        console.error(err);
      }
    });
  }
}
