# Design and Development of a Database for Bank Management System

## Overview

This project involves designing and implementing a comprehensive database system for a bank management system, alongside a C# Windows Forms application for user authentication. The database is built to handle information related to clients, accounts, transactions, and loans, while the application provides a user-friendly interface for login operations.

## Features

- **Entities and Relationships**: Logical and physical data models capturing clients, accounts, transactions, and loans.
- **Database Implementation**: Creation of the database in MySQL using DDL commands.
- **Data Insertion**: Populating the database with initial records.
- **SQL Queries**: Development of views, stored procedures, and triggers to manage and retrieve data efficiently.
- **User Rights and Integrity**: Setting up user roles and referential integrity mechanisms.
- **Login Interface**: A C# Windows Forms application for user authentication.

  
![Ekran görüntüsü 2024-07-26 180748](https://github.com/user-attachments/assets/af677b64-48aa-4972-b63a-46cd0271be38)

![Ekran görüntüsü 2024-07-26 180928](https://github.com/user-attachments/assets/4293f50f-9e9f-4083-afa1-7370cd7fd12d)

![Ekran görüntüsü 2024-07-26 202052](https://github.com/user-attachments/assets/ca687b7a-61a5-48dc-afa7-dc2d13be7f80)



## Database Structure

### Tables

1. **Clients**
   - `client_id`: INT (Primary Key)
   - `name`: VARCHAR(255)
   - `address`: VARCHAR(255)
   - `contact_info`: VARCHAR(255)

2. **Accounts**
   - `account_id`: INT (Primary Key)
   - `client_id`: INT (Foreign Key)
   - `account_number`: VARCHAR(20)
   - `account_type`: VARCHAR(50)
   - `balance`: DECIMAL(20, 2)

3. **Loans**
   - `loan_id`: INT (Primary Key)
   - `client_id`: INT (Foreign Key)
   - `account_id`: INT (Foreign Key)
   - `amount`: DECIMAL(20, 2)
   - `interest_rate`: DECIMAL(5, 2)
   - `duration`: INT

4. **Transactions**
   - `transaction_id`: INT (Primary Key)
   - `account_id`: INT (Foreign Key)
   - `transaction_type`: VARCHAR(50)
   - `amount`: DECIMAL(20, 2)
   - `date_time`: DATETIME

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/BaharBerra/Bank-Management-System--DBDD.git

2. Navigate to the project directory:
 ```sh
cd bank-management-db
```
## Usage

### Views

- **ClientAccounts**: Combines client and account information.
- **AccountTransactions**: Details of transactions associated with each account.
- **LoanDetails**: Comprehensive loan details along with associated client and account information.

### Stored Procedures and Functions

- **calculate_balance(account_id)**: Calculates the total balance for a given account.
- **GetTransactionsByAmount(min_amount)**: Retrieves transactions with amounts greater than or equal to the specified minimum amount.
  
### Triggers

- **check_balance**: Prevents transactions that would result in a negative account balance.

## Login Form

This project also includes a C# Windows Forms application for user authentication. The **'LoginForm'** class connects to a SQL Server database, verifies user credentials, and provides feedback on login success or failure.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
