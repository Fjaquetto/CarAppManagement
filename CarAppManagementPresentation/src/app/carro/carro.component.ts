import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html'
})
export class CarroComponent implements OnInit {
  displayModal: boolean;
  position: string;
  txtAnoCarro: Date;
  br: any;
  carroForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.carroForm = this.fb.group({
      txtModelo: ['', Validators.required],
      txtCor: ['', Validators.required],
      txtAnoCarro: ['', Validators.required],
      txtPlaca: ['', Validators.required],
      txtValorComprado: ['', Validators.required],
      txtValorVenda: ['', Validators.required],
      txtDataCompra: ['', Validators.required],
      txtDataVenda: ['', Validators.required],
      txtDetalhe: ['', Validators.required],
      ipvaPago: ['', Validators.required],
      vendido: ['', Validators.required]
    })

    this.br = {
      firstDayOfWeek: 1,
      dayNames: ["domingo", "segunda", "terça", "quarta", "quinta", "sexta", "sábado"],
      dayNamesShort: ["dom", "seg", "ter", "qua", "qui", "sex", "sáb"],
      dayNamesMin: ["D", "S", "T", "Q", "Q", "S", "S"],
      monthNames: ["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"],
      monthNamesShort: ["jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago", "set", "out", "nov", "dez"],
      today: 'Hoje',
      clear: 'Limpar'
    }
  }

  showModalDialog() {
    this.displayModal = true;
  }

}
