import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.less']
})

export class SidebarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  goToCategories(topic: string): void {
    this.router.navigate([`flashcards/topics/${topic}/categories`]);
  }

}
