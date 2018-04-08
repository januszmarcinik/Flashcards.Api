import {Component, OnInit} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';

import {Deck} from '../../../models/deck';
import {DecksService} from '../../../services/decks.service';

@Component({
  selector: 'app-deck-list',
  templateUrl: './deck-list.component.html',
  styleUrls: ['./deck-list.component.less']
})
export class DeckListComponent implements OnInit {

  decks: Deck[];
  category: string;
  topic: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private decksService: DecksService) {
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    this.category = this.route.snapshot.paramMap.get('category');
    this.getDecks();
  }

  add() {
    this.router.navigate(
      [`/flashcards/topics/${this.topic}/categories/${this.category}/decks/add`]);
  }

  edit(deck: Deck) {
    this.router.navigate(
      [`/flashcards/topics/${this.topic}/categories/${this.category}/decks/${deck.name}`]);
  }

  getDecks() {
    this.decksService.getDecks(this.topic, this.category).subscribe(resp => {
      if (resp.ok) {
        this.decks = resp.body;
      }
    }, (err: HttpErrorResponse) => {
      console.log(err.message);
    });
  }

  goToCards(deck: Deck): void {
    this.router.navigate(
      [`/flashcards/topics/${this.topic}/categories/${this.category}/decks/${deck.name}/cards`]);
  }

  goBack(): void {
    this.router.navigate(
      [`/flashcards/topics/${this.topic}/categories`]
    )
  }

}
