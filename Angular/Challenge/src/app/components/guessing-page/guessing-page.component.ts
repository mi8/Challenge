import { Component, OnInit } from "@angular/core";
import { NumbersService } from "../../services/numbers.service";
import { tap } from "rxjs/operators";
import { element } from "protractor";

@Component({
  selector: "app-guessing-page",
  templateUrl: "./guessing-page.component.html",
  styleUrls: ["./guessing-page.component.scss"],
})
export class GuessingPageComponent implements OnInit {
  message: string = "";
  number: number;
  answer:boolean;

  constructor(private gameService: NumbersService) {}

  ngOnInit(): void {}

  onClick() {
    this.number = this.getRandomNumber(1, 50000);
    this.gameService
      .game(this.number)
      .pipe(tap((element) => (this.message = element.message,this.answer = element.answer)))
      .subscribe();
  }

  getRandomNumber(min, max) {
    return Math.random() * (max - min) + min;
  }
}
