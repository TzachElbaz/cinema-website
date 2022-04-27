import { NgModule } from '@angular/core';
import { FormsModule,  ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import {IvyCarouselModule} from 'angular-responsive-carousel';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatAutocompleteModule} from '@angular/material/autocomplete';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { LoginComponent } from './components/login/login.component';
import { AddMovieComponent } from './components/Admin/add-movie/add-movie.component';
import { AddScreeningComponent } from './components/Admin/add-screening/add-screening.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MovieSliderComponent } from './components/movie-slider/movie-slider.component';
import { EditUserComponent } from './components/User/edit-user/edit-user.component';
import { UnauthorizedComponent } from './components/alerts/unauthorized/unauthorized.component';
import { SuccessPageComponent } from './components/alerts/success-page/success-page.component';
import { SearchingFilterPipe } from './searching-filter.pipe';
import { NewOrderComponent } from './components/User/new-order/new-order.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    LoginComponent,
    AddMovieComponent,
    AddScreeningComponent,
    MovieSliderComponent,
    EditUserComponent,
    UnauthorizedComponent,
    SuccessPageComponent,
    SearchingFilterPipe,
    NewOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    IvyCarouselModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatAutocompleteModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
