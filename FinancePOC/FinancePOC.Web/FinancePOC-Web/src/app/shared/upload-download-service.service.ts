import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadDownloadServiceService {

  private baseApiUrl: string;
  private apiDownloadUrl: string;
  private apiUploadUrl: string;
  private apiRtfUploadUrl: string;
  private apiFileUrl: string;
  private apiRtfFileUrl: string;
  private apiHtmlFileUrl: string;
 
  constructor(private httpClient: HttpClient) {
    this.baseApiUrl = 'https://localhost:44390/Finance/';
    this.apiDownloadUrl = this.baseApiUrl + 'download';
    this.apiUploadUrl = this.baseApiUrl + 'upload';
    this.apiRtfUploadUrl = this.baseApiUrl + 'uploadRTF';
    this.apiFileUrl = this.baseApiUrl + 'files';
    this.apiRtfFileUrl = this.baseApiUrl + 'getrtf';
    this.apiHtmlFileUrl = this.baseApiUrl + 'gethtml';
  }

  public downloadFile(file: string): Observable<HttpEvent<Blob>> {
    return this.httpClient.request(new HttpRequest(
      'GET',
      `${this.apiDownloadUrl}?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }


  public convertRtfFile(file: Blob): Observable<HttpEvent<void>> {
    const formData = new FormData();
    formData.append('file', file);

    return this.httpClient.request(new HttpRequest(
      'PUT',
      this.apiRtfUploadUrl,
      formData,
      {
        reportProgress: true
      }));
  }

  public uploadFile(file: Blob): Observable<HttpEvent<void>> {
    const formData = new FormData();
    formData.append('file', file);
 
    return this.httpClient.request(new HttpRequest(
      'POST',
      this.apiUploadUrl,
      formData,
      {
        reportProgress: true
      }));
  }
  
  public uploadRtfFile(file: Blob): Observable<HttpEvent<void>> {
    const formData = new FormData();
    formData.append('file', file);
 
    return this.httpClient.request(new HttpRequest(
      'POST',
      this.apiRtfUploadUrl,
      formData,
      {
        reportProgress: true
      }));
  }

  //  );
 
  public getFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiFileUrl);
  }
  
  public getRtfFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiRtfFileUrl);
  }
  
  public getHtmlFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiHtmlFileUrl);
  }
}
