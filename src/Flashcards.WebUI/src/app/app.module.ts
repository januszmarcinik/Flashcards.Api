import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {UsersModule} from './users/users.module';
import {AppRoutingModule} from './app-routing.module';
import {UsersRoutingModule} from './users/users-routing.module';
import {SharedModule} from './shared/shared.module';
import {FlashcardsModule} from './flashcards/flashcards.module';
import {FlashcardsRoutingModule} from './flashcards/flashcards-routing.module';
import {AuthService} from './shared/auth.service';
import {AuthGuard} from './shared/auth.guard';
import {HashLocationStrategy, LocationStrategy} from '@angular/common';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsersModule,
    UsersRoutingModule,
    SharedModule,
    FlashcardsModule,
    FlashcardsRoutingModule
  ],
  providers: [AuthService, AuthGuard, {provide: LocationStrategy, useClass: HashLocationStrategy}],
  bootstrap: [AppComponent]
})
export class AppModule {
}
