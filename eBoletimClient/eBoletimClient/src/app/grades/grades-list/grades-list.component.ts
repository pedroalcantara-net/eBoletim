import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
import { GradesService } from 'src/app/services/grades.service';
import { ResultsService } from 'src/app/services/results.service';
import { PersonService } from 'src/app/services/person.service';
import { ClassesService } from 'src/app/services/classes.service';
import { SubjectsService } from 'src/app/services/subjects.service';
@Component({
  selector: 'app-grades-list',
  templateUrl: './grades-list.component.html',
  styleUrls: ['./grades-list.component.css'],
})
export class GradesListComponent implements OnInit {
  public data: any[] = [];
  public classes: any[];
  public students: any[];
  constructor(
    private general: GeneralService,
    private gradesService: GradesService,
    private resultsService: ResultsService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectsService: SubjectsService
  ) {}

  ngOnInit(): void {
    this.getStudents();
    this.getClasses();
    this.getData();
    setInterval(async () => {
      this.getData();
    }, 10000);
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

  getData() {
    this.resultsService.getResults().subscribe((data: any) => {
      this.updateTable(data);
    });
  }

  updateTable(results: any) {
    this.data = results;
  }

  deleteGrade(id: number, studentId: number) {
    this.gradesService.deleteGrade(id).subscribe(() => {
      this.getData();
      this.general.toastr.success(`Grade ${id} deleted.`);
      this.gradesService.alertStudent(studentId).subscribe(() => {});
    });
  }

  goToAdd() {
    this.general.router.navigateByUrl('/grades/add');
  }

  goToEdit(id: number) {
    this.general.router.navigateByUrl(`grade/${id}/edit`);
  }
}
