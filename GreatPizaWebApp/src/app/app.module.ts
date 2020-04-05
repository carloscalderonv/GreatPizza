import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PizzaComponent } from './pages/pizza/pizza.component';
import { PizzasComponent } from './pages/pizza/pizzas.component';
import { ToppingComponent } from './pages/topping/topping.component';
import { ToppingsComponent } from './pages/topping/toppings.component';

@NgModule({
  declarations: [
    AppComponent,
    PizzaComponent,
    PizzasComponent,
    ToppingComponent,
    ToppingsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
