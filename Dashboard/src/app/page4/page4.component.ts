import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page4',
  templateUrl: './page4.component.html',
  styleUrls: ['./page4.component.scss']
})
export class Page4Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  textFile = 'https://configurationfiles.blob.core.windows.net/configuration/test.txt'
  zipFile = 'https://configurationfiles.blob.core.windows.net/configuration/Nyt arkiv.zip'

  tools = ['Grafana', 'Prometheus']
}
