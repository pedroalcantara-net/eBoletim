import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GeneralService } from './general.service';

@Injectable({
  providedIn: 'root',
})
export class ClassesService {
  constructor(
    public toastr: ToastrService,
    public router: Router,
    private http: HttpClient,
    private general: GeneralService
  ) {}

  header = new HttpHeaders({ 'Content-Type': 'application/json' });

  getClassesById(id: number) {
    return this.http.get<any>(`/api/classes/${id}`);
  }

  getClasses() {
    return this.http.get<any[]>('/api/classes/list');
  }

  insertClasses(classe: {
    year: number;
    teacherId: number;
    subjectId: number;
  }) {
    return this.http.post<string>(
      '/api/classes/insert',
      JSON.stringify(classe),
      { headers: this.header }
    );
  }

  updateClasses(classe: {
    id: number;
    year: number;
    teacherId: number;
    subjectId: number;
  }) {
    return this.http.patch<string>(
      '/api/classes/update',
      JSON.stringify(classe),
      { headers: this.header }
    );
  }

  deleteClass(classId: any) {
    return this.http.delete(`/api/classes/${classId}/delete/`);
  }
}
