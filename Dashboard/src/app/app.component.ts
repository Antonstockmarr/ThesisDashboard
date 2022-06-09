import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';
import { Subject } from 'rxjs';
import { Approach } from './models/approach';
import { Concern } from './models/concern';
import { DataRepositoryService } from './services/data-repository.service';
import { LocalStorageService } from './services/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Dashboard';
  error = "";
  concerns: Concern[] = [];
  approaches: Approach[] = [];
  validateCallback: () => boolean = () => true;
  submitApproaches: Subject<void> = new Subject<void>();

  // init data
  constructor(private storageService: LocalStorageService, private dataRepository: DataRepositoryService) {
    this.dataRepository.getConcerns().subscribe((concerns: Concern[]) => {
      this.concerns = concerns;
    });

    this.dataRepository.getApproaches().subscribe((approaches: Approach[]) => {
      this.approaches = approaches;
    });
  }

  
  ngOnInit(): void {
    this.validateCallback = this.validateAndSetErrorStates.bind(this);
  }

  // validation
  errorConcernIds: number[] = [];

  validate() : boolean {
    if (this.noSelectedConcerns()) {
      this.error = "No concerns have been selected";
      return false;
    }

    if (this.concernsWithoutApproaches().length != 0) {
      this.error = "All selected concerns must have at least one selected approach";
      return false;
    }

    this.error = "";
    return true;
  }

  validateAndSetErrorStates() : boolean {
    this.errorConcernIds = this.concernsWithoutApproaches();
    return this.validate();
  }

  concernsWithoutApproaches(): number[] {
    let concernIds: number[] = [];
    this.concerns.forEach(concern => {
      let selected = this.storageService.get(`concern${concern.id}`);
      if (selected == 'true' && this.concernWithoutAppoach(concern)) {
         concernIds.push(concern.id);
      }
    });

    return concernIds;
  }
  concernWithoutAppoach(concern: Concern) {
    return !this.approaches.some(approach => {
      let selected = this.storageService.get(`approach${approach.id}`);
      return (selected == 'true' && approach.concernId == concern.id);
    })
  }

  noSelectedConcerns() : boolean {
    return !this.concerns.some(concern => {
      let selected = this.storageService.get(`concern${concern.id}`);
      return selected == 'true';
    })
  }

  stepperEvents(stepper: MatStepper, event: StepperSelectionEvent) {
    if (stepper._steps.length - 1 == event.selectedIndex) {
      this.submitApproaches.next();
    }
  }
}
