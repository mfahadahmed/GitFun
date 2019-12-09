import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/_services/repository.service';
import { NotifierService } from 'angular-notifier';
import { Repository } from 'src/app/_models/repository';
import { AuthService } from 'src/app/_services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-repository-list',
  templateUrl: './repository-list.component.html',
  styleUrls: ['./repository-list.component.css']
})
export class RepositoryListComponent implements OnInit {
  repositories: Repository[];

  constructor(private repoService: RepositoryService, private notifier: NotifierService,
    private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.getAllUserRepositories(this.authService.getUserId());
  }

  getAllUserRepositories(id: string) {
    this.repoService.getAllRepositoriesByUser(id).subscribe(
      repoList => {
        this.repositories = repoList;
      },
      err => this.notifier.notify('error', err.error)
    );
  }

  createRepo() {
    this.router.navigate(['/createrepo']);
  }

  deleteRepo(repoId: string) {
    this.repoService.deleteRepository(repoId).subscribe(
      () => this.getAllUserRepositories(this.authService.getUserId()),
      (err) => this.notifier.notify('error', err.error),
    );
  }
}
