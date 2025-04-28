import { Component, OnInit } from '@angular/core';
import { BidService } from 'src/app/_services/bid.service';

@Component({
  selector: 'app-bid-list',
  templateUrl: './bid-list.component.html',
  styleUrls: ['./bid-list.component.css'],
})
export class BidListComponent implements OnInit {
  bids: any[] = [];
  loading: boolean = true;
  constructor(private bidService: BidService) {}

  ngOnInit(): void {
    this.getAllBids();
  }

  getAllBids(): void {
    this.loading = true;
    this.bidService.getAllBids().subscribe(
      (response: any) => {
        this.bids = response.result;
        this.loading = false;
      },
      (error: any) => {
        console.error('Error fetching bids:', error);
        this.loading = false;
      }
    );
  }
}
