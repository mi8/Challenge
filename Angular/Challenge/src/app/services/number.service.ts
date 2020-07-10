import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { map, catchError, retry } from 'rxjs/operators';
import { NumberResult } from '../models/number-result.model';
import { NbToastrService } from '@nebular/theme';

@Injectable({
  providedIn: 'root'
})
export class NumberService {

  baseUrl: string = 'http://localhost:5000/api/number/';
  errorMessage: string = '';
  errorTry: string;
  errorResult: string;
  initTry: number;

  constructor(public toastrService: NbToastrService, private _client: HttpClient) { }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  // HTTP Get 
  getNumberResult(userNumber: number): Observable<any> {
    return this._client.get<NumberResult>(this.baseUrl + userNumber)
    .pipe(
      //catchError(this.handleError)
      catchError((error: any) => {
        if(error instanceof HttpErrorResponse) {
          ////Test HttpErrorResponse
          //this.errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}\nBody: ${error.error}`;
          ////Show no of tries
          //this.errorTry = `Try: ${JSON.stringify(parseInt(error.error.try, 10)-1)}`;
          this.errorTry = `Try: ${JSON.stringify(error.error.try)}`;
          ////Show result status
          this.errorResult = `Result: ${JSON.stringify(error.error.result)}`;
          console.log(error.error.try);
              if(error.status == 404){
                console.log(error);
                console.log(error.error.result);
                console.log(error.error.try);
                  this.toastrService.show(this.errorResult);
                  this.toastrService.show(this.errorTry);
              }
              else{
                if(error.status == 400){
                  this.errorResult = `${JSON.stringify(error.error)}`;
                  
                console.log(error);
                console.log(error.error);
                this.toastrService.show(this.errorResult);
              }}
        }
        return throwError(error);
    }));
  }

  // HTTP Get
  initGame(userNumber: number): Observable<any> {
    return this._client.get<NumberResult>(this.baseUrl + userNumber)
    .pipe(retry(
      19
      // this.initTry
      ),
      catchError(e => {
        if(e.error instanceof ErrorEvent) {
          // Get client-side error
          this.errorMessage = e.error.message;
        } else {
          // Get server-side error
          console.log(e.error.try);
          // if(e.status == 404){
          //   this.initTry = parseInt(e.error.try, 10);
          // }
          if(e.status == 400){
          // this.errorMessage = `${JSON.stringify(e.error)}`;
          this.errorMessage = "Number successfully generated"
          }
        }
        this.toastrService.show(this.errorMessage);
        return throwError(e);
      })
      )
  }


  // HTTP Get
  initInGame(userNumber: number, tryCount: number): Observable<any> {
    return this._client.get<NumberResult>(this.baseUrl + userNumber)
    .pipe(
        retry(tryCount),
      catchError(e => {
        if(e.error instanceof ErrorEvent) {
          // Get client-side error
          this.errorMessage = e.error.message;
        } else {
          // Get server-side error
          console.log(e.error.try);
          if(e.status == 400){
          // this.errorMessage = `${JSON.stringify(e.error)}`;
          this.errorMessage = "Number successfully generated"
          }
        }
        this.toastrService.show(this.errorMessage);
        return throwError(e);
      })
    )
  }

  initEndGame(userNumber: number): Observable<any> {
    return this._client.get<NumberResult>(this.baseUrl + userNumber)
    .pipe(
        retry(19),
      catchError(e => {
        if(e.error instanceof ErrorEvent) {
          // Get client-side error
          this.errorMessage = e.error.message;
        } else {
          // Get server-side error
          console.log(e.error.try);
          if(e.status == 400){
          // this.errorMessage = `${JSON.stringify(e.error)}`;
          this.errorMessage = "Number successfully generated"
          }
        }
        this.toastrService.show(this.errorMessage);
        return throwError(e);
      })
    )
  }

}