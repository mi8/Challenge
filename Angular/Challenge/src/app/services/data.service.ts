import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Pokedex } from "../models/pokedex";
import { Pokemon } from "../models/pokemon";

@Injectable({
  providedIn: "root",
})
export class DataService {
  // pokemonUrl:string='https://pokeapi.co/api/v2/pokemon/?offset=0&limit=807'
  singlePokemonUrl: string = "https://pokeapi.co/api/v2/pokemon";
  pokemonUrl: string = "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=807";

  constructor(private http: HttpClient) {}

  // Get Pokemon
  getPokemons(): Observable<Pokedex> {
    return this.http.get<Pokedex>(`${this.pokemonUrl}`);
  }

  getSinglePokemon(id: string): Observable<Pokemon> {
    return this.http.get<Pokemon>(`${this.singlePokemonUrl}/${id}`);
  }
}
