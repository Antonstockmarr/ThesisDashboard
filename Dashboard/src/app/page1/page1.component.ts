import { Component, OnInit } from '@angular/core';
import {ThemePalette} from '@angular/material/core';


@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.scss']
})
export class Page1Component implements OnInit {

  tmp: boolean = false;

  longText = `The Shiba`;

  constructor() { }

  ngOnInit(): void {
  }

}
