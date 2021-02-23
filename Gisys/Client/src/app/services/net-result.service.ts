import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { FlashMessagesService } from 'angular2-flash-messages';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NetResult } from '../models/NetResult';
import { NetResultRequestDto } from '../models/NetResultRequestDto';

@Injectable({
  providedIn: 'root'
})
export class NetResultService {

  apiUrl = "https://localhost:44373/v1/NetResult";
  netResult: NetResult;
  constructor(
    private http: Http,
    private flashM: FlashMessagesService
  ) { }

  getNetResult(): Observable<NetResult> {
    return this.http.get(this.apiUrl)
    .pipe(
      map(data => {
        return <NetResult>data.json();
      })
    );
  }

  createNetResult(netResultRequestDto: NetResultRequestDto): Observable<string> {
    return this.http.post(this.apiUrl, netResultRequestDto)
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

  updateNetResult(id: string, netResultRequestDto: NetResultRequestDto): Observable<string> {
    return this.http.put(this.apiUrl + '/' + id, netResultRequestDto)
    .pipe(
      map(data => {
        return data.json();
      })
    );
  }

}
