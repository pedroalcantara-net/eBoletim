import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../services/general.service';
import { ResultsService } from '../services/results.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})

export class DashboardComponent implements OnInit {
  public configuration: Config;
  public columns: Columns[];
  public data: any[];
  constructor(
    private general: GeneralService,
    private resultsService: ResultsService
  ) {}

  ngOnInit(): void {
    let logged = localStorage.getItem('isLoggedIn');
    if (logged != 'true') {
      this.general.router.navigateByUrl('/auth');
    }

    let role = localStorage.getItem('userRole');

    if (role == 'Teacher') {
      this.general.router.navigateByUrl('/home');
    }
    let id = localStorage.getItem('userId') + '';
    let userId = parseInt(id);

    this.resultsService.getChart(userId).subscribe((response)=>{
      this.updateTable(response);
    })

    this.resultsService.startConnection();
    setTimeout(() => {
      this.resultsService.askServer(userId);
      this.resultsListener(userId);
      //this.resultsService.startHttpRequest(userId);
    }, 1000);

    this.columns = [
      { key: 'subject', title: 'Subject' },
      { key: 'teacherName', title: 'Teacher' },
      { key: 'year', title: 'Year' },
      { key: 'quarter1', title: 'Q1' },
      { key: 'quarter2', title: 'Q2' },
      { key: 'quarter3', title: 'Q3' },
      { key: 'quarter4', title: 'Q4' },
      { key: 'average', title: 'Average' },
      { key: 'status', title: 'Status' },
    ];
  }

  resultsListener(userId: number) {
    this.resultsService.hubConnection.on(
      'NewResults_' + userId,
      (results) => {
        console.log("escuta")
        this.updateTable(results);
      }
    );
  }

  updateTable(results: any) {
    this.data = results;
  }
}
