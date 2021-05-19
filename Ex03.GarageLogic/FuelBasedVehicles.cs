using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelBasedVehicles : Vehicles
    {
        protected eFuelType m_FuelType;
        float m_CurrentAmountOfFuel;
        protected float m_MaxAmountOfFuel;
        

        public static void Refueling(i_HowMuchFuelToAdd)
        {

        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
