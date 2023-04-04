﻿namespace UnitTestsApp
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked!"); //True
            //_logBook.Message(""); //False
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;

            balance += amount;

            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= balance)
            {
                _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());

                balance -= amount;

                //return true;
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }

            //return false;
            return _logBook.LogBalanceAfterWithdrawal(balance - amount);
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
