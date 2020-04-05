import { Component, OnInit } from '@angular/core';
import { Pizza } from 'src/app/models/pizza.model';
import { PizzaService } from 'src/app/services/pizza/pizza.service';

@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.css']
})
export class PizzasComponent implements OnInit {
  pizzas:Pizza[]=[];
  loading=true;
  page=1;
  constructor( public pizzaService:PizzaService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.pizzaService
    .getAll()
    .subscribe(pizzas => {
      this.pizzas = pizzas;
      this.loading = false;
    });
  }
  
  delete(pizza:Pizza){
    // Mensajes.MensajeCondicional('SiNo', 'warning', 'Seguro dese Borrar el abogado?', 'Esta acción es irreversible!')
    // .then(result => {
    //   if (result.value) {
    //     this.pizzaService
    //       .delete(pizza.Id)
    //       .subscribe(() => this.loadData());
    //   } else {
    //     Mensajes.Mostrar('Ligero', 'error', 'Cancelado', 'No se hicieron modificaciones');
    //   }
    // });
  }
}
