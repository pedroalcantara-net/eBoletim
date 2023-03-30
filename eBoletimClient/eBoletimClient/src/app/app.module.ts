import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { ToastrModule } from 'ngx-toastr';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { TableModule } from 'ngx-easy-table';
import { SubjectListComponent } from './subjects/subject-list/subject-list.component';
import { SubjectEditComponent } from './subjects/subject-edit/subject-edit.component';
import { ClassesListComponent } from './classes/classes-list/classes-list.component';
import { ClassEditComponent } from './classes/class-edit/class-edit.component';
import { GradesListComponent } from './grades/grades-list/grades-list.component';
import { GradesEditComponent } from './grades/grades-edit/grades-edit.component';
import { ClassAddComponent } from './classes/class-add/class-add.component';
import { GradesAddComponent } from './grades/grades-add/grades-add.component';
import { SignUpComponent } from './sign-up/sign-up.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    DashboardComponent,
    HomeComponent,
    SubjectListComponent,
    SubjectEditComponent,
    ClassesListComponent,
    ClassEditComponent,
    GradesListComponent,
    GradesEditComponent,
    GradesAddComponent,
    ClassAddComponent,
    SignUpComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    TableModule,
    ToastrModule.forRoot({
      enableHtml: true,
      timeOut: 10000,
      positionClass: 'toast-top-right',
      preventDuplicates: false,
    }),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
