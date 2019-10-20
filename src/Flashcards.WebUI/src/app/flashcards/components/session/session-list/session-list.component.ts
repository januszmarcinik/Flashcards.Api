import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {HttpErrorResponse} from '@angular/common/http';
import {SessionListItem} from '../../../models/session/sessionListItem';
import {SessionService} from '../../../services/session.service';

@Component({
  selector: 'app-session-list',
  templateUrl: './session-list.component.html',
  styleUrls: ['./session-list.component.less']
})
export class SessionListComponent implements OnInit {

  private sessions: SessionListItem[];
  private deck: string;

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
    this.sessionsService.getMySessions(this.deck).subscribe(resp => {
      if (resp.ok) {
        this.sessions = resp.body;
      }
    }, (err: HttpErrorResponse) => {
      this.alertService.handleError(err);
    });
  }

  goToCards(): void {
    this.router.navigate(
      [`/flashcards/decks/${this.deck}/cards`]);
  }
}
