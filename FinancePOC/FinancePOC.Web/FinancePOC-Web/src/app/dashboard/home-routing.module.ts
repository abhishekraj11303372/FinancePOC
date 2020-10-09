import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewerComponent } from './viewer/viewer.component';
import { FinanaceDetailsComponent } from './finanace-details/finanace-details.component';
import { FilemanagerComponent } from './filemanager/filemanager.component';
import { TinymceeditorComponent } from './tinymceeditor/tinymceeditor.component';
import { RtfUploaderComponent } from './rtf-uploader/rtf-uploader.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { NavMainComponent } from './nav-main/nav-main.component';

const routes: Routes = [{
  path: '',
  component: NavMainComponent,
  children:[
    { path: 'main', component: NavMainComponent },
    { path: 'welcome', component: WelcomeComponent },
    { path: 'rtfuploader', component: RtfUploaderComponent },
    { path: 'viewer', component: ViewerComponent },
    { path: 'tinymce', component: TinymceeditorComponent },
    { path: 'filemanager', component: FilemanagerComponent },
    { path: 'finance', component: FinanaceDetailsComponent },
    { path: '',  redirectTo: '/main', pathMatch: 'full' },
  ],
} ,
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
