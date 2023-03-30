import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../services/general.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private general: GeneralService) { }

  ngOnInit(): void {
    let logged = localStorage.getItem("isLoggedIn");
    if(logged != "true")
    {
      this.general.router.navigateByUrl("/auth")
    }

    let role = localStorage.getItem("userRole");

    if(role != "Teacher")
    {
      this.general.router.navigateByUrl("/dashboard")
    }
  }

  goToClasses(){
    this.general.router.navigateByUrl('/classes');
  }

  goToGrades(){
    this.general.router.navigateByUrl('/grades');
  }

  goToSubjects(){
    this.general.router.navigateByUrl('/subjects');
  }

}
