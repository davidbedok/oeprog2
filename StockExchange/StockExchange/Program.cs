using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class Program
    {
        private static void testStockExchange()
        {
            StockExchange stock = new StockExchange();
            stock.addClient("Nemecsek", 5000);
            stock.addClient("Tutajos", 3000);
            stock.addSecurties(SecuritiesName.OTP, 500);
            stock.addSecurties(SecuritiesName.MOL, 200);
            stock.addSecurties(SecuritiesName.RICHTER, 800);
            Console.WriteLine(stock.ToString());

            stock.createCommission("Nemecsek", SecuritiesName.OTP, 3, 400, CommissionType.Buy);
            stock.createCommission("Tutajos", SecuritiesName.MOL, 2, 300, CommissionType.Sale);
            stock.createCommission("Nemecsek", SecuritiesName.RICHTER, 4, 750, CommissionType.Buy);

            stock.modify(SecuritiesName.OTP, -150);
            stock.modify(SecuritiesName.MOL, 120);
            stock.modify(SecuritiesName.RICHTER, -40);
            
            Console.WriteLine(stock.ToString());
        }

        private static void Main(string[] args)
        {
            Program.testStockExchange();
        }
    }
}
