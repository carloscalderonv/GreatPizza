import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Topping } from 'src/app/models/topping.model';

@Injectable({
  providedIn: 'root'
})
export class ToppingService {

  constructor(
    public httpClient : HttpClient
  ) { }
  getAll() {
    const url = '/api/topping/';
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let toppings: Topping[];
        toppings = [];
        for (let i = 0; i < (resp as Array<any>).length; i++) {
          let topping: Topping;
          topping = new Topping();
          topping.Id = (resp as Array<any>)[i].id;
          topping.Name = (resp as Array<any>)[i].name;
          toppings.push(topping);
        }
        return toppings;
        })
    );
  }

  get( id: string ) {
    const url = '/api/topping/' + id;
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let topping: Topping;
        topping = new Topping();
        topping.Id = (resp as any).id;
        topping.Name = (resp as any).name;
        return topping;
      })
    );
  }

  delete(id: string) {
    const url = '/api/topping/' + id;
    return this.httpClient
      .delete(url)
      .pipe(
        map(resp => {
          return resp;
        })
      );
  }

  save(topping: Topping) {
    const url = '/api/topping/' + (topping.Id || '');
    if (topping.Id) {
      // updating

      return this.httpClient
        .put(url, topping)
        .pipe(
          map((resp: any) => {
            let topping: Topping;
            topping = new Topping();
            topping.Id = (resp as any).id;
            topping.Name = (resp as any).name;
            return topping;
          })
        );
    } else {
      // creating
      return this.httpClient
        .post(url, topping )
        .pipe(
          map((resp: any) => {
            let topping: Topping;
            topping = new Topping();
            topping.Id = (resp as any).id;
            topping.Name = (resp as any).name;
            return topping;
          })
        );
    }
  }
  GetAllByPizza(IdPizza) {
    const url = '/api/topping/by-pizza/'+IdPizza;
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let toppings: Topping[];
        toppings = [];
        for (let i = 0; i < (resp as Array<any>).length; i++) {
          let topping: Topping;
          topping = new Topping();
          topping.Id = (resp as Array<any>)[i].id;
          topping.Name = (resp as Array<any>)[i].name;
          toppings.push(topping);
        }
        return toppings;
        })
    );
  }
  GetAllAvailableByPizza(IdPizza) {
    const url = '/api/topping/available-by-pizza/'+IdPizza;
    return this.httpClient.get(url).pipe(
      map((resp: any) => {
        let toppings: Topping[];
        toppings = [];
        for (let i = 0; i < (resp as Array<any>).length; i++) {
          let topping: Topping;
          topping = new Topping();
          topping.Id = (resp as Array<any>)[i].id;
          topping.Name = (resp as Array<any>)[i].name;
          toppings.push(topping);
        }
        return toppings;
        })
    );
  }
}
