import { Component, OnInit } from '@angular/core';
import { HotelesService } from '../services/hoteles.service';

@Component({
  selector: 'app-hoteles',
  templateUrl: './hoteles.component.html',
  styleUrls: ['./hoteles.component.css']
})
export class HotelesComponent implements OnInit {

  hoteles: any;

  constructor(private readonly service: HotelesService) { }

  ngOnInit(): void {
    this.consultarHoteles();
  }

  consultarHoteles(){
    this.service.consultarHoteles()
    .pipe()
    .subscribe((respuesta: any) => {
      this.hoteles = respuesta;
    })
  }

}
