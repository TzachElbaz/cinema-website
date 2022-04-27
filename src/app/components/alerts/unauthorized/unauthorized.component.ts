import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent implements OnInit {

  constructor(private rout:Router) { }

  backHome(){
    this.rout.navigate(["homePage"]);
  }

  ngOnInit(): void {
  }

}
