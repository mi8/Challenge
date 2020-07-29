import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Api } from '../models/message'

@Injectable({
  providedIn: 'root'
})
export class NumbersService {

  gameUrl: string = "http://localhost:3000/api/number"

  constructor(private http:HttpClient) { }

  game(id:number): Observable<Api>{
    return this.http.get<Api>(`${this.gameUrl}/${id}`)
  }
}
