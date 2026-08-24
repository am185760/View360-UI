using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NCR.CCMS.Parser
{
    public class AtmCompleteCounter
    {
        private AtmCounter cassetteCounter;
        private AtmCounter rejectedCounter;
        private AtmCounter remainingCounter;
        private AtmCounter dispensedCounter;
        private AtmCounter totalCounter;
        
        private DateTime counterDateTime;
        private int startIndex;
        private int endIndex;

        public AtmCompleteCounter()
        {
            cassetteCounter = new AtmCounter(0);
            rejectedCounter = new AtmCounter(0);
            remainingCounter = new AtmCounter(0);
            dispensedCounter = new AtmCounter(0);
            totalCounter = new AtmCounter(0);
        }

        public static bool operator==(AtmCompleteCounter first, AtmCompleteCounter second)
        {
            return ((first.CassetteCounter.Type1 == second.CassetteCounter.Type1) && (first.CassetteCounter.Type2 == second.CassetteCounter.Type2) && (first.CassetteCounter.Type3 == second.CassetteCounter.Type3) && (first.CassetteCounter.Type4 == second.CassetteCounter.Type4));
        }

        public static bool operator!=(AtmCompleteCounter first, AtmCompleteCounter second)
        {
            //Edited by Ali Shah on 27th Sep, 2016
            //To fix the issue in QIIB
            //Issue: There was replenishment where counters were changing except counter of cassette 4 whose count was zero.
            //return ((first.CassetteCounter.Type1 != second.CassetteCounter.Type1) && (first.CassetteCounter.Type2 != second.CassetteCounter.Type2) && (first.CassetteCounter.Type3 != second.CassetteCounter.Type3) && (first.CassetteCounter.Type4 != second.CassetteCounter.Type4));
            return ((first.CassetteCounter.Type1 != second.CassetteCounter.Type1) || (first.CassetteCounter.Type2 != second.CassetteCounter.Type2) || (first.CassetteCounter.Type3 != second.CassetteCounter.Type3) || (first.CassetteCounter.Type4 != second.CassetteCounter.Type4));
        }

        public static bool IsCounterZero(AtmCounter atmCounter)
        {
            return ((atmCounter.Type1 == 0) && (atmCounter.Type2 == 0) && (atmCounter.Type3 == 0) && (atmCounter.Type4 == 0));
        }


        public AtmCounter CassetteCounter
        {
            get
            {
                return cassetteCounter;
            }
            set
            {
                cassetteCounter = value;
            }
        }

        public AtmCounter RejectedCounter
        {
            get
            {
                return rejectedCounter;
            }
            set
            {
                rejectedCounter = value;
            }
        }

        public AtmCounter RemainingCounter
        {
            get
            {
                return remainingCounter;
            }
            set
            {
                remainingCounter = value;
            }
        }

        public AtmCounter DispensedCounter
        {
            get
            {
                return dispensedCounter;
            }
            set
            {
                dispensedCounter = value;
            }
        }

        public AtmCounter TotalCounter
        {
            get
            {
                return totalCounter;
            }
            set
            {
                totalCounter = value;
            }
        }

        public DateTime CounterDateTime
        {
            get
            {
                return counterDateTime;
            }
            set
            {
                counterDateTime = value;
            }
        }

        public int StartIndex
        {
            get
            {
                return startIndex;
            }
            set
            {
                startIndex = value;
            }
        }

        public int EndIndex
        {
            get
            {
                return endIndex;
            }
            set
            {
                endIndex = value;
            }
        }
    }
}
