using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricBasedVehicles
    {
        Car.eColor m_color;
        Car.eNunDoors m_numDoors;
        private const int m_NumberOfTirs = 4;
        private const float m_MaxEngine = 3.2f;
        private const int m_MaxPrashore = 32;

        public ElectricCar () :
            base(m_NumberOfTirs, m_MaxPrashore, m_MaxEngine)
        {
        }

        public Car.eColor Color
        {
            get
            {
                return m_color;
            }
            set
            {
                m_color = value;
            }
        }
        public Car.eNunDoors NumberOfDoors
        {
            get
            {
                return m_numDoors;
            }
            set
            {
                m_numDoors = value;
            }
        }

        public override string ToString()
        {
            string stringInformationElectricCar;

            stringInformationElectricCar = string.Format(
            @"This is electric car,
            color: {0}
            number of doors: {1}
            {2}", m_color, m_numDoors, base.ToString());
            return stringInformationElectricCar;
        }
    }
}
