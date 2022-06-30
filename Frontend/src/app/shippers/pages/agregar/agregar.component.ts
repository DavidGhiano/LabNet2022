import { Component, OnInit } from '@angular/core';
import { Shippers } from '../../interface/shippers.interface';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ShippersService } from '../../services/shippers.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.component.html',
  styles: [`
    mat-card{  
      max-width: 400px;
    }
    mat-form-field, button {
      width: 100%;
    }
  `]
})
export class AgregarComponent implements OnInit {

  shipper:Shippers ={
    ID: 0,
    CompanyName: '',
    Telefono: ''
  }
  form: FormGroup;

  constructor( private formBuilder: FormBuilder,
               private service: ShippersService,
               private router: Router,
               private activatedRoute: ActivatedRoute,
               private snackBar:MatSnackBar )
  {
    this.form = this.formBuilder.group({
      ID:[0],
      CompanyName:['',[Validators.required, Validators.maxLength(40)]],
      Telefono:['', [Validators.required, Validators.maxLength(24)]]
    })
  }

  ngOnInit(): void {
    if(this.router.url.includes('editar')){
      this.activatedRoute.params
          .pipe(
            switchMap( ({id}) => this.service.getShippersById(id) )
          )
          .subscribe( s=> {
            this.shipper = s;
            this.form.setValue( s );
          })
    }
  }

  isValido( campo:string ){
    return this.form.controls[campo].hasError('required') && this.form.controls[campo].touched;
  }

  onGuardar(){
    if( this.form.invalid ){
      this.form.markAllAsTouched();
      return;
    }

    let shipper:Shippers =
    {
      CompanyName: this.form.get('CompanyName')?.value,
      Telefono: this.form.get('Telefono')?.value
    }
    if( this.shipper.ID != 0){
      shipper.ID = this.form.get('ID')?.value;
      this.service.patchShippers(shipper)
                  .subscribe( s => this.verSnackBar("Datos Actualizados"));
    }else{
      this.service.postShippers(shipper)
                  .subscribe( s => {
                    this.shipper = s;
                    this.router.navigate(['/shippers/editar', s.ID]);
                    this.verSnackBar("Transporte Creado");
                  }, error => {
                    this.verSnackBar(error.error.Message);
                  });
    }
  }


  verSnackBar(mensaje: string){
    this.snackBar.open(mensaje, 'Cerrar',{
      duration: 3000
    })
  }

}
