import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuctionService } from 'src/app/_services/auction.service';

@Component({
  selector: 'app-auctions-list',
  templateUrl: './auctions-list.component.html',
  styleUrls: ['./auctions-list.component.css'],
})
export class AuctionsListComponent implements OnInit {
  auctions: any[] = [];
  loading: boolean = true;

  constructor(private auctionService: AuctionService) {}

  ngOnInit(): void {
    this.getAllAuctions();
  }

  getAllAuctions(): void {
    this.loading = true;
    this.auctionService.getAllAuctions().subscribe(
      (response: any) => {
        this.auctions = response.result || [];
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching auctions:', error);
        this.auctions = [];
        this.loading = false;
      }
    );
  }

  deleteAuction(auctionId: number): void {
    const isDelete = confirm('Are you sure want to delete');
    if (isDelete) {
      this.auctionService.deleteAuction(auctionId).subscribe(
        (response: any) => {
          if (response.isSuccess) {
            this.getAllAuctions();
            alert('Auction deleted successfully!');
          } else {
            alert(response.message);
          }
        },
        (error) => {
          console.error(
            `Error in deleting the auction details with Id:- ${auctionId}`,
            error
          );
        }
      );
    }
  }
}
