import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PizzaComponent } from './pages/pizza/pizza.component';
import { PizzasComponent } from './pages/pizza/pizzas.component';
import { ToppingComponent } from './pages/topping/topping.component';
import { ToppingsComponent } from './pages/topping/toppings.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { LoadingComponent } from './components/loading/loading.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToppingPizzaComponent } from './pages/pizza/topping-pizza.component';
import { MenuComponent } from './components/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    PizzaComponent,
    PizzasComponent,
    ToppingComponent,
    ToppingsComponent,
    LoadingComponent,
    ToppingPizzaComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
