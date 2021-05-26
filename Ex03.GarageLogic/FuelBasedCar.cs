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
        private const eFuelType m_FuelType = eFuelType.Octan95;
        private const int m_NumberOfTirs = 4;
        private const float m_MaxTank = 45f;
        private const int m_MaxPrashore = 32;

        public FuelBasedCar() : 
            base(m_FuelType, m_NumberOfTirs, m_MaxPrashore, m_MaxTank)
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
            return string.Format("The car is {0} and has {1} doors", NumberOfDoors, Color);
        }

    }
}
