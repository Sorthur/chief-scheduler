import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthorizeNewService } from 'src/api-authorization/authorize-new.service';
import { LoginModel } from 'src/models/login-model';
import { take } from 'rxjs/operators'
import { LoginResponse } from 'src/api-authorization/login-response';

@Component({
  selector: 'app-login-new',
  templateUrl: './login-new.component.html',
  styleUrls: ['./login-new.component.scss']
})
export class LoginNewComponent implements OnInit {

  form: FormGroup;
  errorMessage: string = null;
  loaderVisible = false;

  constructor(private authService: AuthorizeNewService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  login(): void {
    console.warn(this.form.value)
    if (!this.isFormValid()) return;
    this.loaderVisible = true;
    this.errorMessage = null;

    this.authService.login(new LoginModel(this.form.value['login'], this.form.value['password']))
      .pipe(take(1))
      .subscribe((response: LoginResponse) => {
        this.loaderVisible = false;
        if (response.succesful) {
          // redirect or success message
        } else {
          this.errorMessage = response.message;
        }
      });
  }

  shouldDisplayFormError(): boolean {
    return this.form.controls['login'].errors?.required && this.form.controls['login'].dirty
      || this.form.controls['password'].errors?.required && this.form.controls['password'].dirty
  }

  isFormValid(): boolean {
    return !(this.form.controls['login'].errors?.required
      || this.form.controls['password'].errors?.required)
  }
}
