import { Inject, Injectable } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import {forkJoin, ReplaySubject, Observable} from 'rxjs';
import { environment} from 'src/environments/environment';
declare const CryptoJs: any;

@Injectable({
  providedIn: 'root'
})
export class UtilService {

  constructor() { }

  Encrypt(data: any): any{
    let json = JSON.stringify(data);
    return CryptoJs.AES.encrypt(json, environment.encKey);
  }
  Decrypt(encData: any): any{
    var bytes = CryptoJs.AES.decrypt(encData.toString(), environment.encKey);
    var data = bytes.toString(CryptoJs.enc.Utf8);
    return JSON.parse(data);
  }
  static GenerateGUID(): string {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}

/**Handled loading the external library ondemand into our app*/
@Injectable({providedIn : 'root'})
export class ExternalLibraryService{
  private _loadedLibraries : {[url: string]: ReplaySubject<any>} = {};
  
  constructor(@Inject(DOCUMENT) private readonly document: any){}

  // forkjoin parameters will grow when we are adding any new external library into app
  lazyLoadLibrary(resourseURL: string): Observable<any>{
    return forkJoin([
      this.loadScript(resourseURL)
    ]);
  }

  private loadScript(url: string): Observable<any>{
    if(this._loadedLibraries[url]){
      return this._loadedLibraries[url].asObservable();
    }

    this._loadedLibraries[url] = new ReplaySubject();

    const script = this.document.createElement('script');
    script.type =  'text/javascript';
    script.async = true;
    script.src =  url;
    script.onload = () =>{
      this._loadedLibraries[url].next(0);
      this._loadedLibraries[url].complete();
    }

    this.document.body.appendChild(script);
    return this._loadedLibraries[url].asObservable();
  }
}
