using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics.Persistence
{
    public class DashboardServiceImpl : DashboardService
    {

        public List<String> GetInstruments(int userId)
        {
            List<String> result = null;
            if (this.CheckUserId(userId))
            {
                result = this.GetResultSet(userId);
            }
            return result;
        }

        private bool CheckUserId(int userId)
        {
            if (userId % 2 != 0)
            {
                throw new DuplicateKeyException("Lorem ipsum " + userId, "user");
            }
            return true;
        }

        private List<String> GetResultSet(int userId)
        {
            List<String> result = new List<String>();
            if (userId == 42)
            {
                throw new UniqueConstraintException("Dolor sit " + userId, "amet");
            }
            result.Add("Settings");
            result.Add("Navigation");
            return result;
        }

    }
}
