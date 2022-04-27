import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataRepositoryService {

  focusAreas: any[] = [];

  constructor(private http: HttpClient) {
    this.http.get<ArrayBuffer>(
      this.baseUrl + '/api/focusAreas',
      {observe: 'body', responseType: 'json'})
      .subscribe((data) => {
        this.focusAreas = JSON.parse(JSON.stringify(data));
      })
  }

  baseUrl = 'http://localhost:5000';


  getFocusAreas(): any[] {
  return this.focusAreas
  }
}