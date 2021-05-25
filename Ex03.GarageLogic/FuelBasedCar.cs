using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelBasedCar : FuelBasedVehicles
    {
        Car.eColor m_color;
        Car.eNunDoors m_numDoors;
        
        public FuelBasedCar()
        {
            m_FuelType = eFuelType.Octan95;
            m_Tire = new List<Tires>(4);
            m_MaxFuel = 45f;
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
            return string.Format("The car is {0} and has {1} doors", NumberOfDoors, Color);
        }

    }
}
