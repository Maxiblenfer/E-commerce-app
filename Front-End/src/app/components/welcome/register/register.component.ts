import { Component, OnInit } from '@angular/core';
import {
  AbstractControlOptions,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Gender } from 'src/app/models/Select';
import { User } from 'src/app/models/User';
import { LoginService } from 'src/app/services/login.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [MessageService],
})
export class RegisterComponent implements OnInit {
  formRegister: FormGroup;
  minDate: Date = new Date();
  emailtaken = true;
  loading = false;
  genders: Gender[] = [
    { name: 'Male', value: 'Male' },
    {
      name: 'Female',
      value: 'Female',
    },
  ];
  selectedGender: string = '';
  constructor(
    private title: Title,
    private fb: FormBuilder,
    private httpLogin: LoginService,
    private messageService: MessageService,
    private httpUser: UserService,
    private router: Router
  ) {
    title.setTitle('Register');
    this.formRegister = fb.group(
      {
        names: ['', Validators.required],
        lastnames: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmpassword: ['', Validators.required],
        birthdate: [this.minDate, Validators.required],
        gender: [this.genders[0].value, Validators.required],
        email: ['', [Validators.required, Validators.email]],
      },
      {
        validators: [this.checkPassword],
      } as AbstractControlOptions
    );
  }

  ngOnInit() {
    this.minDate.setFullYear(this.minDate.getFullYear() - 18);
    console.log(this.formRegister);
  }

  checkPassword(group: FormGroup): any {
    const password1 = group.controls['password'].value;
    const password2 = group.controls['confirmpassword'].value;
    return password1 === password2 ? null : { notSame: true };
  }

  checkEmail() {
    const Object: any = {
      email: this.formRegister.value.email,
    };
    console.log(Object.email);

    this.httpLogin.checkEmail(Object).subscribe((data) => {
      console.log(data);

      if (data.message == 'yes') {
        this.emailtaken = false;
      } else {
        this.emailtaken = true;
      }
    });
  }
  registerUser() {
    console.log(this.formRegister);
    if (this.formRegister.valid && !this.emailtaken) {
      this.loading = true;
      const user: User = {
        Id: 0,
        names: this.formRegister.value.names.trim(),
        lastnames: this.formRegister.value.lastnames.trim(),
        password: this.formRegister.value.password,
        birthdate: this.formRegister.value.birthdate,
        gender: this.formRegister.value.gender,
        email: this.formRegister.value.email.trim(),
      };
      console.log(user);
      this.httpUser.registerUser(user).subscribe(
        (data) => {
          this.showMessage(
            'User registered succesfully',
            `the user ${user.names.toUpperCase()} ${user.lastnames.toUpperCase()} has been registered succesfully, now check your email to activate your account`,
            'success'
          );
          this.formRegister.reset();
          this.loading = false;
          setTimeout(() => {
            this.router.navigate(['/welcome/login']);
          }, 10000);
        },
        (error) => {
          this.showMessage('Error', 'An error has happened', 'error');
          this.loading = false;
        }
      );
    }
  }
  showMessage(title: string, description: string, logo: string) {
    this.messageService.add({
      severity: logo,
      summary: title,
      detail: description,
    });
  }
}
