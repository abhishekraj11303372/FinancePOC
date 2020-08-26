import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewerComponent } from './viewer/viewer.component';
import { FinanaceDetailsComponent } from './finanace-details/finanace-details.component';
import { FilemanagerComponent } from './filemanager/filemanager.component';
import { TinymceeditorComponent } from './tinymceeditor/tinymceeditor.component';
import { RtfUploaderComponent } from './rtf-uploader/rtf-uploader.component';

const routes: Routes = [
  { path: 'rtfuploader', component: RtfUploaderComponent },
  { path: 'viewer', component: ViewerComponent },
  { path: 'tinymce', component: TinymceeditorComponent },
  { path: 'filemanager', component: FilemanagerComponent },
  { path: 'finance', component: FinanaceDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
