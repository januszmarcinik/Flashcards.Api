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

  category: string;
  topic: string;
  deckForm: FormGroup;
  errors: any;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private deckService: DecksService,
              private fb: FormBuilder) {
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    this.category = this.route.snapshot.paramMap.get('category');
    this.createForm();
  }

  createForm() {
    this.deckForm = this.fb.group({
      'name': new FormControl('', Validators.required)
    });
  }

  save() {
    this.deckService.add(this.topic, this.category, this.deckForm.value).subscribe(resp => {
      if (resp.ok) {
        this.router.navigate([`/flashcards/topics/${this.topic}/categories/${this.category}/decks`]);
      }
    }, (err: HttpErrorResponse) => {
      console.log(err);
      this.errors = err.message;
    });
  }

  goBack(): void {
    this.router.navigate([`/flashcards/topics/${this.topic}/categories/${this.category}/decks`]);
  }

}
