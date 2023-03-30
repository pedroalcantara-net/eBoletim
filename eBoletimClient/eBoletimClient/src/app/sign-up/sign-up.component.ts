import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../services/general.service';
import { PersonService } from '../services/person.service';
import { ValidationService } from '../services/validation.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent implements OnInit {
  constructor(
    public validation: ValidationService,
    private general: GeneralService,
    private personService: PersonService
  ) {}

  ngOnInit(): void {}

  signUp(signUp: {
    name: string;
    surname: string;
    cpf: string;
    email: string;
    password: string;
    passwordC: string;
    roleId: string;
  }) {
    let valid = true;
    if (
      signUp.cpf == '' ||
      signUp.name == '' ||
      signUp.surname == '' ||
      signUp.password == '' ||
      signUp.email == '' ||
      signUp.passwordC == ''
    ) {
      this.general.toastr.error(
        'There are empty fields! Check your credentials and try again.'
      );
      valid = false;
    }
    if (!this.validation.validateCPF(signUp.cpf)) {
      this.general.toastr.error(
        'Invalid CPF! Check your credentials and try again.'
      );
      valid = false;
    }
    if (!this.validation.validateEmail(signUp.email)) {
      this.general.toastr.error(
        'Invalid E-mail! Check your credentials and try again.'
      );
      valid = false;
    }
    if (signUp.password != signUp.passwordC) {
      this.general.toastr.error(
        "Passwords don't match! Check your credentials and try again."
      );
      valid = false;
    }

    if (valid) {
      this.personService
        .insertPerson({
          name: signUp.name,
          surname: signUp.surname,
          cpf: signUp.cpf,
          email: signUp.email,
          password: signUp.password,
          roleId: parseInt(signUp.roleId),
        })
        .subscribe({
          next: () => {
            this.general.toastr.success("Complete!")
            setTimeout(()=>{
              this.general.router.navigateByUrl('auth')
            },2000)
          },
          error: () => {
            this.general.toastr.error(
              'An error occurred. Try again later.'
            );
          },
        });
    }
  }
}
