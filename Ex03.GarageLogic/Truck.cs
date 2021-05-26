using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : FuelBasedVehicles
    {
        private bool m_IsContainDangerouSsubstance;
        private float m_MaxCarryingWeight;
        private const eFuelType m_FuelType = eFuelType.Soler;
        private const int m_NumberOfTirs = 16;
        private const float m_MaxTank = 120f;
        private const int m_MaxPrashore = 26;


        public Truck() : 
            base(m_FuelType, m_NumberOfTirs, m_MaxPrashore, m_MaxTank)
        {
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
