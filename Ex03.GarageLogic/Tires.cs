using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Tires
    {
        string m_ManufacturerName;
        float m_MaxAirPressure;
        float m_CurrentAirPressure;

        public Tires(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure = 0)
        {
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public static void Inflatoin(int i_AirPressiroToAdd)
        {

        }


    }
}
