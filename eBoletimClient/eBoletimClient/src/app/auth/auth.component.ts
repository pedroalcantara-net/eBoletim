import { SignalrService } from './../services/signalr.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from './../services/auth.service'

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit, OnDestroy {
  constructor(
    public signalrService: SignalrService,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    localStorage.setItem('isLoggedIn','false');
  }

  ngOnDestroy(): void {}

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    this.auth.authMe(form.value.userName, form.value.password);
  }
}
