import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {MatDialog, MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {ActivatedRoute, Router} from '@angular/router';

import {Card} from '../../../models/card';
import {AlertService} from '../../../../shared/services/alert.service';
import {CardsService} from '../../../services/cards.service';
import {ConfirmDeleteComponent} from '../../../../shared/components/confirm-delete/confirm-delete.component';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.less']
})
export class CardListComponent implements OnInit {

  deck: string;

  displayedColumns = ['no', 'question', 'confirmed', 'id'];
  dataSource: MatTableDataSource<Card>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private dialog: MatDialog,
              private alertService: AlertService,
              private cardsService: CardsService) {
  }

  ngOnInit() {
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.loadCards();
  }

  loadCards(): void {
    this.cardsService.getByDeck(this.deck)
      .subscribe((cards) => {
        this.dataSource = new MatTableDataSource(cards.body);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      });
  }

  add(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards/add`]
    );
  }

  edit(card: Card): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards/${card.id}/edit`]
    );
  }

  preview(card: Card): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards/${card.id}`]
    );
  }

  delete(card: Card): void {
    event.stopPropagation();
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      data: {name: card.question}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.cardsService.remove(this.deck, card)
          .subscribe((response) => {
            if (response.ok) {
              this.loadCards();
            }
          }, (ex: HttpErrorResponse) => {
            this.alertService.handleError(ex);
          });
      }
    });
  }

  session(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/session`]
    );
  }

  sessionHistory(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/session-history`]
    );
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/decks`]
    );
  }

}
