import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import {ThemePalette} from '@angular/material/core';
import { faUsers,faTriangleExclamation, faServer, faFileContract} from '@fortawesome/free-solid-svg-icons';
import { CheckboxLineComponent } from '../subcomponents/checkbox-line/checkbox-line.component';
import { LocalStorageComponent } from '../local-storage/local-storage.component';


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
  localStorage = new LocalStorageComponent();

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
  }

  public presetValues(value: string) {
    console.log(value);

    this.checkboxesDataList.forEach(element => {
      if (value == "UX") {
        if (element.id == "HC" || element.id == "DT" || element.id =="NT") {
          element.isChecked = true;
          this.changeSelection(element.isChecked, element.id);
          return;
        }
      }
      if (value == "IH") {
        if (element.id == "DT" || element.id == "NT" || element.id =="AS" || element.id =="EL") {
          element.isChecked = true;
          this.changeSelection(element.isChecked, element.id);
          return;
        }
      }
      if (value == "RM") {
        if (element.id == "OM" || element.id == "NT") {
          element.isChecked = true;
          this.changeSelection(element.isChecked, element.id);
          return; 
        }
      }
      element.isChecked =false;
      this.changeSelection(element.isChecked, element.id);
    });
  }

  public key: string = 'Name';
  public myItem: string | null = '';
  

  selectedItemsList : any[] = [];
  checkedIDs : any[] = [];

  changeSelection(e: boolean, keyLabel:string) {
    console.log("something");
    this.checkboxesDataList.forEach(element => {
      if (element.id == keyLabel) {
        element.isChecked = e; 
      } 
    });
    this.localStorage.storeInLocalStorage(keyLabel, e ? "true": "false");
  }

}
