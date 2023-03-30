import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SubjectsService } from 'src/app/services/subjects.service';
import { GeneralService } from 'src/app/services/general.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-subject-edit',
  templateUrl: './subject-edit.component.html',
  styleUrls: ['./subject-edit.component.css'],
})
export class SubjectEditComponent implements OnInit {
  id: number;
  form: FormGroup;
  subjectName: string;

  constructor(
    public subjectService: SubjectsService,
    public general: GeneralService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    let idUrl = this.route.snapshot.paramMap.get('id');
    if (idUrl != null) {
      this.id = parseInt(idUrl);

      this.subjectService.getSubjectById(this.id).subscribe((subject: any) => {
        this.subjectName = subject.subjectName;
      });
    }
  }

  updateSubject(newSubjectName: string) {
    this.subjectService
      .updateSubjects({ id: this.id, subjectName: newSubjectName })
      .subscribe((res) => {
        this.general.router.navigateByUrl('/subjects');
      });
  }
}
