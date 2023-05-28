import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { PrimeNGConfig } from 'primeng/api';
import { Login } from 'src/app/models/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  FormLogin: FormGroup;
  constructor(
    private primengConfig: PrimeNGConfig,
    private title: Title,
    fb: FormBuilder
  ) {
    title.setTitle('Login');
    this.FormLogin = fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  ngOnInit() {
    this.primengConfig.ripple = true;
  }

  LoginIn() {
    console.log(this.FormLogin.value.email);
    if (this.FormLogin.valid) {
      const login: Login = new Login(
        this.FormLogin.value.email,
        this.FormLogin.value.password
      );
      console.log(login);
      this.FormLogin.reset();
    }
  }
}
