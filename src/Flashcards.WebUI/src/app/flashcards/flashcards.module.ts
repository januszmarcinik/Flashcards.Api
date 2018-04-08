import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CategoryListComponent} from './components/categories/category-list/category-list.component';
import {RouterModule} from '@angular/router';
import {SharedModule} from '../shared/shared.module';
import {CategoriesService} from './services/categories.service';
import {CategoryAddComponent} from './components/categories/category-add/category-add.component';
import {CategoryEditComponent} from './components/categories/category-edit/category-edit.component';
import {ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from '../material.module';
import {DeckListComponent} from './components/decks/deck-list/deck-list.component';
import {DecksService} from './services/decks.service';
import {DeckAddComponent} from './components/decks/deck-add/deck-add.component';
import {CardListComponent} from './components/cards/card-list/card-list.component';
import {CardsService} from './services/cards.service';
import {DeckEditComponent} from './components/decks/deck-edit/deck-edit.component';
import {CardAddComponent} from './components/cards/card-add/card-add.component';
import { CardEditComponent } from './components/cards/card-edit/card-edit.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    ReactiveFormsModule,
    MaterialModule
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
    CardEditComponent
  ],
  providers: [CategoriesService, DecksService, CardsService]
})
export class FlashcardsModule {
}
