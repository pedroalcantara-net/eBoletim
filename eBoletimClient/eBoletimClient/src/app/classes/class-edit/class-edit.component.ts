import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassesService } from 'src/app/services/classes.service';
import { GeneralService } from 'src/app/services/general.service';
import { PersonService } from 'src/app/services/person.service';
import { SubjectsService } from 'src/app/services/subjects.service';

@Component({
  selector: 'app-class-edit',
  templateUrl: './class-edit.component.html',
  styleUrls: ['./class-edit.component.css'],
})
export class ClassEditComponent implements OnInit {
  public subjects: any[];
  public teachers: any[];
  public id: number;
  public classe: any;
  constructor(
    private general: GeneralService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectService: SubjectsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    let idUrl = this.route.snapshot.paramMap.get('id');
    this.getTeachers();
    this.getSubjects();
    if (idUrl != null) {
      this.id = parseInt(idUrl);

      this.classesService
        .getClassesById(this.id)
        .subscribe((tempClass: any) => {
          this.classe = tempClass;
        });
    }
  }

  editClass(classeInput: {
    year: string;
    teacherId: string;
    subjectId: string;
  }) {
    this.classesService
      .updateClasses({
        id: this.classe.id,
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
