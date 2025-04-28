import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css'],
})
export class UserDashboardComponent implements OnInit {
  availableProducts: any[] = [];
  loading: boolean = true;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.getAllAvailableProducts();
  }

  getAllAvailableProducts(): void {
    this.loading = true;
    this.productService.getAvailableProducts().subscribe(
      (response: any) => {
        this.availableProducts = response.result;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching products:', error);
        this.loading = false;
      }
    );
  }
}
