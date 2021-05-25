using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : FuelBasedVehicles
    {
        bool m_IsContainDangerouSsubstance;
        float m_MaxCarryingWeight;

        public Truck()
        {
            m_FuelType = eFuelType.Soler;
            m_Tire = new List<Tires>(16);
            m_MaxFuel = 120f;
        }

        public bool IsContainDangerouSsubstance
        {
            get
            {
                return m_IsContainDangerouSsubstance;
            }
            set
            {
                m_IsContainDangerouSsubstance = value;
            }
        }

        public float MaxCarryingWeight
        {
            get
            {
                return m_MaxCarryingWeight;
            }
            set
            {
                m_MaxCarryingWeight = value;
            }
        }
    }
}
