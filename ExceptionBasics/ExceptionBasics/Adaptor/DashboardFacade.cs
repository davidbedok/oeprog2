using ExceptionBasics.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics.Adaptor
{
    public class DashboardFacade
    {

        private readonly Random random;
        private readonly DashboardService service;

        public DashboardFacade()
        {
            this.random = new Random();
            this.service = new DashboardServiceImpl();
        }

        public List<String> GetUserInstruments()
        {
            List<String> instruments = null;
            int userId = this.GetCurrentUserId();
            try
            {
                instruments = this.service.GetInstruments(userId);
            }
            catch (PersistenceException e)
            {
                Console.WriteLine("Error in '" + e.Field + "' field. Details: " + e.Message);
            }
            return instruments;
        }

        private int GetCurrentUserId()
        {
            return this.random.Next(50);
        }

    }
}
