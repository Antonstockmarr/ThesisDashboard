import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-checkbox-line',
  templateUrl: './checkbox-line.component.html',
  styleUrls: ['./checkbox-line.component.css']
})
export class CheckboxLineComponent implements OnInit {
  @Input() description!: string;
  @Input() tooltip!: string;
  @Input() onClick: (value: boolean) => void = (value) => {};
  @Input() disabled: boolean = false;
  @Input() checked: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }
}
