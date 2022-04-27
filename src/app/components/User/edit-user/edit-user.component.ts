import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  userData: any;
  userOrders: any;
  token: any;
  userId: any;
  editBtn = false;
  header = new HttpHeaders();
  constructor(public http: HttpClient, public rout: Router) {
    this.userId = sessionStorage.getItem("clientData");
    this.token = sessionStorage.getItem("jwt");
    this.header = this.header.append("Authorization", "Bearer " + this.token);
    http.get("http://localhost:6478/user/self/" + this.userId,
      { "observe": "response", "headers": this.header }).subscribe(u => this.userData = u.body);

    http.get("http://localhost:6478/user/orders/" + this.userId,
      { "observe": "response", "headers": this.header }).subscribe(o => this.userOrders = o.body);
  }

  showEdit() {
    this.editBtn = !this.editBtn;
  }
  saveCahnges() {
    this.showEdit();
    this.http.put("http://localhost:6478/user/" + this.userId, this.userData,
      { "observe": "response", "headers": this.header })
      .subscribe(s => {
        this.http.get("http://localhost:6478/user/self/" + this.userId,
          { "observe": "response", "headers": this.header }).subscribe(u => this.userData = u.body);
      }
      );
  }
  logOut() {
    sessionStorage.clear();
    alert("you are now logged out");
    this.rout.navigate(['login']);
  }

  ngOnInit(): void {
    if (sessionStorage.getItem("role") != "User" && sessionStorage.getItem("role") != "Admin") {
      this.rout.navigate(['login']);
    }
  }
}
