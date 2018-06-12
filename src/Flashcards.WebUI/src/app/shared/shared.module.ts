import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HeaderComponent} from './components/header/header.component';
import {SidebarComponent} from './components/sidebar/sidebar.component';
import {RouterModule} from '@angular/router';
import {ConfirmDeleteComponent} from './components/confirm-delete/confirm-delete.component';
import {MaterialModule} from '../material.module';
import {AlertComponent} from './components/alert/alert.component';
import {AlertService} from './services/alert.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule
  ],
  exports: [HeaderComponent, SidebarComponent, ConfirmDeleteComponent],
  declarations: [
    HeaderComponent,
    SidebarComponent,
    ConfirmDeleteComponent,
    AlertComponent
  ],
  providers: [AlertService],
  entryComponents: [ConfirmDeleteComponent, AlertComponent]
})

export class SharedModule {
}
