import { HttpClient } from '@angular/common/http';
import { Component} from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title: string = 'Cinema';
  btnClicked:boolean = false;
  allMovies:any;
  control = new FormControl();
  filterKey:string="";
  role=sessionStorage.getItem("role");


  orderTickets(movieId:string, title:string){
    sessionStorage.setItem("movieId",movieId);
    sessionStorage.setItem("title",title);
  }

  btnSwitch() {
    this.btnClicked = true;
  }
  refresh():void{
    window.location.reload();
  }
  constructor(http:HttpClient) {
     http.get("http://localhost:6478/user").subscribe(m=>this.allMovies=m);
  }
}



