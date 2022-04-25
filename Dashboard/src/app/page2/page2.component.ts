import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../services/local-storage.service';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.scss']
})
export class Page2Component implements OnInit {

  private id : string = "";
  private value : string = "";
  

  constructor(private storageService: LocalStorageService) { }

  ngOnInit(): void {
    this.storageService.watchStorage().subscribe((idvalue:[string,string]) => {
      this.id = idvalue[0];
      this.value = idvalue[1];
      this.checkboxesDataList.forEach(element => {
        if (element.id === this.id) {
          element.isChecked = this.value == 'true' ? true : false;
        }
      });
    })
  }

  checkbox(value: boolean): void {
    console.log(value);
  }

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


}
