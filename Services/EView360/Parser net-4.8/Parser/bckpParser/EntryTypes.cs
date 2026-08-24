using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal enum EntryTypes : int
    {
        /// <summary>
        /// Value designates to the unknown entries.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Value designates to the entries determining change in service state.
        /// </summary>
        ServiceState = 1,

        /// <summary>
        /// Value designates to the entries determining current mode of the ATM.
        /// </summary>
        CurrentMode = 2,

        /// <summary>
        /// Value designates to the entries determining current cassette mode of the ATM.
        /// </summary>
        CassetteMode = 3,

        /// <summary>
        /// Value designates to the entries determining note counts mismatch between last saved in configuration and currently loaded from CDI stores.
        /// </summary>
        Mismatch = 4,

        /// <summary>
        /// Value designates to the entries determining change in current mode.
        /// </summary>
        ModeChanged = 5,

        /// <summary>
        /// Value designates to the cash withdrawal transaction entries.
        /// </summary>
        CashWithdrawal = 6,

        /// <summary>
        /// Value designates to the counts clear transaction entries.
        /// </summary>
        CountsCleared = 7,

        /// <summary>
        /// Value designates to the counts set transaction entries in case of order is in place.
        /// </summary>
        CountsSet = 8,

        /// <summary>
        /// Value designates to the counts set transaction entries in case of order is missing.
        /// </summary>
        OrderMissing = 9,

        /// <summary>
        /// Value designates to the counts set transaction entries in case of counts clear retries exhausted.
        /// </summary>
        RetriesExhausted = 10,

        /// <summary>
        /// Value designates to the add cash transaction entries determining.
        /// </summary>
        AddCash = 11,

        /// <summary>
        /// Value designates to the test cash transaction entries.
        /// </summary>
        TestCash = 12,

        /// <summary>
        /// Value designates to the replenishment entries.
        /// </summary>
        Replenishment = 13,

        /// <summary>
        /// Value designates to the end of day balance entries.
        /// </summary>
        EODBalance = 13,
    }
}
