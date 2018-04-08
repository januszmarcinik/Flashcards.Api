import {NgModule} from '@angular/core';
import {Route, RouterModule} from '@angular/router';
import {DeckListComponent} from './components/decks/deck-list/deck-list.component';
import {DeckAddComponent} from './components/decks/deck-add/deck-add.component';
import {AuthGuard} from '../shared/auth.guard';
import {DeckEditComponent} from './components/decks/deck-edit/deck-edit.component';
import {CategoryListComponent} from './components/categories/category-list/category-list.component';
import {CategoryEditComponent} from './components/categories/category-edit/category-edit.component';
import {CategoryAddComponent} from './components/categories/category-add/category-add.component';
import {CardListComponent} from './components/cards/card-list/card-list.component';
import {CardAddComponent} from './components/cards/card-add/card-add.component';
import {CardEditComponent} from './components/cards/card-edit/card-edit.component';

const USER_ROUTES: Route[] = [
  {path: 'flashcards/topics/:topic/categories',
    component: CategoryListComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/add',
    component: CategoryAddComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category',
    component: CategoryEditComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks',
    component: DeckListComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks/add',
    component: DeckAddComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks/:deck',
    component: DeckEditComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks/:deck/cards',
    component: CardListComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks/:deck/cards/add',
    component: CardAddComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/topics/:topic/categories/:category/decks/:deck/cards/:card',
    component: CardEditComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [
    RouterModule.forChild(USER_ROUTES)
  ],
  exports: [RouterModule]
})

export class FlashcardsRoutingModule {
}
