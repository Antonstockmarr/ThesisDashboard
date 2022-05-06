import { Component, OnInit } from '@angular/core';
import { setupConfiguration } from '../models/setConfiguration';
import { DataRepositoryService } from '../services/data-repository.service';

@Component({
  selector: 'app-page4',
  templateUrl: './page4.component.html',
  styleUrls: ['./page4.component.scss']
})
export class Page4Component implements OnInit {

  config: setupConfiguration[] = [];
  imageURL : string ="";
  configurationfiles : string = "";

  constructor(private dataRepository: DataRepositoryService) {
    this.dataRepository.getSetupConfiguration().subscribe((config: setupConfiguration[]) => {
      this.config = config;
      // this.imageURL = this.config[0].ImageURL;
      this.configurationfiles = "https://configurationfiles.blob.core.windows.net/" + this.config[0].imageURL; 
      console.log(this.config);
      console.log(this.config[0]);
      console.log(this.config[0].imageURL);
    });

   }

  ngOnInit(): void {
    // this.configurationfiles = "https://configurationfiles.blob.core.windows.net/" + this.config[0].ImageURL;
  }

  textFile = 'https://configurationfiles.blob.core.windows.net/configuration/test.txt'
  zipFile = 'https://configurationfiles.blob.core.windows.net/configuration/Nyt arkiv.zip'
  // configurationfiles = "https://configurationfiles.blob.core.windows.net/" + this.config[0].ImageURL;


  tools = ['Grafana', 'Prometheus']
}
