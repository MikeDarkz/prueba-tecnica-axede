import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelesService {

  URL: string;

  constructor(private readonly http: HttpClient) { 
    this.URL = "https://localhost:44315/";
  }

  consultarHoteles() {
    return this.http
      .get(
        `${this.URL}api/Hotel`)
      .pipe(
        map((respuesta: any) => {
          return respuesta
        })
      );
  }
}
