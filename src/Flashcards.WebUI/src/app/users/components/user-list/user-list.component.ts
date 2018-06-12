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

  getRoleName(roleNumber: number): string {
    if (roleNumber == 1) {
      return "Admin";
    }
    if (roleNumber == 2) {
      return "Moderator";
    }
    if (roleNumber == 3) {
      return "User";
    }

    return "";
  }
}
