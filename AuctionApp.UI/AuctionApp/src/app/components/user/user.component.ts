import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  user: any;
  sellProducts: any[] = [];
  buyProducts: any[] = [];
  loading: boolean = true;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const userId = params['id'];
      this.loading = true;

      this.productService.getBuyProducts(userId).subscribe(
        (response: any) => {
          this.buyProducts = response.result;
          this.loading = false;
        },
        (error) => {
          console.error('Error fetching product details:', error);
          this.loading = false;
        }
      );
    });

    this.route.params.subscribe((params) => {
      const userId = params['id'];
      this.loading = true;

      this.productService.getSellProducts(userId).subscribe(
        (response: any) => {
          this.sellProducts = response.result;
          this.loading = false;
        },
        (error) => {
          console.error('Error fetching product details:', error);
          this.loading = false;
        }
      );
    });

    this.route.params.subscribe((params) => {
      const userId = params['id'];
      this.loading = true;

      this.authService.getUserById(userId).subscribe(
        (response: any) => {
          this.user = response.result;
          this.loading = false;
        },
        (error: any) => {
          console.error('Error fetching user details:', error);
          this.loading = false;
        }
      );
    });
  }
}
