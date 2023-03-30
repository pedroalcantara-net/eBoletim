import { Component, OnInit } from '@angular/core';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'eBoletimClient';

  constructor(public signalrService: SignalrService) {}

  ngOnInit() {
    this.signalrService.startConnection();
    setTimeout(() => {
      this.signalrService.askServerListener();
      this.signalrService.askServer();
    }, 1000);
  }

  ngOnDestroy() {
    this.signalrService.hubConnection.off('startConResponse');
  }
}
