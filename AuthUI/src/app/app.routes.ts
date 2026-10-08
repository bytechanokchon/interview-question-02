import { Routes } from '@angular/router';
import { Login } from './features/login/login';
import { Register } from './features/register/register';
import { UserInfo } from './features/user-info/user-info';

export const routes: Routes = [
    {
        path: '',
        component: Login
    },
    {
        path: 'register',
        component: Register
    },
    {
        path: 'user-info',
        component: UserInfo
    }
];
