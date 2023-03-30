import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class SignalrService {
  constructor(public toastr: ToastrService, public router: Router) {}

  hubConnection: signalR.HubConnection;
  personName: string;
  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/base', {
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

  askServer() {
    this.hubConnection
      .invoke('StartCon', 'client')
      .then(() => {

      })
      .catch((err) => console.error(err));
  }

  askServerListener() {
    this.hubConnection.on('startConResponse', (sometext) => [

    ]);
  }
}
