# 🛒 Online Auction Application

An Online Auction Application built with secure authentication and admin functionalities. This system enables users to participate in auctions to buy or sell products, track bidding history, and manage users and auctions via an admin panel.

## 🚀 Features

- 🔐 **Authentication**
  - Login functionality for both Admin and Normal users via email and password.
  - Authentication ensures only logged-in users can access the auction features.
  - User data is seeded into the database; no signup functionality included.

- 🧑‍💼 **User Roles**
  - **Normal Users**: Can view and participate in ongoing auctions.
  - **Admin Users**: Can manage auctions and users.

- 📦 **Auctions**
  - Display product details, current highest bid, and remaining time.
  - Users can place bids on ongoing auctions.
  - Admin can:
    - View all auctions.
    - Delete auctions.
    - Suspend or ban users from participation.

- 📜 **User Activity History**
  - Admin can view a complete history of:
    - Auctions a user has participated in.
    - Products bought or sold.
    - Bidding/offering records.

- 📘 **API Documentation**
  - Swagger is integrated for interactive API documentation and testing.
  - Access it via: [http://auction-app.runasp.net/swagger](https://auction-app.runasp.net/swagger/index.html) (adjust the port if different in your setup)
 
## 🔑 Default Users (Seeded)

To log in and test the application, use the following seeded credentials:

| Role        | Email                | Password   |
|-------------|----------------------|------------|
| Admin       | admi01n@gmail.com    | Admin@123  |
| Admin       | admin02@example.com  | Admin@123  |
| Normal User | ishita@gmail.com     | User@123   |
| Normal User | khushi@gmail.com     | User@123   |
| Normal User | rohit@gmail.com      | User@123   |
| Normal User | abhi@gmail.com       | User@123   |
| Normal User | rahul@gmail.com      | User@123   |
| Normal User | nitin@gmail.com      | User@123   |

> ✅ These users are added via the database seed method.
> 🔐 You can update these credentials or add more users in the `AuctionDbContext` class before running migrations.

## 🛠️ Technologies Used

- **Backend**: .NET Core / ASP.NET Core Web API
- **Frontend**: Angular
- **Authentication**: JWT-based Authentication
- **Database**: SQL Server (with Seed method for user initialization)
- **ORM**: Entity Framework Core
