import { Time } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {

  constructor(public http:HttpClient, private rout:Router) { }
  movie=   {
    "Title": "",
    "Director": "",
    "MovieLength":"",
    "Summary": "",
    "PosterPhoto": "aaaa",
    NumberOfScreenings:0
  }


  redirectPage(){
    this.rout.navigate(['addScreening']);
  }

  onFileUpload(event:any){
    const file:File = event.target.files[0];
    }

    addMovie(){
      let token=sessionStorage.getItem("jwt");
      let header=new HttpHeaders();
      header = header.append("Authorization","Bearer "+token);
      this.http.post("http://localhost:6478/admin",
       this.movie,{"observe":"response","headers":header}).subscribe(c=>{
         alert(c.statusText);
         this.redirectPage();
        });
    }

  ngOnInit(): void {
    if(sessionStorage.getItem("role")!="Admin"){
      this.rout.navigate(['unauthorized']);
  }
  }
}
