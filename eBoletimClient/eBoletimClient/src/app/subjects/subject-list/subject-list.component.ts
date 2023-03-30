import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { SubjectsService } from '../../services/subjects.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css'],
})
export class SubjectListComponent implements OnInit {
  public configuration: Config;
  public columns: Columns[];
  public data: any[] = [];
  public row: any;
  public modal = false;
  constructor(
    private general: GeneralService,
    private subjectsService: SubjectsService
  ) {}

  ngOnInit(): void {
    this.getData();
    setInterval(async () => {
      this.getData();
    }, 10000);

    this.columns = [
      { key: 'id', title: 'ID' },
      { key: 'subjectName', title: 'Subject' },
    ];
  }

  getData() {
    this.subjectsService.getSubjects().subscribe((data: any) => {
      this.updateTable(data);
    });
  }

  updateTable(results: any) {
    this.data = results;
  }

  editSubject(id: number) {
    this.general.router.navigateByUrl(`/subjects/${id}/edit`);
  }

  deleteSubject(id: number) {
    // let rowData = this.data[index];
    this.subjectsService.deleteSubject(id).subscribe(() => {
      this.getData();
    });
  }

  insertSubject(subject: string) {
    if (subject != '') {
      this.subjectsService.insertSubjects(subject).subscribe(() => {
        this.general.toastr.success(`${subject} registered.`);
        this.getData();
      });
    } else {
      this.general.toastr.error("'Subject' field was empty.");
    }
  }

  hideModal() {
    this.modal = false;
  }
}
