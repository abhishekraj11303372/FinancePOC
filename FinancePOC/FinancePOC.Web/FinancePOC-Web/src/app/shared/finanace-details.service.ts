import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FinanaceDetails } from "./finanace-details.model";

@Injectable({
  providedIn: 'root',
})
export class FinanaceDetailsService {
  formdata: FinanaceDetails;
  readonly rootURL = 'https://localhost:44390';
  list: FinanaceDetails[];

  constructor(private http: HttpClient) {}

  refreshList() {
    this.http
      .get(this.rootURL + '/Finance')
      .toPromise()
      .then(res => this.list = res as FinanaceDetails[]);
  }
}


