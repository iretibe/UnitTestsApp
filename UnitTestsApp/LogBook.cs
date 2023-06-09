﻿namespace UnitTestsApp
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        string MessageWithReturnStr(string message);
        bool LogWithOutputResult(string str, out string outputStr);
        bool LogWithRefObj(ref Customer customer);
    }

    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);

            return true;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;

            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);

            return message.ToLower();
        }
    }

    public class LogFaker : ILogBook
    {
        public int LogSeverity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            throw new NotImplementedException();
        }

        public bool LogToDb(string message)
        {
            throw new NotImplementedException();
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {

        }

        public string MessageWithReturnStr(string message)
        {
            throw new NotImplementedException();
        }
    }
}
