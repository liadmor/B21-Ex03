using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        public Vehicle m_NewVehicle;
        private ePossibleVehicles m_VehicleType;
        public enum ePossibleVehicles
        {
            ElectricBasedMotorcycle = 1,
            FuelBasedMotorcycle,
            ElectricBasedCar,
            FuelBaseCar,
            Truck
        }

        public void NewVehicle(ePossibleVehicles i_VehicleType)
        {
            m_VehicleType = i_VehicleType;

            switch (m_VehicleType)
            {
                case ePossibleVehicles.ElectricBasedCar:
                    m_NewVehicle = new ElectricCar();
                    break;

                case ePossibleVehicles.FuelBaseCar:
                    m_NewVehicle = new FuelBasedCar();
                    break;

                case ePossibleVehicles.FuelBasedMotorcycle:
                    m_NewVehicle = new FuelBasedMotorcycle();
                    break;

                case ePossibleVehicles.ElectricBasedMotorcycle:
                    m_NewVehicle = new ElectricMotorcycle();
                    break;

                case ePossibleVehicles.Truck:
                    m_NewVehicle = new Truck();
                    break;
            }
        }

        public 

    }
}
