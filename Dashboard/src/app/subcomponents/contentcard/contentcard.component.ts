import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-contentcard',
  templateUrl: './contentcard.component.html',
  styleUrls: ['./contentcard.component.scss']
})
export class ContentcardComponent implements OnInit {

  @Input() title?: string = "";

  constructor() { }

  ngOnInit(): void {
  }

}
