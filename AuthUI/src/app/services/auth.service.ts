import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    private readonly apiUrl = 'https://localhost:7276/api/Auths';

    constructor (private http: HttpClient) {

    }

    register(username: string, password: string) {
        return this.http.post(`${this.apiUrl}/Register`, {
            username: username,
            password: password
        });
    }

    login(username: string, password: string) {
        return this.http.post(`${this.apiUrl}/Login`, {
            username: username,
            password: password
        });
    }
}