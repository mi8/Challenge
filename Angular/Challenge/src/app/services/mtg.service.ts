import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MtgList } from '../models/mtg-list.model';
import { MtgDetail } from '../models/mtg-detail.model';
import { Router, NavigationEnd } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MtgService {

  constructor(private _client: HttpClient) { }

  getAll(url: string): Observable<MtgList> {
    return this._client.get<MtgList>(url);
  }

  getOne(url: string): Observable<MtgDetail>
  {
    return this._client.get<MtgDetail>(url);
  }
 
}