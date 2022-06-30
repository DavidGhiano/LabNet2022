import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { ShippersRoutingModule } from './shippers-routing.module';
import { MaterialModule } from '../material/material.module';
import { ListadoComponent } from './pages/listado/listado.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgregarComponent } from './pages/agregar/agregar.component';



@NgModule({
  declarations: [
    HomeComponent,
    ListadoComponent,
    AgregarComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    ShippersRoutingModule
  ]
})
export class ShippersModule { }
