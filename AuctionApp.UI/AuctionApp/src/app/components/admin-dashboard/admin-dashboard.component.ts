import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent implements OnInit {
  users: any[] = [];
  loading: boolean = true;

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers(): void {
    this.loading = true;
    this.authService.getAllUsers().subscribe(
      (response: any) => {
        if (response.isSuccess) {
          this.users = response.result;
          this.loading = false;
        } else {
          this.loading = false;
        }
      },
      (error) => {
        console.error('Error in fetching users:', error);
        this.loading = false;
      }
    );
  }

  suspendUser(userId: string): void {
    const isBan = confirm('Are you sure want to ban the user');
    if (isBan) {
      this.authService.suspendUser(userId).subscribe(
        (response: any) => {
          if (response.isSuccess) {
            alert(response.message);
          } else {
            alert(response.message);
          }
        },
        (error: any) => {
          console.error(
            `Error in suspend user with given user id:${userId}`,
            error
          );
        }
      );
    }
  }
}
