using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public class TransactionTrunk : System.Object
    {
        private static int MAX_ACCOUNT = 100;
        private static int MAX_TRANSACTION = 100;

        private Account[] accounts;
        private int actAccount;
        private Transaction[] transactions;
        private int actTransaction;

        public TransactionTrunk()
        {
            this.accounts = new Account[TransactionTrunk.MAX_ACCOUNT];
            this.actAccount = 0;
            this.transactions = new Transaction[TransactionTrunk.MAX_TRANSACTION];
            this.actTransaction = 0;
        }

        private Account findAccountByAccountNumber(string accountNumber)
        {
            Account ret = null;
            int i = 0;
            bool find = false;
            while ((i < actAccount) && (!find))
            {
                if (this.accounts[i].AccountNumber.Equals(accountNumber))
                {
                    ret = this.accounts[i];
                    find = true;
                }
                i++;
            }
            return ret;
        }

        private void addAccount(Account account)
        {
            if (this.actAccount < TransactionTrunk.MAX_ACCOUNT)
            {
                this.accounts[this.actAccount++] = account;
            }
        }

        public void addAccount(string ownerName, string accountNumber)
        {
            this.addAccount(new Account(ownerName, accountNumber));
        }

        private void addTransaction( Transaction transaction )
        {
            if (this.actTransaction < TransactionTrunk.MAX_TRANSACTION)
            {
                this.transactions[this.actTransaction++] = transaction;
            }
        }

        public void addCreditTransaction(string accountNumber,double balance,int day)
        {
            this.addTransaction(new CreditTransaction(this.findAccountByAccountNumber(accountNumber),balance,day));
        }

        public void addDebitTransaction(string accountNumber, double balance, int day)
        {
            this.addTransaction(new DebitTransaction(this.findAccountByAccountNumber(accountNumber), balance, day));
        }

        public double getBalance(string accountNumber)
        {
            double ret = 0;
            Account actAccount = this.findAccountByAccountNumber(accountNumber);
            if (actAccount != null)
            {
                for (int i = 0; i < this.actTransaction; i++)
                {
                    if (this.transactions[i].BaseAccount.Equals(actAccount))
                    {
                        ret += this.transactions[i].getValue();
                    }
                }
            }
            return ret;
        }

        public double getBalance(string accountNumber, int startDay, int endDay ){
            double ret = 0;
            Account actAccount = this.findAccountByAccountNumber(accountNumber);
            if (actAccount != null)
            {
                Transaction[] tmpTransactions = new Transaction[TransactionTrunk.MAX_TRANSACTION];
                int tmpTranNum = 0;
                for (int i = 0; i < this.actTransaction; i++)
                {
                    if (this.transactions[i].BaseAccount.Equals(actAccount))
                    {
                        if (this.transactions[i].Day >= startDay)
                        {
                            if (this.transactions[i].Day <= endDay)
                            {
                                ret += this.transactions[i].getValue();
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(400);
            sb.Append("Accounts\n");
            for (int i = 0; i < this.actAccount; i++)
            {
                sb.Append("["+i+"] "+this.accounts[i] + "\n");
            }
            sb.Append("Transactions\n");
            for (int i = 0; i < this.actTransaction; i++)
            {
                sb.Append("[" + i + "] " + this.transactions[i] + "\n");
            }
            return sb.ToString();
        }


    }
}
