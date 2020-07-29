import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PokemonsComponent } from './components/pokemons/pokemons.component';
import { TypecolorsPipe } from './pipe/typecolors.pipe';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { GuessingPageComponent } from './components/guessing-page/guessing-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PokemonsComponent,
    TypecolorsPipe,
    SpinnerComponent,
    GuessingPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NoopAnimationsModule,
    NgxSpinnerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
