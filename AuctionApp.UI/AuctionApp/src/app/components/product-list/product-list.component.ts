import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { timeInterval } from 'rxjs';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  products: any[] = [];
  originalProducts: any[] = [];
  loading: boolean = true;
  searchProduct = {
    searchTerm: '',
    sortBy: '',
    sortDescending: 'true',
  };

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts(): void {
    this.loading = true;
    this.productService.getAllProducts().subscribe(
      (response: any) => {
        this.products = response.result;
        this.originalProducts = this.products.map((product) => ({
          ...product,
          timeRemaining: this.calculateTimeRemaining(
            product.createdAt,
            product.auctionDuration,
            product.boughtByUserId
          ),
        }));
        this.applySearchAndSorting();
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching products:', error);
        this.loading = false;
      }
    );
  }

  calculateTimeRemaining(
    creationTime: Date,
    auctionDuration: number,
    boughtByUserId: string
  ): number {
    if (boughtByUserId !== null) return 0;
    const createdAtUtc = new Date(creationTime);
    const istOffset = 5.5 * 60 * 60 * 1000;
    const createdAtIst = new Date(createdAtUtc.getTime() + istOffset);

    const auctionEndTime = new Date(
      createdAtIst.getTime() + auctionDuration * 60 * 60 * 1000
    );
    const now = new Date();
    const remainingTimeMs = auctionEndTime.getTime() - now.getTime();
    return Math.max(remainingTimeMs, 0);
  }

  onSearchSubmit(): void {
    this.applySearchAndSorting();
  }

  sortProductsAscending(products: any[], sortBy: string): any[] {
    return [...products].sort((a, b) => {
      let valueA = a[sortBy];
      let valueB = b[sortBy];
      if (typeof valueA === 'string' && !isNaN(Number(valueA)))
        valueA = Number(valueA);
      if (typeof valueB === 'string' && !isNaN(Number(valueA)))
        valueB = Number(valueB);

      if (valueA < valueB) return -1;
      if (valueA > valueB) return 1;
      return 0;
    });
  }

  sortProductsDescending(products: any[], sortBy: string): any[] {
    return [...products].sort((a, b) => {
      let valueA = a[sortBy];
      let valueB = b[sortBy];
      if (typeof valueA === 'string' && !isNaN(Number(valueA)))
        valueA = Number(valueA);
      if (typeof valueB === 'string' && !isNaN(Number(valueA)))
        valueB = Number(valueB);

      if (valueA > valueB) return -1;
      if (valueA < valueB) return 1;
      return 0;
    });
  }

  applySearchAndSorting(): void {
    let filteredProducts = [...this.originalProducts];
    if (this.searchProduct.searchTerm.trim()) {
      filteredProducts = filteredProducts.filter((product) =>
        product.name
          .toLowerCase()
          .includes(this.searchProduct.searchTerm.trim().toLowerCase())
      );
    }

    if (this.searchProduct.sortBy) {
      if (this.searchProduct.sortDescending === 'true')
        filteredProducts = this.sortProductsDescending(
          filteredProducts,
          this.searchProduct.sortBy
        );
      else
        filteredProducts = this.sortProductsAscending(
          filteredProducts,
          this.searchProduct.sortBy
        );
    }

    this.products = filteredProducts;
  }

  onSortByChange(): void {
    this.applySearchAndSorting();
  }

  onSortDirectionChange(): void {
    this.applySearchAndSorting();
  }

  onInputClear(): void {
    this.searchProduct.searchTerm = '';
    this.searchProduct.sortBy = '';
    this.searchProduct.sortDescending = 'true';
    this.products = [...this.originalProducts];
    this.applySearchAndSorting();
  }

  viewProductDetails(productId: number): void {
    this.router.navigate(['/product-detail', productId]);
  }
}
