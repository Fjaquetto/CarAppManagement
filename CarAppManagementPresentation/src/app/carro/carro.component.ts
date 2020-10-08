import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html'
})
export class CarroComponent implements OnInit {
  displayModal: boolean;

  displayBasic: boolean;

  displayBasic2: boolean;

  displayMaximizable: boolean;

  displayPosition: boolean;

  position: string;

  showModalDialog() {
      this.displayModal = true;
  }
  constructor() { }

  ngOnInit(): void {
  }

  show() {

  
  }

}
