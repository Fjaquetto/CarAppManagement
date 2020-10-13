import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Carros } from '../DTOs/carros';


@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html'
})
export class CarroComponent implements OnInit {
  urlServer: string = "https://localhost:44311/";

  displayModal: boolean;
  position: string;
  txtAnoCarro: Date;
  br: any;
  carroForm: FormGroup;
  carros: Carros[];
  erroForm: boolean = false;

  loading: boolean;

  modelo: string;
  cor: string;
  ano: string;
  placa: string;
  descricao: string;
  valorComprado: number;
  valorVenda: number;
  dataCompra: string;
  dataVenda: string;
  ipvaPago: boolean;
  vendido: boolean;

  constructor(private fb: FormBuilder, private http: HttpClient, private messageService: MessageService) { }

  ngOnInit(): void {

    this.loading = true;

    this.carroForm = this.fb.group({
      txtModelo: ['', Validators.required],
      txtCor: ['', Validators.required],
      txtAnoCarro: ['', Validators.required],
      txtPlaca: ['', Validators.required],
      txtRenavam: ['', Validators.required],
      txtValorComprado: ['', Validators.required],
      txtValorVenda: [''],
      txtDebitoPendente: [''],
      txtDataCompra: ['', Validators.required],
      txtDataVenda: [''],
      txtDetalhe: ['', Validators.required],
      ipvaPago: [false, Validators.required],
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

    this.obterCarros();
  }

  showModalDialog() {
    this.displayModal = true;
  }

  adicionarCarro() {

    let carro = {
      modelo: this.carroForm.controls['txtModelo'].value,
      cor: this.carroForm.controls['txtCor'].value,
      ano: this.carroForm.controls['txtAnoCarro'].value,
      placa: this.carroForm.controls['txtPlaca'].value.toUpperCase(),
      renavam: this.carroForm.controls['txtRenavam'].value,
      valorComprado: this.carroForm.controls['txtValorComprado'].value,
      valorVenda: this.carroForm.controls['txtValorVenda'].value,
      dataCompra: this.formatarData(this.carroForm.controls['txtDataCompra'].value),
      dataVenda: this.formatarData(this.carroForm.controls['txtDataVenda'].value),
      debitoPendente: this.carroForm.controls['txtDebitoPendente'].value,
      descricao: this.carroForm.controls['txtDetalhe'].value,
      ipvaPago: this.carroForm.controls['ipvaPago'].value,
      vendido: this.isCarroVendido()
    }

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("auth-token")
    });

    let options = { headers: headers };

    this.http.post(this.urlServer + "api/veiculos", carro, options).subscribe({
      next: (data: any) => {
        console.log(data);
        this.displayModal = false;
        this.obterCarros();
        this.messageService.add({ severity: 'success', summary: 'Adicionado!', detail: 'Veículo adicionado com sucesso!' });

      },
      error: error => {
        console.log(error)
        this.erroForm = true;
      }
    })
  }

  obterCarros() {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("auth-token")
    });

    let options = { headers: headers };

    this.http.get(this.urlServer + "api/veiculos", options)
      .toPromise()
      .then(res => <Carros[]>res)
      .then(carros => {
        this.carros = carros
        console.log(this.carros)
        this.loading = false;
      });

  }

  formatarData(date) {
    if (date !== "") {
      var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2)
        month = '0' + month;
      if (day.length < 2)
        day = '0' + day;

      return [year, month, day].join('-');
    }
    else {
      return null;
    }
  }

  formatarDataTabela(date) {

    if (!date) 
      return null;
    
    if (date !== "") {
      var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2)
        month = '0' + month;
      if (day.length < 2)
        day = '0' + day;

      return [day, month, year].join('/');
    }
    else {
      return null;
    }
  }

  formatarBool(data) {
    if (data == true)
      return "Sim"
    
    if (data == false)
      return "Não"    
  }

  isCarroVendido() {
    if (!this.carroForm.controls['txtDataVenda'].value) {
      return false;
    }
    else {
      return true;
    }
  }
} 
