import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { ClassAddComponent } from './classes/class-add/class-add.component';
import { ClassEditComponent } from './classes/class-edit/class-edit.component';
import { ClassesListComponent } from './classes/classes-list/classes-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GradesAddComponent } from './grades/grades-add/grades-add.component';
import { GradesEditComponent } from './grades/grades-edit/grades-edit.component';
import { GradesListComponent } from './grades/grades-list/grades-list.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SubjectEditComponent } from './subjects/subject-edit/subject-edit.component';
import { SubjectListComponent } from './subjects/subject-list/subject-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full',
  },
  {
    path: 'auth',
    component: AuthComponent,
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'subjects',
    component: SubjectListComponent,
  },
  {
    path: 'subjects/:id/edit',
    component: SubjectEditComponent,
  },
  {
    path: 'classes',
    component: ClassesListComponent,
  },
  {
    path: 'class/add',
    component: ClassAddComponent,
  },
  {
    path: 'class/:id/edit',
    component: ClassEditComponent,
  },
  {
    path: 'grades',
    component: GradesListComponent,
  },
  {
    path: 'grades/add',
    component: GradesAddComponent,
  },
  {
    path: 'grade/:id/edit',
    component: GradesEditComponent,
  },
  {
    path: 'signup',
    component: SignUpComponent,
  },
  {
    path: '**',
    redirectTo: 'auth',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
