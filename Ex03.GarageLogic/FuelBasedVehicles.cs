﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelBasedVehicles : Vehicle
    {
        protected eFuelType m_VehicleFuelType;
        protected float m_VehichleMaxTank;
        protected float m_CurrentFuel;

        public FuelBasedVehicles(eFuelType i_FuelType, int i_NumberOfTires, int i_MaxPrashore, float i_MaxEnergiSource) :
            base(i_NumberOfTires, i_MaxPrashore, i_MaxEnergiSource)
        {
            m_VehicleFuelType = i_FuelType;
            m_VehichleMaxTank = i_MaxEnergiSource;
            m_CurrentFuel = m_CurrentEnergySource;
        }

        public void Refuel(float i_HowMuchFuelToAdd, eFuelType i_FuelType)
        {

            if (m_VehicleFuelType != i_FuelType)
            {
                throw new ArgumentException();
            }
            else
            {
                if (i_HowMuchFuelToAdd + m_CurrentFuel > m_VehichleMaxTank)
                {
                    throw new ValueOutOfRangeException(0, m_VehichleMaxTank - m_CurrentFuel);

                }
                else 
                {
                    m_CurrentFuel += i_HowMuchFuelToAdd;
                }
            }
        }

        public float CurrentFuel
        {
            get
            {
                return m_CurrentFuel;
            }
            set
            {
                m_CurrentFuel = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"The current {0} fuel's amount : [{1}/{2}]", m_VehicleFuelType, m_CurrentFuel, m_VehichleMaxTank);
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
