import { Component, OnInit } from '@angular/core';
import { SystemSetting } from '../models/system-setting';

@Component({
  selector: 'app-page3',
  templateUrl: './page3.component.html',
  styleUrls: ['./page3.component.scss']
})
export class Page3Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  click(value: boolean): void {
    console.log(value);
  }

  technologies: SystemSetting[] = [
    {
      id: '0',
      label: 'Kubernetes',
      isChecked: false
    },
    {
      id: '1',
      label: 'Docker',
      isChecked: false
    },
    {
      id: '2',
      label: 'Prometheus',
      isChecked: false
    }
  ]

}
