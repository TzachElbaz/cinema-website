import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit {

  screeningOptions: any;
  selectedMovie = {
     "title": sessionStorage.getItem("title"),
      "id": 0 };
  btnClicked: boolean = false;
  header = new HttpHeaders();
  order = {
    "clientId": sessionStorage.getItem('clientData'),
    "movieId": Number(sessionStorage.getItem("movieId")),
    "screeningId": 0,
    "numberOfTickets": 1
  };

  constructor(public http: HttpClient, private rout: Router) {

    http.get("http://localhost:6478/user/screening/" + this.order.movieId).subscribe(
      m => this.screeningOptions = m);
  }

  newOrder(screeningId: number) {
    if (sessionStorage.getItem("role") != "User" && sessionStorage.getItem("role") != "Admin")
    {
      alert("Before placing an order you must first Log In");
      this.rout.navigate(['login']);
      return;
    }
    this.order.screeningId = screeningId;
    this.http.post("http://localhost:6478/user",
      this.order, { "observe": "response", "headers": this.header }).subscribe(o=>{
        console.log(o.body);
        sessionStorage.setItem("orderId",(o as any).body.orderId);
        this.rout.navigate(['success']);
      }
      );
  }

  closeForm() {
    this.rout.navigate(['homePage']);
  }

  ngOnInit(): void {
    let token = sessionStorage.getItem("jwt");
    this.header = this.header.append("Authorization", "Bearer " + token);
  }

}
