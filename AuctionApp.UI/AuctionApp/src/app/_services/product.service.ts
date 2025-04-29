import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'http://auction-app.runasp.net/api/product';

  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<any> {
    let url = `${this.apiUrl}/get-all-products`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getProductById(productId: number): Observable<any> {
    let url = `${this.apiUrl}/${productId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getAvailableProducts(): Observable<any> {
    let url = `${this.apiUrl}/available-products`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getSellProducts(userId: string): Observable<any> {
    let url = `${this.apiUrl}/sell-products/${userId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getBuyProducts(userId: string): Observable<any> {
    let url = `${this.apiUrl}/buy-products/${userId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  createProduct(product: any): Observable<any> {
    let url = `${this.apiUrl}/create-product`;
    return this.http.post<any>(url, product, { responseType: 'json' });
  }
}
