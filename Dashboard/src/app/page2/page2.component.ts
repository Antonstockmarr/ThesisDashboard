import { Component, OnInit } from '@angular/core';
import { Approach } from '../models/approach';
import { Concern } from '../models/concern';
import { DataRepositoryService } from '../services/data-repository.service';
import { LocalStorageService } from '../services/local-storage.service';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.scss']
})
export class Page2Component implements OnInit {

  approaches: Approach[] = [];
  concerns: Concern[] = [];

  constructor(private storageService: LocalStorageService, private dataRepository: DataRepositoryService) {
    this.dataRepository.getApproaches().subscribe((approaches: Approach[]) => {
      this.approaches = approaches;
    });

    this.dataRepository.getConcerns().subscribe((concerns: Concern[]) => {
      this.concerns = concerns;
    });
   }

  ngOnInit(): void {
    this.storageService.watchStorage().subscribe((valuePair:[string,string]) => {
      const concernName = valuePair[0];
      const isChecked = valuePair[1];
      const concern = this.concerns.find((c) => c.name === concernName);
      if (!concern) return;
      this.concerns.forEach(c => {
        if (c.id === concern.id) {
          c.isChecked = isChecked == 'true' ? true : false;
        }
      });
    });
  }

  concernApproaches(concern: Concern): Approach[] {
    return this.approaches.filter(approach => approach.concernId == concern.id);
  }


  checkbox(value: boolean): void {
    console.log(value);
  }
}
