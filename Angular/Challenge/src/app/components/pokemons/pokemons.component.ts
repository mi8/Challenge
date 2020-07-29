import { Component, OnInit } from "@angular/core";
import { Pokedex } from "../../models/pokedex";
import { DataService } from "src/app/services/data.service";
import {
  map,
  tap,
  switchMap,
  mergeAll,
  combineAll,
  delay,
} from "rxjs/operators";
import { zip, merge, Observable, forkJoin } from "rxjs";
import { Pokemon } from "src/app/models/pokemon";

@Component({
  selector: "app-pokemons",
  templateUrl: "./pokemons.component.html",
  styleUrls: ["./pokemons.component.scss"],
})
export class PokemonsComponent implements OnInit {
  pokemons: Pokedex;

  constructor(private pokemonService: DataService) {}

  ngOnInit(): void {
    this.pokemonService
      // Get All Data
      .getPokemons()
      .pipe(
        map((data) => {
          const pokedexResultsWithId = data.results.map((pokedexResults) => {
            const splittedUrl = pokedexResults.url.split("/");
            return {
              ...pokedexResults,
              id: splittedUrl[splittedUrl.length - 2],
            };
          });
          return { ...data, results: pokedexResultsWithId };
        }),
        switchMap((data) => {
          return forkJoin(
            ...data.results.map((item) =>
              this.pokemonService.getSinglePokemon(item.id).pipe(
                map((pokemon: Pokemon) => {
                  return { ...item, pokemon };
                })
              )
            )
          ).pipe(
            map((pokemons: Array<Pokemon>) => {
              return { ...data, results: pokemons };
            })
          );
        }),
        tap(console.log),
        tap((data) => {
          this.pokemons = data;
        })
      )
      .subscribe();
  }
}
