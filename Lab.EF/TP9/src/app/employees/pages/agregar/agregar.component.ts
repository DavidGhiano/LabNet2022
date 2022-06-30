import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Employees } from '../../interface/employees.interface';
import { EmployeesService } from '../../service/employees.service';

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

  employees:Employees ={
    ID: 0,
    Nombre: '',
    Apellido: ''
  };
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, 
              private service: EmployeesService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private snackBar: MatSnackBar)
  { 
    this.form = this.formBuilder.group({
      ID:[0],
      Nombre:['', [Validators.required, Validators.maxLength(20)]],
      Apellido:['', [Validators.required, Validators.maxLength(10)]],
    })
  }

  ngOnInit(): void {
    if(this.router.url.includes('editar')){
      this.activatedRoute.params
          .pipe(
            switchMap( ({id}) => this.service.getEmployeesById(id) )
          ).subscribe( e=> {
            this.employees = e;
            this.form.setValue(e);
          });
      

    }
  }

  isValido( campo: string){
    return this.form.controls[campo].errors?.['requerid'] && this.form.controls[campo].touched;
  }


  onGuardar(event:any){
    if( this.form.invalid ){
      this.form.markAllAsTouched();
      return;
    }

    let employees:Employees =
    {
      Nombre: this.form.get('Nombre')?.value,
      Apellido: this.form.get('Apellido')?.value
    }
    if( this.employees.ID != 0 ){
      employees.ID = this.form.get('ID')?.value; 
      this.service.patchEmployees(employees)
                  .subscribe(e => this.verSnackBar("Datos Actualizados"));
    }else{
      this.service.postEmployees(employees)
                  .subscribe(e =>{
                    this.employees = e;
                    this.router.navigate([ '/employees/editar', e.ID ]);
                    this.verSnackBar("Empleado Creado");
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
