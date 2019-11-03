import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {HttpErrorResponse} from '@angular/common/http';

import {UserRegister} from '../../models/user-register';
import {PasswordValidator} from '../../password-validator';
import {UsersService} from '../../users.service';
import {AlertService} from '../../../shared/services/alert.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.less']
})
export class UserRegisterComponent implements OnInit {

  registerForm: FormGroup;
  user: UserRegister;

  constructor(private fb: FormBuilder,
              private userService: UsersService,
              private router: Router,
              private alertService: AlertService) {
  }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.registerForm = this.fb.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('', [Validators.required])
    }, {
      validator: PasswordValidator.matchPassword
    });
  }

  register() {
    this.user = this.registerForm.value as UserRegister;
    this.userService.add(this.user).subscribe(response => {
      if (response.ok) {
        this.alertService.showMessage('Successfully registered. Now you are able to sign in.');
        this.login();
      }
    }, (err: HttpErrorResponse) => {
      this.alertService.handleError(err);
    });
  }

  login() {
    this.router.navigate(['/login']);
  }
}
