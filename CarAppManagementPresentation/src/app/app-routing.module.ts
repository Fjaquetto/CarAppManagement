import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CarroComponent } from './carro/carro.component';

const routes: Routes = [
// { path: '', redirectTo: '/login', pathMatch: 'full' },
{ path: '', component: LoginComponent },
// { path: 'login', component: LoginComponent },

{ path: 'home', component: HomeComponent },
{ path: 'carro', component: CarroComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
