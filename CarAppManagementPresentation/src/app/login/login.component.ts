import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  urlServer: string = "https://localhost:44311/"; 
  loginForm: FormGroup;

  constructor(private http: HttpClient, private _formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      Email: new FormControl(),
      Password: new FormControl()
    })

    this.verificaUsuarioLogado();
  }

  logar() {

    debugger;

    this.http.post(this.urlServer + "api/account/login", this.loginForm.value).subscribe({
      next: data =>
      {
        localStorage.setItem("auth-token", data.toString())
        this.verificaUsuarioLogado();
      },
      error: error => 
      {
        if (error.status == 403){
        console.log("Login ou Senha Inválidos.")
      }}     
    })
  }

  verificaUsuarioLogado() {
    if (localStorage.getItem("auth-token") != null) {
      this.router.navigate(['home']);
    }
  }
}
