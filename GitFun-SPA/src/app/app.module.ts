import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { NotifierModule } from 'angular-notifier';
import { JwtModule } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { RepositoryListComponent } from './repository-list/repository-list.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { StarListComponent } from './star-list/star-list.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { appRoutes } from './routes';
import { UserRowComponent } from './users/user-row/user-row.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { OverviewComponent } from './overview/overview.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      HomeComponent,
      RegisterComponent,
      RepositoryListComponent,
      ProjectListComponent,
      StarListComponent,
      UserListComponent,
      UserRowComponent,
      UserDetailComponent,
      OverviewComponent
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
      }),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/auth']
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
