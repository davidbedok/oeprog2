using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwedishStore.Api
{
    public interface Salable
    {

        String sell(int pieces);

        double getPrice();

        String getFancyName();

    }
}
