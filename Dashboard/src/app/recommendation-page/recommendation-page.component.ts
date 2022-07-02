import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { Configuration } from '../models/configuration';
import { Tool } from '../models/tool';
import { DataRepositoryService } from '../services/data-repository.service';

@Component({
  selector: 'app-recommendation-page',
  templateUrl: './recommendation-page.component.html',
  styleUrls: ['./recommendation-page.component.scss']
})
export class RecommendationPageComponent implements OnInit {

  @Input() submitApproaches!: Subject<void>;
  Markdown: Subject<string> = new Subject<string>();
  tools: Tool[] = []

  configuration: Configuration = {id: -1, image: "", description: "", setupFiles: "", markdown: ""};

  constructor(private dataRepository: DataRepositoryService) {}

  ngOnInit(): void {
    this.submitApproaches.asObservable().subscribe(async () => {
      await this.getConfiguration();
      if (this.configuration.id != -1){
        this.tools = await this.dataRepository.getToolsFromConfigurationId(this.configuration.id);
        this.Markdown.next(this.configuration.markdown);
      }
    });
  }
  
  async getConfiguration() {
    this.configuration = await this.dataRepository.getConfiguration();
  }  
}
