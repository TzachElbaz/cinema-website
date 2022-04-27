import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit  } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'success-page',
  templateUrl: './success-page.component.html',
  styleUrls: ['./success-page.component.css']
})
export class SuccessPageComponent implements OnInit  {

  userOrders:any;
  header = new HttpHeaders();
  orderId=sessionStorage.getItem("orderId");

  constructor(private http:HttpClient,private rout:Router) {
    if(sessionStorage.getItem("orderId")=="0"){
      this.rout.navigate(['unauthorized']);
      return;
    }
    let token = sessionStorage.getItem("jwt");
    this.header = this.header.append("Authorization", "Bearer " + token);
    http.get("http://localhost:6478/user/neworder/" + this.orderId,
    { "observe": "response", "headers": this.header }).subscribe(o => this.userOrders = o.body);
    sessionStorage.setItem("orderId","0");
   }

  backHome(){
    this.rout.navigate(["homePage"]);
  }

  ngOnInit(): void {
    if (sessionStorage.getItem("role") != "User" && sessionStorage.getItem("role") != "Admin") {
      this.rout.navigate(['login']);
    }
  }


}
