import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FinanaceDetailsComponent } from "./finanace-details/finanace-details.component";
import { FinanaceDetailsService } from "./shared/finanace-details.service";
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ViewerComponent } from './viewer/viewer.component';

@NgModule({
  declarations: [AppComponent, FinanaceDetailsComponent, ViewerComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, CKEditorModule],
  providers: [FinanaceDetailsService],
  bootstrap: [AppComponent],
})
export class AppModule {}
