import {AbstractControl} from '@angular/forms';

export class PasswordValidator {
  public static matchPassword(form: AbstractControl) {
    const password = form.get('password').value;
    const confirmPassword = form.get('confirmPassword').value;
    if (password !== confirmPassword) {
      form.get('confirmPassword').setErrors({matchPassword: true});
    } else {
      return null;
    }
  }
}
