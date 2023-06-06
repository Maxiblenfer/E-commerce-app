import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/User';
import { LoginService } from 'src/app/services/login.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  UserData!:User;
  Token: string = '';
  constructor(private httpuser: UserService, private httplogin: LoginService) {}
  ngOnInit(): void {
    

    this.httpuser.GetUserData().subscribe((data) => {
      
      this.UserData=data;
    });
  }
}
