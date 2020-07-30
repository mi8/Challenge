import { Component, OnInit } from "@angular/core";
import { NumbersService } from "../../services/numbers.service";
import { catchError, take } from "rxjs/operators";
import { GuessGame } from "src/app/models/message";

@Component({
  selector: "app-guessing-page",
  templateUrl: "./guessing-page.component.html",
  styleUrls: ["./guessing-page.component.scss"],
})
export class GuessingPageComponent implements OnInit {
  message: string = "";
  number: number;
  answer: boolean;

  constructor(private gameService: NumbersService) {}

  ngOnInit(): void {}

  onClick() {
    this.number = this.getRandomNumber(1, 50000);
    this.gameService
      .game(this.number)
      .pipe(
        catchError((err) => {
          this.message =
            "Server offline, please use the NumberController.js file in nodejs";
          return err;
        }),
        take(1)
      )
      .subscribe(
        (element: GuessGame) => (
          (this.message = element.message), (this.answer = element.answer)
        )
      );
  }

  getRandomNumber(min, max) {
    return Math.random() * (max - min) + min;
  }
}
