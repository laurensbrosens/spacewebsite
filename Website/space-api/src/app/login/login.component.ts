import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginserviceService } from '../Services/loginservice.service';
import  jwt_decode  from 'jwt-decode';
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private login: LoginserviceService, private router: Router) { }
  icon: string;
  infotoken: any;
  username: string;
  ngOnInit(): void {
    var urlstring = window.location.href;
    console.log(urlstring);
    this.login.token  = urlstring.split('id_token=',2)[1] //Haalt de JWT token uit de url
    console.log("L token = " + this.login.token);
    if (this.login.token != null) { //Haal info uit de JWT token
      this.infotoken = jwt_decode(this.login.token)
      console.log("Info = " + JSON.stringify(this.infotoken));
      this.icon = this.infotoken.picture;
      this.username = this.infotoken.name;
    }
    console.log("This icon = " + this.icon)
  }
  LoginRedirect(){
    window.location.href = 'https://accounts.google.com/o/oauth2/v2/auth?client_id=493056234706-j2hk0h5p8bj994079498d2cghvll1n4m.apps.googleusercontent.com&redirect_uri=http%3A%2F%2F192.168.1.57%3A5001%2Flogin&scope=profile http://mail.google.com&nonce=0394852-3190485-2490358&response_type=id_token token'
  }
  Logout(){
    this.login.token = null;
    this.infotoken = null;
    this.icon = "";
    this.username = "";
    console.log("L token = " + this.login.token);
    this.router.navigate(['login']); //Zorgt ervoor dat de url terug leeg is zodat key niet onmiddellijk opgeslagen wordt
    //location.reload();
  }
}
