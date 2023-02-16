import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService) {}
  
  ngOnInit(): void {
    // TODO document why this method 'ngOnInit' is empty
  
    
  }

  login() {
    this.accountService.login(this.model).subscribe({
     next: response => {
      console.log(response);
     },
     error: error => console.log(error)
    })
   }
  
   logout() {
    this.accountService.logout();
   }
  
}
