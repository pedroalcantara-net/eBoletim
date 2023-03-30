import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
import { PersonService } from 'src/app/services/person.service';
import { ClassesService } from 'src/app/services/classes.service';
import { SubjectsService } from 'src/app/services/subjects.service';

@Component({
  selector: 'app-classes-list',
  templateUrl: './classes-list.component.html',
  styleUrls: ['./classes-list.component.css'],
})
export class ClassesListComponent implements OnInit {
  public configuration: Config;
  public columns: Columns[];
  public data: any[] = [];
  public row: any;
  public modal = false;
  public subjects: any[];
  public teachers: any[];
  constructor(
    private general: GeneralService,
    private personService: PersonService,
    private classesService: ClassesService,
    private subjectService: SubjectsService
  ) {}

  ngOnInit(): void {
    this.getData();
    setInterval(async () => {
      this.getData();
    }, 15000);
  }

  getData() {
    this.classesService.getClasses().subscribe((data: any) => {
      for (let classe of data) {
        this.subjectService
          .getSubjectById(classe.subjectId)
          .subscribe((subject) => {
            classe.subjectName = subject.subjectName;
          });

        this.personService
          .getPerson(classe.teacherId)
          .subscribe((teacher: any) => {
            classe.teacherName = teacher.name + ' ' + teacher.surname;
          });
      }
      this.updateTable(data);
    });
  }

  updateTable(results: any) {
    this.data = results;
  }

  editClass(id:number){
    this.general.router.navigateByUrl(`class/${id}/edit`)
  }

  deleteClass(id: number) {
    // let rowData = this.data[index];
    this.classesService.deleteClass(id).subscribe(() => {
      this.general.toastr.success(`Class ${id} deleted.`)
      this.getData();
    });
  }

  goToAdd(){
    this.general.router.navigateByUrl('/class/add')
  }
}
