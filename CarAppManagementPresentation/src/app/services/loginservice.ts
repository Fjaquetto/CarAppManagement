import { Injectable } from '@angular/core';
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable()
export class LoginService {

    constructor(private router: Router, private jwt: JwtHelperService) { }

}