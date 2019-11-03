import {Component, OnInit, ViewChild} from '@angular/core';
import {SessionService} from '../../../services/session.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {Card} from '../../../models/card';
import {GUID_EMPTY} from '../../../../../constans/constans';
import {CardsService} from '../../../services/cards.service';
import {CommentListComponent} from '../../comments/comment-list/comment-list.component';

@Component({
  selector: 'app-card-preview',
  templateUrl: './card-preview.component.html',
  styleUrls: ['./card-preview.component.less']
})
export class CardPreviewComponent implements OnInit {

  deck: string;
  cardId: string;
  isAnswerShown: boolean;
  previousExists: boolean;
  nextExists: boolean;
  card: Card;
  @ViewChild('commentList', {static: false}) commentList: CommentListComponent;

  constructor(private sessionService: SessionService,
              private route: ActivatedRoute,
              private router: Router,
              private alertService: AlertService,
              private cardsService: CardsService) {
    this.card = {
      question: '',
      confirmed: false,
      answer: '',
      id: '',
      nextCardId: '',
      previousCardId: ''
    };
  }

  ngOnInit() {
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.cardId = this.route.snapshot.paramMap.get('card');
    this.loadCard(this.cardId);
  }

  loadCard(id: string): void {
    this.cardsService.getById(this.deck, id)
      .subscribe((card) => {
        this.card = card.body;
        this.previousExists = this.card.previousCardId !== GUID_EMPTY;
        this.nextExists = this.card.nextCardId !== GUID_EMPTY;
        this.isAnswerShown = false;
      });
  }

  toggleShowAnswer(): void {
    this.isAnswerShown = !this.isAnswerShown;
  }

  prev(): void {
    this.router.navigateByUrl(`/flashcards/decks/${this.deck}/cards/${this.card.previousCardId}`);
    this.loadCard(this.card.previousCardId);
    this.commentList.changeCard(this.card.previousCardId);
  }

  next(): void {
    this.router.navigateByUrl(`/flashcards/decks/${this.deck}/cards/${this.card.nextCardId}`);
    this.loadCard(this.card.nextCardId);
    this.commentList.changeCard(this.card.nextCardId);
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards`]
    );
  }

}
