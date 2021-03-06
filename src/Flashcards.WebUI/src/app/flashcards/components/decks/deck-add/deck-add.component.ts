import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {DecksService} from '../../../services/decks.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-deck-create',
  templateUrl: './deck-add.component.html',
  styleUrls: ['./deck-add.component.less']
})
export class DeckAddComponent implements OnInit {

  deckForm: FormGroup;
  errors: any;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private deckService: DecksService,
              private fb: FormBuilder) {
  }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.deckForm = this.fb.group({
      'name': new FormControl('', [Validators.required, Validators.pattern('([A-Za-z\\d\\-]+)')]),
      'description': new FormControl('', Validators.maxLength(100))
    });
  }

  save() {
    this.deckService.add(this.deckForm.value).subscribe(resp => {
      if (resp.ok) {
        this.router.navigate([`/flashcards/decks`]);
      }
    }, (err: HttpErrorResponse) => {
      console.log(err);
      this.errors = err.error.message;
    });
  }

  goBack(): void {
    this.router.navigate([`/flashcards/decks`]);
  }

}
