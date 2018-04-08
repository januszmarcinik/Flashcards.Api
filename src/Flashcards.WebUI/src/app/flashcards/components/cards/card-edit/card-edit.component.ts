import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {CardsService} from '../../../services/cards.service';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {MatDialog} from '@angular/material';
import {Card} from '../../../models/cards/card';

@Component({
  selector: 'app-card-edit',
  templateUrl: './card-edit.component.html',
  styleUrls: ['./card-edit.component.less']
})
export class CardEditComponent implements OnInit {

  topic: string;
  category: string;
  deck: string;
  cardId: string;

  card: Card;
  cardForm: FormGroup;
  errors: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private dialog: MatDialog,
              private formBuilder: FormBuilder,
              private alertService: AlertService,
              private cardsService: CardsService) {
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    this.category = this.route.snapshot.paramMap.get('category');
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.cardId = this.route.snapshot.paramMap.get('card');

    this.loadCard();
    this.cardForm = this.buildForm();
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      id: new FormControl('', [Validators.required]),
      title: new FormControl('', [Validators.required, Validators.maxLength(32)]),
      question: new FormControl('', Validators.required),
      answer: new FormControl('', Validators.required)
    });
  }

  loadCard(): void {
    this.cardsService.getById(this.topic, this.category, this.deck, this.cardId)
      .subscribe((card) => {
        this.card = card.body;
        this.cardForm.setValue({
          id: this.card.id,
          title: this.card.title,
          question: this.card.question,
          answer: this.card.answer
        });
      });
  }

  save() {
    this.cardsService.edit(this.topic, this.category, this.deck, this.cardForm.value)
      .subscribe((response) => {
        if (response.ok) {
          this.router.navigate(
            [`/flashcards/topics/${this.topic}/categories/${this.category}/decks/${this.deck}/cards`]);
        }
      }, (ex: HttpErrorResponse) => {
        this.errors = ex.error.message;
      });
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/topics/${this.topic}/categories/${this.category}/decks/${this.deck}/cards`]
    )
  }

}
