import { Component, OnInit, ViewChild } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { PdfViewerComponent } from 'ng2-pdf-viewer';
import { UploadAdapter } from '../shared/uploadadapter';

@Component({
  selector: 'app-viewer',
  templateUrl: './viewer.component.html',
  styleUrls: ['./viewer.component.css']
})
export class ViewerComponent implements OnInit {
  @ViewChild(PdfViewerComponent, {static:false}) private pdfComponent: PdfViewerComponent;
  pdfSrc: any;

  search(stringToSearch: string) {
    this.pdfComponent.pdfFindController.executeCommand('find', {
      caseSensitive: false, findPrevious: undefined, highlightAll: true, phraseSearch: true, query: stringToSearch
    });
  }
  public Editor = ClassicEditor ;
  public editorData = "<p>Hello world!</p>" ;
  constructor() { }
  onFileSelected() {
    let $img: any = document.querySelector('#file');
  
    if (typeof (FileReader) !== 'undefined') {
      let reader = new FileReader();
  
      reader.onload = (e: any) => {
        this.pdfSrc = e.target.result;
      };
  
      reader.readAsArrayBuffer($img.files[0]);
    }
  }

  ngOnInit() {
  }

  onReady(eventData) {
    eventData.plugins.get('FileRepository').createUploadAdapter = function (loader) {
      console.log(btoa(loader.file));
      return new UploadAdapter(loader);
    };
  }
}
