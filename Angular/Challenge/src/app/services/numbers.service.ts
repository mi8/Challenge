import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { GuessGame } from '../models/message'

@Injectable({
  providedIn: 'root'
})
export class NumbersService {

  gameUrl: string = "http://localhost:3000/api/number"

  constructor(private http:HttpClient) { }

  game(num:number): Observable<GuessGame>{
    return this.http.get<GuessGame>(`${this.gameUrl}/${num}`)
  }
}
