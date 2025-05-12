using System;
using System.Collections.Generic;

abstract class BankAccount
{
    static List<BankAccount> accounts = new List<BankAccount>();

    public static void StoreAccount(BankAccount acc)
    {
        accounts.Add(acc);
    }

    public BankAccount(int credit, string accountname, string password)
    {
        this.credit = credit;
        this.accountname = accountname;
        this.password = password;
        this.accountID = ++number;
        accounts.Add(this);
    }

    public static BankAccount LogIn()
    {
        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter Password: ");
        string temp = Console.ReadLine();

        foreach (BankAccount acc in accounts)
        {
            if (username == acc.accountname && acc.PasswordCheck(temp))
            {
                return acc;
            }
        }
        Console.WriteLine("WRONG");
        return null;
    }

    private static int number = 0000;

    protected int accountID;
    public int AccountId => accountID;
    protected decimal credit;
    protected string accountname;
    protected string password;
    public string Password
    {
        set
        {
            Console.WriteLine("Enter old password: ");
            string temp = Console.ReadLine();
            if (temp == password)
            {
                password = value;
                Console.WriteLine($"{password} is your new password");
                transactions.Add($"{accountname} account's password has changed");
            }
            else
            {
                Console.WriteLine("Incorrect Password");
            }
        }
    }

    public bool PasswordCheck(string tmp)
    {
        return tmp == password;
    }

    public decimal Credit { get; protected set; }
    public string Accountname { get; set; }

    public List<string> transactions = new List<string>();

    public virtual void Deposit(decimal money)
    {
        if (money > 0)
        {
            this.credit += money;
            transactions.Add($"{money} deposed");
            Console.WriteLine($"{this.credit} Deposited");
        }
        else
        {
            Console.WriteLine("Deposit something wth");
            transactions.Add($"depositing {money} failed");
        }
    }

    public void Transfer(BankAccount account2, decimal money)
    {
        if (this.credit > money)
        {
            this.credit -= money;
            account2.credit += money;
            transactions.Add($"{money} has been transferred from {this.accountname} to {account2}");
        }
        else
        {
            Console.WriteLine("You have less than you want to transfer");
            transactions.Add($"transfering {money} has failed");
        }
    }

    public virtual void Withdraw(decimal money)
    {
        if (credit > money)
        {
            credit -= money;
            transactions.Add($"{money} withdrawed");
        }
        else
        {
            Console.WriteLine("Withdrawn failed");
            transactions.Add($"Withdrawing {money} failed");
        }
    }

    public void DisplayCredit()
    {
        Console.WriteLine(credit);
    }

    public virtual void DisplayAccountInformation()
    {
        Console.WriteLine(credit + accountname, +accountID);
        Console.WriteLine($"Credit: {credit} \n Account Name: {accountname} \n AccountID: {accountID} \n -------------");
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine("TRANSACTION HISTORY :-");
        foreach (var transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}

class RegulerAccount : BankAccount
{
    public RegulerAccount(int credit, string accountname, string password) : base(credit, accountname, password)
    {
    }
}

class SavingAccount : BankAccount
{
    int interestRate = 20;
    public double InterestRate { get; }

    public void MoneyInYears(int years)
    {
        for (int i = 0; i < years; i++)
        {
            this.credit += interestRate / 100m * this.credit;
        }
        Console.WriteLine($"Money after {years} years is : " + this.credit);
    }

    public override void Deposit(decimal money)
    {
        if (money > 0)
        {
            this.credit += money + (interestRate / 1000 * (this.credit + money));
            transactions.Add($"{money} deposed");
            Console.WriteLine($"{this.credit} Deposited");
        }
        else
        {
            Console.WriteLine("Deposit something wth");
            transactions.Add($"depositing {money} failed");
        }
    }

    public override void DisplayAccountInformation()
    {
        Console.WriteLine(credit + accountname, +accountID);
        Console.WriteLine($"Credit: {credit} \n Account Name: {accountname} \n AccountID: {accountID} \n Interest rate: {interestRate} \n -------------");
    }

    public SavingAccount(int credit, string accountname, string password) : base(credit, accountname, password)
    {
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        RegulerAccount account1 = new RegulerAccount(2000, "A1234", "pass1");
        RegulerAccount account2 = new RegulerAccount(1500, "B4325", "pass2");
        SavingAccount account3 = new SavingAccount(1000, "C1234", "pass3");

        Console.WriteLine("===== INITIAL ACCOUNT INFO =====");
        account1.DisplayAccountInformation();
        account2.DisplayAccountInformation();
        account3.DisplayAccountInformation();

        Console.WriteLine("\n===== LOGGING IN =====");
        BankAccount loggedIn = BankAccount.LogIn();

        if (loggedIn != null)
        {
            Console.WriteLine("\n===== DEPOSITING 500 =====");
            loggedIn.Deposit(500);

            Console.WriteLine("\n===== WITHDRAWING 300 =====");
            loggedIn.Withdraw(300);

            Console.WriteLine("\n===== TRANSFERRING 200 TO account2 =====");
            loggedIn.Transfer(account2, 200);

            Console.WriteLine("\n===== DISPLAY CREDIT =====");
            loggedIn.DisplayCredit();

            Console.WriteLine("\n===== TRANSACTION HISTORY =====");
            loggedIn.DisplayTransactionHistory();

            Console.WriteLine("\n===== PASSWORD CHANGE TEST =====");
            loggedIn.Password = "newpass123";

            if (loggedIn is SavingAccount saving)
            {
                Console.WriteLine("\n===== MONEY IN 5 YEARS (Savings) =====");
                saving.MoneyInYears(5);
            }

            Console.WriteLine("\n===== FINAL ACCOUNT INFO =====");
            loggedIn.DisplayAccountInformation();
        }
        else
        {
            Console.WriteLine("Login failed.");
        }
    }
}
