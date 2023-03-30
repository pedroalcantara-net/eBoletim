import { Injectable } from '@angular/core';
import { GeneralService } from './general.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from './../shared/models/person.model';
import { Role } from './../shared/models/role.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient, private general: GeneralService) {}
  header = new HttpHeaders({ 'Content-Type': 'application/json' });

  async authMe(user: string, pass: string) {
    let login = { CPF: user, Password: pass };

    this.http
      .post<number>(`/api/Login/Login`, JSON.stringify(login), {
        headers: this.header,
      })
      .subscribe({
        next: (response) => {
          localStorage.setItem('userId', response.toString());
          this.checkUser(response);
        },
        error: (error) => {
          this.general.toastr.error(
            'Incorrect CPF or Password. Check your credentials and try again.'
          );
        },
      });
  }

  async checkUser(userId: number) {
    this.http.get<Person>(`/api/Person/${userId}`).subscribe({
      next: (response) => {
        this.checkUserRole(response.roleId);
      },
      error: (error) => {
        this.general.toastr.error(
          "Couldn't retrieve user info. Try again later."
        );
      },
    });
  }

  async checkUserRole(roleId: number) {
    this.http.get<Role>(`/api/Roles/${roleId}`).subscribe({
      next: (response) => {
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('userRole', response.role);
        if (response.role === 'Teacher') {
          this.general.router.navigateByUrl('/home');
        } else {
          this.general.router.navigateByUrl('/dashboard');
        }
      },
      error: (error) => {
        this.general.toastr.error(
          "Couldn't retrieve user role info. Try again later."
        );
      },
    });
  }
}
