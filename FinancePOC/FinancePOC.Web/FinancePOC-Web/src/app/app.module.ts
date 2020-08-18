import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FinanaceDetailsComponent } from "./finanace-details/finanace-details.component";
import { FinanaceDetailsService } from "./shared/finanace-details.service";
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ViewerComponent } from './viewer/viewer.component';
import { UploadcomponentComponent } from './uploadcomponent/uploadcomponent.component';
import { DownloadcomponentComponent } from './downloadcomponent/downloadcomponent.component';
import { FilemanagerComponent } from './filemanager/filemanager.component';
import { UploadDownloadServiceService } from './shared/upload-download-service.service';

@NgModule({
  declarations: [AppComponent,
     FinanaceDetailsComponent,
      ViewerComponent, UploadcomponentComponent, 
      DownloadcomponentComponent, FilemanagerComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, CKEditorModule],
  providers: [FinanaceDetailsService,UploadDownloadServiceService],
  bootstrap: [AppComponent],
})
export class AppModule {}
