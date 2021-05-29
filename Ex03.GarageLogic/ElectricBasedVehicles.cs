using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBasedVehicles : Vehicle
    {
        protected float m_MaxTimeOfEngine;

        public ElectricBasedVehicles(int i_NumberOfTires, int i_MaxPrashore, float i_MaxEnergiSource) : 
            base(i_NumberOfTires, i_MaxPrashore, i_MaxEnergiSource)
        {
            m_MaxTimeOfEngine = i_MaxEnergiSource;
        }

        public float RemainingTimeOfEngine
        {
            get
            {
                return m_CurrentEnergySource;
            }
            set
            {
                m_CurrentEnergySource = value;
            }
        }

        public float MaxTimeOfEngine
        {
            get
            {
                return m_MaxTimeOfEngine;
            }
            set
            {
                m_MaxTimeOfEngine = value;
            }
        }


        internal void Recharge(float i_HowManyMoreHoursToAdd)
        {

            if (i_HowManyMoreHoursToAdd + m_CurrentEnergySource > m_MaxTimeOfEngine)
            {
                throw new ValueOutOfRangeException(0, m_MaxTimeOfEngine - m_CurrentEnergySource);
            }
            else
            {
                m_CurrentEnergySource += i_HowManyMoreHoursToAdd;

            }
        }

        public override string ToString()
        {
            string stringInformationElectricBaseVehicle;

            stringInformationElectricBaseVehicle = string.Format(
                                                  @"this vehicle based on Electric
                                                  the current engin is: [{0}/{1}]
                                                  {2}", m_CurrentEnergySource, m_MaxTimeOfEngine ,base.ToString());
            return stringInformationElectricBaseVehicle;
        }


    }
}
