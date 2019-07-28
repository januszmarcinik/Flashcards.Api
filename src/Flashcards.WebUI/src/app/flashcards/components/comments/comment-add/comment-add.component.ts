import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpErrorResponse} from '@angular/common/http';
import {ActivatedRoute, Router} from '@angular/router';
import {AlertService} from '../../../../shared/services/alert.service';
import {MatDialog} from '@angular/material';
import {QUILL_EDITOR_MODULES} from '../../../../../constans/constans';
import {CommentsService} from '../../../services/comments.service';

@Component({
  selector: 'app-comment-add',
  templateUrl: './comment-add.component.html',
  styleUrls: ['./comment-add.component.less']
})
export class CommentAddComponent implements OnInit {

  @Input() deck: string;
  @Output() onSave = new EventEmitter();

  cardId: string;
  modules = QUILL_EDITOR_MODULES;

  commentForm: FormGroup;
  errors: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private dialog: MatDialog,
              private formBuilder: FormBuilder,
              private alertService: AlertService,
              private commentsService: CommentsService) {
  }

  ngOnInit() {
    this.commentForm = this.buildForm();
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      text: new FormControl('', [Validators.required, Validators.maxLength(512)]),
    });
  }

  save() {
    this.commentsService.add(this.deck, this.cardId, this.commentForm.value)
      .subscribe((response) => {
        if (response.ok) {
          this.onSave.emit();
          this.commentForm.setValue({
            text: ''
          });
        }
      }, (ex: HttpErrorResponse) => {
        this.errors = ex.error.message;
      });
  }

}
