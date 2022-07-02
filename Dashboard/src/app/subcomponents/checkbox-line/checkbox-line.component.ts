import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatCheckbox, MatCheckboxChange } from '@angular/material/checkbox';


@Component({
  selector: 'app-checkbox-line',
  templateUrl: './checkbox-line.component.html',
  styleUrls: ['./checkbox-line.component.scss']
})
export class CheckboxLineComponent implements OnInit {
  @Input() name!: string;
  @Input() tooltip?: string = '';
  @Input() description?: string = '';
  @Output() onClick: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Input() disabled: boolean = false;
  @Input() isChecked: boolean = false;
  @Input() nameFontSize?: number = 22;
  @Input() descriptionFontSize?: number = 16;


  constructor() { }

  ngOnInit(): void {
  }

  onChange(e: MatCheckboxChange) {
    this.onClick.emit(e.checked); 
  }

  getNameStyle(): string {
    return `font-size: ${this.nameFontSize}px`
  }

  getDescriptionStyle(): string {
    return `font-size: ${this.descriptionFontSize}px`
  }
}
