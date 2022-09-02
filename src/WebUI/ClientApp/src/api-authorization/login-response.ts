export class LoginResponse {
    succesful: boolean;
    message?: string;

    constructor(succesful: boolean, message?: string) {
        this.succesful = succesful;
        this.message = message;

    }
}