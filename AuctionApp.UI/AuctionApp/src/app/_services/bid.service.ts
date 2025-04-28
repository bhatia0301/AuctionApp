import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BidService {
  private apiUrl = 'https://namanbhatia0301-001-site1.ktempurl.com/api/bid';

  constructor(private http: HttpClient) {}

  getAllBids(): Observable<any> {
    let url = `${this.apiUrl}/get-all-bids`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getBidsByUserId(): Observable<any> {
    let url = `${this.apiUrl}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  placeBid(bid: any, productId: number): Observable<any> {
    let url = `${this.apiUrl}/place-bid/${productId}`;
    return this.http.post<any>(url, bid, { responseType: 'json' });
  }

  getLastBidOfUser(): Observable<any> {
    let url = `${this.apiUrl}/last-bid`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getCurrentHighestBid(productId: number): Observable<any> {
    let url = `${this.apiUrl}/current-highest/${productId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }
}
