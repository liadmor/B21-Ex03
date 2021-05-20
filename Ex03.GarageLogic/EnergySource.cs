using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class EnergySource
    {
        protected readonly float r_MaxEnergy;
        protected float m_CurrentEnergy;

        public EnergySource(float i_MaxEnergy, float i_CurrentEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergyPercentage
        {
            get
            {
                return m_CurrentEnergy / r_MaxEnergy * 100;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }

        public enum eEnergySource
        {
            FuelBased = 1,
            ElectricBased
        }


    }
}
