import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { JobDetailsComponent } from './components/job-details/job-details.component';

export const routes: Routes = 
[
    { path: '', component: HomeComponent, data: { animation: 'LoginPage' } },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'main-page', component: MainPageComponent },
    { path: 'job-details', component: JobDetailsComponent },
];
