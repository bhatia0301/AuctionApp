import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuctionService } from 'src/app/_services/auction.service';

@Component({
  selector: 'app-auction',
  templateUrl: './auction.component.html',
  styleUrls: ['./auction.component.css'],
})
export class AuctionComponent implements OnInit {
  auction: any | undefined;
  loading: boolean = true;
  remainingTime: string = '';
  isAuctionOngoing: boolean = true;
  private countdownSubscription?: Subscription;

  constructor(
    private auctionService: AuctionService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loading = true;
    this.route.params.subscribe((params) => {
      const auctionId = params['id'];
      this.auctionService.getAuctionById(auctionId).subscribe(
        (response: any) => {
          this.auction = response.result;

          this.loading = false;
        },
        (error: any) => {
          console.error('Error fetching auction details:', error);
          this.loading = false;
        }
      );
    });
  }
}
