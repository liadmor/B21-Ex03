using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedCar : FuelBasedVehicles
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
            string stringInformationFuelCar;

            stringInformationFuelCar = string.Format(
                                                  @"This is Fuel base car {0},
                                                  color: {1}
                                                  number of doors: {2}
                                                  Fuel Type: {3}", base.ToString(), m_color, m_numDoors, m_FuelType);
            return stringInformationFuelCar;
        }
    }
}
