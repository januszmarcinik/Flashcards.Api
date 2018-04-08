import {NgModule} from '@angular/core';
import {Route, RouterModule} from '@angular/router';
import {UserListComponent} from './users/components/user-list/user-list.component';
import {AuthGuard} from './shared/auth.guard';
import {DashboardComponent} from './shared/components/dashboard/dashboard.component';

const APP_ROUTES: Route[] = [
  {path: '', pathMatch: 'full', redirectTo: 'dashboard'},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'users', component: UserListComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [
    RouterModule.forRoot(APP_ROUTES)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
