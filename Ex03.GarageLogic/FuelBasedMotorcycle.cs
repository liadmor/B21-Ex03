using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelBasedMotorcycle : FuelBasedVehicles
    {
        eLicenseType m_LicenseType;
        int m_EngineCapacity;
        private const int k_NumOfTires = 2;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const int k_maxFuelTank = m_MaxAmountOfFuel;

        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }
        public FuelBasedMotorcycle(eLicenseType i_LicenseType, int i_EngineCapacity)
        {

        }
    }
}
        


