import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PizzasComponent } from './pages/pizza/pizzas.component';
import { PizzaComponent } from './pages/pizza/pizza.component';
import { ToppingsComponent } from './pages/topping/toppings.component';
import { ToppingComponent } from './pages/topping/topping.component';


const routes: Routes = [
  {path: 'pizzas', component: PizzasComponent, data: {tittle: 'List of Pizzas'}},
  {path: 'pizza/:id', component: PizzaComponent, data: {tittle: 'Pizza'}},
  {path: 'toppings', component: ToppingsComponent, data: {tittle: 'List of Toppings'}},
  {path: 'topping/:id', component: ToppingComponent, data: {tittle: 'Topping'}},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
