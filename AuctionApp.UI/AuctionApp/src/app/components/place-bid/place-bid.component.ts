import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BidService } from 'src/app/_services/bid.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-place-bid',
  templateUrl: './place-bid.component.html',
  styleUrls: ['./place-bid.component.css'],
})
export class PlaceBidComponent implements OnInit {
  loading: boolean = true;
  product: any;
  submitted: boolean = false;
  createBid = {
    bidAmount: '',
  };
  auctionStatus: string = '';
  currentHighestBid: number = 0;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private bidService: BidService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.loading = true;
    this.route.params.subscribe((params) => {
      const productId = params['id'];
      this.productService.getProductById(productId).subscribe(
        (response: any) => {
          this.product = response.result;
          this.checkAuctionStatus();
          this.loading = false;
        },
        (error) => {
          console.error('Error fetching product details:', error);
          this.loading = false;
        }
      );
      this.bidService
        .getCurrentHighestBid(productId)
        .subscribe((response: any) => {
          this.currentHighestBid = response.result.bidAmount;
        });
    });
  }

  checkAuctionStatus(): void {
    const createdAtUtc = new Date(this.product.createdAt);
    const istOffset = 5.5 * 60 * 60 * 1000; // IST is UTC+5:30
    const createdAtIst = new Date(createdAtUtc.getTime() + istOffset);
    const auctionEndTime = new Date(
      createdAtIst.getTime() + this.product.auctionDuration * 60 * 60 * 1000
    );
    const now = new Date();
    const remainingTimeMs = auctionEndTime.getTime() - now.getTime();

    if (this.product.boughtByUserId) {
      this.auctionStatus = 'Product has been sold';
    } else if (remainingTimeMs <= 0) {
      this.auctionStatus = 'Auction Ended';
    } else {
      this.auctionStatus = 'Auction Ongoing';
    }
  }

  placeBid(form: any): void {
    this.submitted = true;
    if (form.valid) {
      this.route.params.subscribe((params) => {
        const productId = params['id'];
        this.bidService.placeBid(this.createBid, productId).subscribe(
          (response: any) => {
            if (response.message === 'Bid placed successfully') {
              alert(response.message);
              this.router.navigate(['/user-bids']);
            } else if (response.message === 'Product purchased successfully') {
              this.auctionStatus = 'Product has been sold';
              alert(response.message);
              this.router.navigate(['/user-bids']);
            } else if (response.message === 'Product has been sold') {
              alert(response.message);
            } else {
              alert(response.message);
              this.router.navigate(['/user-dashboard']);
            }
          },
          (error) => {
            console.error('Error in the placing bid:', error);
          }
        );
      });
    }
  }
}
