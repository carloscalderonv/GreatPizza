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
    const url = '/api/pizza/';
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let pizzas: Pizza[];
        pizzas = [];
        for (let i = 0; i < (resp as Array<any>).length; i++) {
          let pizza: Pizza;
          pizza = new Pizza();
          pizza.Id = (resp as Array<any>)[i].id;
          pizza.Name = (resp as Array<any>)[i].name;
          pizza.Description = (resp as Array<any>)[i].description;
          pizzas.push(pizza);
        }
        return pizzas;
        })
    );
  }

  get( id: string ) {
    const url = '/api/pizza/' + id;
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let pizza: Pizza;
        pizza = new Pizza();
        pizza.Id = (resp as any).id;
        pizza.Name = (resp as any).name;
        pizza.Description = (resp as any).description;
        return pizza;
      })
    );
  }

  delete(id: string) {
    const url = '/api/pizza/' + id;
    return this.httpClient
      .delete(url)
      .pipe(
        map(resp => {
          return resp;
        })
      );
  }

  save(pizza: Pizza) {
    const url = '/api/pizza/' + (pizza.Id || '');
    if (pizza.Id) {
      // actualizando

      return this.httpClient
        .put(url, pizza)
        .pipe(
          map((resp: any) => {
            let pizza: Pizza;
            pizza = new Pizza();
            pizza.Id = (resp as any).id;
            pizza.Name = (resp as any).name;
            pizza.Description = (resp as any).description;
            return pizza;
          })
        );
    } else {
      // creando
      return this.httpClient
        .post(url, pizza )
        .pipe(
          map((resp: any) => {
            let pizza: Pizza;
            pizza = new Pizza();
            pizza.Id = (resp as any).id;
            pizza.Name = (resp as any).name;
            pizza.Description = (resp as any).description;
            return pizza;
          })
        );
    }
  }
}
