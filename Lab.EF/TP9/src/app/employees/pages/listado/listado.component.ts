import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Employees } from '../../interface/employees.interface';
import { EmployeesService } from '../../service/employees.service';
import { DialogoComponent } from '../../../shared/dialogo/dialogo.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styles: [
  ]
})
export class ListadoComponent implements OnInit {

  displayedColumns: string[] = ['ID', 'Nombre', 'Apellido', 'Acciones'];
  dataSource:Employees[] = [];
  constructor( private employeesService:EmployeesService,
               private dialog:MatDialog,
               private snackBar: MatSnackBar ) { }

  ngOnInit(): void {
    this.employeesService.getEmployees()
                          .subscribe(e => this.dataSource = e);
  }

  borrar(nombre:string, id: number) {
    const dialogo = this.dialog.open( DialogoComponent,{
      width: '300px',
      data: nombre
    })
    dialogo.afterClosed().subscribe(
      result => {
        if( result ){
          this.employeesService.deleteEmployees( id )
                               .subscribe( resp=> {
                                 this.verSnackBar("Empleado eliminado");
                                 this.dataSource = this.dataSource.filter( e => e.ID != id);
                               }, error=> {
                                  this.verSnackBar("No se puede eliminar el registro");
                               });
        }
      }
    )
  }

  verSnackBar(mensaje: string){
    this.snackBar.open(mensaje, 'Cerrar',{
      duration: 3000
    })
  }
}
