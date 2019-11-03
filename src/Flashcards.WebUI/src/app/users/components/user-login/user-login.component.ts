import {Component, OnInit} from '@angular/core';
import {UsersService} from '../../users.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {UserLogin} from '../../models/user-login';
import {HttpErrorResponse} from '@angular/common/http';
import {AuthService} from '../../../shared/auth.service';
import {Router} from '@angular/router';
import {AlertService} from '../../../shared/services/alert.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.less']
})
export class UserLoginComponent implements OnInit {

  loginForm: FormGroup;
  userLogin: UserLogin;

  constructor(private userService: UsersService,
              private fb: FormBuilder,
              private authService: AuthService,
              private router: Router,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.createForm();
  }

  login() {
    this.userLogin = this.loginForm.value as UserLogin;
    this.userService.auth(this.userLogin).subscribe(
      response => {
        const token = response.body;
        this.authService.setToken(token);
        this.router.navigate(['/users']);
      }, (err: HttpErrorResponse) => {
        this.alertService.handleError(err);
      }
    );
  }

  createForm() {
    this.loginForm = this.fb.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  register(): void {
    this.router.navigate([`register`]);
  }

}
