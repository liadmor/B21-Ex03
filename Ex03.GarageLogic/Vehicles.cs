using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Vehicles
    {
        string m_ModelName;
        string m_LicensingNumber;
        protected float m_EnergyPrecent;
        protected List<Tires> m_Tires;

        public Vehicles(string i_ModelName, string i_LicensingNumber, float i_EnergyPrecent)
        {
            m_ModelName = i_ModelName;
            m_LicensingNumber = i_LicensingNumber;
            m_EnergyPrecent = i_EnergyPrecent;
            m_Tires = new List<Tires>();
        }
    }
}
