import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {HttpErrorResponse} from '@angular/common/http';
import {SessionListItem} from '../../../models/session/sessionListItem';
import {SessionService} from '../../../services/session.service';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-session-list',
  templateUrl: './session-list.component.html',
  styleUrls: ['./session-list.component.less']
})
export class SessionListComponent implements OnInit {

  private deck: string;
  displayedColumns = ['no', 'date', 'result'];
  dataSource: MatTableDataSource<SessionListItem>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private sessionsService: SessionService,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.getSessions();
  }

  getSessions() {
    this.sessionsService.getMySessions(this.deck)
      .subscribe((sessions) => {
        this.dataSource = new MatTableDataSource(sessions.body);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      });
  }

  goToCards(): void {
    this.router.navigate(
      [`/flashcards/decks/${this.deck}/cards`]);
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }
}
