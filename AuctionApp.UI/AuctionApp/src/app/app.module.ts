import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { ProductComponent } from './components/product/product.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { CustomInterceptor } from './_interceptors/custom.interceptor';
import { UserComponent } from './components/user/user.component';
import { AuctionComponent } from './components/auction/auction.component';
import { AuctionsListComponent } from './components/auctions-list/auctions-list.component';
import { BidListComponent } from './components/bid-list/bid-list.component';
import { PlaceBidComponent } from './components/place-bid/place-bid.component';
import { UserBidsComponent } from './components/user-bids/user-bids.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    ProductListComponent,
    AddProductComponent,
    AdminDashboardComponent,
    UserDashboardComponent,
    CategoryListComponent,
    ProductComponent,
    PageNotFoundComponent,
    UnauthorizedComponent,
    UserComponent,
    AuctionComponent,
    AuctionsListComponent,
    BidListComponent,
    PlaceBidComponent,
    UserBidsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
