import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.less']
})
export class ConfirmDeleteComponent implements OnInit {

  title: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    this.title = 'Are You sure You want to delete';

    if (this.data['title'] !== undefined) {
      this.title = this.data['title'];
    } else if (this.data['name'] !== undefined) {
      this.title += ` ${this.data['name']}?`;
    } else {
      this.title += '?';
    }
  }
}
