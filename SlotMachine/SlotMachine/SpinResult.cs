using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachines
{
    public class SpinResult : ISpinResult
    {
        public List<List<IReelSymbol>> Result { get; set; }

        public decimal Winnings { get; set; }
    }
}
