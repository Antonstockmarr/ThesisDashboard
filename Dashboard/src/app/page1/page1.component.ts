import { Component, OnInit, Output } from '@angular/core';
import {ThemePalette} from '@angular/material/core';
import { faUsers,faTriangleExclamation, faServer, faFileContract} from '@fortawesome/free-solid-svg-icons';
import { CheckboxLineComponent } from '../subcomponents/checkbox-line/checkbox-line.component';



@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.scss']
})
export class Page1Component implements OnInit {

  // Icons
  faUsers = faUsers;
  faSensorTriangleExclamation = faTriangleExclamation;
  faServer = faServer;
  faContract = faFileContract;

  public temp: boolean = false;

  Approaches : string[] = ['Health Checks', 'Distributed Tracing', 'Network Traffic', 'Custom Logs', 'Error Logs', 'Alert System', 'OS Metrics'];


  constructor() { }

  ngOnInit(): void {
  }

  public preSetValus(value: boolean) {
    // this.temp = checkedS;
    // this.temp = (this.temp)? true : false;
    this.temp = value;
    console.log(this.temp.valueOf());
  }

}
