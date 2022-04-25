import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class LocalStorageService {
    //Create a Subject
    private storageSub= new Subject<[string,string]>();
  
    watchStorage(): Observable<[string,string]> {
      return this.storageSub.asObservable();
    }
  //Why we use asObservable? 
  //The subject is private and not exposed outside the message service so it can't be subscribed to directly. You shouldn't expose the subject 
  //because it can be used to broadcast messages to subscribers which is the responsibility of the message service, instead you should expose an 
  //observable to subscribers because it can only be used for receiving messages.
  
    set(key: string, data: string) {
      localStorage.setItem(key, data);
      this.storageSub.next([key,data]);
    }
  //An EventEmitter, extends Subject. You fire off an event that all subscribers will listen too, whenever you use next
  
    get(key: string){
      return localStorage.getItem(key); 
    }  
  }
