import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-difficulty-bar',
  templateUrl: './difficulty-bar.component.html',
  styleUrls: ['./difficulty-bar.component.scss']
})
export class DifficultyBarComponent implements OnInit {
  
  @Input()
  difficulty!: 'easy' | 'medium' | 'hard';
  
  constructor() { }

  ngOnInit(): void {
  }

}
