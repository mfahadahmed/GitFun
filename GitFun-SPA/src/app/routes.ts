import { Routes } from '@angular/router';
import { RepositoryListComponent } from './repositories/repository-list/repository-list.component';
import { StarListComponent } from './star-list/star-list.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { OverviewComponent } from './overview/overview.component';
import { EditUserComponent } from './users/edit-user/edit-user.component';
import { CreateRepositoryComponent } from './repositories/create-repository/create-repository.component';
import { RepositoryDetailsComponent } from './repositories/repository-details/repository-details.component';
import { ProjectsListComponent } from './projects/projects-list/projects-list.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'overview', component: OverviewComponent },
            { path: 'projects', component: ProjectsListComponent },
            { path: 'users', component: UserListComponent },
            { path: 'edituser', component: EditUserComponent },
            { path: 'createrepo', component: CreateRepositoryComponent },
            { path: 'repositories', component: RepositoryListComponent },
            { path: 'repositories/:id', component: RepositoryDetailsComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];