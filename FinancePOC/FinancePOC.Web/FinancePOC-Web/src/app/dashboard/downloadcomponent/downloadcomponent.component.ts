import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { UploadDownloadServiceService } from '../shared/upload-download-service.service';
import { ProgressStatus, ProgressStatusEnum } from '../shared/finanace-details.model';

@Component({
  selector: 'app-downloadcomponent',
  templateUrl: './downloadcomponent.component.html',
  styleUrls: ['./downloadcomponent.component.css']
})
export class DownloadcomponentComponent implements OnInit {

  @Input() public disabled: boolean;
  @Input() public fileName: string;
  @Output() public downloadStatus: EventEmitter<ProgressStatus>;
 
  constructor(private service: UploadDownloadServiceService) {
    this.downloadStatus = new EventEmitter<ProgressStatus>();
  }
 
  public download() {
    this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    this.service.downloadFile(this.fileName).subscribe(
      data => {
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            this.downloadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
            break;
          case HttpEventType.Response:
            this.downloadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
            const downloadedFile = new Blob([data.body], { type: data.body.type });
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            a.download = this.fileName;
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            break;
        }
      },
      error => {
        this.downloadStatus.emit( {status: ProgressStatusEnum.ERROR});
      }
    );
  }

  ngOnInit() {
  }

}
