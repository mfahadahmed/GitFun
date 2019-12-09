import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Repository } from '../_models/repository';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  baseUrl = environment.webApiUrl + 'repository/';

  constructor(private http: HttpClient) { }

  createRepository(repository: Repository) {
    return this.http.post(this.baseUrl, repository);
  }

  updateRepository(id: string, repository: Repository) {
    return this.http.put(this.baseUrl + id, repository);
  }

  deleteRepository(id: string) {
    return this.http.delete(this.baseUrl + id);
  }

  getAllRepositories(): Observable<Repository[]> {
    return this.http.get<Repository[]>(this.baseUrl);
  }

  getAllRepositoriesByUser(id: string): Observable<Repository[]> {
    return this.http.get<Repository[]>(this.baseUrl + 'getAllRepositoriesByUser/' + id);
  }

  getRepositoryDetails(id: string): Observable<Repository> {
    return this.http.get<Repository>(this.baseUrl + id);
  }
}
