import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GeneralService } from './general.service';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(
    public toastr: ToastrService,
    public router: Router,
    private http: HttpClient,
    private general: GeneralService
  ) {}

  getPerson(id:number) {
    return this.http.get<any[]>(`/api/person/${id}`);
  }

  getPersonByRoleId(id:number) {
    return this.http.get<any[]>(`/api/person/list/${id}`);
  }

  insertPerson(person:{
    name: string,
    surname: string,
    cpf: string,
    email: string,
    password: string,
    roleId: number
  }){
    return this.http.post<any>(`/api/person/insert`,person);
  }
}
