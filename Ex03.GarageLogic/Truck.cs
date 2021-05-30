using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : FuelBasedVehicles
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

        public bool IsContainDangerousSubstances
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

        public override string ToString()
        {
            string stringInformationTruck;
            
            stringInformationTruck = string.Format(
            @"This is Truck,
            Fuel Type: {0}
            Is Contain Dangerou Ssubstance: {1}
            Max Carrying Weight: {2},
            {3}", m_FuelType, m_IsContainDangerouSsubstance, m_MaxCarryingWeight, base.ToString());
            return stringInformationTruck;
        }
    }
}
