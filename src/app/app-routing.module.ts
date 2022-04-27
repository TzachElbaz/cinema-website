import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddMovieComponent } from './components/Admin/add-movie/add-movie.component';
import { AddScreeningComponent } from './components/Admin/add-screening/add-screening.component';
import { SuccessPageComponent } from './components/alerts/success-page/success-page.component';
import { UnauthorizedComponent } from './components/alerts/unauthorized/unauthorized.component';
import { LoginComponent } from './components/login/login.component';
import { MovieSliderComponent } from './components/movie-slider/movie-slider.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { EditUserComponent } from './components/User/edit-user/edit-user.component';
import { NewOrderComponent } from './components/User/new-order/new-order.component';

const routes: Routes = [
    {path:"homePage", component:MovieSliderComponent},
    {path:"signup", component:SignUpComponent},
    {path:"login", component:LoginComponent, children:[
      {path:"editUser", component:EditUserComponent}
    ]},
    {path:"addMovie", component:AddMovieComponent},
    {path:"addScreening", component:AddScreeningComponent},
    {path:"editUser", component:EditUserComponent},
    {path:"unauthorized", component:UnauthorizedComponent},
    {path:"success", component:SuccessPageComponent},
    {path:"newOrder", component:NewOrderComponent},
    {path:"**", redirectTo:"homePage"},
    {path:"", redirectTo:"homePage", pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
