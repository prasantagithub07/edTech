import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Course } from '../models/course';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient) { 
    this.httpHeaders = new HttpHeaders({'context-type': 'application/json'});
  }

 
}
