import {Component, OnInit} from '@angular/core';
import {UsersService} from '../../users.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {UserLogin} from '../../models/user-login';
import {Token} from '../../models/token';
import {HttpErrorResponse} from '@angular/common/http';
import {AuthService} from '../../../shared/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.less']
})
export class UserLoginComponent implements OnInit {
  loginForm: FormGroup;
  userLogin: UserLogin;
  token: Token;
  errors: any;

  constructor(private userService: UsersService,
              private fb: FormBuilder,
              private authService: AuthService,
              private router: Router) {
  }

  ngOnInit() {
    this.createForm();
  }

  login() {
    this.userLogin = <UserLogin> this.loginForm.value;
    this.userService.auth(this.userLogin).subscribe(
      response => {
        this.token = response.body;
        this.authService.setToken(this.token);
        this.router.navigate(['/users']);
      }, (err: HttpErrorResponse) => {
        this.errors = err.error.message;
      }
    );
  }

  createForm() {
    this.loginForm = this.fb.group({
      'email': new FormControl('', [Validators.required, Validators.email]),
      'password': new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

}
