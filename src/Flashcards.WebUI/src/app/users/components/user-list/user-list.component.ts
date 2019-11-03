import {Component, OnInit, ViewChild} from '@angular/core';
import {User} from '../../models/user';
import {UsersService} from '../../users.service';
import {MatDialog, MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {HttpErrorResponse} from '@angular/common/http';
import {AlertService} from '../../../shared/services/alert.service';
import {ConfirmDeleteComponent} from '../../../shared/components/confirm-delete/confirm-delete.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.less']
})
export class UserListComponent implements OnInit {

  displayedColumns = ['no', 'email', 'role', 'id'];
  dataSource: MatTableDataSource<User>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private usersService: UsersService,
              private dialog: MatDialog,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(): void {
    this.usersService.getAll().subscribe((users) => {
      this.dataSource = new MatTableDataSource(users.body);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, (ex: HttpErrorResponse) => {
      this.alertService.handleError(ex);
    });
  }

  getRoleName(roleNumber: number): string {
    if (roleNumber === 1) {
      return 'Admin';
    }
    if (roleNumber === 2) {
      return 'User';
    }

    return '';
  }

  delete(user: User): void {
    event.stopPropagation();
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      data: {name: user.email}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.usersService.remove(user.id)
          .subscribe((response) => {
            if (response.ok) {
              this.loadUsers();
            }
          }, (ex: HttpErrorResponse) => {
            this.alertService.handleError(ex);
          });
      }
    });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }
}
