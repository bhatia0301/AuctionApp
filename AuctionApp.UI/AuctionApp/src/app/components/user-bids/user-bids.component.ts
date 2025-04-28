import { Component, OnInit } from '@angular/core';
import { BidService } from 'src/app/_services/bid.service';

@Component({
  selector: 'app-user-bids',
  templateUrl: './user-bids.component.html',
  styleUrls: ['./user-bids.component.css'],
})
export class UserBidsComponent implements OnInit {
  userBids: any[] = [];
  loading: boolean = true;

  constructor(private bidService: BidService) {}

  ngOnInit(): void {
    this.getAllUserBids();
  }
  getAllUserBids(): void {
    this.loading = true;
    this.bidService.getBidsByUserId().subscribe(
      (response: any) => {
        this.userBids = response.result;
        this.loading = false;
      },
      (error: any) => {
        console.error('Error fetching user bids:', error);
        this.loading = false;
      }
    );
  }
}
