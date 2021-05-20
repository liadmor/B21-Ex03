using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricBasedVehicles : EnergySource
    {
        public ElectricBasedVehicles(float i_MaxEnergy, float i_CurrentEnergy)
        : base(i_MaxEnergy, i_CurrentEnergy)
        {
        }

        internal void Recharge(float i_HowManyMoreHoursToAdd)
        {

            if ((CurrentEnergy + i_HowManyMoreHoursToAdd <= MaxEnergy) && (i_HowManyMoreHoursToAdd > 0))
            {
                CurrentEnergy += i_HowManyMoreHoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
            }
        }
    }
}
