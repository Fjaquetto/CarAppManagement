import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  nomeUsuario: object;

  constructor(private login: LoginComponent) {  }

  ngOnInit(): void {
    this.login.verificaUsuarioLogado();

    this.nomeUsuario = JSON.parse(localStorage.getItem("user-token")).name;
  }

}
