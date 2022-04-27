import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'movie-slider',
  templateUrl: './movie-slider.component.html',
  styleUrls: ['./movie-slider.component.css']
})
export class MovieSliderComponent implements OnInit {
  allMovies: any;
  screeningOptions: any;
  selectedMovie = { "title": "", "id": 0 };
  btnClicked: boolean = false;
  header = new HttpHeaders();
  order = {
    "clientId": sessionStorage.getItem('clientData'),
    "movieId": 0,
    "screeningId": 0,
    "numberOfTickets": 1
  };

  constructor(public http: HttpClient, private rout: Router) {
    http.get("http://localhost:6478/user").subscribe(
      m => this.allMovies = m);
  }

  orderNowClicked(movieId: number, numberOfScreenings: number, title: string) {
    if (numberOfScreenings == 0) {
      alert("This movie has no screenings available for now");
      return;
    }
    this.http.get("http://localhost:6478/User/screening/" + movieId).subscribe(
      s => this.screeningOptions = s);
    this.btnClicked = true;
    this.selectedMovie.id = movieId;
    this.order.movieId = movieId;
    this.selectedMovie.title = title;
  }
  closeForm() {
    this.btnClicked = false;
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

  ngOnInit(): void {
    let token = sessionStorage.getItem("jwt");
    this.header = this.header.append("Authorization", "Bearer " + token);
  }

}
