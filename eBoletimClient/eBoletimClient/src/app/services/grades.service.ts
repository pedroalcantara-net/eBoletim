import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GeneralService } from './general.service';

@Injectable({
  providedIn: 'root',
})
export class GradesService {
  constructor(
    public toastr: ToastrService,
    public router: Router,
    private http: HttpClient,
    private general: GeneralService
  ) {}

  header = new HttpHeaders({ 'Content-Type': 'application/json' });

  getGradeById(id: number) {
    return this.http.get<any>(`/api/grade/${id}`);
  }

  getGrades() {
    return this.http.get<any[]>('/api/grade/list');
  }

  insertGrades(grade: {
    studentId: number;
    classId: number;
    grade: number;
    quarter: number;
  }) {
    return this.http.post<any>('/api/grade/insert', JSON.stringify(grade), {
      headers: this.header,
    });
  }

  updateGrade(grade: {
    id: number;
    studentId: number;
    classId: number;
    grade: number;
    quarter: number;
  }) {
    return this.http.patch<any>('/api/grade/update', JSON.stringify(grade), {
      headers: this.header,
    });
  }

  deleteGrade(gradeId: any) {
    return this.http.delete(`/api/grade/${gradeId}/delete/`);
  }

  alertStudent(studentId: any) {
    return this.http.get(`/api/grade/alert/${studentId}`);
  }
}
