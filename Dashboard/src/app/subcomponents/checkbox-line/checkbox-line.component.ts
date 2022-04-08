import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-checkbox-line',
  templateUrl: './checkbox-line.component.html',
  styleUrls: ['./checkbox-line.component.css']
})
export class CheckboxLineComponent implements OnInit {
  @Input() description!: string;
  @Input() tooltip!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
