import { Component, OnInit } from '@angular/core';
import { Shippers } from '../../interface/shippers.interface';
import { ShippersService } from '../../services/shippers.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogoComponent } from '../../../shared/dialogo/dialogo.component';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styles: [
  ]
})
export class ListadoComponent implements OnInit {

  displayedColumns: string[] = ['ID', 'CompanyName', 'Telefono', 'Acciones'];
  dataSource:Shippers[] = []

  constructor( private servicio:ShippersService,
               private dialog:MatDialog,
               private snackBar: MatSnackBar ) { }

  ngOnInit(): void {
    this.servicio.getShippers()
                 .subscribe(s=> this.dataSource = s);
  }

  borrar(nombre:string, id:number){
    const dialogo = this.dialog.open( DialogoComponent,{
      width: '300px',
      data: nombre
    });
    dialogo.afterClosed().subscribe(
      result => {
        if( result ){
          this.servicio.deleteShippers( id )
                       .subscribe( resp=>{
                        this.verSnackBar("Transporte eliminado");
                        this.dataSource = this.dataSource.filter( s => s.ID != id );
                       }, error=> {
                        this.verSnackBar("No se puede eliminar el registro");
                       });
        }
      });
  }

  verSnackBar(mensaje: string){
    this.snackBar.open(mensaje, 'Cerrar',{
      duration: 3000
    })
  }
}
