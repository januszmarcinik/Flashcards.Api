import {Component, OnInit} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';

import {Deck} from '../../../models/deck';
import {DecksService} from '../../../services/decks.service';
import {CardsService} from '../../../services/cards.service';
import {MatDialog} from '@angular/material';
import {ConfirmDeleteComponent} from '../../../../shared/components/confirm-delete/confirm-delete.component';
import {AlertService} from '../../../../shared/services/alert.service';

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
              private decksService: DecksService,
              private cardService: CardsService,
              private dialog: MatDialog,
              private alertService: AlertService) {
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

  delete(deck: Deck) {
    this.cardService.getByDeck(this.topic, this.category, deck.name).subscribe(resp => {
      const cardCount = resp.body.length;
      if (cardCount > 0) {
        const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
          data: {'title': `This deck has a ${cardCount} cards. Are you sure to remove everything?`}
        });
        this.alertAndDeleteCard(dialogRef, deck);

      } else {
        const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
          data: {'name': deck.name}
        });

        this.alertAndDeleteCard(dialogRef, deck);
      }
    });
  }

  getDecks() {
    this.decksService.getByCategory(this.topic, this.category).subscribe(resp => {
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
    );
  }

  private alertAndDeleteCard(dialogRef: any, deck: Deck) {
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.decksService.delete(this.topic, this.category, deck).subscribe(delResp => {
          if (delResp.ok) {
            this.ngOnInit();
          }
        }, (err: HttpErrorResponse) => {
          this.alertService.handleError(err);
        });
      }
    });
  }

}
