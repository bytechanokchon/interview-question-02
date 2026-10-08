import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {

   loginForm!: FormGroup;

  constructor(
    private router: Router, 
    private fb: FormBuilder, 
    private authService: AuthService,
    private cookieService: CookieService
  ) { }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }

  ngOnInit() {
    this.initialForm();
  }

  initialForm() {
    this.loginForm = this.fb.group({
      username: [
        '',
        [
          Validators.required
        ]
      ],

      password: [
        '',
        [
          Validators.required
        ]
      ]
    });
  }

  onClickToRegisterPage(): void {
    this.router.navigate(['/register']);
  }

   onSubmit() {

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const username: string = this.loginForm.get("username")?.value;
    const password: string = this.loginForm.get("password")?.value;

    this.authService.login(username, password).subscribe((response: any) => {
      if (response.isSuccess) {
        const token = response.value;

        this.cookieService.set(
          'access_token',
          token,
          60/1440,    // อายุ 1 ชั่วโมง
          '/',
          undefined,
          true,       // Secure
          'Strict'    // SameSite
        );

        this.router.navigate(['/user-info']);

      } else {
        window.alert(response.message);
      }
    });
  }
}
