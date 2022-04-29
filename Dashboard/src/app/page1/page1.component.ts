import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import {ThemePalette} from '@angular/material/core';
import { faUsers,faTriangleExclamation, faServer, faFileContract} from '@fortawesome/free-solid-svg-icons';
import { CheckboxLineComponent } from '../subcomponents/checkbox-line/checkbox-line.component';
import { LocalStorageComponent } from '../local-storage/local-storage.component';
import { LocalStorageService } from '../services/local-storage.service';
import { DataRepositoryService } from '../services/data-repository.service';
import { Objective } from '../models/objective';
import { Concern } from '../models/concern';


@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.scss']
})
export class Page1Component implements OnInit {


  constructor(private storageService: LocalStorageService, private dataRepository: DataRepositoryService) {
    this.dataRepository.getObjectives().subscribe((objectives: Objective[]) => {
      this.objectives = objectives;
    });

    this.dataRepository.getConcerns().subscribe((concerns: Concern[]) => {
      this.concerns = concerns;
    });
  }

  ngOnInit(): void {

  }

  // Icons
  faUsers = faUsers;
  faSensorTriangleExclamation = faTriangleExclamation;
  faServer = faServer;
  faContract = faFileContract;

  objectives: Objective[] = [];
  concerns: Concern[] = [];

  // Approaches : string[] = ['Health Checks', 'Distributed Tracing', 'Network Traffic', 'Custom Logs', 'Error Logs', 'Alert System', 'OS Metrics'];

    
  presetConcerns(objective: Objective) {
    console.log(objective);

    this.concerns.forEach(concern => {
      this.changeSelection(concern, objective.id == concern.objectiveId);
    });
  }

  changeSelection(concern: Concern, value: boolean) {
    concern.isChecked = value;
    this.storageService.set(concern.name, concern.isChecked ? "true" : "false");
  }
}
