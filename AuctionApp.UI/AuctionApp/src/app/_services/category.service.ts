import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'http://auction-app.runasp.net/api/category';

  constructor(private http: HttpClient) {}

  getAllCategories(): Observable<any> {
    let url = `${this.apiUrl}/get-all`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  createCategory(category: any): Observable<any> {
    let url = `${this.apiUrl}/add-category`;
    return this.http.post<any>(url, category, { responseType: 'json' });
  }
}
