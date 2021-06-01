import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginserviceService } from './loginservice.service';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  headerDict : any = {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Authorization': "Bearer " + this.login.token
  };
  public readonly url : string = "http://localhost:49774/api/v1/";
  constructor(private http: HttpClient, private login: LoginserviceService) {}
  get AllLaunches() : Observable<Ilaunch[]>{
    const requestOptions = {                                                                                                                                                                                 
      headers: new HttpHeaders(this.headerDict), 
    };
    return this.http.get<Ilaunch[]>(this.url + "Launches", requestOptions);//this.url + "launches",requestOptions);
  }

  thisurl(url : any) : Observable<any>{
    const requestOptions = {                                                                                                                                                                                 
      headers: new HttpHeaders(this.headerDict), 
    };
    return this.http.get(url, requestOptions); //get hypermedia link
  }
}

export interface Ilaunch {
  LaunchDate: Date;
  id: number;
  Link: string;
  RocketType: any;
  MissionDestination: any;
  LocationName: any;
  OrganisationName: any;
}