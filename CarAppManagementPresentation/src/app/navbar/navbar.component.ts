import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { Router } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {

  items: MenuItem[];

  constructor(public route: Router, public login: LoginComponent) { }

  ngOnInit(): void {

    this.items = [
      {
        label: 'CarAppManagement',
        icon: 'pi pi-fw pi-home',
        routerLink: "/home"
      },
      {
        label: 'Veículos',
        icon: 'pi pi-fw pi-briefcase',
        routerLink: "/veiculo"
      }
    ];
  }

  logout() {
    localStorage.clear();
    this.login.verificaUsuarioLogado();
  }

}


