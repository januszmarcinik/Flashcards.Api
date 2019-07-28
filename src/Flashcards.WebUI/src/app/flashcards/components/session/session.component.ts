import {Component, OnInit} from '@angular/core';
import {SessionService} from "../../services/session.service";
import {SessionState} from "../../models/session/sessionState";
import {ActivatedRoute, Router} from "@angular/router";
import {AlertService} from "../../../shared/services/alert.service";
import {HttpErrorResponse} from "@angular/common/http";
import {SessionCardStatus} from "../../models/session/sessionCardStatus";

@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.less']
})
export class SessionComponent implements OnInit {

  deck: string;
  sessionState: SessionState;
  isAnswerShown: boolean;

  constructor(private sessionService: SessionService,
              private route: ActivatedRoute,
              private router: Router,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.getSessionState();
  }

  getSessionState(): void {
    this.sessionService.getSessionState(this.deck)
      .subscribe((result) => {
        this.sessionState = result.body;
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      });
  }

  applySessionCard(status: SessionCardStatus): void {
    this.isAnswerShown = false;
    let command = {
      cardId: this.sessionState.card.cardId,
      status: status
    };
    this.sessionService.applySessionCard(this.deck, command)
      .subscribe((result) => {
        this.sessionState = result.body;
        if (this.sessionState.isFinished) {
          this.goBack();
        }
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      });
  }

  doNotYet(): void {
    this.applySessionCard(SessionCardStatus.doNotYet);
  }

  notSure(): void {
    this.applySessionCard(SessionCardStatus.notSure);
  }

  alreadyDone(): void {
    this.applySessionCard(SessionCardStatus.alreadyDone);
  }

  toggleShowAnswer(): void {
    this.isAnswerShown = !this.isAnswerShown;
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards`]
    );
  }

}
