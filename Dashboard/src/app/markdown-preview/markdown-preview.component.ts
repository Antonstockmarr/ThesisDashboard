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

  @Input() Markdown!: Subject<void>;

  markdown: string | undefined;
  constructor(private mdService: MarkdownService, private http: HttpClient) { 
    console.log(this.Markdown)
    console.log(this.markdown);
  }

   ngOnInit(): void {
    this.Markdown.asObservable().subscribe(async () => {
      await this.getMarkdownfile();
    });
  }

  async getMarkdownfile() {
    const markdownRaw =  await firstValueFrom(this.http.get('https://configurationfiles.blob.core.windows.net/markdown-files/setupDescription.md', { responseType: 'text' }));
    this.markdown = this.mdService.compile(markdownRaw);
    console.log(this.markdown);
  }  

}
