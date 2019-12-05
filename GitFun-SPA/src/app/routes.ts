import { Routes } from '@angular/router';
import { RepositoryListComponent } from './repository-list/repository-list.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { ProfileComponent } from './profile/profile.component';
import { StarListComponent } from './star-list/star-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'profile', component: ProfileComponent },
            { path: 'repositories', component: RepositoryListComponent },
            { path: 'projects', component: ProjectListComponent },
            { path: 'stars', component: StarListComponent },
            { path: 'users', component: UserListComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];