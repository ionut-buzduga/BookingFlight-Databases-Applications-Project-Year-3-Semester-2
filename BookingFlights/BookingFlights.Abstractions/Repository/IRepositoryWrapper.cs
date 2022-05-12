﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Repository
{

    public interface IRepositoryWrapper
    {
        IFlightsRepository FlightsRepository { get; }
        

        void Save();
    }
}
