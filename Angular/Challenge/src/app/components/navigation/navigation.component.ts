import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  items: NbMenuItem[];
  tabs: any[];

  constructor() { }

  ngOnInit(): void {
    // this.items = [
    //   { link: '/home', title: 'Home', icon: 'home' },
    //   { link: '/starwars', title: 'SWAPI: the Star Wars API', icon: 'award' },
    //   { link: '/mtg', title: 'Magic: The Gathering API', icon: 'award' },
    //   { link: '/number', title: 'Guess the Number', icon: 'award' }
    // ]
    this.tabs = [
      {
        title: 'Home',
        icon: 'home',
        route: '/',
      },
      {
        title: 'Magic: the Gathering API',
        icon: 'award',
        responsive: true,
        route: [ '/mtg' ],
      },
      {
        title: 'Guess the Number',
        icon: 'award',
        responsive: true,
        route: [ '/number' ],
      },
    ];
  }

}
