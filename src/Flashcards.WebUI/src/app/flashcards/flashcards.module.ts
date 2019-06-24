import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CategoryListComponent} from './components/categories/category-list/category-list.component';
import {RouterModule} from '@angular/router';
import {SharedModule} from '../shared/shared.module';
import {CategoriesService} from './services/categories.service';
import {CategoryAddComponent} from './components/categories/category-add/category-add.component';
import {CategoryEditComponent} from './components/categories/category-edit/category-edit.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../material.module';
import {DeckListComponent} from './components/decks/deck-list/deck-list.component';
import {DecksService} from './services/decks.service';
import {DeckAddComponent} from './components/decks/deck-add/deck-add.component';
import {CardListComponent} from './components/cards/card-list/card-list.component';
import {CardsService} from './services/cards.service';
import {DeckEditComponent} from './components/decks/deck-edit/deck-edit.component';
import {CardAddComponent} from './components/cards/card-add/card-add.component';
import {CardEditComponent} from './components/cards/card-edit/card-edit.component';
import {QuillModule} from 'ngx-quill';
import {CommentListComponent} from './components/comments/comment-list/comment-list.component';
import {CommentAddComponent} from './components/comments/comment-add/comment-add.component';
import {CommentsService} from './services/comments.service';
import {NgxUploaderModule} from 'ngx-uploader';
import {BlockCutDirective} from '../shared/directives/blockCutDirective';
import {SessionComponent} from './components/session/session.component';
import {SessionService} from './services/session.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    ReactiveFormsModule,
    MaterialModule,
    QuillModule,
    FormsModule,
    NgxUploaderModule
  ],
  declarations: [
    CategoryListComponent,
    CategoryEditComponent,
    CategoryAddComponent,
    DeckListComponent,
    CardListComponent,
    DeckAddComponent,
    DeckEditComponent,
    CardAddComponent,
    CardEditComponent,
    CommentListComponent,
    CommentAddComponent,
    BlockCutDirective,
    SessionComponent
  ],
  providers: [CategoriesService, DecksService, CardsService, CommentsService, SessionService]
})
export class FlashcardsModule {
}
