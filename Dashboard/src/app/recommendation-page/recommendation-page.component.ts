import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { Configuration } from '../models/configuration';
import { DataRepositoryService } from '../services/data-repository.service';

@Component({
  selector: 'app-recommendation-page',
  templateUrl: './recommendation-page.component.html',
  styleUrls: ['./recommendation-page.component.scss']
})
export class RecommendationPageComponent implements OnInit {

  @Input() submitApproaches!: Subject<void>;
  Markdown: Subject<string> = new Subject<string>();

  configuration: Configuration = {id: -1, image: "", description: "", setupFiles: "", markdown: ""};

  constructor(private dataRepository: DataRepositoryService) {
    console.log(this.configuration);
    }

  ngOnInit(): void {
    this.submitApproaches.asObservable().subscribe(async () => {
      await this.getConfiguration();
      this.Markdown.next(this.configuration.markdown);
    });
  }
  
  async getConfiguration() {
    this.configuration = await this.dataRepository.getConfiguration();
  }  
}
