import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ResultsService {
  constructor(public toastr: ToastrService, public router: Router, private http:HttpClient) {}

  hubConnection: signalR.HubConnection;

  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/resultcon', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    this.hubConnection
      .start()
      .then(() => {
      })
      .catch((err) => {});
  };

  askServer(userId: number) {
    this.hubConnection
      .invoke('StartCon', userId)
      .then((response: string) => {
        this.toastr.success("Connection established")
      })
      .catch((err) => console.error(err));
  }


  getResults() {
    return this.http.get<any[]>('/api/results/list');
  }

  getChart(id:number)
  {
    return this.http.get<any[]>(`/api/results/${id}/chart`);
  }
}
