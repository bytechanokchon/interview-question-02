import { Component } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';

interface JwtPayload {
  username: string;
}

@Component({
  imports: [],
  selector: 'app-user-info',
  styleUrl: './user-info.css',
  templateUrl: './user-info.html',
})
export class UserInfo {
  username: string | null = null;

  constructor(private cookieService: CookieService) {}

  ngOnInit() {
    const token = this.cookieService.get('access_token');
    if (!token) {
      return;
    }

    try {
      const payload = jwtDecode<JwtPayload>(token);
      console.log(payload)
      this.username = payload.username ?? '';
    } catch (error) {
      console.error('Invalid JWT token', error);
    }
  }
}
