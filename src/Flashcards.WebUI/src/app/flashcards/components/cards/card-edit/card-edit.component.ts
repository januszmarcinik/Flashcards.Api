import {Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {CardsService} from '../../../services/cards.service';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {MatDialog} from '@angular/material';
import {Card} from '../../../models/card';
import {GUID_EMPTY, QUILL_EDITOR_MODULES} from '../../../../../constans/constans';
import {CommentListComponent} from '../../comments/comment-list/comment-list.component';

@Component({
  selector: 'app-card-edit',
  templateUrl: './card-edit.component.html',
  styleUrls: ['./card-edit.component.less']
})
export class CardEditComponent implements OnInit {

  deck: string;
  cardId: string;

  isReadOnly: boolean = true;
  isAnswerShown: boolean = false;
  previousExists: boolean;
  nextExists: boolean;
  modules: any;

  card: Card;
  cardForm: FormGroup;
  errors: string;

  @ViewChild('commentList', {static: false}) commentList: CommentListComponent;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private dialog: MatDialog,
              private formBuilder: FormBuilder,
              private alertService: AlertService,
              private cardsService: CardsService) {
  }

  ngOnInit() {
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.cardId = this.route.snapshot.paramMap.get('card');

    this.loadCard(this.cardId);
    this.cardForm = this.buildForm();

    this.modules = QUILL_EDITOR_MODULES;
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      id: new FormControl('', [Validators.required]),
      title: new FormControl({value: '', disabled: true}, [Validators.required, Validators.maxLength(128)]),
      question: new FormControl('', Validators.required),
      answer: new FormControl('', Validators.required)
    });
  }

  loadCard(id: string): void {
    this.cardsService.getById(this.deck, id)
      .subscribe((card) => {
        this.card = card.body;
        this.previousExists = this.card.previousCardId != GUID_EMPTY;
        this.nextExists = this.card.nextCardId != GUID_EMPTY;
        this.isAnswerShown = false;

        this.cardForm.setValue({
          id: this.card.id,
          title: this.card.title,
          question: this.card.question,
          answer: this.card.answer
        });
      });
  }

  save() {
    this.cardsService.edit(this.deck, this.cardForm.value)
      .subscribe((response) => {
        if (response.ok) {
          this.isReadOnly = true;
          this.cardForm.controls['title'].disable();
          this.loadCard(this.cardForm.controls['id'].value);
        }
      }, (ex: HttpErrorResponse) => {
        this.errors = ex.error.message;
      });
  }

  cancel(): void {
    this.isReadOnly = true;
    this.cardForm.controls['title'].disable();
  }

  edit(): void {
    this.isReadOnly = false;
    this.isAnswerShown = true;
    this.cardForm.controls['title'].enable();
  }

  prev(): void {
    this.router.navigateByUrl(`/flashcards/topics/It/categories/Azure/decks/${this.deck}/cards/${this.card.previousCardId}`);
    this.loadCard(this.card.previousCardId);
    this.commentList.changeCard(this.card.previousCardId);
  }

  next(): void {
    this.router.navigateByUrl(`/flashcards/topics/It/categories/Azure/decks/${this.deck}/cards/${this.card.nextCardId}`);
    this.loadCard(this.card.nextCardId);
    this.commentList.changeCard(this.card.nextCardId);
  }

  toggleShowAnswer(): void {
    this.isAnswerShown = !this.isAnswerShown;
  }

  confirmCard(): void {
    this.cardsService.confirmCard(this.deck, this.card.id).subscribe(resp => {
      this.card.confirmed = !this.card.confirmed;
    });
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards`]
    );
  }

  onCut($event): void {
    if ($event.target['tagName'].toLowerCase() === 'img') {
      this.alertService.showMessage('You cannot CUT. Use COPY / PASTE / DELETE');
    }
  }

}
