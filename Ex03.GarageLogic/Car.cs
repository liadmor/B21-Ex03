using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicles
    {
        private eColor m_color;
        private eNunDoors m_numDoors;
        private const int k_numberOfTires = 4;
        private const float k_MaxAirPresure = 32;



        public Car(eColor i_color, eNunDoors i_numDoors, float i_EnergyPrecent, string i_ManufacturerName, string i_ModelName, string i_LicensingNumber) : base(i_ModelName, i_LicensingNumber, i_EnergyPrecent)
        {
            m_color = i_color;
            m_numDoors = i_numDoors;
            for (int i = 0; i < k_numberOfTires; i++)
            {
                m_Tires.Add( new Tires(i_ManufacturerName, k_MaxAirPresure));
            }
        }

        public enum eNunDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public enum eColor
        {
            Red,
            Black,
            White,
            Silver
        }

    }
}
