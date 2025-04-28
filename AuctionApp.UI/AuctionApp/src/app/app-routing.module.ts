import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { LoginComponent } from './components/login/login.component';
import { ProductComponent } from './components/product/product.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { UserComponent } from './components/user/user.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { AuctionsListComponent } from './components/auctions-list/auctions-list.component';
import { AuctionComponent } from './components/auction/auction.component';
import { BidListComponent } from './components/bid-list/bid-list.component';
import { PlaceBidComponent } from './components/place-bid/place-bid.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { UserBidsComponent } from './components/user-bids/user-bids.component';
import { authGuard } from './_guards/auth.guard';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

const routes: Routes = [
  {
    path: '',
    component: ProductListComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'product-detail/:id',
    component: ProductComponent,
  },
  {
    path: 'user-dashboard',
    component: UserDashboardComponent,
    canActivate: [authGuard],
    data: { Role: 'User' },
  },
  {
    path: 'admin-dashboard',
    component: AdminDashboardComponent,
    canActivate: [authGuard],
    data: { Role: 'Admin' },
  },
  {
    path: 'user-details/:id',
    component: UserComponent,
    canActivate: [authGuard],
    data: { Role: 'Admin' },
  },
  {
    path: 'all-categories',
    component: CategoryListComponent,
  },
  {
    path: 'all-auctions',
    component: AuctionsListComponent,
    canActivate: [authGuard],
    data: { Role: 'Admin' },
  },
  {
    path: 'auction-details/:id',
    component: AuctionComponent,
    canActivate: [authGuard],
    data: { Role: 'Admin' },
  },
  {
    path: 'all-bids',
    component: BidListComponent,
    canActivate: [authGuard],
    data: { Role: 'Admin' },
  },
  {
    path: 'place-bid/:id',
    component: PlaceBidComponent,
    canActivate: [authGuard],
    data: { Role: 'User' },
  },
  {
    path: 'add-product',
    component: AddProductComponent,
    canActivate: [authGuard],
    data: { Role: 'User' },
  },
  {
    path: 'user-bids',
    component: UserBidsComponent,
    canActivate: [authGuard],
    data: { Role: 'User' },
  },
  {
    path: 'unauthorized',
    component: UnauthorizedComponent,
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
