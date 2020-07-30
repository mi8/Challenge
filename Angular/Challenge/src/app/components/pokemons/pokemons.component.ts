import { Component, OnInit } from "@angular/core";
import { DataService } from "src/app/services/data.service";
import {
  map,
  switchMap,
} from "rxjs/operators";
import { zip, merge, Observable, forkJoin } from "rxjs";
import { Pokemon } from "src/app/models/pokemon";
import { Pokedex } from 'src/app/models/pokedex';

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
            map((pokemons) => {
              return { ...data, results: pokemons };
            })
          );
        }),
      )
      .subscribe((data) => {
          this.pokemons = data;
        });
  }
}
