import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToppingPizzaComponent } from './topping-pizza.component';

describe('ToppingPizzaComponent', () => {
  let component: ToppingPizzaComponent;
  let fixture: ComponentFixture<ToppingPizzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToppingPizzaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToppingPizzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
