import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/_services/repository.service';
import { NotifierService } from 'angular-notifier';
import { AuthService } from 'src/app/_services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Repository } from 'src/app/_models/repository';

@Component({
  selector: 'app-repository-details',
  templateUrl: './repository-details.component.html',
  styleUrls: ['./repository-details.component.css']
})
export class RepositoryDetailsComponent implements OnInit {
  repository: Repository;
  editMode = false;

  constructor(private repoService: RepositoryService, private notifier: NotifierService,
    private router: Router, private route: ActivatedRoute, private authService: AuthService) { }

  ngOnInit() {
    this.getRepositoryDetails();
  }

  getRepositoryDetails() {
    const repoId = this.route.snapshot.params['id'];
    console.log('Repo Id:' + repoId);

    this.repoService.getRepositoryDetails(repoId).subscribe(
      data => {
        console.log('Repo Details: ');
        console.log(data);
        this.repository = data;
      },
      err => this.notifier.notify('error', err.error)
    );
  }

  toggleEditMode() {
    this.editMode = !this.editMode;
  }

  disableEditMode() {
    this.editMode = false;
  }

  getOwner = () => this.authService.getUsername();
}
