import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../services/local-storage.service';
import { DataRepositoryService } from '../services/data-repository.service';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';
import { HostListener } from "@angular/core";

@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.scss']
})
export class Page1Component implements OnInit {

  objectives: Objective[] = [];
  concerns: Concern[] = [];
  showConcerns = false;


  checkedConcerns: Map<number, boolean> = new Map();

  constructor(private storageService: LocalStorageService, private dataRepository: DataRepositoryService) {
    this.dataRepository.getObjectives().subscribe((objectives: Objective[]) => {
      this.objectives = objectives;
    });

    this.dataRepository.getConcerns().subscribe((concerns: Concern[]) => {
      this.concerns = concerns;
      concerns.forEach((concern) => {
        if (!(this.checkedConcerns.has(concern.id)))
          this.checkedConcerns.set(concern.id, false)
      });
    });
  }

  public innerWidth: any;
  ngOnInit() {
      this.innerWidth = window.innerWidth;
  }

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.innerWidth = window.innerWidth;
  }

  getGridColumns() {
    if (this.innerWidth < 500) {
      return 1;
    }
    else return 3;
  }

  getIcon(objective: Objective): string {
    return `assets/${objective.name}.png`;
  }
    
  presetConcerns(objective: Objective) {
    this.showConcerns = true;
    this.concerns.forEach(concern => {
      this.changeSelection(concern, objective.id == concern.objectiveId);
    });
  }

  changeSelection(concern: Concern, value: boolean) {
    this.checkedConcerns.set(concern.id, value);
    this.storageService.set(concern.name, value ? "true" : "false");
  }

}
