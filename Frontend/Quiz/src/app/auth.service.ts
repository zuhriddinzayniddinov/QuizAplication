import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  login(credations: any) {
    this.http.post<any>('https://localhost:44315/api/Accaunt', credations)
      .subscribe(response => {
        localStorage.setItem('name',response.name);
        localStorage.setItem('role',response.role);
        localStorage.setItem('accessToken', response.accessToken);
        localStorage.setItem('expireDate', response.expireDate);
      });
    this.router.navigate(['/']);
  }

  get Name() {
    return localStorage.getItem('name');
  }

  register(credations: any) {
    this.http.post<any>('https://localhost:44315/api/Accaunt/Register', credations)
      .subscribe(response => {
        console.log(response);
      });
    this.router.navigate(['login']);
  }

  logout() {
    localStorage.clear();
  }

  get role(){
    let userRole = localStorage.getItem('role');

    return userRole == 'Admin' || userRole == 'Maker';
  }

  get isAuth(){
    return !!localStorage.getItem('accessToken');
  }
}
