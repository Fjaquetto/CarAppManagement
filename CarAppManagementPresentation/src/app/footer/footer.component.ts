import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html'
})
export class FooterComponent implements OnInit {
  carregarFooter: boolean;

  constructor(public route: Router) { }

  ngOnInit(): void {
  }

}
