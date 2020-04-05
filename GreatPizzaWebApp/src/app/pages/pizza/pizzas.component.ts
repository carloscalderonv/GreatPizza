import { Component, OnInit } from '@angular/core';
import { Pizza } from 'src/app/models/pizza.model';
import { PizzaService } from 'src/app/services/pizza/pizza.service';
import Swal from 'sweetalert2'
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
    const swalWithBootstrapButtons = Swal.mixin();
    swalWithBootstrapButtons.fire(
      {
        title: 'Delete Pizza?',
        text: "This will delete the Pizza, do you want to continue?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      })
    .then(result => {
      if (result.value) {
        this.pizzaService
          .delete(pizza.Id)
          .subscribe(() => this.loadData());
      } else {
        Swal.mixin({
          toast: true,
          position: 'top',
          showConfirmButton: false,
          timer: 3000
        }).fire('Pizza was not deleted', '', 'info');
      }
    });
  }
}
