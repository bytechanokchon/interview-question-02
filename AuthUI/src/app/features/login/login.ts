import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {

  constructor(private router: Router) {}

  onClickToRegisterPage(): void {
    this.router.navigate(['/register']);
  }
}
