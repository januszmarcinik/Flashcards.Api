import {Component, OnInit} from '@angular/core';
import {CardsService} from '../../../services/cards.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {MatDialog} from '@angular/material';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpErrorResponse} from '@angular/common/http';
import {QUILL_EDITOR_MODULES} from '../../../../../constans/constans';

@Component({
  selector: 'app-card-add',
  templateUrl: './card-add.component.html',
  styleUrls: ['./card-add.component.less']
})
export class CardAddComponent implements OnInit {

  deck: string;

  modules: any;
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
    this.deck = this.route.snapshot.paramMap.get('deck');
    this.cardForm = this.buildForm();
    this.modules = QUILL_EDITOR_MODULES;
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      title: new FormControl('', [Validators.required, Validators.maxLength(128)]),
      question: new FormControl('', Validators.required),
      answer: new FormControl('', Validators.required)
    });
  }

  save() {
    this.cardsService.add(this.deck, this.cardForm.value)
      .subscribe((response) => {
        if (response.ok) {
          this.router.navigate(
            [`/flashcards/decks/${this.deck}/cards`]);
        }
      }, (ex: HttpErrorResponse) => {
        this.errors = ex.error.message;
      });
  }

  goBack(): void {
    this.router.navigate(
      [`flashcards/decks/${this.deck}/cards`]
    );
  }

}
