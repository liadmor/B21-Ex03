using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        string m_ModelName;
        string m_LicensingNumber;
        protected float m_EnergyPrecent;
        protected List<Tires> m_Tire;
        Factory.ePossibleVehicles m_VehicleType;
        int m_NumberOfTires;
        int m_MaxTireAirPressure;
        float m_MaxEnergySource;
        protected float m_CurrentEnergySource;

        public Vehicle(int i_NumberOfTires, int i_MaxTireAirPressure, float i_MaxEnergySource)
        {

            m_NumberOfTires = i_NumberOfTires;
            m_MaxEnergySource = i_MaxEnergySource;
            m_MaxTireAirPressure = i_MaxTireAirPressure;
            m_Tire = new List<Tires>(m_NumberOfTires);
        }

        public Factory.ePossibleVehicles VehicleType
        {
            get
            {
                return m_VehicleType;
            }
            set
            {
                m_VehicleType = value;
            }
        }


        public List<Tires> Tire
        {
            get
            {
                return m_Tire;
            }
            set
            {
                m_Tire = value;
            }

        }

        public float MaxEnergySource
        {
            get
            {
                return m_MaxEnergySource;
            }
            set
            {
                m_MaxEnergySource = value;
            }
        }


        public float CurrentEnergySource
        {
            get
            {
                return m_CurrentEnergySource;
            }
            set
            {
                m_CurrentEnergySource = value;
            }
        }

        public void SetTireInfo(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            foreach (Tires tire in m_Tire)
            {
                tire.ManufacturerName = i_ManufacturerName;
                tire.MaxAirPressure = i_MaxAirPressure;
                tire.CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        public float EnergyPrecent
        {
            get
            {
                return m_EnergyPrecent;
            }
            set
            {
                m_EnergyPrecent = (m_CurrentEnergySource / m_MaxEnergySource) * 100;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicensingNumber
        {
            get
            {
                return m_LicensingNumber;
            }

            set
            {
                m_LicensingNumber = value;
            }
        }

        public int MaxTireAirPressure
        {
            get
            {
                return m_MaxTireAirPressure;
            }
        }

        public override string ToString()
        {
            string vehicleInformationOutput;
            vehicleInformationOutput = string.Format(
            @"Vehicle:
            --------------------------------
            License Number: {0}
            Model Name: {1}
            Energy Percentage Left: {2}%
            {3}",
            m_LicensingNumber,
            m_ModelName,
            m_EnergyPrecent,
            m_Tire[0].ToString());

            return vehicleInformationOutput;
        }

        
    }
}