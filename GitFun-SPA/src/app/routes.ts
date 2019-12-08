import { Routes } from '@angular/router';
import { RepositoryListComponent } from './repository-list/repository-list.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { StarListComponent } from './star-list/star-list.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { OverviewComponent } from './overview/overview.component';
import { EditUserComponent } from './edit-user/edit-user.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'overview', component: OverviewComponent },
            { path: 'repositories', component: RepositoryListComponent },
            { path: 'projects', component: ProjectListComponent },
            { path: 'stars', component: StarListComponent },
            { path: 'users', component: UserListComponent },
            { path: 'edituser', component: EditUserComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];