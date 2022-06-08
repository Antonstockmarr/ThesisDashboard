import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-contentcard',
  templateUrl: './contentcard.component.html',
  styleUrls: ['./contentcard.component.scss']
})
export class ContentcardComponent implements OnInit {

  @Input() title?: string = "";
  @Input() errorState: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  getColor(): string {
    if (!this.errorState) {
      return "background-color: #eeeeee"
    }
    else return "background-color: #FABFB8"
  }
}
