import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.less']
})
export class AlertComponent implements OnInit {

  message: string;

  constructor(@Inject(MAT_DIALOG_DATA) private data: any) {
  }

  ngOnInit() {
    this.message = this.data.message;
  }
}
