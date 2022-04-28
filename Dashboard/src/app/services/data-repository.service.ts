import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { FocusArea } from '../models/focus-area';

@Injectable({
  providedIn: 'root'
})
export class DataRepositoryService {

  focusAreas: Observable<FocusArea[]> = new Observable<FocusArea[]>();
  
  constructor(private http: HttpClient) {
    this.focusAreas = this.http.get<FocusArea[]>(
      this.baseUrl + '/api/focusAreas',
      {observe: 'body', responseType: 'json'});
  }

  baseUrl = 'http://localhost:5000';


  getFocusAreas(): Observable<FocusArea[]> {
  return this.focusAreas;
  }
}