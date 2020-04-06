import { Component, OnInit, Input } from '@angular/core';
import { Topping } from 'src/app/models/topping.model';
import { ToppingService } from 'src/app/services/topping/topping.service';
import Swal from 'sweetalert2';
import { PizzaService } from 'src/app/services/pizza/pizza.service';

@Component({
  selector: 'app-topping-pizza',
  templateUrl: './topping-pizza.component.html',
  styleUrls: ['./topping-pizza.component.css']
})
export class ToppingPizzaComponent implements OnInit {
  @Input() public IdPizza: string;
  idToppingToAdd: string;
  toppings:Topping[]=[];
  availableToppings:Topping[]=[];
  loading=true;
  page=1;
  constructor( 
    public toppingService:ToppingService,
    public pizzaService:PizzaService
    ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.toppingService
    .GetAllByPizza(this.IdPizza)
    .subscribe(toppings => {
      this.toppings = toppings;
      this.loading = false;
    });
    this.toppingService
    .GetAllAvailableByPizza(this.IdPizza)
    .subscribe(toppings => {
      this.availableToppings = toppings;
      this.loading = false;
    });
  }
  
  remove(topping:Topping){
    const swalWithBootstrapButtons = Swal.mixin();
    swalWithBootstrapButtons.fire(
      {
        title: 'Remove Topping?',
        text: "Do you want to remove Topping from Pizza?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes, remove it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      })
    .then(result => {
      if (result.value) {
        this.pizzaService
          .removeTopping(this.IdPizza,topping.Id)
          .subscribe(() => this.loadData());
      } else {
        Swal.mixin({
          toast: true,
          position: 'top',
          showConfirmButton: false,
          timer: 3000
        }).fire('Topping was removed', '', 'info');
      }
    });
  }
  add(idTopping:string){
    console.log(idTopping)
      const swalWithBootstrapButtons = Swal.mixin();
      swalWithBootstrapButtons.fire(
        {
          title: 'Add Topping?',
          text: "Do you want to add this Topping to Pizza?",
          icon: 'question',
          showCancelButton: true,
          confirmButtonText: 'Yes, add it!',
          cancelButtonText: 'No, cancel!',
          reverseButtons: true
        })
      .then(result => {
        if (result.value) {
          this.pizzaService
            .addTopping(this.IdPizza,idTopping)
            .subscribe(() => this.loadData());
        } else {
          Swal.mixin({
            toast: true,
            position: 'top',
            showConfirmButton: false,
            timer: 3000
          }).fire('Topping was removed', '', 'info');
        }
      });
  }
}
