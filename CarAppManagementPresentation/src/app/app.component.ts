import { Component } from '@angular/core';
import { LoginComponent } from './login/login.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CarAppManagementPresentation';
  carregarFooterNavbar: boolean;

  constructor() { }

  ngOnInit(): void {
  }
}
