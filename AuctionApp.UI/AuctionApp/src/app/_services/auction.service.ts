import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuctionService {
  private apiUrl = 'https://namanbhatia0301-001-site1.ktempurl.com/api/auction';

  constructor(private http: HttpClient) {}

  getAllAuctions(): Observable<any> {
    let url = `${this.apiUrl}/get-all-auctions`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getAuctionById(auctionId: number): Observable<any> {
    let url = `${this.apiUrl}/${auctionId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  deleteAuction(auctionId: number): Observable<any> {
    let url = `${this.apiUrl}/delete-auction/${auctionId}`;
    return this.http.delete<any>(url, { responseType: 'json' });
  }
}
