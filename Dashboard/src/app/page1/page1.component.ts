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

  // Approaches : string[] = ['Health Checks', 'Distributed Tracing', 'Network Traffic', 'Custom Logs', 'Error Logs', 'Alert System', 'OS Metrics'];

  checkboxesDataList : any[] = [
    {
      id: '1',
      label: 'Availability',
      isChecked: false
    },
    {
      id: '2',
      label: 'Performance',
      isChecked: false
    },
    {
      id: '3',
      label: 'User behaviour',
      isChecked: false
    },
    {
      id: '4',
      label: 'Error Management',
      isChecked: false
    },
    {
      id: '5',
      label: 'Network Security',
      isChecked: false
    },
    {
      id: '6',
      label: 'Scalability',
      isChecked: false
    },
    {
      id: '7',
      label: 'Capacity planning',
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
        if (element.id == "1" || element.id == "2" || element.id =="3") {
          element.isChecked = true;
          this.changeSelection(element.isChecked, element.id);
          return;
        }
      }
      if (value == "IH") {
        if (element.id == "4" || element.id == "5") {
          element.isChecked = true;
          this.changeSelection(element.isChecked, element.id);
          return;
        }
      }
      if (value == "RM") {
        if (element.id == "6" || element.id == "7") {
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
    this.localStorage.set(keyLabel, e ? "true": "false");
  }

}
