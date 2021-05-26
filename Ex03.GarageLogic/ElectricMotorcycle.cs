using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricBasedVehicles
    {
        Motorcycle.eLicenseType m_LicenseType;
        int m_EngineCapacity;
        private const int m_NumberOfTirs = 2;
        private const float m_MaxEngine = 1.8f;
        private const int m_MaxPrashore = 30;

        public ElectricMotorcycle() :
            base(m_NumberOfTirs, m_MaxPrashore, m_MaxEngine, m_MaxEngine)
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

        public int EngineCapacity
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

    }
}
