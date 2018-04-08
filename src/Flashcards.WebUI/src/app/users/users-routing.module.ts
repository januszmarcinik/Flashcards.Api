import {NgModule} from '@angular/core';
import {Route, RouterModule} from '@angular/router';
import {UserLoginComponent} from './components/user-login/user-login.component';
import {UserRegisterComponent} from './components/user-register/user-register.component';

const USER_ROUTES: Route[] = [
  {path: 'login', component: UserLoginComponent},
  {path: 'register', component: UserRegisterComponent}
];

@NgModule({
  imports: [
    RouterModule.forChild(USER_ROUTES)
  ],
  exports: [RouterModule]
})

export class UsersRoutingModule {
}
