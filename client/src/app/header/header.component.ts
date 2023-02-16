import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  products: any;



  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5000/api/products').subscribe({
      next: response => this.products = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }

}
