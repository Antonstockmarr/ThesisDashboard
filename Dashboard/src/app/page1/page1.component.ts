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
      id: 'HC',
      label: 'Health Checks',
      isChecked: false
    },
    {
      id: 'DT',
      label: 'Distributed Tracing',
      isChecked: false
    },
    {
      id: 'NT',
      label: 'Network Traffic',
      isChecked: false
    },
    {
      id: 'EL',
      label: 'Error Logs',
      isChecked: false
    },
    {
      id: 'AS',
      label: 'Alert System',
      isChecked: false
    },
    {
      id: 'OM',
      label: 'OS Metrics',
      isChecked: false
    }
  ]


  constructor() { }

  ngOnInit(): void {
    this.fetchSelectedItems()
    this.fetchCheckedIDs()
  }

  public presetValues(value: string) {
    console.log(value);

    this.checkboxesDataList.forEach(element => {
      if (value == "UX") {
        if (element.id == "HC" || element.id == "DT" || element.id =="NT") {
          element.isChecked = true;
          return;
        }
      }
      if (value == "IH") {
        if (element.id == "DT" || element.id == "NT" || element.id =="AS" || element.id =="EL") {
          element.isChecked = true;
          return;
        }
      }
      if (value == "RM") {
        if (element.id == "OM" || element.id == "NT") {
          element.isChecked = true;
          return; 
        }
      }
      element.isChecked =false;
    });
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
