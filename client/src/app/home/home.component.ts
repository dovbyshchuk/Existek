import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Products } from '../_models/products';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  title = 'client';
  categories: any;
  products: any;
  panelOpenState = false;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5000/api/productcategories').subscribe({
      next: response => this.categories = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    });
    this.http.get<Products>('https://localhost:5000/api/products').subscribe({
      next: response => this.products = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
      
    });
  }
}
