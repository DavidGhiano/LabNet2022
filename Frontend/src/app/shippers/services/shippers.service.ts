import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shippers } from '../interface/shippers.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  URL:string = environment.url;

  constructor( private http: HttpClient) { }

  getShippers(): Observable<Shippers[]> {
    return this.http.get<Shippers[]>(`${this.URL}/Shippers`);
  }

  getShippersById(id: number): Observable<Shippers>{
    return this.http.get<Shippers>(`${this.URL}/Shippers/${id}`);
  }

  postShippers(Shippers:Shippers): Observable<Shippers> {
    return this.http.post<Shippers>(`${this.URL}/Shippers`, Shippers);;
  }

  patchShippers(Shippers:Shippers): Observable<Shippers> {
    return this.http.patch<Shippers>(`${this.URL}/Shippers`, Shippers);
  }

  deleteShippers(id:Number):Observable<Shippers> {
    return this.http.delete<Shippers>(`${this.URL}/Shippers/${id}`)
  }
}
