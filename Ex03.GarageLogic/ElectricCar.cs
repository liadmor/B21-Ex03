using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricBasedVehicles
    {
        Car.eColor m_color;
        Car.eNunDoors m_numDoors;

        public ElectricCar()
        {
            m_MaxTimeOfEngine = 3.2f;
            m_Tire = new List<Tires>(4);
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
    }
}
