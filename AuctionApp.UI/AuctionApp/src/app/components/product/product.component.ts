import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { interval, Subscription } from 'rxjs';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit, OnDestroy {
  @Input() returnUrl: string = '/';

  loading: boolean = true;
  remainingTime: string = '';
  isAuctionOngoing: boolean = true;
  product: any;
  auctionStatus: string = '';
  private countdownSubscription?: Subscription;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loading = true;
    this.route.params.subscribe((params) => {
      const productId = params['id'];
      this.productService.getProductById(productId).subscribe(
        (response: any) => {
          this.product = response.result;
          this.calculateRemainingTime();
          this.loading = false;
          this.startCountdown();
        },
        (error) => {
          console.error('Error fetching product details:', error);
          this.loading = false;
        }
      );
    });
  }

  calculateRemainingTime(): void {
    if (!this.product) return;

    const createdAtUtc = new Date(this.product.createdAt);
    const istOffset = 5.5 * 60 * 60 * 1000;
    const createdAtIst = new Date(createdAtUtc.getTime() + istOffset);

    const auctionEndTime = new Date(
      createdAtIst.getTime() + this.product.auctionDuration * 60 * 60 * 1000
    );
    const now = new Date();
    const remainingTimeMs = auctionEndTime.getTime() - now.getTime();

    this.isAuctionOngoing = remainingTimeMs > 0;
    this.remainingTime = this.formatRemainingTime(remainingTimeMs);

    if (this.product.boughtByUserId) {
      this.auctionStatus = 'Product has been sold';
    } else if (remainingTimeMs <= 0) {
      this.auctionStatus = 'Auction Ended';
    } else {
      this.auctionStatus = 'Auction Ongoing';
    }
  }

  formatRemainingTime(ms: number): string {
    if (ms <= 0) return 'Auction Ended';
    const seconds = Math.floor((ms / 1000) % 60);
    const minutes = Math.floor((ms / (1000 * 60)) % 60);
    const hours = Math.floor((ms / (1000 * 60 * 60)) % 24);
    const days = Math.floor(ms / (1000 * 60 * 60 * 24));
    return `${days}d ${hours}h ${minutes}m ${seconds}s`;
  }

  startCountdown(): void {
    this.countdownSubscription = interval(1000).subscribe(() => {
      this.calculateRemainingTime();
    });
  }

  ngOnDestroy(): void {
    if (this.countdownSubscription) {
      this.countdownSubscription.unsubscribe();
    }
  }

  navigateBack(): void {
    this.router.navigate([this.returnUrl]);
  }
}
