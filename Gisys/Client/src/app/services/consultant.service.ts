import { Injectable } from '@angular/core';
import { Consultant } from '../models/Consultant';
import { Http, Response, RequestOptions } from '@angular/http';  
import { Router } from '@angular/router';  
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { FlashMessagesService } from 'angular2-flash-messages';
import { ConsultantRequest } from '../models/ConsultantRequest';

@Injectable({
  providedIn: 'root'
})
export class ConsultantService {

  apiUrl = "https://localhost:44373/v1/Consultant";
  consultant: Consultant;
  constructor(
    private http: Http,
    private flashM: FlashMessagesService,
    private router: Router
  ) { }

  getConsultantCollection(): Observable<Consultant[]> {
    return this.http.get(this.apiUrl)
    .pipe(
      map(data => {
        return <Consultant[]>data.json();
      })
    );
  }

  getConsultant(id: string): Observable<Consultant> {
    return this.http.get(this.apiUrl + '/' + id)
    .pipe(
      map(data => {
        return <Consultant>data.json();
      })
    );
  }

  getConsultantShareOfBonusPot(id: string): Observable<string> {
    return this.http.get(this.apiUrl + '/' + id + '/shareOfBonusPot')
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

  getConsultantBonusPot(id: string, netResult: number): Observable<string> {
    return this.http.get(this.apiUrl + '/' + id + '/' + netResult)
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

  addConsultant(consultantRequest: ConsultantRequest): Observable<string> {
    return this.http.post(this.apiUrl, consultantRequest)
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

  updateConsultant(id: string, consultantRequest: ConsultantRequest): Observable<string> {
    return this.http.put(this.apiUrl + '/' + id, consultantRequest)
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

  deleteConsultant(id: string): Observable<boolean> {
    return this.http.delete(this.apiUrl + '/' + id )
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }
  
}
