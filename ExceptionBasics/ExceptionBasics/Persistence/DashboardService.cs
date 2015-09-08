using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics.Persistence
{
    public interface DashboardService
    {

        List<String> GetInstruments(int userId);

    }
}
