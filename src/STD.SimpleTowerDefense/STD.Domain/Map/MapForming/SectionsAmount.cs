using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Domain.Map.MapForming
{
    internal struct SectionsAmount
    {
        private int _amount;

        internal SectionsAmount(int amount)
        {
            Amount = amount;
        }

        internal int Amount
        {
            get => _amount;
            set
            {
                if (value is Int32 parsedValue)
                {
                    // ignore    
                }
                else if (Int32.TryParse(value.ToString(), out parsedValue))
                {
                    // ignore
                }

                if (parsedValue > 0)
                {
                    _amount = parsedValue;
                }
            }
        }

        public static explicit operator int(SectionsAmount sectionsAmount) => sectionsAmount.Amount;
    }
}
