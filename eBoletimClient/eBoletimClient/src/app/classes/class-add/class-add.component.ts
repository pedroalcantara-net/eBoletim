import { Component, OnInit } from '@angular/core';
import { ClassesService } from 'src/app/services/classes.service';
import { GeneralService } from 'src/app/services/general.service';
import { PersonService } from 'src/app/services/person.service';
import { SubjectsService } from 'src/app/services/subjects.service';

@Component({
  selector: 'app-class-add',
  templateUrl: './class-add.component.html',
  styleUrls: ['./class-add.component.css'],
})
export class ClassAddComponent implements OnInit {
  public subjects: any[];
  public teachers: any[];
  constructor(
    private general: GeneralService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectService: SubjectsService
  ) {}

  ngOnInit(): void {
    this.getTeachers();
    this.getSubjects();
  }

  insertClass(classeInput: {
    year: string;
    teacherId: string;
    subjectId: string;
  }) {
    this.classesService
      .insertClasses({
        year: parseInt(classeInput.year),
        teacherId: parseInt(classeInput.teacherId),
        subjectId: parseInt(classeInput.subjectId),
      })
      .subscribe(() => {
        this.general.toastr.success(`Class registered.`);
        setTimeout(() => {
          this.general.router.navigateByUrl('classes');
        }, 2000);
      });
  }

  getTeachers() {
    this.personService.getPersonByRoleId(1).subscribe((teacherList) => {
      this.teachers = teacherList;
    });
  }

  getSubjects() {
    this.subjectService.getSubjects().subscribe((subjectList) => {
      this.subjects = subjectList;
    });
  }
}
