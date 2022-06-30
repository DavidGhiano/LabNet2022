import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

const ROUTES: Routes = 
[
  {
    path:'',
    component: HomeComponent
  },
  {
    path: 'employees',
    loadChildren: () => import('./employees/employees.module').then( e => e.EmployeesModule)
  },
  {
    path: 'shippers',
    loadChildren: () => import('./shippers/shippers.module').then( s => s.ShippersModule)
  },
  {
    path: '**',
    redirectTo: ''
  }
]

@NgModule({
  imports: [
    RouterModule.forRoot( ROUTES )
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
