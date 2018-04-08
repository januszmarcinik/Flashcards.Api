import {Injectable} from '@angular/core';
import {MatDialog} from '@angular/material';
import {HttpErrorResponse} from '@angular/common/http';
import {AlertComponent} from '../components/alert/alert.component';

@Injectable()
export class AlertService {

  private message: string;

  constructor(private dialog: MatDialog) {
  }

  handleError(ex: HttpErrorResponse): void {
    if (ex.error != null) {
      this.message = ex.error.message;
    }
    else {
      this.message = ex.message;
    }

    this.dialog.open(AlertComponent, {
      data: {message: this.message}
    });
  }

}
