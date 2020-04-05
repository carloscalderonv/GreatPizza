import { Component, OnInit, Input } from '@angular/core';
import { Pizza } from 'src/app/models/pizza.model';
import { PizzaService } from 'src/app/services/pizza/pizza.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent implements OnInit {
  @Input() public id: string;
  pizza: Pizza = new Pizza();
  loading = true;
  constructor(
    public pizzaService: PizzaService,
    public router: Router,
    public activatedRoute: ActivatedRoute,
  ) { 
    activatedRoute.params.subscribe( params => {
      this.id = params.id;
    });
  }

  ngOnInit(): void {
    this.loadData( this.id );
  }
  loadData( IdPizza: string ) {
    this.loading = true;
    if (IdPizza != "new") {
      this.pizzaService.get( IdPizza )
            .subscribe(
              pizza => {
                this.pizza = pizza;
                this.loading= false;
              },
              err => {
                this.router.navigate(['/pizza']);
              }
            );
    } else {
      this.loading = false;
    }
  }
  save( f: NgForm ) {
    if ( !f.invalid ) {
      if ( !f.pristine)
      {
        this.pizzaService.save( this.pizza )
        .subscribe( pizza => {
          f.reset(f.value);
          if (this.id !="new" ) {
            Swal.mixin({
              toast: true,
              position: 'top',
              showConfirmButton: false,
              timer: 3000
            }).fire('Pizza was Updated', '', 'success');
          } else {
            Swal.mixin({
              toast: true,
              position: 'top',
              showConfirmButton: false,
              timer: 3000
            }).fire('Pizza was Created', '', 'success');
          }
            this.pizza.Id = pizza.Id;
            this.router.navigate(['/pizza', pizza.Id ]);
      });
      } 
      else
      {
        Swal.mixin({
          toast: true,
          position: 'top',
          showConfirmButton: false,
          timer: 3000
        }).fire('Pizza was not modified', '', 'info');
      }
    }
    else
    {
      Swal.mixin({
        toast: true,
        position: 'top',
        showConfirmButton: false,
        timer: 3000
      }).fire('There was an error Saving the data', '', 'error');
    }
  }

  cancel(f: NgForm) {
    if (!f.pristine)
    {
      const swalWithBootstrapButtons = Swal.mixin();
      swalWithBootstrapButtons.fire(
        {
          title: 'Cancel Edition',
          text: "All non saved changes will lost, are you sure?",
          icon: 'question',
          showCancelButton: true,
          confirmButtonText: 'Yes',
          cancelButtonText: 'No',
          reverseButtons: true
        })
        .then(
        result=>{
          if (result.value)
          {
            this.router.navigate(['/pizzas']);
          }
        }
      )
    }
    else
    {
      this.router.navigate(['/pizzas']);
    }
  }
}
