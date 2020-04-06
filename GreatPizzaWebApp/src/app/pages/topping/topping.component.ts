import { Component, OnInit, Input } from '@angular/core';
import { Topping } from 'src/app/models/topping.model';
import { ToppingService } from 'src/app/services/topping/topping.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-topping',
  templateUrl: './topping.component.html',
  styleUrls: ['./topping.component.css']
})
export class ToppingComponent implements OnInit {
  @Input() public id: string;
  topping: Topping = new Topping();
  loading = true;
  constructor(
    public toppingService: ToppingService,
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
  loadData( IdTopping: string ) {
    this.loading = true;
    if (IdTopping != "new") {
      this.toppingService.get( IdTopping )
            .subscribe(
              topping => {
                this.topping = topping;
                this.loading= false;
              },
              err => {
                this.router.navigate(['/topping']);
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
        this.toppingService.save( this.topping )
        .subscribe( topping => {
          f.reset(f.value);
          if (this.id !="new" ) {
            Swal.mixin({
              toast: true,
              position: 'top',
              showConfirmButton: false,
              timer: 3000
            }).fire('Topping was Updated', '', 'success');
          } else {
            Swal.mixin({
              toast: true,
              position: 'top',
              showConfirmButton: false,
              timer: 3000
            }).fire('Topping was Created', '', 'success');
          }
            this.topping.Id = topping.Id;
            this.router.navigate(['/topping', topping.Id ]);
      });
      } 
      else
      {
        Swal.mixin({
          toast: true,
          position: 'top',
          showConfirmButton: false,
          timer: 3000
        }).fire('Topping was not modified', '', 'info');
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
            this.router.navigate(['/toppings']);
          }
        }
      )
    }
    else
    {
      this.router.navigate(['/toppings']);
    }
  }
}

