import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-register',
  styleUrl: './register.css',
  templateUrl: './register.html',
})
export class Register {
  constructor(private router: Router) {}

  onClickGoToLoginPage() {
    this.router.navigate(['']);
  }

}
