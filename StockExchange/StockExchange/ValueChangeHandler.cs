using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class ValueChangeHandler : ValueChangeEvent
    {

        private readonly Client client;
        private readonly Commission commission;
        private readonly Securities securities;

        public ValueChangeHandler(Client client, Commission commission, Securities securities)
        {
            this.client = client;
            this.commission = commission;
            this.securities = securities;
        }

        public void change(int newValue)
        {
            if (!this.commission.Done)
            {
                bool done = false;
                if (this.commission.Type == CommissionType.Buy)
                {
                    if (commission.ExpectedValue >= newValue)
                    {
                        this.client.buy(commission.Count * newValue);
                        done = true;
                    }
                }
                else if (this.commission.Type == CommissionType.Sale)
                {
                    if (commission.ExpectedValue <= newValue)
                    {
                        this.client.sale(commission.Count * newValue);
                        done = true;
                    }
                }
                if (done)
                {
                    this.commission.Done = true;
                    Console.WriteLine("Commission done. " + this.commission + " - " + this.client.Name + " - " + securities);
                }
            }
        }

    }
}
