import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Repository } from 'src/app/_models/repository';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { RepositoryService } from 'src/app/_services/repository.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-edit-repository',
  templateUrl: './edit-repository.component.html',
  styleUrls: ['./edit-repository.component.css']
})
export class EditRepositoryComponent implements OnInit {
  @Input() repository: Repository;
  @Output() disableEdit = new EventEmitter();
  
  constructor(private repoService: RepositoryService, private notifier: NotifierService,
    private authService: AuthService) { }

  ngOnInit() {
  }

  editRepository() {
    this.repository.owner = this.getOwnerId();
    this.repoService.updateRepository(this.repository.id, this.repository).subscribe(
      () => {
        this.notifier.notify('success', 'Repository updated successfully');
        this.disableEdit.emit(false);
      },
      (err) => this.notifier.notify('error', err.error)
    );
  }

  getOwner = () => this.authService.getUsername();
  getOwnerId = () => this.authService.getUserId();
}
