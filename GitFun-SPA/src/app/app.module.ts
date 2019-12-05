import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { NotifierModule } from 'angular-notifier';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { RepositoryListComponent } from './repository-list/repository-list.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { StarListComponent } from './star-list/star-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { appRoutes } from './routes';

@NgModule({
   declarations: [
      AppComponent,
      UserComponent,
      NavbarComponent,
      HomeComponent,
      RegisterComponent,
      ProfileComponent,
      RepositoryListComponent,
      ProjectListComponent,
      StarListComponent,
      UserListComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NotifierModule.withConfig({
         position: {
           horizontal: {
             position: 'middle'
           }
         }
      })
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
