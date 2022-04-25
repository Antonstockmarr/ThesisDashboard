import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-local-storage',
  templateUrl: './local-storage.component.html',
  styleUrls: ['./local-storage.component.scss']
})
export class LocalStorageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public storeInLocalStorage(keyLabel:string, value: string) {
    localStorage.setItem(keyLabel, value);
  }

}
