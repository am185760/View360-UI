using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCR.CCMS.Parser
{
    public class AtmCounter
    {
        private int type1;
        private int type2;
        private int type3;
        private int type4;

        public AtmCounter()
        {
            type1 = 0;
            type2 = 0;
            type3 = 0;
            type4 = 0;
        }

        public AtmCounter(int initialValue)
        {
            type1 = initialValue;
            type2 = initialValue;
            type3 = initialValue;
            type4 = initialValue;
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
    }
}
