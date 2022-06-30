import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { AgregarComponent } from './pages/agregar/agregar.component';
//localhost:4200/shippers/listado
const RUTAS: Routes = 
[
  {
    path:'',
    component:HomeComponent,
    children: 
    [
      {
        path: 'agregar',
        component: AgregarComponent
      },
      {
        path: 'editar/:id',
        component: AgregarComponent
      },
      {
        path: 'listado',
        component: ListadoComponent
      }, 
      {
        path: '**',
        redirectTo: 'listado'
      }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild( RUTAS )
  ],
  exports: [
    RouterModule
  ]
})
export class ShippersRoutingModule { }
