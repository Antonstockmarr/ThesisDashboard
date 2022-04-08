import { Component, Input, OnInit } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  @Input() stepper!: MatStepper

  constructor() { }

  ngOnInit(): void {
  }

  goBack(stepper: MatStepper){
    stepper.previous();
  }

  goForward(stepper: MatStepper){
    stepper.next();
  }

  isFirst(stepper: MatStepper):boolean{
    return stepper.selectedIndex == 0;
  }

  isLast(stepper: MatStepper):boolean{
    return stepper.selectedIndex == stepper._steps.length - 1;
  }
}
