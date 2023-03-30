import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
import { GradesService } from 'src/app/services/grades.service';
import { ResultsService } from 'src/app/services/results.service';
import { PersonService } from 'src/app/services/person.service';
import { ClassesService } from 'src/app/services/classes.service';
import { SubjectsService } from 'src/app/services/subjects.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-grades-edit',
  templateUrl: './grades-edit.component.html',
  styleUrls: ['./grades-edit.component.css'],
})
export class GradesEditComponent implements OnInit {
  public classes: any[];
  public students: any[];
  public thisGrade: any;
  public id: number;
  public classId: any;
  public studentId: any;
  constructor(
    private general: GeneralService,
    private gradesService: GradesService,
    private resultsService: ResultsService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectsService: SubjectsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    let idUrl = this.route.snapshot.paramMap.get('id');
    if (idUrl != null) {
      this.id = parseInt(idUrl);
      this.gradesService.getGradeById(this.id).subscribe((tempGrade: any) => {
        this.thisGrade = tempGrade;
        this.classId = tempGrade.classId;
        this.studentId = tempGrade.studentId;
      });
    }
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

  updateGrade(grade: {
    studentId: string;
    classId: string;
    grade: string;
    quarter: string;
  }) {
    this.gradesService
      .updateGrade({
        id: this.id,
        studentId: parseInt(grade.studentId),
        classId: parseInt(grade.classId),
        grade: parseFloat(grade.grade),
        quarter: parseInt(grade.quarter),
      })
      .subscribe(() => {
        this.general.toastr.success(`Grade registered.`);
        setTimeout(() => {
          this.general.router.navigateByUrl('grades');
        }, 2000);
      });
  }
}
