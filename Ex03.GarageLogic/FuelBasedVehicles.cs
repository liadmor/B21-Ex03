using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedVehicles : EnergySource
    {
        private readonly eFuelType r_FuelType;

        public FuelBasedVehicles(float r_MaxEnergy, float m_CurrentEnergy, eFuelType i_FuelType)
            : base(r_MaxEnergy, m_CurrentEnergy)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        internal void Refueling(float i_HowMuchFuelToAdd, eFuelType i_FuelType)
        {
            if (r_FuelType != i_FuelType)
            {
                throw new ArgumentException();
            }
            else
            {
                if (CurrentEnergy + i_HowMuchFuelToAdd <= MaxEnergy && i_HowMuchFuelToAdd > 0)
                {
                    CurrentEnergy += i_HowMuchFuelToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
                }
            }
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
