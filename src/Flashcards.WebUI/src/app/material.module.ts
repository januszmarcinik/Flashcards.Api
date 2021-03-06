import {NgModule} from '@angular/core';
import {
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  MatDialogModule,
  MatButtonModule,
  MatSlideToggleModule,
  MatTableModule,
  MatPaginatorModule,
  MatSortModule,
  MatProgressBarModule,
  MatIconModule,
  MatBadgeModule,
  MatChipsModule,
  MatCheckboxModule
} from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSelectModule} from '@angular/material/select';

const modules = [
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  BrowserAnimationsModule,
  MatSelectModule,
  MatDialogModule,
  MatButtonModule,
  MatSlideToggleModule,
  MatTableModule,
  MatPaginatorModule,
  MatSortModule,
  MatProgressBarModule,
  MatIconModule,
  MatBadgeModule,
  MatChipsModule,
  MatCheckboxModule
];

@NgModule({
  imports: modules,
  exports: modules
})
export class MaterialModule {

}
