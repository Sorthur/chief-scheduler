import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-login-new',
  templateUrl: './login-new.component.html',
  styleUrls: ['./login-new.component.scss']
})
export class LoginNewComponent implements OnInit {

  form: FormGroup;

  constructor(private authService: AuthorizeService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  login(): void {
    console.warn(this.form.value)
    if (!this.isFormValid()) return;

    this.authService.login(); //todo
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
