import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GeneralService } from './general.service';

@Injectable({
  providedIn: 'root',
})
export class SubjectsService {
  constructor(
    public toastr: ToastrService,
    public router: Router,
    private http: HttpClient,
    private general: GeneralService
  ) {}

  header = new HttpHeaders({ 'Content-Type': 'application/json' });

  getSubjectById(id:number)
  {
    return this.http.get<any>(`/api/subjects/${id}`);
  }

  getSubjects() {
    return this.http.get<any[]>('/api/subjects/list');
  }

  insertSubjects(newSubject: string) {
    return this.http.post<string>('/api/subjects/insert',JSON.stringify(newSubject),{headers:this.header})
  }

  updateSubjects(subject: any) {
    return this.http.patch('/api/subjects/update',subject)
  }

  deleteSubject(subjectId: any)
  {
    return this.http.delete(`/api/subjects/${subjectId}/delete/`)
  }
}
