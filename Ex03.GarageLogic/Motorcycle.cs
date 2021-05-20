using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle
    {
        int m_EngineCapacity;
        eLicenseType m_LicenseType;
        private const int k_NumOfTires = 2;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const int k_maxFuelTank = 6;
        private const float k_MaxAirPresure = 30;

        public Motorcycle(int i_EngineCapacity, eLicenseType i_LicenseType)
        {

        }

        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
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
