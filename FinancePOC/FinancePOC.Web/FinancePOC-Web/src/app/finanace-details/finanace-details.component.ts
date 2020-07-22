import { Component, OnInit } from "@angular/core";
import { FinanaceDetailsService } from "../shared/finanace-details.service";
import { FinanaceDetails } from '../shared/finanace-details.model';

@Component({
  selector: "app-finanace-details",
  templateUrl: "./finanace-details.component.html",
  styleUrls: ["./finanace-details.component.css"],
})
export class FinanaceDetailsComponent implements OnInit {
  constructor(private service: FinanaceDetailsService) {}

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(fd:FinanaceDetails){
    this.service.formdata = fd;
  }
}
