import { Component, OnInit, Input, Output, ViewChild, EventEmitter, ElementRef } from '@angular/core';
import { UploadDownloadServiceService } from '../shared/upload-download-service.service';
import { ProgressStatus, ProgressStatusEnum } from '../shared/finanace-details.model';
import { HttpEventType } from '@angular/common/http';
import html from './file.html';

@Component({
  selector: 'app-rtf-uploader',
  templateUrl: './rtf-uploader.component.html',
  styleUrls: ['./rtf-uploader.component.css']
})
export class RtfUploaderComponent implements OnInit {
  @Input() public disabled: boolean;
  @Output() public uploadStatus: EventEmitter<ProgressStatus>;
  @ViewChild('inputFile') inputFile: ElementRef;

  public view = require('html-loader!../../assets/FinancePOCDotnetMembers.html');

  public Rtffiles: string[];
  public Htmlfiles: string[];
  //public view = require('htmlloader!E:\POC\FinancePOC\FinancePOC\FinancePOC.Web\FinancePOC-Web\src\assets\FinancePOCDotnetMembers.html'); 
  constructor(private service: UploadDownloadServiceService) {
    this.uploadStatus = new EventEmitter<ProgressStatus>();
  }
  ngOnInit() {
    this.getRtfFiles();
  }

  private getRtfFiles() {
    this.service.getRtfFiles().subscribe(
      data => {
        this.Rtffiles = data;
      }
    );

    this.service.getHtmlFiles().subscribe(
      data => {
        this.Htmlfiles = data;
      }
    );
  }

  public uploadRtf(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadStatus.emit({ status: ProgressStatusEnum.START });
      this.service.uploadRtfFile(file).subscribe(
        data => {
          if (data) {
            switch (data.type) {
              case HttpEventType.UploadProgress:
                this.uploadStatus.emit({ status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100) });
                break;
              case HttpEventType.Response:
                this.inputFile.nativeElement.value = '';
                this.uploadStatus.emit({ status: ProgressStatusEnum.COMPLETE });
                break;
            }
          }
        },
        error => {
          this.inputFile.nativeElement.value = '';
          this.uploadStatus.emit({ status: ProgressStatusEnum.ERROR });
        }
      );
    }
  }

  public ConvertRtf(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ConvertRtf.apply
        ({ status: ProgressStatusEnum.START });
      this.service.convertRtfFile(file).subscribe(
        data => {
          if (data) {
            switch (data.type) {
              case HttpEventType.UploadProgress:
                this.ConvertRtf.apply({ status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100) });
                break;
              case HttpEventType.Response:
                this.inputFile.nativeElement.value = '';
                this.ConvertRtf.apply({ status: ProgressStatusEnum.COMPLETE });
                break;
            }
          }
        },
        error => {
          this.inputFile.nativeElement.value = '';
          this.ConvertRtf.apply({ status: ProgressStatusEnum.ERROR });
        }
      );
    }

  }
}
