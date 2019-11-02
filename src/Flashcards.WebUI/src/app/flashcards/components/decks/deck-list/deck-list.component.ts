import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';

import {Deck} from '../../../models/deck';
import {DecksService} from '../../../services/decks.service';
import {CardsService} from '../../../services/cards.service';
import {MatDialog, MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {ConfirmDeleteComponent} from '../../../../shared/components/confirm-delete/confirm-delete.component';
import {AlertService} from '../../../../shared/services/alert.service';

@Component({
  selector: 'app-deck-list',
  templateUrl: './deck-list.component.html',
  styleUrls: ['./deck-list.component.less']
})
export class DeckListComponent implements OnInit {

  displayedColumns = ['no', 'name', 'description', 'id'];
  dataSource: MatTableDataSource<Deck>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private decksService: DecksService,
              private cardService: CardsService,
              private dialog: MatDialog,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.getDecks();
  }

  add() {
    this.router.navigate(
      [`/flashcards/decks/add`]);
  }

  edit(deck: Deck) {
    this.router.navigate(
      [`/flashcards/decks/${deck.name}`]);
  }

  delete(deck: Deck) {
    event.stopPropagation();
    this.cardService.getByDeck(deck.name).subscribe(resp => {
      const cardCount = resp.body.length;
      if (cardCount > 0) {
        const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
          data: {title: `This deck has a ${cardCount} cards. Are you sure to remove everything?`}
        });
        this.alertAndDeleteCard(dialogRef, deck);

      } else {
        const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
          data: {name: deck.name}
        });

        this.alertAndDeleteCard(dialogRef, deck);
      }
    });
  }

  getDecks() {
    this.decksService.getAll()
      .subscribe((decks) => {
        this.dataSource = new MatTableDataSource(decks.body);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      });
  }

  goToCards(deck: Deck): void {
    this.router.navigate(
      [`/flashcards/decks/${deck.name}/cards`]);
  }

  private alertAndDeleteCard(dialogRef: any, deck: Deck) {
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.decksService.delete(deck).subscribe(delResp => {
          if (delResp.ok) {
            this.ngOnInit();
          }
        }, (err: HttpErrorResponse) => {
          this.alertService.handleError(err);
        });
      }
    });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

}
