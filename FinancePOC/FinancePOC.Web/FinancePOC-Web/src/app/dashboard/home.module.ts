import { HttpClientModule } from "@angular/common/http";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FinanaceDetailsComponent } from "./finanace-details/finanace-details.component";
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ViewerComponent } from './viewer/viewer.component';
import { UploadcomponentComponent } from './uploadcomponent/uploadcomponent.component';
import { DownloadcomponentComponent } from './downloadcomponent/downloadcomponent.component';
import { FilemanagerComponent } from './filemanager/filemanager.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
// import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { TinymceeditorComponent } from './tinymceeditor/tinymceeditor.component';
import { EditorModule } from '@tinymce/tinymce-angular';
import { RtfUploaderComponent } from './rtf-uploader/rtf-uploader.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavMainComponent } from './nav-main/nav-main.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { WelcomeComponent } from './welcome/welcome.component';
import { HomeRoutingModule } from './home-routing.module';
import { FinanaceDetailsService } from "./shared/finanace-details.service";
import { UploadDownloadServiceService } from "./shared/upload-download-service.service";
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
     FinanaceDetailsComponent,
      ViewerComponent, UploadcomponentComponent, 
      DownloadcomponentComponent, FilemanagerComponent, TinymceeditorComponent, RtfUploaderComponent, NavMainComponent, WelcomeComponent],
  imports: [CommonModule, HomeRoutingModule, CKEditorModule, 
    PdfViewerModule, EditorModule, LayoutModule, 
    MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule],
    providers: [FinanaceDetailsService,UploadDownloadServiceService],
    schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class HomeModule {}
// platformBrowserDynamic().bootstrapModule(HomeModule);
