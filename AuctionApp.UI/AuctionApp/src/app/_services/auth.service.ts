import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://auction-app.runasp.net/api/auth';

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<any> {
    let url = `${this.apiUrl}/get-all-users`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  getUserById(userId: string): Observable<any> {
    let url = `${this.apiUrl}/user-detail/${userId}`;
    return this.http.get<any>(url, { responseType: 'json' });
  }

  suspendUser(userId: string): Observable<any> {
    let url = `${this.apiUrl}/suspend-user/${userId}`;
    return this.http.post<any>(url, {}, { responseType: 'json' });
  }
}
