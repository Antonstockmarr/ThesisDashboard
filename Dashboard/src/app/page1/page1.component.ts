import { Component, OnInit } from '@angular/core';
import { faUsers,faTriangleExclamation, faServer, faFileContract} from '@fortawesome/free-solid-svg-icons';
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

  objectives: Objective[] = [];
  concerns: Concern[] = [];

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

  ngOnInit(): void {

  }

  getIcon(objective: Objective) {
    if (objective.name == "UX")
      return faUsers;
    if (objective.name == "resource")
      return faServer;
    if (objective.name == "Incident")
      return faTriangleExclamation
    else return faUsers;
  }
    
  presetConcerns(objective: Objective) {
    console.log(objective);

    this.concerns.forEach(concern => {
      this.changeSelection(concern, objective.id == concern.objectiveId);
    });
  }

  changeSelection(concern: Concern, value: boolean) {
    this.checkedConcerns.set(concern.id, value);
    this.storageService.set(concern.name, value ? "true" : "false");
  }
}
