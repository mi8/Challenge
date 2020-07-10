import { Component, OnInit } from '@angular/core';
import { NumberResult } from 'src/app/models/number-result.model';
import { NumberService } from 'src/app/services/number.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NbToastrService } from '@nebular/theme';


@Component({
  selector: 'app-number',
  templateUrl: './number.component.html',
  styleUrls: ['./number.component.scss']
})
export class NumberComponent implements OnInit {

  numberResult: NumberResult;
  inputNumbers: number[];
  errorResponse: any;
  NoOfTries: number = 20;
  inputNumber: number;
  isInit: boolean;
  isInList: boolean;
  winnerStatus: boolean;

  constructor(public toastrService: NbToastrService, private numberService: NumberService) { }

  ngOnInit(): void {
    this.inputNumber = null;
    this.inputNumbers = [];  
    this.errorResponse = { try: null, result: ''};
    this.numberResult = {try: 0, result: ''}
    this.isInit=false;
    //this.winnerStatus = false;
  }


  add(){
    this.inputNumbers.push(this.inputNumber);
    this.NoOfTries--;
  }

  onClick(){          
    if(this.NoOfTries > 0 ){
      if(this.inputNumbers.includes(this.inputNumber)){
        this.toastrService.warning("Number already tried");
      }
      else{
        this.checkResult(this.inputNumber);
        this.add(); 
      }      
    };
  }

  checkResult(number){
    return this.numberService.getNumberResult(number)
    .subscribe(
      data => this.numberResult = data,
      error => this.errorResponse = { try: error.error.try, result: error.error.result})
  }

  initNumber(number: number=0){
    return this.numberService.initGame(number)
    .subscribe(
      error => this.errorResponse = error
    ), this.isInit = true, this.NoOfTries = 20, this.inputNumbers=[], this.inputNumber=null, this.numberResult.result = "";
  }

  initNumberInGame(number : number = 0){
    return this.numberService.initInGame(number, this.NoOfTries)
    .subscribe(
      error => this.errorResponse = error
    ), this.inputNumbers = [], this.NoOfTries = 20, this.inputNumber=null;
  }

  
  // initNumberEndGame(number: number = 0){
  //   return this.numberService.initEndGame(number)
  //   .subscribe(
  //     error => this.errorResponse = error),
  //     this.inputNumbers = [], this.NoOfTries = 20, this.inputNumber=null, this.winnerStatus = true;
  // }

}