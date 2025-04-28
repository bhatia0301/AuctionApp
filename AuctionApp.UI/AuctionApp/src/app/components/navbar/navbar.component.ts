import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/_services/login.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  constructor(public loginService: LoginService, private route: Router) {}

  onLogoutClick() {
    this.loginService.logout();
    this.route.navigate(['/']);
  }
}
