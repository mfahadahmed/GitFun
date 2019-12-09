import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/_services/repository.service';
import { NotifierService } from 'angular-notifier';
import { AuthService } from 'src/app/_services/auth.service';
import { Repository } from 'src/app/_models/repository';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-repository',
  templateUrl: './create-repository.component.html',
  styleUrls: ['./create-repository.component.css']
})
export class CreateRepositoryComponent implements OnInit {
  model: Repository = {};

  constructor(private repoService: RepositoryService, private notifier: NotifierService,
    private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  createRepository() {
    this.model.owner = this.authService.getUserId();

    this.repoService.createRepository(this.model).subscribe(() => {
        this.notifier.notify('success', 'Repository created successfully');
        this.router.navigate(['/repositories']);
      }, (err) => {
        this.notifier.notify('error', err.error);
      }
    );
  }

  cancel = () => this.router.navigate(['/repositories']);

  getOwner = () => this.authService.getUsername();
}
