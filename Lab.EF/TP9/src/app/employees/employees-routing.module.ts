import { NgModule } from '@angular/core';
import { ListadoComponent } from './pages/listado/listado.component';
import { AgregarComponent } from './pages/agregar/agregar.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

const ROUTES: Routes =
[
  {
    path:'',
    component:HomeComponent,
    children: [
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
    RouterModule.forChild( ROUTES )
  ],
  exports: [
    RouterModule
  ]
})
export class EmployeesRoutingModule { }
