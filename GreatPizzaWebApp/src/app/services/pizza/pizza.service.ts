import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Pizza } from 'src/app/models/pizza.model';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  
  constructor(
    public httpClient : HttpClient
  ) { }
  getAll() {
    const url = '/api/Pizza/';
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let pizzas: Pizza[];
        pizzas = [];
        for (let i = 0; i < (resp as Array<Pizza>).length; i++) {
          let pizza: Pizza;
          pizza = new Pizza();
          pizza.Id = (resp as Array<Pizza>)[i].Id;
          pizza.Name = (resp as Array<Pizza>)[i].Name;
          pizza.Description = (resp.data as Array<Pizza>)[i].Description;
          pizzas.push(pizza);
        }
        return pizzas;
        })
    );
  }
}
