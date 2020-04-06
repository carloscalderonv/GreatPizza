import { Component, OnInit } from '@angular/core';
import { Topping } from 'src/app/models/topping.model';
import { ToppingService } from 'src/app/services/topping/topping.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-toppings',
  templateUrl: './toppings.component.html',
  styleUrls: ['./toppings.component.css']
})
export class ToppingsComponent implements OnInit {
  toppings:Topping[]=[];
  loading=true;
  page=1;
  constructor( public toppingService:ToppingService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.toppingService
    .getAll()
    .subscribe(topping => {
      this.toppings = topping;
      this.loading = false;
    });
  }
  
  delete(topping:Topping){
    const swalWithBootstrapButtons = Swal.mixin();
    swalWithBootstrapButtons.fire(
      {
        title: 'Delete Topping?',
        text: "This will delete the Topping, do you want to continue?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      })
    .then(result => {
      if (result.value) {
        this.toppingService
          .delete(topping.Id)
          .subscribe(() => this.loadData());
      } else {
        Swal.mixin({
          toast: true,
          position: 'top',
          showConfirmButton: false,
          timer: 3000
        }).fire('Topping was not deleted', '', 'info');
      }
    });
  }
}

