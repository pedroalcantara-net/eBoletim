import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
import { GradesService } from 'src/app/services/grades.service';
import { PersonService } from 'src/app/services/person.service';
import { ClassesService } from 'src/app/services/classes.service';
import { SubjectsService } from 'src/app/services/subjects.service';

@Component({
  selector: 'app-grades-add',
  templateUrl: './grades-add.component.html',
  styleUrls: ['./grades-add.component.css'],
})
export class GradesAddComponent implements OnInit {
  public data: any[] = [];
  public classes: any[];
  public students: any[];
  constructor(
    private general: GeneralService,
    private gradesService: GradesService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectsService: SubjectsService
  ) {}

  ngOnInit(): void {
    this.getStudents();
    this.getClasses();
  }

  getStudents() {
    this.personService.getPersonByRoleId(2).subscribe((studentList) => {
      this.students = studentList;
    });
  }

  getClasses() {
    this.classesService.getClasses().subscribe((classesList) => {
      for (let classe of classesList) {
        this.subjectsService
          .getSubjectById(classe.subjectId)
          .subscribe((subject) => {
            classe.subjectName = subject.subjectName;
          });
      }
      this.classes = classesList;
    });
  }

  insertGrades(grade: {
    studentId: string;
    classId: string;
    grade: string;
    quarter: string;
  }) {
    this.gradesService
      .insertGrades({
        studentId: parseInt(grade.studentId),
        classId: parseInt(grade.classId),
        grade: parseFloat(grade.grade),
        quarter: parseInt(grade.quarter),
      })
      .subscribe(() => {
        this.general.toastr.success(`Grade registered.`);
        setTimeout(()=>{
          this.general.router.navigateByUrl('grades')
        },2000)
      });
  }
}
