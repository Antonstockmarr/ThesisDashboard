import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatCheckbox, MatCheckboxChange } from '@angular/material/checkbox';


@Component({
  selector: 'app-checkbox-line',
  templateUrl: './checkbox-line.component.html',
  styleUrls: ['./checkbox-line.component.scss']
})
export class CheckboxLineComponent implements OnInit {
  @Input() description!: string;
  @Input() tooltip?: string = '';
  @Output() onClick: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Input() disabled: boolean = false;
  @Input() isChecked: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  onChange(e: MatCheckboxChange) {
    this.onClick.emit(e.checked); 
  }

}
