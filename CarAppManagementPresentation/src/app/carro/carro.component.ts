import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';


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


  constructor(private fb: FormBuilder, private http: HttpClient) { }

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
      ipvaPago: [false, Validators.required],
      vendido: [false, Validators.required]
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

  adicionarCarro() {

    debugger;

    let carro = {
      modelo: this.carroForm.controls['txtModelo'].value,
      cor: this.carroForm.controls['txtCor'].value,
      ano: this.formatarData(this.carroForm.controls['txtAnoCarro'].value),
      placa: this.carroForm.controls['txtPlaca'].value,
      valorComprado: this.carroForm.controls['txtValorComprado'].value,
      valorVenda: this.carroForm.controls['txtValorVenda'].value,
      dataCompra: this.formatarData(this.carroForm.controls['txtDataCompra'].value),
      dataVenda: this.formatarData(this.carroForm.controls['txtDataVenda'].value),
      descricao: this.carroForm.controls['txtDetalhe'].value,
      ipvaPago: this.carroForm.controls['ipvaPago'].value,
      vendido: this.carroForm.controls['vendido'].value
    }

    console.log(carro);

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("auth-token")
    });

    let options = { headers: headers };

    console.log(options);

    this.http.post(this.urlServer + "api/veiculos", carro, options).subscribe({
      next: (data: any) =>
      {
        console.log(data);
      },
      error: error => 
      {
        console.log(error)
      }
    })      
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
} 
