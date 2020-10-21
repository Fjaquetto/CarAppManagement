import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Carros } from '../DTOs/carros';
import { LoginComponent } from '../login/login.component';
import { MainService } from '../services/mainservice';


@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html',
  styleUrls: ['./carro.component.scss']
})
export class CarroComponent implements OnInit {

  displayModal: boolean;
  displayDescricao: boolean;
  descricaoModal: string;
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

  idCarro: number;

  constructor(private login: LoginComponent, private fb: FormBuilder, private http: HttpClient, private messageService: MessageService, private mainService: MainService) { }

  ngOnInit(): void {
    this.login.verificaUsuarioLogado();

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
      ipvaPago: [false],
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
    this.limparModal();

    this.displayModal = true;
  }

  adicionarCarro() {

    if (!this.carroForm.controls['ipvaPago'].value)
      this.carroForm.controls['ipvaPago'].setValue(false);

    let carro = {
      id: this.idCarro,
      modelo: this.carroForm.controls['txtModelo'].value,
      cor: this.carroForm.controls['txtCor'].value,
      ano: this.carroForm.controls['txtAnoCarro'].value,
      placa: this.carroForm.controls['txtPlaca'].value.toUpperCase(),
      renavam: this.carroForm.controls['txtRenavam'].value,
      valorComprado: this.carroForm.controls['txtValorComprado'].value,
      valorVenda: this.carroForm.controls['txtValorVenda'].value,
      dataCompra: this.mainService.formatarData(this.carroForm.controls['txtDataCompra'].value),
      dataVenda: this.mainService.formatarData(this.carroForm.controls['txtDataVenda'].value),
      debitoPendente: this.carroForm.controls['txtDebitoPendente'].value,
      descricao: this.carroForm.controls['txtDetalhe'].value,
      ipvaPago: this.carroForm.controls['ipvaPago'].value
    }

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("auth-token")
    });

    let options = { headers: headers };

    if (!this.idCarro) {
      this.http.post(this.mainService.urlServer + "api/veiculos", carro, options).subscribe({
        next: (data: any) => {
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
    else {
      this.http.put(this.mainService.urlServer + "api/veiculos", carro, options).subscribe({
        next: (data: any) => {
          this.displayModal = false;
          this.obterCarros();
          this.messageService.add({ severity: 'success', summary: 'Atualizado!', detail: 'Veículo atualizado com sucesso!' });
  
        },
        error: error => {
          console.log(error)
          this.erroForm = true;
        }
      })
    }
  }

  obterCarros() {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("auth-token")
    });

    let options = { headers: headers };

    this.http.get(this.mainService.urlServer + "api/veiculos", options)
      .toPromise()
      .then(res => <Carros[]>res)
      .then(carros => {
        this.carros = carros
        this.loading = false;
      });

  }

  // mostrarDetalheCarro(data) {
  //   this.displayDescricao = true;
  //   this.descricaoModal = data;
  // }

  popularModal(data) {
    console.log(data);

    this.carroForm.controls['txtModelo'].setValue(data.modelo);
    this.carroForm.controls['txtCor'].setValue(data.cor);
    this.carroForm.controls['txtAnoCarro'].setValue(data.ano);
    this.carroForm.controls['txtPlaca'].setValue(data.placa);
    this.carroForm.controls['txtRenavam'].setValue(data.renavam);
    this.carroForm.controls['txtValorComprado'].setValue(data.valorComprado);
    this.carroForm.controls['txtDebitoPendente'].setValue(data.debitoPendente);
    this.carroForm.controls['txtValorVenda'].setValue(data.valorVenda);
    this.carroForm.controls['txtDataCompra'].setValue(this.mainService.formatarDataModal(data.dataCompra));
    this.carroForm.controls['txtDataVenda'].setValue(this.mainService.formatarDataModal(data.dataVenda));
    this.carroForm.controls['txtDetalhe'].setValue(data.descricao);
    this.carroForm.controls['ipvaPago'].setValue(data.ipvaPago);

    this.idCarro = data.id;

    this.displayModal = true;
  }

  limparModal() {
    this.carroForm.get('txtModelo').reset();
    this.carroForm.get('txtCor').reset();
    this.carroForm.get('txtAnoCarro').reset();
    this.carroForm.get('txtPlaca').reset();
    this.carroForm.get('txtRenavam').reset();
    this.carroForm.controls['txtValorComprado'].setValue(0);
    this.carroForm.controls['txtValorVenda'].setValue(0);
    this.carroForm.controls['txtDebitoPendente'].setValue(0);
    this.carroForm.get('txtDataCompra').reset();
    this.carroForm.get('txtDataVenda').reset();
    this.carroForm.get('txtDetalhe').reset();
    this.carroForm.get('ipvaPago').reset();

    this.idCarro = 0;
  }
} 
