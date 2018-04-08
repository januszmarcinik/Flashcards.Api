import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.less']
})
export class ConfirmDeleteComponent implements OnInit {

  private title: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    this.title = 'Are You sure You want to delete';

    if (this.data['name'].length == 0) {
      this.title += '?';
    }
    else {
      this.title += ` ${this.data['name']}?`;
    }
  }
}
