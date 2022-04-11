import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
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

  checkboxesDataList : any[] = [
    {
      id: 'C001',
      label: 'Health Checks',
      isChecked: true
    },
    {
      id: 'C002',
      label: 'Distributed Tracing',
      isChecked: true
    },
    {
      id: 'C003',
      label: 'Network Traffic',
      isChecked: true
    },
    {
      id: 'C004',
      label: 'Custom Logs',
      isChecked: false
    },
    {
      id: 'C004',
      label: 'Error Logs',
      isChecked: false
    },
    {
      id: 'C005',
      label: 'Alert System',
      isChecked: true
    },
    {
      id: 'C006',
      label: 'OS Metrics',
      isChecked: true
    }
  ]


  constructor() { }

  ngOnInit(): void {
    this.fetchSelectedItems()
    this.fetchCheckedIDs()
  }

  public preSetValus(value: boolean) {
    console.log(this.temp.valueOf());
  }

  public key: string = 'Name';
  public myItem: string | null = '';
  

  selectedItemsList : any[] = [];
  checkedIDs : any[] = [];

  changeSelection(e: MatCheckboxChange, keyLabel:string) {
    localStorage.setItem(keyLabel,e.checked? "true":"false");
  }

  fetchSelectedItems() {
    console.log("something2");
    this.selectedItemsList = this.checkboxesDataList.filter((value, index) => {
      return value.isChecked
    });
  }


  fetchCheckedIDs() {
     this.checkedIDs = []
     console.log("something3");
    this.checkboxesDataList.forEach((value, index) => {
      if (value.isChecked) {
      this.checkedIDs.push(value.id);
       console.log(value.id);
      }
    });
  }

}
