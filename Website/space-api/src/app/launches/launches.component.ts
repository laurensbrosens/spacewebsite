import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { ApiserviceService, Ilaunch } from '../Services/apiservice.service';

@Component({
  selector: 'app-launches',
  templateUrl: './launches.component.html',
  styleUrls: ['./launches.component.css']
})
export class LaunchesComponent implements OnInit {

  constructor(private api : ApiserviceService) { }
  launcheslist: Ilaunch[];
  launchinfo: any;

  ngOnInit(): void {
    this.api.AllLaunches.subscribe(d => this.launcheslist = d);
  }
  openlaunchinfopage(url : string){
    this.api.thisurl(url).subscribe(d => {this.launchinfo = d; console.log(this.launchinfo)});
  }
}
