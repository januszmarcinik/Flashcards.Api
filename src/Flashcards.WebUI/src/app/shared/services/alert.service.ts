import {Injectable} from '@angular/core';
import {MatDialog} from '@angular/material';
import {HttpErrorResponse} from '@angular/common/http';
import {AlertComponent} from '../components/alert/alert.component';

@Injectable()
export class AlertService {

  constructor(private dialog: MatDialog) {
  }

  handleError(ex: HttpErrorResponse): void {
    if (ex.error.message) {
      this.showMessage(ex.error.message);
    } else if (ex.error) {
      this.showMessage(ex.error);
    } else {
      this.showMessage(ex.message);
    }
  }

  showMessage(message: string): void {
    this.dialog.open(AlertComponent, {
      data: {message}
    });
  }
}
