using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoSimulation
{
    class LotteryNumber
    {
        private int number;
        private long pcs;

        public LotteryNumber(int number)
        {
            this.Number = number;
            this.pcs = 0L;
        }

        public int Number { get => number; set => number = value; }
        public long Pcs { get => pcs; set => pcs = value; }

        public override string ToString()
        {
            return number + " : " + pcs;
        }
    }
}
