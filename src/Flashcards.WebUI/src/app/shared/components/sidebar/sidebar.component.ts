import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {environment} from '../../../../environments/environment';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.less']
})

export class SidebarComponent implements OnInit {

  environmentName: string;

  constructor(private router: Router) {
    this.environmentName = environment.name;
  }

  ngOnInit() {
  }

  goToCategories(topic: string): void {
    this.router.navigate([`flashcards/topics/${topic}/categories`]);
  }

}
