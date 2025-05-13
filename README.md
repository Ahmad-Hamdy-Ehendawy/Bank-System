
Bank Account System Documentation

Overview:

This program simulates a banking system with basic features such as account creation, login, deposit, withdrawal, transfer, transaction history, and password change. There are two types of accounts: regular accounts and savings accounts. The savings account adds interest over time.

Classes:

1. BankAccount (Abstract Class)  
   This is the base class for all accounts. It includes common functionality such as:
   - Storing accounts.
   - Logging in using username and password.
   - Depositing and withdrawing money.
   - Transferring money between accounts.
   - Displaying transaction history.
   - Changing the password.

   Fields and Properties:
   - accountID (int): Unique identifier for the account.
   - credit (decimal): Current balance of the account.
   - accountname (string): Username associated with the account.
   - password (string): Password associated with the account.
   - transactions (List<string>): List to store transaction history.

   Methods:
   - StoreAccount(BankAccount acc): Adds the account to the list of stored accounts.
   - LogIn(): Prompts the user for username and password to log into an account.
   - Deposit(decimal money): Deposits money into the account.
   - Withdraw(decimal money): Withdraws money from the account.
   - Transfer(BankAccount account2, decimal money): Transfers money from the current account to another account.
   - DisplayCredit(): Displays the current credit of the account.
   - DisplayAccountInformation(): Displays the account details.
   - DisplayTransactionHistory(): Displays the transaction history of the account.

2. RegulerAccount (Derived Class)  
   A regular type of bank account with no interest.

   Constructor:
   - RegulerAccount(int credit, string accountname, string password): Initializes a new regular account with a specified credit, username, and password.

3. SavingAccount (Derived Class)  
   A savings type of bank account where interest is added over time.

   Fields and Properties:
   - interestRate (int): The interest rate applied to the savings account (fixed at 20% per year).
   
   Methods:
   - MoneyInYears(int years): Calculates the balance of the savings account after the specified number of years, applying interest annually.
   - Deposit(decimal money): Deposits money into the account, adding interest to the deposit amount.
   - DisplayAccountInformation(): Displays the account details, including the interest rate.

   Constructor:
   - SavingAccount(int credit, string accountname, string password): Initializes a new savings account with a specified credit, username, and password.

Program Execution Flow:

1. Account Creation:
   - Three accounts are created in the program: two regular accounts and one savings account.

2. Account Login:
   - The user is prompted to log in by entering a username and password. If the credentials match an existing account, the user gains access to that account.

3. Account Operations:
   - Once logged in, the user can perform the following operations:
     - Deposit money into the account.
     - Withdraw money from the account.
     - Transfer money to another account.
     - View the account balance.
     - View the transaction history.
     - Change the account password.

4. Saving Account Specific Operations:
   - If a user logs into a savings account, the system will display the future balance after applying interest for a specified number of years.

Sample Output:

===== INITIAL ACCOUNT INFO =====
Credit: 2000
Account Name: A1234
AccountID: 1
-------------
Credit: 1500
Account Name: B4325
AccountID: 2
-------------
Credit: 1000
Account Name: C1234
AccountID: 3
-------------

===== LOGGING IN =====
Enter username: 
A1234
Enter Password: 
pass1
===== DEPOSITING 500 =====
2500 Deposited

===== WITHDRAWING 300 =====
2200 withdrawed

===== TRANSFERRING 200 TO account2 =====
200 has been transferred from A1234 to B4325

===== DISPLAY CREDIT =====
2200

===== TRANSACTION HISTORY =====
500 deposed
300 withdrawed
200 has been transferred from A1234 to B4325

===== PASSWORD CHANGE TEST =====
newpass123 is your new password

===== MONEY IN 5 YEARS (Savings) =====
Money after 5 years is : 1200

===== FINAL ACCOUNT INFO =====
Credit: 2200 
Account Name: A1234 
AccountID: 1 
-------------
Conclusion:

This system models the basic operations of bank accounts and demonstrates how inheritance can be used to extend functionality for different types of accounts. The user can interact with their accounts through simple commands and perform basic banking operations.
