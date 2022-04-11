import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatCheckbox, MatCheckboxChange } from '@angular/material/checkbox';


@Component({
  selector: 'app-checkbox-line',
  templateUrl: './checkbox-line.component.html',
  styleUrls: ['./checkbox-line.component.css']
})
export class CheckboxLineComponent implements OnInit {
  @Input() description!: string;
  @Input() tooltip!: string;
  @Output() onClick: EventEmitter<MatCheckboxChange> = new EventEmitter<MatCheckboxChange>();
  @Input() disabled: boolean = false;
  @Input() checked: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  onChange(ob: MatCheckboxChange) {
    this.onClick.emit(ob); 
  }

}
