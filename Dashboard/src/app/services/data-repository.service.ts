import { HttpClient, HttpClientModule, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, firstValueFrom, lastValueFrom, Observable } from 'rxjs';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';
import { Approach } from '../models/approach';
import { Configuration } from '../models/configuration';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class DataRepositoryService {

  objectives: Observable<Objective[]> = new Observable<Objective[]>();
  concerns: Observable<Concern[]> = new Observable<Concern[]>();
  approaches: Observable<Approach[]> = new Observable<Approach[]>();
  
  baseUrl = 'http://localhost:5000';
  
  constructor(private http: HttpClient, private localStorage: LocalStorageService) {
    this.objectives = this.http.get<Objective[]>(
      this.baseUrl + '/api/Objectives',
      {observe: 'body', responseType: 'json'});

    this.concerns = this.http.get<Concern[]>(
      this.baseUrl + '/api/concerns',
      {observe: 'body', responseType: 'json'});

    this.approaches = this.http.get<Approach[]>(
      this.baseUrl + '/api/approaches',
      {observe: 'body', responseType: 'json'});

    // this.setupConfiguration = this.http.get<setupConfiguration[]>(
    //   this.baseUrl + '/api/setupConfiguration',
    //   {observe: 'body', responseType: 'json'});
  }

  getObjectives(): Observable<Objective[]> {
    return this.objectives;
  }


  getConcerns(): Observable<Concern[]> {
    return this.concerns;
  }

  getApproaches(): Observable<Approach[]> {
    // let approaches = new Observable<Approach[]>((subscriber) => {
    //   subscriber.next([
    //   {
    //     id: 1,
    //     name: 'Health checks',
    //     description: 'Periodically ping services to see if they are up',
    //     implementationDifficulty: 'easy',
    //     maintenanceDifficulty: 'easy',
    //     concernId: 1,
    //   }
    //   ]);
    // });
    return this.approaches;
  }

  async getConfiguration(): Promise<Configuration> {
    let approaches = await lastValueFrom(this.getApproaches());

    let params = new HttpParams();

    approaches.forEach(approach => {
      let selected = this.localStorage.get(`approach${approach.id}`);
      if (selected == 'true') {
        params = params.append('approachIds', approach.id);
      } 
    })
    let observable = this.http.get<Configuration>(
      this.baseUrl + '/api/configurations',
      {observe: 'body', responseType: 'json', params: params})
      .pipe(
        catchError((error : HttpErrorResponse) => {
          return new Observable<Configuration>((observer) => {
            let description;
            if (error.status == 404) {
              description = "Sorry, this configuration has not been created yet";
            }
            else if (error.status == 500) {
              description = "Sorry, there was an issue with the database";
            }
            else if (error.status == 0) {
              description = "The connection to the backend was refused, is it running?";
            }
            else {
              description = "There was a http exception with code " + error.status;
            }
            
            observer.next({id: -1, setupFiles: "", description: description, image: "", markdown: ""});
          });
        })
      );
    
    return firstValueFrom(observable);
  }
}