import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'add-screening',
  templateUrl: './add-screening.component.html',
  styleUrls: ['./add-screening.component.css']
})
export class AddScreeningComponent implements OnInit {

  allMovies: any;
  screenings: any;
  selectedID: number = 0;
  token: any;
  header = new HttpHeaders();
  order = { "date": "", "time": "" };
  today = new Date().toISOString().split('T')[0];

  constructor(public http: HttpClient, private rout: Router) { }

  ngOnInit(): void {
    if (sessionStorage.getItem("role") != "Admin") {
      this.rout.navigate(['unauthorized']);
    }
    this.token = sessionStorage.getItem('jwt');
    this.header = this.header.append("Authorization", "Bearer " + this.token);
    this.http.get("http://localhost:6478/Admin",
      { "observe": "response", "headers": this.header })
      .subscribe(m => this.allMovies = m.body);
  }

  getScreenings(selectedMovieId: number) {
    this.http.get("http://localhost:6478/Admin/screening/" + selectedMovieId,
      { "observe": "response", "headers": this.header })
      .subscribe(s => this.screenings = s.body);
    this.selectedID = selectedMovieId;
  }

  postNewScreening() {
    let days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    let dayName: string = days[new Date(this.order.date).getDay()];
    this.http.post("http://localhost:6478/Admin/screening/" + this.selectedID,
      {
        "movieId": this.selectedID,
        "day": dayName,
        "date": this.order.date,
        "hour": this.order.time,
      }, { "observe": "response", "headers": this.header }).subscribe(g => {
        this.http.get("http://localhost:6478/Admin/screening/" + this.selectedID,
          { "observe": "response", "headers": this.header }).subscribe(
            s => this.screenings = s.body)
      });
  }

  deleteScreening(screeningId: number) {
    if (!confirm("Are you sure you want to remove this screening?")) return;
    this.http.delete("http://localhost:6478/Admin/screening/" + this.selectedID,
      { "observe": "response", "headers": this.header, "body": screeningId }).subscribe(g => {
        this.http.get("http://localhost:6478/Admin/screening/" + this.selectedID,
          { "observe": "response", "headers": this.header })
          .subscribe(s => this.screenings = s.body)
      },(error)=>alert("There are orders for this screening"));
  }

  deleteMovie() {
    if (!confirm("Are you sure you want to remove this movie permanently?")) return;
    this.http.delete("http://localhost:6478/Admin/" + this.selectedID,
      { "observe": "response", "headers": this.header })
      .subscribe(g =>window.location.reload(),
      (error)=>(alert("There are active screenings for this Movie")));
  }

}
