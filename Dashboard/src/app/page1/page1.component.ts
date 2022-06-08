import { Component, Input, OnInit } from '@angular/core';
import { LocalStorageService } from '../services/local-storage.service';
import { DataRepositoryService } from '../services/data-repository.service';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';
import { HostListener } from "@angular/core";
import { Approach } from '../models/approach';

@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.scss']
})
export class Page1Component implements OnInit {

  @Input() errorConcernIds: Number[] = [];

  objectives: Objective[] = [];
  concerns: Concern[] = [];
  approaches: Approach[] = [];

  showConcerns = false;

  checkedConcerns: Map<number, boolean> = new Map();
  checkedApproaches: Map<number, boolean> = new Map();

  // Init data
  constructor(private storageService: LocalStorageService, private dataRepository: DataRepositoryService) {
    this.dataRepository.getObjectives().subscribe((objectives: Objective[]) => {
      this.objectives = objectives;
    });

    this.dataRepository.getConcerns().subscribe((concerns: Concern[]) => {
      this.concerns = concerns;
      concerns.forEach((concern) => {
        if (!(this.checkedConcerns.has(concern.id)))
          this.checkedConcerns.set(concern.id, false);
          this.storageService.set(`concern${concern.id}`, 'false');
      });
    });

    this.dataRepository.getApproaches().subscribe((approaches: Approach[]) => {
      this.approaches = approaches;
      approaches.forEach((approach) => {
        if (!(this.checkedApproaches.has(approach.id)))
          this.checkedApproaches.set(approach.id, false);
          this.storageService.set(`approach${approach.id}`, 'false');
      });
    });
  }

  // Responsive objective columns
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

  // Load local images
  getIcon(objective: Objective): string {
    return `assets/${objective.name}.png`;
  }
    
  // Selection methods
  presetConcerns(objective: Objective) {
    this.showConcerns = true;
    this.concerns.forEach(concern => {
      this.changeConcernSelection(concern, objective.id == concern.objectiveId);
    });
  }

  changeConcernSelection(concern: Concern, value: boolean) {
    this.storageService.set(`concern${concern.id}`, value ? 'true' : 'false');
    this.checkedConcerns.set(concern.id, value);
    this.concernApproaches(concern).forEach(approach => {
      this.changeApproachSelection(approach, false);
    })
  }

  changeApproachSelection(approach: Approach, value: boolean) {
    this.storageService.set(`approach${approach.id}`, value ? 'true' : 'false');
    this.checkedApproaches.set(approach.id, value);
  }

  concernApproaches(concern: Concern): Approach[] {
    return this.approaches.filter(approach => approach.concernId == concern.id);
  }

  getErrorState(concern: Concern): boolean {
    return this.errorConcernIds.includes(concern.id);
  }
}
