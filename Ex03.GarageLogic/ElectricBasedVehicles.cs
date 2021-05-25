using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricBasedVehicles : Vehicle
    {
        protected float m_RemainingTimeOfEngine;
        protected float m_MaxTimeOfEngine;

        public ElectricBasedVehicles()
        {
        }

        public float RemainingTimeOfEngine
        {
            get
            {
                return m_RemainingTimeOfEngine;
            }
            set
            {
                m_RemainingTimeOfEngine = value;
            }
        }

        internal void Recharge(float i_HowManyMoreHoursToAdd)
        {

            if (i_HowManyMoreHoursToAdd + m_RemainingTimeOfEngine > m_MaxTimeOfEngine)
            {
                throw new ValueOutOfRangeException(0, m_MaxTimeOfEngine - m_RemainingTimeOfEngine);
            }
            else
            {
                m_RemainingTimeOfEngine += i_HowManyMoreHoursToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format(@"The current battery's amount : [{0}/{1}]", m_RemainingTimeOfEngine, m_MaxTimeOfEngine);
        }
    }
}
