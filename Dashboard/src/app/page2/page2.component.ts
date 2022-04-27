import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../services/local-storage.service';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.scss']
})
export class Page2Component implements OnInit {

  private id : string = "";
  private value : string = "";
  

  constructor(private storageService: LocalStorageService) { }

  ngOnInit(): void {
    this.storageService.watchStorage().subscribe((idvalue:[string,string]) => {
      this.id = idvalue[0];
      this.value = idvalue[1];
      this.checkboxesDataList.forEach(element => {
        if (element.id === this.id) {
          element.isChecked = this.value == 'true' ? true : false;
        }
      });
    })
  }

  checkbox(value: boolean): void {
    console.log(value);
  }

  monitoringApproaches: any[] = [
    {
      description: 'Health checks',
      tooltip: 'Periodically ping services to see if they are up',
      difficulty: 'easy'
    },
    {
      description: 'Work metrics',
      tooltip: 'Metrics on how the services are running, like latency, throughput, etc.',
      difficulty: 'medium'
    },
    {
      description: 'Distributed tracing',
      tooltip: 'Track requests across services to link events and produce timelines.',
      difficulty: 'hard'
    },
    {
      description: 'Application logs',
      tooltip: 'Logs that are produced within the application. This requires source code instrumentation.',
      difficulty: 'easy'
    },
    {
      description: 'Alert system',
      tooltip: 'Send alerts to stakeholders as reaction to specific events or thresholds.',
      difficulty: 'medium'
    },
    {
      description: 'Network logs',
      tooltip: 'Monitor network log to analyse traffic and identify malicious activity.',
      difficulty: 'easy'
    },
    {
      description: 'Resource metrics',
      tooltip: 'Monitor CPU, storage and memory usage',
      difficulty: 'easy'
    }
  ];

  getApproach(description: string): any {
    return this.monitoringApproaches.find(a => a.description === description);
  }

  checkboxesDataList : any[] = [
    {
      id: '1',
      label: 'Availability',
      isChecked: false,
      approaches: [
        this.getApproach('Health checks'),
        this.getApproach('Work metrics')
      ]
    },
    {
      id: '2',
      label: 'Performance',
      isChecked: false,
      approaches: [
        this.getApproach('Work metrics'),
        this.getApproach('Distributed tracing'),
      ]
    },
    {
      id: '3',
      label: 'User behaviour',
      isChecked: false,
      approaches: [
        this.getApproach('Distributed tracing'),
      ]
    },
    {
      id: '4',
      label: 'Error Management',
      isChecked: false,
      approaches: [
        this.getApproach('Distributed tracing'),
        this.getApproach('Application logs'),
        this.getApproach('Alert system'),
      ]
    },
    {
      id: '5',
      label: 'Network Security',
      isChecked: false,
      approaches: [
        this.getApproach('Network logs'),
      ]
    },
    {
      id: '6',
      label: 'Scalability',
      isChecked: false,
      approaches: [
        this.getApproach('Work metrics'),
        this.getApproach('Resource metrics'),
      ]
    },
    {
      id: '7',
      label: 'Capacity planning',
      isChecked: false,
      approaches: [
        this.getApproach('Resource metrics'),
      ]
    }
  ]


}
