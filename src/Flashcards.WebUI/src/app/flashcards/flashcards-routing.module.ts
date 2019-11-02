import {NgModule} from '@angular/core';
import {Route, RouterModule} from '@angular/router';
import {DeckListComponent} from './components/decks/deck-list/deck-list.component';
import {DeckAddComponent} from './components/decks/deck-add/deck-add.component';
import {AuthGuard} from '../shared/auth.guard';
import {DeckEditComponent} from './components/decks/deck-edit/deck-edit.component';
import {CardListComponent} from './components/cards/card-list/card-list.component';
import {CardAddComponent} from './components/cards/card-add/card-add.component';
import {CardEditComponent} from './components/cards/card-edit/card-edit.component';
import {ActiveSessionComponent} from './components/session/active-session/active-session.component';
import {SessionListComponent} from './components/session/session-list/session-list.component';
import {CardPreviewComponent} from './components/cards/card-preview/card-preview.component';

const USER_ROUTES: Route[] = [
  {path: 'flashcards/decks',
    component: DeckListComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/add',
    component: DeckAddComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck',
    component: DeckEditComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/cards',
    component: CardListComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/cards/add',
    component: CardAddComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/cards/:card',
    component: CardPreviewComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/cards/:card/edit',
    component: CardEditComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/session',
    component: ActiveSessionComponent, canActivate: [AuthGuard]},
  {path: 'flashcards/decks/:deck/session-history',
    component: SessionListComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [
    RouterModule.forChild(USER_ROUTES)
  ],
  exports: [RouterModule]
})

export class FlashcardsRoutingModule {
}
