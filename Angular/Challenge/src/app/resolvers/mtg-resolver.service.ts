import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MtgService } from '../services/mtg.service';
import { MtgDetail } from '../models/mtg-detail.model';

@Injectable({
  providedIn: 'root'
})
export class MtgResolverService {

  constructor(private mtgService: MtgService) { }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  resolve(route: ActivatedRouteSnapshot): 
  Observable<MtgDetail> {
    return this.mtgService.getOne('https://api.scryfall.com/cards/' + route.params['url'])
  }
}