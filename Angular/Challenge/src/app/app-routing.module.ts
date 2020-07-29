import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuessingPageComponent } from './components/guessing-page/guessing-page.component';
import { PokemonsComponent } from './components/pokemons/pokemons.component';


const routes: Routes = [
  {path:'', component: PokemonsComponent},
  {path:'game', component: GuessingPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
