import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UserListComponent} from './components/user-list/user-list.component';
import {SharedModule} from '../shared/shared.module';
import {UsersService} from './users.service';
import {HttpClientModule} from '@angular/common/http';
import {UserLoginComponent} from './components/user-login/user-login.component';
import {MaterialModule} from '../material.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { UserRegisterComponent } from './components/user-register/user-register.component';
import {RouterModule} from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    HttpClientModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [UserListComponent],
  declarations: [UserListComponent, UserLoginComponent, UserRegisterComponent],
  providers: [UsersService]
})
export class UsersModule {
}
