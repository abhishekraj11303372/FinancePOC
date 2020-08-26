import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { UploadDownloadServiceService } from '../shared/upload-download-service.service';
import { ProgressStatus, ProgressStatusEnum } from '../shared/finanace-details.model';

@Component({
  selector: 'app-view-component',
  templateUrl: './view-component.component.html',
  styleUrls: ['./view-component.component.css']
})
export class ViewComponentComponent implements OnInit {
  @Output() public viewForm: EventEmitter<ProgressStatus>;

   constructor(private service: UploadDownloadServiceService) { 
     this.viewForm = new EventEmitter<ProgressStatus>();
   }

  public view() {
    this.service.viewFormFile().subscribe(
      data => {
        
        },
    
      (error) => {
        this.viewForm.emit({ status: ProgressStatusEnum.ERROR });
      }
    );

    console.log("There was a problem with form");
  }

    
  

  ngOnInit() {
  }

}

