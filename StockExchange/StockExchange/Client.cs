using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class Client
    {

        private String name;
        private int money;
        private List<Commission> commissions;

        public String Name
        {
            get { return this.name; }
        }

        public Client(String name, int money)
        {
            this.name = name;
            this.money = money;
            this.commissions = new List<Commission>();
        }

        public void addCommission(Securities securities, int count, int expectedValue, CommissionType type)
        {
            Commission commisson = new Commission(securities.Name, count, expectedValue, type);
            if (type == CommissionType.Buy && money < commisson.value() )
            {
                throw new NotEnoughMoneyException("Client hasn't got enough money to buy securities. (" + securities + ", count: " + count + ", expectedValue: " + expectedValue + ")." + this.ToString());
            }
            this.commissions.Add(commisson);
            securities.bind(new ValueChangeHandler(this, commisson, securities));
        }

        public void buy( int value )
        {
            this.money -= value;
        }

        public void sale(int value)
        {
            this.money += value;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine("[Client] " + this.name + " money: " + this.money);
            foreach( Commission commission in this.commissions ) {
                info.AppendLine(" - " + commission.ToString());
            }
            return info.ToString();
        }



    }
}
