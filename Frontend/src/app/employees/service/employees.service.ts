import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employees } from '../interface/employees.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  URL: string = environment.url;

  constructor( private http: HttpClient ) { }

  getEmployees(): Observable<Employees[]> {
    return this.http.get<Employees[]>(`${this.URL}/Employees`);
  }

  getEmployeesById(id: number): Observable<Employees>{
    return this.http.get<Employees>(`${this.URL}/Employees/${id}`);
  }

  postEmployees(employees:Employees): Observable<Employees> {
    return this.http.post<Employees>(`${this.URL}/Employees`, employees);;
  }

  patchEmployees(employees:Employees): Observable<Employees> {
    return this.http.patch<Employees>(`${this.URL}/Employees`, employees);
  }

  deleteEmployees(id:Number):Observable<Employees> {
    return this.http.delete<Employees>(`${this.URL}/Employees/${id}`)
  }
}
