import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  signUpBtn: boolean = false;
  loginData = { "email": "", "password": "" }
  token: any;
  constructor(public htp: HttpClient, private rout: Router) {
  }

  sendLogin(): void {
    this.htp.post("http://localhost:6478/login",
      this.loginData, { "observe": "response" }).subscribe(r => {
        if (r.status == 200) {
          this.token = (r as any).body.tok1;
          let clientId = (r as any).body.clientData.clientId;
          sessionStorage.setItem('jwt', this.token);
          sessionStorage.setItem('clientData', clientId);
          sessionStorage.setItem("role", (r as any).body.clientData.role);
          this.rout.navigate(['editUser']);
        }
      },
      (error) =>{alert(error.error.message)}
      );
  }
  signUpClicked() {
    this.signUpBtn = !this.signUpBtn;
  }

  ngOnInit(): void {
    if (sessionStorage.getItem("role") == "User" || sessionStorage.getItem("role") == "Admin") {
      this.rout.navigate(['editUser']);
    }
  }

}
