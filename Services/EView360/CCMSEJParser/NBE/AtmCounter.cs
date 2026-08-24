using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanza.CCMS.Parser
{
    class AtmCounter
    {
        private int type1;
        private int type2;
        private int type3;
        private int type4;
        private int type5;

        public AtmCounter()
        {
            type1 = 0;
            type2 = 0;
            type3 = 0;
            type4 = 0;
            type5 = 0;
        }

        public int Type1
        {
            get
            {
                return type1;
            }
            set
            {
                type1 = value > 0 ? value : 0;
            }
        }

        public int Type2
        {
            get
            {
                return type2;
            }
            set
            {
                type2 = value > 0 ? value : 0;
            }
        }

        public int Type3
        {
            get
            {
                return type3;
            }
            set
            {
                type3 = value > 0 ? value : 0;
            }
        }

        public int Type4
        {
            get
            {
                return type4;
            }
            set
            {
                type4 = value > 0 ? value : 0;
            }
        }
        public int Type5
        {
            get
            {
                return type5;
            }
            set
            {
                type5 = value > 0 ? value : 0;
            }
        }
    }
}
