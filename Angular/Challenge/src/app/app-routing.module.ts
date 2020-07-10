import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NumberComponent } from './components/number/number.component';
import { HomeComponent } from './components/home/home.component';
import { MtgComponent } from './components/mtg/mtg.component';
import { MtgDetailsComponent } from './components/mtg-details/mtg-details.component';
import { MtgResolverService } from './resolvers/mtg-resolver.service';


const routes: Routes = [
  //Start at home component => index.html
  {path: '', component: HomeComponent},
  {path: 'number', component: NumberComponent},
  {path: 'mtg', component: MtgComponent},
  {path: 'mtgdetails/:url', resolve: { mtg: MtgResolverService}, component: MtgDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
