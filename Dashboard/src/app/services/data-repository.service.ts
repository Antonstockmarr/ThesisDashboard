import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';
import { Approach } from '../models/approach';
import { setupConfiguration } from '../models/setConfiguration';

@Injectable({
  providedIn: 'root'
})
export class DataRepositoryService {

  objectives: Observable<Objective[]> = new Observable<Objective[]>();
  concerns: Observable<Concern[]> = new Observable<Concern[]>();
  approaches: Observable<Approach[]> = new Observable<Approach[]>();
  setupConfiguration: Observable<setupConfiguration[]> = new Observable<setupConfiguration[]>(); 
  
  baseUrl = 'http://localhost:5000';
  
  constructor(private http: HttpClient) {
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

  getSetupConfiguration(): Observable<setupConfiguration[]> {
    return this.setupConfiguration;
  }
}