using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedMotorcycle : FuelBasedVehicles
    {
        Motorcycle.eLicenseType m_LicenseType;
        int m_EngineCapacity;
        private const eFuelType m_FuelType = eFuelType.Octan98;
        private const int m_NumberOfTirs = 2;
        private const float m_MaxTank = 6f;
        private const int m_MaxPrashore = 30;

        public FuelBasedMotorcycle() : 
            base(m_FuelType, m_NumberOfTirs, m_MaxPrashore, m_MaxTank)
        {

        }

        public Motorcycle.eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int Enginecapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            string stringInformationFuelBasedMotorcycle;

            stringInformationFuelBasedMotorcycle = string.Format(
            @"This is Fuel Based Motorcycle,
            License Type: {0}
            Engine Capacity: {1}
            Fuel Type = {2}
            {3}", m_LicenseType, m_EngineCapacity, m_FuelType, base.ToString());
            return stringInformationFuelBasedMotorcycle;
        }
    }
}
