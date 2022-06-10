import { Component, OnInit, Input } from '@angular/core';
import { MarkdownService } from 'ngx-markdown';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom, Subject } from 'rxjs';

@Component({
  selector: 'app-markdown-preview',
  templateUrl: './markdown-preview.component.html',
  styleUrls: ['./markdown-preview.component.scss']
})
export class MarkdownPreviewComponent implements OnInit {

  @Input() Markdown!: Subject<string>;


  markdown: string | undefined;
  constructor(private mdService: MarkdownService, private http: HttpClient) { 
  }

  ngOnInit(): void {
    this.Markdown.asObservable().subscribe(async (markdownTemp) => {
      await this.getMarkdownfile(markdownTemp);
    });
  }

  // For testing
  // async ngOnInit() {
  //   const markdownRaw = await firstValueFrom(this.http.get('/markdown-files/setupDescription.md', 
  //     { responseType: 'text' }));  
  //   this.markdown = this.mdService.compile(markdownRaw);
  // }

  async getMarkdownfile(markdownTemp: string) {
    const markdownRaw =  await firstValueFrom(this.http.get(markdownTemp, { responseType: 'text' }));
    // const markdownRaw =  await firstValueFrom(this.http.get('/markdown-files/markdown.md', { responseType: 'text' }));
    this.markdown = this.mdService.compile(markdownRaw);
    console.log(markdownRaw);
    console.log(this.markdown);
  }  

}
