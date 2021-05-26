using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        string m_ModelName;
        string m_LicensingNumber;
        protected float m_EnergyPrecent;
        protected List<Tires> m_Tire;
        //liad
        int m_NumberOfTires;
        int m_MaxPrashore;
        float m_MaxEnergiSource;
        //liad

        public Vehicle(int i_NumberOfTires, int i_MaxPrashore, float i_MaxEnergiSource)
        {
            
        }
    }
}
