import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewerComponent } from './viewer/viewer.component';
import { FinanaceDetailsComponent } from './finanace-details/finanace-details.component';

const routes: Routes = [
  { path: 'viewer', component: ViewerComponent },
  { path: 'finance', component: FinanaceDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
