import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SetupConfiguration } from '../models/setupConfiguration';
import { DataRepositoryService } from '../services/data-repository.service';

@Component({
  selector: 'app-recommendation-page',
  templateUrl: './recommendation-page.component.html',
  styleUrls: ['./recommendation-page.component.scss']
})
export class RecommendationPageComponent implements OnInit {

  @Input() submitApproaches!: Subject<void>;
  Markdown: Subject<void> = new Subject<void>();

  configuration: SetupConfiguration = {id: -1, image: "", description: "", setupFiles: ""};

  constructor(private dataRepository: DataRepositoryService) {
    console.log(this.configuration);
    }

  ngOnInit(): void {
    this.submitApproaches.asObservable().subscribe(async () => {
      await this.getConfiguration();
      this.Markdown.next();
    });
  }
  
  async getConfiguration() {
    this.configuration = await this.dataRepository.getSetupConfiguration();
  }  
}
