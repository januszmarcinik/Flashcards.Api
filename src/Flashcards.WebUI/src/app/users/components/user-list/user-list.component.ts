import {Component, OnInit} from '@angular/core';
import {User} from '../../models/user';
import {UsersService} from '../../users.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.less']
})
export class UserListComponent implements OnInit {

  users: User[] = [];

  constructor(private usersService: UsersService) {
  }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(): void {
    this.usersService.getAll().subscribe((users) => {
      this.users = users.body;
    });
  }
}
