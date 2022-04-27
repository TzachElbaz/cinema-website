import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  client=   {
    "clientId": "",
    "firstName": "",
    "lastName": "",
    "email": "",
    "phone": "",
    "password": "",
    "creditCardNumber": "",
    "role": "User"
  }

  constructor(public htp:HttpClient, private rout:Router) { }

  ngOnInit(): void {
    if(sessionStorage.getItem("role")=="User"||sessionStorage.getItem("role")=="Admin"){
      this.rout.navigate(['editUser']);
  }
  }

  postNewUser():void{
    this.htp.post("http://localhost:6478/signup",
    this.client,{"observe":"response"}).subscribe(c=>alert(c.statusText));
    this.rout.navigate(['login']);
  }

}
