using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class StockExchange
    {

        private List<Securities> listOfSecurities;
        private List<Client> clients;

        public StockExchange()
        {
            this.listOfSecurities = new List<Securities>();
            this.clients = new List<Client>();
        }

        public void addSecurties(SecuritiesName name, int value)
        {
            this.listOfSecurities.Add(new Securities(name, value));
        }

        public void addClient(String name, int money)
        {
            this.clients.Add(new Client(name, money));
        }

        public void modify(SecuritiesName securitiesName, int changeValue )
        {
            Securities securities = this.find(securitiesName);
            if (securities != null)
            {
                securities.modify(changeValue);
            }
        }

        private Securities find(SecuritiesName securitiesName)
        {
            Securities ret = null;
            foreach (Securities securities in this.listOfSecurities)
            {
                if (securities.Name == securitiesName)
                {
                    ret = securities;
                    break;
                }
            }
            return ret;
        }

        public void createCommission(String clientName, SecuritiesName securitiesName, int count, int expectedValue, CommissionType type)
        {
            Client client = this.find(clientName);
            Securities securities = this.find(securitiesName);
            if (client != null && securities != null)
            {
                if (type == CommissionType.Buy && securities.Value < expectedValue)
                {
                    throw new InvalidCommissionException("Cannot create " + type + " commission, 'cos the expectedValue is greater than the actual (" + securities + ", expectedValue: " + expectedValue + ").");
                }
                else if (type == CommissionType.Sale && securities.Value > expectedValue) {
                    throw new InvalidCommissionException("Cannot create " + type + " commission, 'cos the expectedValue is lower than the actual (" + securities + ", expectedValue: " + expectedValue + ").");
                }
                client.addCommission(securities, count, expectedValue, type);
            }
        }

        private Client find(String clientName)
        {
            Client ret = null;
            foreach (Client client in this.clients)
            {
                if (client.Name.Equals(clientName))
                {
                    ret = client;
                    break;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine("---[ StockExchange ]---");
            foreach (Securities securities in this.listOfSecurities)
            {
                info.AppendLine(securities.ToString());
            }
            foreach (Client client in this.clients)
            {
                info.Append(client.ToString());
            }
            return info.ToString();
        }

    }
}
