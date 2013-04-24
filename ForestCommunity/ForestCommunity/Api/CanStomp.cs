﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Forest;

namespace ForestCommunity.Api
{
    public interface CanStomp
    {
        void stomp(SeedBed seed);
        int stompTime();
    }
}
