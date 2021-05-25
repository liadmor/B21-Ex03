using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelBasedVehicles : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_MaxFuel;
        protected float m_CurrentFuel;

        internal void Refuel(float i_HowMuchFuelToAdd, eFuelType i_FuelType)
        {

            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException();
            }
            else
            {
                if (i_HowMuchFuelToAdd + m_CurrentFuel > m_MaxFuel)
                {
                    throw new ValueOutOfRangeException(0, m_MaxFuel - m_CurrentFuel);

                }
                else 
                {
                    m_CurrentFuel += i_HowMuchFuelToAdd;
                }
            }
        }

        public float CurrentFuel
        {
            get
            {
                return m_CurrentFuel;
            }
            set
            {
                m_CurrentFuel = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"The current {0} fuel's amount : [{1}/{2}]", m_FuelType, m_CurrentFuel, m_MaxFuel);
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
