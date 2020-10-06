import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  urlServer: string = "https://localhost:44311/"; 
  loginForm: FormGroup;
  isLoggedIn: boolean;
  carregarFooterNavbar: boolean = false;

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {   

    this.loginForm = this.fb.group({
      Email: ['', Validators.required],
      Password: ['', Validators.required]
    })

    this.verificaUsuarioLogado();

  }

  logar() {

    this.http.post(this.urlServer + "api/account/login", this.loginForm.value).subscribe({
      next: (data: any) =>
      {
        localStorage.setItem("auth-token", data.accessToken)
        localStorage.setItem("user-token", JSON.stringify(data.userToken))       
        this.verificaUsuarioLogado();
        this.carregarFooterNavbar = true;
      },
      error: error => 
      {
        if (error.status == 403){
          this.isLoggedIn = false;
      }}     
    })
  }

  verificaUsuarioLogado() {
    if (localStorage.getItem("auth-token") != null) {
      this.router.navigate(['home']);
    }
    else {
      this.router.navigate(['']);
    }
  }
}
