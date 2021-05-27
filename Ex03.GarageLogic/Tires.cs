using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Tires
    {
        private string m_ManufacturerName;
        public float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Tires(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void Inflatoin(int i_AirPressiroToAdd)
        {
            if (CurrentAirPressure + i_AirPressiroToAdd <= MaxAirPressure)
            {
                CurrentAirPressure += i_AirPressiroToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            string wheelInformationOutput = string.Format(
                                                            @"Tires:
                                                            --------------------------------
                                                            Manufacturer: {0}
                                                            Current Air Pressure: {1}
                                                            Max Air Pressure: {2}",
                                                            m_ManufacturerName,
                                                            m_CurrentAirPressure,
                                                            m_MaxAirPressure);

            return wheelInformationOutput;
        }
    }
}
