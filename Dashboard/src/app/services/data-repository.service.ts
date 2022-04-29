import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';
import { Approach } from '../models/approach';

@Injectable({
  providedIn: 'root'
})
export class DataRepositoryService {

  objectives: Observable<Objective[]> = new Observable<Objective[]>();
  concerns: Observable<Concern[]> = new Observable<Concern[]>();
  approaches: Observable<Approach[]> = new Observable<Approach[]>();
  
  baseUrl = 'http://localhost:5000';
  
  constructor(private http: HttpClient) {
    this.objectives = this.http.get<Objective[]>(
      this.baseUrl + '/api/objectives',
      {observe: 'body', responseType: 'json'});

    /*this.concerns = this.http.get<Concern[]>(
      this.baseUrl + '/api/concerns',
      {observe: 'body', responseType: 'json'});

    this.approaches = this.http.get<Approach[]>(
      this.baseUrl + '/api/approaches',
      {observe: 'body', responseType: 'json'});
      */
  }

  getObjectives(): Observable<Objective[]> {
    return this.objectives;
  }

  getConcerns(): Observable<Concern[]> {
    //return this.concerns;
    let concerns: Observable<Concern[]> = new Observable<Concern[]>((subscriber) => {
      subscriber.next([
        {
          id: 1,
          name: 'Availability',
          description: 'description',
          objectiveId: 0,
        },
        {
          id: 2,
          name: 'Performance',
          description: 'description',
          objectiveId: 0,
        },
        {
          id: 3,
          name: 'User behaviour',
          description: 'description',
          objectiveId: 0,
        },
        {
          id: 4,
          name: 'Error Management',
          description: 'description',
          objectiveId: 1,
        },
        {
          id: 5,
          name: 'Network Security',
          description: 'description',
          objectiveId: 1,
        },
        {
          id: 6,
          name: 'Scalability',
          description: 'description',
          objectiveId: 2,
        },
        {
          id: 7,
          name: 'Capacity planning',
          description: 'description',
          objectiveId: 2,
        }
      ]);
    });
    return concerns;
  }

  getApproaches(): Observable<Approach[]> {
    let approaches = new Observable<Approach[]>((subscriber) => {
      subscriber.next([
      {
        id: 1,
        name: 'Health checks',
        description: 'Periodically ping services to see if they are up',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 1,
      },
      {
        id: 2,
        name: 'Work metrics',
        description: 'Metrics on how the services are running, like latency, throughput, etc.',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 1,
      },
      {
        id: 3,
        name: 'Distributed tracing',
        description: 'Track requests across services to link events and produce timelines.',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 2,
      },
      {
        id: 4,
        name: 'Application logs',
        description: 'Logs that are produced within the application. This requires source code instrumentation.',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 2,
      },
      {
        id: 5,
        name: 'Alert system',
        description: 'Send alerts to stakeholders as reaction to specific events or thresholds.',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 4,
      },
      {
        id: 6,
        name: 'Network logs',
        description: 'Monitor network log to analyse traffic and identify malicious activity.',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 5,
      },
      {
        id: 7,
        name: 'Resource metrics',
        description: 'Monitor CPU, storage and memory usage',
        implementationDifficulty: 'easy',
        maintenanceDifficulty: 'easy',
        concernId: 1,
      }
      ]);
    });
    return approaches;
  }
}