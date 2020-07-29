import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "typecolors",
})
export class TypecolorsPipe implements PipeTransform {
  transform(type: string): string {
    let color: string;

    switch (type) {
      case "fire":
        color = "red lighten-1";
        break;
      case "water":
        color = "blue lighten-1";
        break;
      case "grass":
        color = "green lighten-1";
        break;
      case "bug":
        color = "#558b2f light-green darken-3";
        break;
      case "normal":
        color = "grey lighten-3";
        break;
      case "flying":
        color = "blue lighten-3";
        break;
      case "poison":
        color = "deep-purple accent-1";
        break;
      case "fairy":
        color = "pink lighten-4";
        break;
      case "psychic":
        color = "#ec407a pink lighten-1";
        break;
      case "electric":
        color = "lime accent-1";
        break;
      case "fighting":
        color = "#bcaaa4 brown lighten-3";
        break;
      case "ground":
        color = "#8d6e63 brown lighten-1";
        break;
      case "dark":
        color = "#424242 grey darken-3";
        break;
      case "steel":
        color = "#e0e0e0 grey lighten-2";
        break;
      case "ghost":
        color = "#9575cd deep-purple lighten-2";
        break;
      case "rock":
        color = "#a1887f brown lighten-2";
        break;
      case "dragon":
        color = "#d1c4e9 deep-purple lighten-4";
        break;
      default:
        color = "grey";
        break;
    }

    // Come from the materialze css
    return "chip " + color;
  }
}
