import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  urlServer: string = "https://localhost:44311/"; 
  loginForm: FormGroup;

  constructor(private http: HttpClient, private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      Email: new FormControl(),
      Password: new FormControl()
    })
  }

  logar() {
    console.log(this.loginForm.value);

    debugger;

    this.http.post(this.urlServer + "api/account/login", this.loginForm.value).subscribe({
      next: data =>
      this.inserirSessionStorage(data)
      ,
      error: error => console.error('Erro!', error)
    })
  }

  inserirSessionStorage(data) {
    window.sessionStorage.setItem("auth-token", data.toString())
    console.log(window.sessionStorage.getItem("auth-token"));
  }
}
