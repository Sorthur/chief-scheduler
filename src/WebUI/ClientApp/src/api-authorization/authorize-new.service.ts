import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of, Subject } from "rxjs";
import { take } from "rxjs/operators";
import { AppSettings } from "src/models/app-settings";
import { LoginModel } from "src/models/login-model";
import { JwtResponse } from "./jwt-response";
import { LoginResponse } from "./login-response";

@Injectable({
    providedIn: 'root'
})
export class AuthorizeNewService {
    loginUrl = 'https://localhost:5001/api/auth/login'
    loginResponse$ = new Subject<LoginResponse>();

    constructor(private http: HttpClient) { }

    public login(loginModel: LoginModel): Observable<LoginResponse> {
        this.getJwt(loginModel)
            .pipe(take(1))
            .subscribe(response => {
                localStorage.setItem(AppSettings.AUTH_TOKEN, response.token)
                this.loginResponse$.next(new LoginResponse(true, 'success'))
            }, (err: HttpErrorResponse) => {
                this.loginResponse$.next(new LoginResponse(false, 'wyjebalo sie wszystko, koniec swiata - ' + err.message))
            }, () => this.loginResponse$.complete());

        return this.loginResponse$;
    }

    public getJwt(loginModel: LoginModel): Observable<JwtResponse> {
        return this.http.post<JwtResponse>(this.loginUrl, loginModel);
    }
}