

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
 using System.Data.SqlClient;

namespace ServicesDAL
{
    [Serializable()]
    public class Summary
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public Summary() { }
        public Summary(long atm_id, decimal closing_balance, decimal withdrawals, decimal pre_withdrawals, DateTime trxn_datetime, long summary_id)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.closing_balance = closing_balance;
            this.closing_balanceChanged = true;
            this.withdrawals = withdrawals;
            this.withdrawalsChanged = true;
            this.pre_withdrawals = pre_withdrawals;
            this.pre_withdrawalsChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
        }
        public Summary(long atm_id, decimal closing_balance, decimal withdrawals, decimal pre_withdrawals, DateTime trxn_datetime, decimal? return_amount, decimal? replenishment_amount, int? cash_remaining1, int? cash_remaining2, int? cash_remaining3, int? cash_remaining4, int? cash_remaining5, int? cash_remaining6, int? cash_remaining7, int? return_type1, int? return_type2, int? return_type3, int? return_type4, int? return_type5, int? return_type6, int? return_type7, int? cash_added1, int? cash_added2, int? cash_added3, int? cash_added4, int? cash_added5, int? cash_added6, int? cash_added7, DateTime? generated_at, decimal? opening_balance, int? purged_return_type1, int? purged_return_type2, int? purged_return_type3, int? purged_return_type4, int? purged_return_type5, int? purged_return_type6, int? purged_return_type7)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.closing_balance = closing_balance;
            this.closing_balanceChanged = true;
            this.withdrawals = withdrawals;
            this.withdrawalsChanged = true;
            this.pre_withdrawals = pre_withdrawals;
            this.pre_withdrawalsChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.return_amount = return_amount;
            this.return_amountChanged = true;
            this.replenishment_amount = replenishment_amount;
            this.replenishment_amountChanged = true;
            this.cash_remaining1 = cash_remaining1;
            this.cash_remaining1Changed = true;
            this.cash_remaining2 = cash_remaining2;
            this.cash_remaining2Changed = true;
            this.cash_remaining3 = cash_remaining3;
            this.cash_remaining3Changed = true;
            this.cash_remaining4 = cash_remaining4;
            this.cash_remaining4Changed = true;
            this.cash_remaining5 = cash_remaining5;
            this.cash_remaining5Changed = true;
            this.cash_remaining6 = cash_remaining6;
            this.cash_remaining6Changed = true;
            this.cash_remaining7 = cash_remaining7;
            this.cash_remaining7Changed = true;
            this.return_type1 = return_type1;
            this.return_type1Changed = true;
            this.return_type2 = return_type2;
            this.return_type2Changed = true;
            this.return_type3 = return_type3;
            this.return_type3Changed = true;
            this.return_type4 = return_type4;
            this.return_type4Changed = true;
            this.return_type5 = return_type5;
            this.return_type5Changed = true;
            this.return_type6 = return_type6;
            this.return_type6Changed = true;
            this.return_type7 = return_type7;
            this.return_type7Changed = true;
            this.cash_added1 = cash_added1;
            this.cash_added1Changed = true;
            this.cash_added2 = cash_added2;
            this.cash_added2Changed = true;
            this.cash_added3 = cash_added3;
            this.cash_added3Changed = true;
            this.cash_added4 = cash_added4;
            this.cash_added4Changed = true;
            this.cash_added5 = cash_added5;
            this.cash_added5Changed = true;
            this.cash_added6 = cash_added6;
            this.cash_added6Changed = true;
            this.cash_added7 = cash_added7;
            this.cash_added7Changed = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.opening_balance = opening_balance;
            this.opening_balanceChanged = true;
            this.purged_return_type1 = purged_return_type1;
            this.purged_return_type1Changed = true;
            this.purged_return_type2 = purged_return_type2;
            this.purged_return_type2Changed = true;
            this.purged_return_type3 = purged_return_type3;
            this.purged_return_type3Changed = true;
            this.purged_return_type4 = purged_return_type4;
            this.purged_return_type4Changed = true;
            this.purged_return_type5 = purged_return_type5;
            this.purged_return_type5Changed = true;
            this.purged_return_type6 = purged_return_type6;
            this.purged_return_type6Changed = true;
            this.purged_return_type7 = purged_return_type7;
            this.purged_return_type7Changed = true;
        }
        private Summary(long atm_id, decimal closing_balance, decimal withdrawals, decimal pre_withdrawals, DateTime trxn_datetime, decimal? return_amount, decimal? replenishment_amount, long summary_id, int? cash_remaining1, int? cash_remaining2, int? cash_remaining3, int? cash_remaining4, int? cash_remaining5, int? cash_remaining6, int? cash_remaining7, int? return_type1, int? return_type2, int? return_type3, int? return_type4, int? return_type5, int? return_type6, int? return_type7, int? cash_added1, int? cash_added2, int? cash_added3, int? cash_added4, int? cash_added5, int? cash_added6, int? cash_added7, DateTime? generated_at, decimal? opening_balance, int? purged_return_type1, int? purged_return_type2, int? purged_return_type3, int? purged_return_type4, int? purged_return_type5, int? purged_return_type6, int? purged_return_type7)
        {
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.closing_balance = closing_balance;
            this.closing_balanceChanged = true;
            this.withdrawals = withdrawals;
            this.withdrawalsChanged = true;
            this.pre_withdrawals = pre_withdrawals;
            this.pre_withdrawalsChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.return_amount = return_amount;
            this.return_amountChanged = true;
            this.replenishment_amount = replenishment_amount;
            this.replenishment_amountChanged = true;
            this.summary_id = summary_id;
            this.summary_idChanged = true;
            this.cash_remaining1 = cash_remaining1;
            this.cash_remaining1Changed = true;
            this.cash_remaining2 = cash_remaining2;
            this.cash_remaining2Changed = true;
            this.cash_remaining3 = cash_remaining3;
            this.cash_remaining3Changed = true;
            this.cash_remaining4 = cash_remaining4;
            this.cash_remaining4Changed = true;
            this.cash_remaining5 = cash_remaining5;
            this.cash_remaining5Changed = true;
            this.cash_remaining6 = cash_remaining6;
            this.cash_remaining6Changed = true;
            this.cash_remaining7 = cash_remaining7;
            this.cash_remaining7Changed = true;
            this.return_type1 = return_type1;
            this.return_type1Changed = true;
            this.return_type2 = return_type2;
            this.return_type2Changed = true;
            this.return_type3 = return_type3;
            this.return_type3Changed = true;
            this.return_type4 = return_type4;
            this.return_type4Changed = true;
            this.return_type5 = return_type5;
            this.return_type5Changed = true;
            this.return_type6 = return_type6;
            this.return_type6Changed = true;
            this.return_type7 = return_type7;
            this.return_type7Changed = true;
            this.cash_added1 = cash_added1;
            this.cash_added1Changed = true;
            this.cash_added2 = cash_added2;
            this.cash_added2Changed = true;
            this.cash_added3 = cash_added3;
            this.cash_added3Changed = true;
            this.cash_added4 = cash_added4;
            this.cash_added4Changed = true;
            this.cash_added5 = cash_added5;
            this.cash_added5Changed = true;
            this.cash_added6 = cash_added6;
            this.cash_added6Changed = true;
            this.cash_added7 = cash_added7;
            this.cash_added7Changed = true;
            this.generated_at = generated_at;
            this.generated_atChanged = true;
            this.opening_balance = opening_balance;
            this.opening_balanceChanged = true;
            this.purged_return_type1 = purged_return_type1;
            this.purged_return_type1Changed = true;
            this.purged_return_type2 = purged_return_type2;
            this.purged_return_type2Changed = true;
            this.purged_return_type3 = purged_return_type3;
            this.purged_return_type3Changed = true;
            this.purged_return_type4 = purged_return_type4;
            this.purged_return_type4Changed = true;
            this.purged_return_type5 = purged_return_type5;
            this.purged_return_type5Changed = true;
            this.purged_return_type6 = purged_return_type6;
            this.purged_return_type6Changed = true;
            this.purged_return_type7 = purged_return_type7;
            this.purged_return_type7Changed = true;
        }

        #region members and properties for columns

        #region AtmId
        private bool atm_idChanged = false;
        private long atm_id;
        public long AtmId
        {
            get { return atm_id; }
            set
            {
                atm_id = value;
                atm_idChanged = true;
            }
        }
        private string atm_idDbString
        {
            get
            {
                return atm_id.ToString();
            }
        }
        #endregion
        #region ClosingBalance
        private bool closing_balanceChanged = false;
        private decimal closing_balance;
        public decimal ClosingBalance
        {
            get { return closing_balance; }
            set
            {
                closing_balance = value;
                closing_balanceChanged = true;
            }
        }
        private string closing_balanceDbString
        {
            get
            {
                return closing_balance.ToString();
            }
        }
        #endregion
        #region Withdrawals
        private bool withdrawalsChanged = false;
        private decimal withdrawals;
        public decimal Withdrawals
        {
            get { return withdrawals; }
            set
            {
                withdrawals = value;
                withdrawalsChanged = true;
            }
        }
        private string withdrawalsDbString
        {
            get
            {
                return withdrawals.ToString();
            }
        }
        #endregion
        #region PreWithdrawals
        private bool pre_withdrawalsChanged = false;
        private decimal pre_withdrawals;
        public decimal PreWithdrawals
        {
            get { return pre_withdrawals; }
            set
            {
                pre_withdrawals = value;
                pre_withdrawalsChanged = true;
            }
        }
        private string pre_withdrawalsDbString
        {
            get
            {
                return pre_withdrawals.ToString();
            }
        }
        #endregion
        #region TrxnDatetime
        private bool trxn_datetimeChanged = false;
        private DateTime trxn_datetime;
        public DateTime TrxnDatetime
        {
            get { return trxn_datetime; }
            set
            {
                trxn_datetime = value;
                trxn_datetimeChanged = true;
            }
        }
        private string trxn_datetimeDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", trxn_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region ReturnAmount
        private bool return_amountChanged = false;
        private decimal? return_amount;
        public decimal? ReturnAmount
        {
            get { return return_amount; }
            set
            {
                return_amount = value;
                return_amountChanged = true;
            }
        }
        private string return_amountDbString
        {
            get
            {
                if (this.return_amount.HasValue)
                    return return_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReplenishmentAmount
        private bool replenishment_amountChanged = false;
        private decimal? replenishment_amount;
        public decimal? ReplenishmentAmount
        {
            get { return replenishment_amount; }
            set
            {
                replenishment_amount = value;
                replenishment_amountChanged = true;
            }
        }
        private string replenishment_amountDbString
        {
            get
            {
                if (this.replenishment_amount.HasValue)
                    return replenishment_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region SummaryId
        private bool summary_idChanged = false;
        private long summary_id;
        public long SummaryId
        {
            get { return summary_id; }
            set
            {
                summary_id = value;
                summary_idChanged = true;
            }
        }
        private string summary_idDbString
        {
            get
            {
                return summary_id.ToString();
            }
        }
        #endregion
        #region CashRemaining1
        private bool cash_remaining1Changed = false;
        private int? cash_remaining1;
        public int? CashRemaining1
        {
            get { return cash_remaining1; }
            set
            {
                cash_remaining1 = value;
                cash_remaining1Changed = true;
            }
        }
        private string cash_remaining1DbString
        {
            get
            {
                if (this.cash_remaining1.HasValue)
                    return cash_remaining1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining2
        private bool cash_remaining2Changed = false;
        private int? cash_remaining2;
        public int? CashRemaining2
        {
            get { return cash_remaining2; }
            set
            {
                cash_remaining2 = value;
                cash_remaining2Changed = true;
            }
        }
        private string cash_remaining2DbString
        {
            get
            {
                if (this.cash_remaining2.HasValue)
                    return cash_remaining2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining3
        private bool cash_remaining3Changed = false;
        private int? cash_remaining3;
        public int? CashRemaining3
        {
            get { return cash_remaining3; }
            set
            {
                cash_remaining3 = value;
                cash_remaining3Changed = true;
            }
        }
        private string cash_remaining3DbString
        {
            get
            {
                if (this.cash_remaining3.HasValue)
                    return cash_remaining3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining4
        private bool cash_remaining4Changed = false;
        private int? cash_remaining4;
        public int? CashRemaining4
        {
            get { return cash_remaining4; }
            set
            {
                cash_remaining4 = value;
                cash_remaining4Changed = true;
            }
        }
        private string cash_remaining4DbString
        {
            get
            {
                if (this.cash_remaining4.HasValue)
                    return cash_remaining4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining5
        private bool cash_remaining5Changed = false;
        private int? cash_remaining5;
        public int? CashRemaining5
        {
            get { return cash_remaining5; }
            set
            {
                cash_remaining5 = value;
                cash_remaining5Changed = true;
            }
        }
        private string cash_remaining5DbString
        {
            get
            {
                if (this.cash_remaining5.HasValue)
                    return cash_remaining5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining6
        private bool cash_remaining6Changed = false;
        private int? cash_remaining6;
        public int? CashRemaining6
        {
            get { return cash_remaining6; }
            set
            {
                cash_remaining6 = value;
                cash_remaining6Changed = true;
            }
        }
        private string cash_remaining6DbString
        {
            get
            {
                if (this.cash_remaining6.HasValue)
                    return cash_remaining6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashRemaining7
        private bool cash_remaining7Changed = false;
        private int? cash_remaining7;
        public int? CashRemaining7
        {
            get { return cash_remaining7; }
            set
            {
                cash_remaining7 = value;
                cash_remaining7Changed = true;
            }
        }
        private string cash_remaining7DbString
        {
            get
            {
                if (this.cash_remaining7.HasValue)
                    return cash_remaining7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType1
        private bool return_type1Changed = false;
        private int? return_type1;
        public int? ReturnType1
        {
            get { return return_type1; }
            set
            {
                return_type1 = value;
                return_type1Changed = true;
            }
        }
        private string return_type1DbString
        {
            get
            {
                if (this.return_type1.HasValue)
                    return return_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType2
        private bool return_type2Changed = false;
        private int? return_type2;
        public int? ReturnType2
        {
            get { return return_type2; }
            set
            {
                return_type2 = value;
                return_type2Changed = true;
            }
        }
        private string return_type2DbString
        {
            get
            {
                if (this.return_type2.HasValue)
                    return return_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType3
        private bool return_type3Changed = false;
        private int? return_type3;
        public int? ReturnType3
        {
            get { return return_type3; }
            set
            {
                return_type3 = value;
                return_type3Changed = true;
            }
        }
        private string return_type3DbString
        {
            get
            {
                if (this.return_type3.HasValue)
                    return return_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType4
        private bool return_type4Changed = false;
        private int? return_type4;
        public int? ReturnType4
        {
            get { return return_type4; }
            set
            {
                return_type4 = value;
                return_type4Changed = true;
            }
        }
        private string return_type4DbString
        {
            get
            {
                if (this.return_type4.HasValue)
                    return return_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType5
        private bool return_type5Changed = false;
        private int? return_type5;
        public int? ReturnType5
        {
            get { return return_type5; }
            set
            {
                return_type5 = value;
                return_type5Changed = true;
            }
        }
        private string return_type5DbString
        {
            get
            {
                if (this.return_type5.HasValue)
                    return return_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType6
        private bool return_type6Changed = false;
        private int? return_type6;
        public int? ReturnType6
        {
            get { return return_type6; }
            set
            {
                return_type6 = value;
                return_type6Changed = true;
            }
        }
        private string return_type6DbString
        {
            get
            {
                if (this.return_type6.HasValue)
                    return return_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ReturnType7
        private bool return_type7Changed = false;
        private int? return_type7;
        public int? ReturnType7
        {
            get { return return_type7; }
            set
            {
                return_type7 = value;
                return_type7Changed = true;
            }
        }
        private string return_type7DbString
        {
            get
            {
                if (this.return_type7.HasValue)
                    return return_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded1
        private bool cash_added1Changed = false;
        private int? cash_added1;
        public int? CashAdded1
        {
            get { return cash_added1; }
            set
            {
                cash_added1 = value;
                cash_added1Changed = true;
            }
        }
        private string cash_added1DbString
        {
            get
            {
                if (this.cash_added1.HasValue)
                    return cash_added1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded2
        private bool cash_added2Changed = false;
        private int? cash_added2;
        public int? CashAdded2
        {
            get { return cash_added2; }
            set
            {
                cash_added2 = value;
                cash_added2Changed = true;
            }
        }
        private string cash_added2DbString
        {
            get
            {
                if (this.cash_added2.HasValue)
                    return cash_added2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded3
        private bool cash_added3Changed = false;
        private int? cash_added3;
        public int? CashAdded3
        {
            get { return cash_added3; }
            set
            {
                cash_added3 = value;
                cash_added3Changed = true;
            }
        }
        private string cash_added3DbString
        {
            get
            {
                if (this.cash_added3.HasValue)
                    return cash_added3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded4
        private bool cash_added4Changed = false;
        private int? cash_added4;
        public int? CashAdded4
        {
            get { return cash_added4; }
            set
            {
                cash_added4 = value;
                cash_added4Changed = true;
            }
        }
        private string cash_added4DbString
        {
            get
            {
                if (this.cash_added4.HasValue)
                    return cash_added4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded5
        private bool cash_added5Changed = false;
        private int? cash_added5;
        public int? CashAdded5
        {
            get { return cash_added5; }
            set
            {
                cash_added5 = value;
                cash_added5Changed = true;
            }
        }
        private string cash_added5DbString
        {
            get
            {
                if (this.cash_added5.HasValue)
                    return cash_added5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded6
        private bool cash_added6Changed = false;
        private int? cash_added6;
        public int? CashAdded6
        {
            get { return cash_added6; }
            set
            {
                cash_added6 = value;
                cash_added6Changed = true;
            }
        }
        private string cash_added6DbString
        {
            get
            {
                if (this.cash_added6.HasValue)
                    return cash_added6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CashAdded7
        private bool cash_added7Changed = false;
        private int? cash_added7;
        public int? CashAdded7
        {
            get { return cash_added7; }
            set
            {
                cash_added7 = value;
                cash_added7Changed = true;
            }
        }
        private string cash_added7DbString
        {
            get
            {
                if (this.cash_added7.HasValue)
                    return cash_added7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region GeneratedAt
        private bool generated_atChanged = false;
        private DateTime? generated_at;
        public DateTime? GeneratedAt
        {
            get { return generated_at; }
            set
            {
                generated_at = value;
                generated_atChanged = true;
            }
        }
        private string generated_atDbString
        {
            get
            {
                if (this.generated_at.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", generated_at.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region OpeningBalance
        private bool opening_balanceChanged = false;
        private decimal? opening_balance;
        public decimal? OpeningBalance
        {
            get { return opening_balance; }
            set
            {
                opening_balance = value;
                opening_balanceChanged = true;
            }
        }
        private string opening_balanceDbString
        {
            get
            {
                if (this.opening_balance.HasValue)
                    return opening_balance.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType1
        private bool purged_return_type1Changed = false;
        private int? purged_return_type1;
        public int? PurgedReturnType1
        {
            get { return purged_return_type1; }
            set
            {
                purged_return_type1 = value;
                purged_return_type1Changed = true;
            }
        }
        private string purged_return_type1DbString
        {
            get
            {
                if (this.purged_return_type1.HasValue)
                    return purged_return_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType2
        private bool purged_return_type2Changed = false;
        private int? purged_return_type2;
        public int? PurgedReturnType2
        {
            get { return purged_return_type2; }
            set
            {
                purged_return_type2 = value;
                purged_return_type2Changed = true;
            }
        }
        private string purged_return_type2DbString
        {
            get
            {
                if (this.purged_return_type2.HasValue)
                    return purged_return_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType3
        private bool purged_return_type3Changed = false;
        private int? purged_return_type3;
        public int? PurgedReturnType3
        {
            get { return purged_return_type3; }
            set
            {
                purged_return_type3 = value;
                purged_return_type3Changed = true;
            }
        }
        private string purged_return_type3DbString
        {
            get
            {
                if (this.purged_return_type3.HasValue)
                    return purged_return_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType4
        private bool purged_return_type4Changed = false;
        private int? purged_return_type4;
        public int? PurgedReturnType4
        {
            get { return purged_return_type4; }
            set
            {
                purged_return_type4 = value;
                purged_return_type4Changed = true;
            }
        }
        private string purged_return_type4DbString
        {
            get
            {
                if (this.purged_return_type4.HasValue)
                    return purged_return_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType5
        private bool purged_return_type5Changed = false;
        private int? purged_return_type5;
        public int? PurgedReturnType5
        {
            get { return purged_return_type5; }
            set
            {
                purged_return_type5 = value;
                purged_return_type5Changed = true;
            }
        }
        private string purged_return_type5DbString
        {
            get
            {
                if (this.purged_return_type5.HasValue)
                    return purged_return_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType6
        private bool purged_return_type6Changed = false;
        private int? purged_return_type6;
        public int? PurgedReturnType6
        {
            get { return purged_return_type6; }
            set
            {
                purged_return_type6 = value;
                purged_return_type6Changed = true;
            }
        }
        private string purged_return_type6DbString
        {
            get
            {
                if (this.purged_return_type6.HasValue)
                    return purged_return_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgedReturnType7
        private bool purged_return_type7Changed = false;
        private int? purged_return_type7;
        public int? PurgedReturnType7
        {
            get { return purged_return_type7; }
            set
            {
                purged_return_type7 = value;
                purged_return_type7Changed = true;
            }
        }
        private string purged_return_type7DbString
        {
            get
            {
                if (this.purged_return_type7.HasValue)
                    return purged_return_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region SummaryReader
        public class SummaryReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            Summary currentSummary;
            Columns columns;
            bool partialRead = false;
            private SummaryReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public SummaryReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public SummaryReader(IDataReader reader, IDbConnection conn, Columns columns)
            {
                this.reader = reader;
                this.conn = conn;
                this.columns = columns;
                partialRead = true;
            }

            public bool IsClosed
            {
                get { return reader.IsClosed; }
            }
            public int Depth
            {
                get { return reader.Depth; }
            }
            public int FieldCount
            {
                get { return reader.FieldCount; }
            }

            public object Current
            {
                get { return currentSummary; }

            }
            public void Close()
            {
                reader.Close();
                conn.Close();
            }
            public void Close(bool closeConnection)
            {
                reader.Close();
                if (closeConnection)
                    conn.Close();
            }

            public bool Read()
            {
                if (reader.Read())
                {
                    currentSummary = new Summary();
                    if (partialRead)
                    {
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentSummary.atm_id = (long)reader["atm_id"];
                        if ((columns & Columns.closing_balance) == Columns.closing_balance && reader["closing_balance"] != DBNull.Value)
                            currentSummary.closing_balance = (decimal)reader["closing_balance"];
                        if ((columns & Columns.withdrawals) == Columns.withdrawals && reader["withdrawals"] != DBNull.Value)
                            currentSummary.withdrawals = (decimal)reader["withdrawals"];
                        if ((columns & Columns.pre_withdrawals) == Columns.pre_withdrawals && reader["pre_withdrawals"] != DBNull.Value)
                            currentSummary.pre_withdrawals = (decimal)reader["pre_withdrawals"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentSummary.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if ((columns & Columns.return_amount) == Columns.return_amount && reader["return_amount"] != DBNull.Value)
                            currentSummary.return_amount = (decimal?)reader["return_amount"];
                        if ((columns & Columns.replenishment_amount) == Columns.replenishment_amount && reader["replenishment_amount"] != DBNull.Value)
                            currentSummary.replenishment_amount = (decimal?)reader["replenishment_amount"];
                        if ((columns & Columns.summary_id) == Columns.summary_id && reader["summary_id"] != DBNull.Value)
                            currentSummary.summary_id = (long)reader["summary_id"];
                        if ((columns & Columns.cash_remaining1) == Columns.cash_remaining1 && reader["cash_remaining1"] != DBNull.Value)
                            currentSummary.cash_remaining1 = (int?)reader["cash_remaining1"];
                        if ((columns & Columns.cash_remaining2) == Columns.cash_remaining2 && reader["cash_remaining2"] != DBNull.Value)
                            currentSummary.cash_remaining2 = (int?)reader["cash_remaining2"];
                        if ((columns & Columns.cash_remaining3) == Columns.cash_remaining3 && reader["cash_remaining3"] != DBNull.Value)
                            currentSummary.cash_remaining3 = (int?)reader["cash_remaining3"];
                        if ((columns & Columns.cash_remaining4) == Columns.cash_remaining4 && reader["cash_remaining4"] != DBNull.Value)
                            currentSummary.cash_remaining4 = (int?)reader["cash_remaining4"];
                        if ((columns & Columns.cash_remaining5) == Columns.cash_remaining5 && reader["cash_remaining5"] != DBNull.Value)
                            currentSummary.cash_remaining5 = (int?)reader["cash_remaining5"];
                        if ((columns & Columns.cash_remaining6) == Columns.cash_remaining6 && reader["cash_remaining6"] != DBNull.Value)
                            currentSummary.cash_remaining6 = (int?)reader["cash_remaining6"];
                        if ((columns & Columns.cash_remaining7) == Columns.cash_remaining7 && reader["cash_remaining7"] != DBNull.Value)
                            currentSummary.cash_remaining7 = (int?)reader["cash_remaining7"];
                        if ((columns & Columns.return_type1) == Columns.return_type1 && reader["return_type1"] != DBNull.Value)
                            currentSummary.return_type1 = (int?)reader["return_type1"];
                        if ((columns & Columns.return_type2) == Columns.return_type2 && reader["return_type2"] != DBNull.Value)
                            currentSummary.return_type2 = (int?)reader["return_type2"];
                        if ((columns & Columns.return_type3) == Columns.return_type3 && reader["return_type3"] != DBNull.Value)
                            currentSummary.return_type3 = (int?)reader["return_type3"];
                        if ((columns & Columns.return_type4) == Columns.return_type4 && reader["return_type4"] != DBNull.Value)
                            currentSummary.return_type4 = (int?)reader["return_type4"];
                        if ((columns & Columns.return_type5) == Columns.return_type5 && reader["return_type5"] != DBNull.Value)
                            currentSummary.return_type5 = (int?)reader["return_type5"];
                        if ((columns & Columns.return_type6) == Columns.return_type6 && reader["return_type6"] != DBNull.Value)
                            currentSummary.return_type6 = (int?)reader["return_type6"];
                        if ((columns & Columns.return_type7) == Columns.return_type7 && reader["return_type7"] != DBNull.Value)
                            currentSummary.return_type7 = (int?)reader["return_type7"];
                        if ((columns & Columns.cash_added1) == Columns.cash_added1 && reader["cash_added1"] != DBNull.Value)
                            currentSummary.cash_added1 = (int?)reader["cash_added1"];
                        if ((columns & Columns.cash_added2) == Columns.cash_added2 && reader["cash_added2"] != DBNull.Value)
                            currentSummary.cash_added2 = (int?)reader["cash_added2"];
                        if ((columns & Columns.cash_added3) == Columns.cash_added3 && reader["cash_added3"] != DBNull.Value)
                            currentSummary.cash_added3 = (int?)reader["cash_added3"];
                        if ((columns & Columns.cash_added4) == Columns.cash_added4 && reader["cash_added4"] != DBNull.Value)
                            currentSummary.cash_added4 = (int?)reader["cash_added4"];
                        if ((columns & Columns.cash_added5) == Columns.cash_added5 && reader["cash_added5"] != DBNull.Value)
                            currentSummary.cash_added5 = (int?)reader["cash_added5"];
                        if ((columns & Columns.cash_added6) == Columns.cash_added6 && reader["cash_added6"] != DBNull.Value)
                            currentSummary.cash_added6 = (int?)reader["cash_added6"];
                        if ((columns & Columns.cash_added7) == Columns.cash_added7 && reader["cash_added7"] != DBNull.Value)
                            currentSummary.cash_added7 = (int?)reader["cash_added7"];
                        if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"] != DBNull.Value)
                            currentSummary.generated_at = (DateTime?)reader["generated_at"];
                        if ((columns & Columns.opening_balance) == Columns.opening_balance && reader["opening_balance"] != DBNull.Value)
                            currentSummary.opening_balance = (decimal?)reader["opening_balance"];
                        if ((columns & Columns.purged_return_type1) == Columns.purged_return_type1 && reader["purged_return_type1"] != DBNull.Value)
                            currentSummary.purged_return_type1 = (int?)reader["purged_return_type1"];
                        if ((columns & Columns.purged_return_type2) == Columns.purged_return_type2 && reader["purged_return_type2"] != DBNull.Value)
                            currentSummary.purged_return_type2 = (int?)reader["purged_return_type2"];
                        if ((columns & Columns.purged_return_type3) == Columns.purged_return_type3 && reader["purged_return_type3"] != DBNull.Value)
                            currentSummary.purged_return_type3 = (int?)reader["purged_return_type3"];
                        if ((columns & Columns.purged_return_type4) == Columns.purged_return_type4 && reader["purged_return_type4"] != DBNull.Value)
                            currentSummary.purged_return_type4 = (int?)reader["purged_return_type4"];
                        if ((columns & Columns.purged_return_type5) == Columns.purged_return_type5 && reader["purged_return_type5"] != DBNull.Value)
                            currentSummary.purged_return_type5 = (int?)reader["purged_return_type5"];
                        if ((columns & Columns.purged_return_type6) == Columns.purged_return_type6 && reader["purged_return_type6"] != DBNull.Value)
                            currentSummary.purged_return_type6 = (int?)reader["purged_return_type6"];
                        if ((columns & Columns.purged_return_type7) == Columns.purged_return_type7 && reader["purged_return_type7"] != DBNull.Value)
                            currentSummary.purged_return_type7 = (int?)reader["purged_return_type7"];

                    }
                    else
                    {
                        if (reader["atm_id"] != DBNull.Value)
                            currentSummary.atm_id = (long)reader["atm_id"];
                        if (reader["closing_balance"] != DBNull.Value)
                            currentSummary.closing_balance = (decimal)reader["closing_balance"];
                        if (reader["withdrawals"] != DBNull.Value)
                            currentSummary.withdrawals = (decimal)reader["withdrawals"];
                        if (reader["pre_withdrawals"] != DBNull.Value)
                            currentSummary.pre_withdrawals = (decimal)reader["pre_withdrawals"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentSummary.trxn_datetime = (DateTime)reader["trxn_datetime"];
                        if (reader["return_amount"] != DBNull.Value)
                            currentSummary.return_amount = (decimal?)reader["return_amount"];
                        if (reader["replenishment_amount"] != DBNull.Value)
                            currentSummary.replenishment_amount = (decimal?)reader["replenishment_amount"];
                        if (reader["summary_id"] != DBNull.Value)
                            currentSummary.summary_id = (long)reader["summary_id"];
                        if (reader["cash_remaining1"] != DBNull.Value)
                            currentSummary.cash_remaining1 = (int?)reader["cash_remaining1"];
                        if (reader["cash_remaining2"] != DBNull.Value)
                            currentSummary.cash_remaining2 = (int?)reader["cash_remaining2"];
                        if (reader["cash_remaining3"] != DBNull.Value)
                            currentSummary.cash_remaining3 = (int?)reader["cash_remaining3"];
                        if (reader["cash_remaining4"] != DBNull.Value)
                            currentSummary.cash_remaining4 = (int?)reader["cash_remaining4"];
                        if (reader["cash_remaining5"] != DBNull.Value)
                            currentSummary.cash_remaining5 = (int?)reader["cash_remaining5"];
                        if (reader["cash_remaining6"] != DBNull.Value)
                            currentSummary.cash_remaining6 = (int?)reader["cash_remaining6"];
                        if (reader["cash_remaining7"] != DBNull.Value)
                            currentSummary.cash_remaining7 = (int?)reader["cash_remaining7"];
                        if (reader["return_type1"] != DBNull.Value)
                            currentSummary.return_type1 = (int?)reader["return_type1"];
                        if (reader["return_type2"] != DBNull.Value)
                            currentSummary.return_type2 = (int?)reader["return_type2"];
                        if (reader["return_type3"] != DBNull.Value)
                            currentSummary.return_type3 = (int?)reader["return_type3"];
                        if (reader["return_type4"] != DBNull.Value)
                            currentSummary.return_type4 = (int?)reader["return_type4"];
                        if (reader["return_type5"] != DBNull.Value)
                            currentSummary.return_type5 = (int?)reader["return_type5"];
                        if (reader["return_type6"] != DBNull.Value)
                            currentSummary.return_type6 = (int?)reader["return_type6"];
                        if (reader["return_type7"] != DBNull.Value)
                            currentSummary.return_type7 = (int?)reader["return_type7"];
                        if (reader["cash_added1"] != DBNull.Value)
                            currentSummary.cash_added1 = (int?)reader["cash_added1"];
                        if (reader["cash_added2"] != DBNull.Value)
                            currentSummary.cash_added2 = (int?)reader["cash_added2"];
                        if (reader["cash_added3"] != DBNull.Value)
                            currentSummary.cash_added3 = (int?)reader["cash_added3"];
                        if (reader["cash_added4"] != DBNull.Value)
                            currentSummary.cash_added4 = (int?)reader["cash_added4"];
                        if (reader["cash_added5"] != DBNull.Value)
                            currentSummary.cash_added5 = (int?)reader["cash_added5"];
                        if (reader["cash_added6"] != DBNull.Value)
                            currentSummary.cash_added6 = (int?)reader["cash_added6"];
                        if (reader["cash_added7"] != DBNull.Value)
                            currentSummary.cash_added7 = (int?)reader["cash_added7"];
                        if (reader["generated_at"] != DBNull.Value)
                            currentSummary.generated_at = (DateTime?)reader["generated_at"];
                        if (reader["opening_balance"] != DBNull.Value)
                            currentSummary.opening_balance = (decimal?)reader["opening_balance"];
                        if (reader["purged_return_type1"] != DBNull.Value)
                            currentSummary.purged_return_type1 = (int?)reader["purged_return_type1"];
                        if (reader["purged_return_type2"] != DBNull.Value)
                            currentSummary.purged_return_type2 = (int?)reader["purged_return_type2"];
                        if (reader["purged_return_type3"] != DBNull.Value)
                            currentSummary.purged_return_type3 = (int?)reader["purged_return_type3"];
                        if (reader["purged_return_type4"] != DBNull.Value)
                            currentSummary.purged_return_type4 = (int?)reader["purged_return_type4"];
                        if (reader["purged_return_type5"] != DBNull.Value)
                            currentSummary.purged_return_type5 = (int?)reader["purged_return_type5"];
                        if (reader["purged_return_type6"] != DBNull.Value)
                            currentSummary.purged_return_type6 = (int?)reader["purged_return_type6"];
                        if (reader["purged_return_type7"] != DBNull.Value)
                            currentSummary.purged_return_type7 = (int?)reader["purged_return_type7"];
                    }

                    currentSummary.isNewEntity = false;
                    return true;
                }
                else
                    return false;
            }
            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return this;
            }
            #endregion


            #region IEnumerator Members

            public Summary CurrentSummary
            {
                get { return currentSummary; }
            }

            public bool MoveNext()
            {
                return Read();
            }

            public void Reset()
            {
                throw new Exception("The method is not implemented.");
            }

            #endregion
        }

        #endregion


        #region Summary functions

        public static SummaryReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.closing_balance == (Columns.closing_balance & columns))
                qry.Append("closing_balance,");
            if (Columns.withdrawals == (Columns.withdrawals & columns))
                qry.Append("withdrawals,");
            if (Columns.pre_withdrawals == (Columns.pre_withdrawals & columns))
                qry.Append("pre_withdrawals,");
            if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
                qry.Append("trxn_datetime,");
            if (Columns.return_amount == (Columns.return_amount & columns))
                qry.Append("return_amount,");
            if (Columns.replenishment_amount == (Columns.replenishment_amount & columns))
                qry.Append("replenishment_amount,");
            if (Columns.summary_id == (Columns.summary_id & columns))
                qry.Append("summary_id,");
            if (Columns.cash_remaining1 == (Columns.cash_remaining1 & columns))
                qry.Append("cash_remaining1,");
            if (Columns.cash_remaining2 == (Columns.cash_remaining2 & columns))
                qry.Append("cash_remaining2,");
            if (Columns.cash_remaining3 == (Columns.cash_remaining3 & columns))
                qry.Append("cash_remaining3,");
            if (Columns.cash_remaining4 == (Columns.cash_remaining4 & columns))
                qry.Append("cash_remaining4,");
            if (Columns.cash_remaining5 == (Columns.cash_remaining5 & columns))
                qry.Append("cash_remaining5,");
            if (Columns.cash_remaining6 == (Columns.cash_remaining6 & columns))
                qry.Append("cash_remaining6,");
            if (Columns.cash_remaining7 == (Columns.cash_remaining7 & columns))
                qry.Append("cash_remaining7,");
            if (Columns.return_type1 == (Columns.return_type1 & columns))
                qry.Append("return_type1,");
            if (Columns.return_type2 == (Columns.return_type2 & columns))
                qry.Append("return_type2,");
            if (Columns.return_type3 == (Columns.return_type3 & columns))
                qry.Append("return_type3,");
            if (Columns.return_type4 == (Columns.return_type4 & columns))
                qry.Append("return_type4,");
            if (Columns.return_type5 == (Columns.return_type5 & columns))
                qry.Append("return_type5,");
            if (Columns.return_type6 == (Columns.return_type6 & columns))
                qry.Append("return_type6,");
            if (Columns.return_type7 == (Columns.return_type7 & columns))
                qry.Append("return_type7,");
            if (Columns.cash_added1 == (Columns.cash_added1 & columns))
                qry.Append("cash_added1,");
            if (Columns.cash_added2 == (Columns.cash_added2 & columns))
                qry.Append("cash_added2,");
            if (Columns.cash_added3 == (Columns.cash_added3 & columns))
                qry.Append("cash_added3,");
            if (Columns.cash_added4 == (Columns.cash_added4 & columns))
                qry.Append("cash_added4,");
            if (Columns.cash_added5 == (Columns.cash_added5 & columns))
                qry.Append("cash_added5,");
            if (Columns.cash_added6 == (Columns.cash_added6 & columns))
                qry.Append("cash_added6,");
            if (Columns.cash_added7 == (Columns.cash_added7 & columns))
                qry.Append("cash_added7,");
            if (Columns.generated_at == (Columns.generated_at & columns))
                qry.Append("generated_at,");
            if (Columns.opening_balance == (Columns.opening_balance & columns))
                qry.Append("opening_balance,");
            if (Columns.purged_return_type1 == (Columns.purged_return_type1 & columns))
                qry.Append("purged_return_type1,");
            if (Columns.purged_return_type2 == (Columns.purged_return_type2 & columns))
                qry.Append("purged_return_type2,");
            if (Columns.purged_return_type3 == (Columns.purged_return_type3 & columns))
                qry.Append("purged_return_type3,");
            if (Columns.purged_return_type4 == (Columns.purged_return_type4 & columns))
                qry.Append("purged_return_type4,");
            if (Columns.purged_return_type5 == (Columns.purged_return_type5 & columns))
                qry.Append("purged_return_type5,");
            if (Columns.purged_return_type6 == (Columns.purged_return_type6 & columns))
                qry.Append("purged_return_type6,");
            if (Columns.purged_return_type7 == (Columns.purged_return_type7 & columns))
                qry.Append("purged_return_type7,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Summary ");

            if (where != null && where.Trim().Length > 0)
            {
                qry.Append(" where ");
                qry.Append(where); ;
            }

            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = qry.ToString();
            return new SummaryReader(cmd.ExecuteReader(), conn, columns);
        }

        static public SummaryReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static SummaryReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select atm_id,closing_balance,withdrawals,pre_withdrawals,trxn_datetime,return_amount,replenishment_amount,summary_id,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,return_type1,return_type2,return_type3,return_type4,return_type5,return_type6,return_type7,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,generated_at,opening_balance,purged_return_type1,purged_return_type2,purged_return_type3,purged_return_type4,purged_return_type5,purged_return_type6,purged_return_type7 from Summary ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new SummaryReader(cmd.ExecuteReader(), conn);
        }

        static public SummaryReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public static Summary LoadSummary(string where)
        {
            SummaryReader reader = Summary.ExecuteReader(where);
            Summary _summary = null;
            if (reader.Read())
                _summary = reader.CurrentSummary;
            reader.Close();
            return _summary;
        }

        public static Summary LoadSummary(string where, IDbConnection conn)
        {
            SummaryReader reader = Summary.ExecuteReader(where, conn);
            Summary _summary = null;
            if (reader.Read())
                _summary = reader.CurrentSummary;
            reader.Close(false);
            return _summary;
        }

        public static Summary LoadSummaryByPk(long summary_id)
        {
            return LoadSummary("summary_id=" + summary_id);
        }

        public static Summary LoadSummaryByPk(long summary_id, IDbConnection conn)
        {
            return LoadSummary(" summary_id=" + summary_id, conn);
        }

        public void Save()
        {
            if (atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || trxn_datetimeChanged || return_amountChanged || replenishment_amountChanged || summary_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed || return_type5Changed || return_type6Changed || return_type7Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || generated_atChanged || opening_balanceChanged || purged_return_type1Changed || purged_return_type2Changed || purged_return_type3Changed || purged_return_type4Changed || purged_return_type5Changed || purged_return_type6Changed || purged_return_type7Changed)
                ExcuteSave(ConnectionFactory.GetNewConnection(DatabaseName.Cash).CreateCommand());
        }

        public void Save(IDbConnection conn, IDbTransaction trx)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.Transaction = trx;
            ExcuteSave(cmd);
        }

        public void Save(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            ExcuteSave(cmd);
        }

        /// an opened connection
        private void ExcuteSave(IDbCommand cmd)
        {
            if (atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || trxn_datetimeChanged || return_amountChanged || replenishment_amountChanged || summary_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed || return_type5Changed || return_type6Changed || return_type7Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || generated_atChanged || opening_balanceChanged || purged_return_type1Changed || purged_return_type2Changed || purged_return_type3Changed || purged_return_type4Changed || purged_return_type5Changed || purged_return_type6Changed || purged_return_type7Changed)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Summary(atm_id,closing_balance,withdrawals,pre_withdrawals,trxn_datetime,return_amount,replenishment_amount,summary_id,cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,cash_remaining5,cash_remaining6,cash_remaining7,return_type1,return_type2,return_type3,return_type4,return_type5,return_type6,return_type7,cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,generated_at,opening_balance,purged_return_type1,purged_return_type2,purged_return_type3,purged_return_type4,purged_return_type5,purged_return_type6,purged_return_type7) values(");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(closing_balanceDbString + ",");
                    qry.Append(withdrawalsDbString + ",");
                    qry.Append(pre_withdrawalsDbString + ",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(return_amountDbString + ",");
                    qry.Append(replenishment_amountDbString + ",");
                    lock (ConnectionFactory.connectionStringCash)
                    {
                        this.summary_id = ConnectionFactory.GetNextId(DatabaseName.Cash);
                        qry.Append(this.summary_id);
                    }
                    qry.Append(",");
                    qry.Append(cash_remaining1DbString + ",");
                    qry.Append(cash_remaining2DbString + ",");
                    qry.Append(cash_remaining3DbString + ",");
                    qry.Append(cash_remaining4DbString + ",");
                    qry.Append(cash_remaining5DbString + ",");
                    qry.Append(cash_remaining6DbString + ",");
                    qry.Append(cash_remaining7DbString + ",");
                    qry.Append(return_type1DbString + ",");
                    qry.Append(return_type2DbString + ",");
                    qry.Append(return_type3DbString + ",");
                    qry.Append(return_type4DbString + ",");
                    qry.Append(return_type5DbString + ",");
                    qry.Append(return_type6DbString + ",");
                    qry.Append(return_type7DbString + ",");
                    qry.Append(cash_added1DbString + ",");
                    qry.Append(cash_added2DbString + ",");
                    qry.Append(cash_added3DbString + ",");
                    qry.Append(cash_added4DbString + ",");
                    qry.Append(cash_added5DbString + ",");
                    qry.Append(cash_added6DbString + ",");
                    qry.Append(cash_added7DbString + ",");
                    qry.Append(generated_atDbString + ",");
                    qry.Append(opening_balanceDbString + ",");
                    qry.Append(purged_return_type1DbString + ",");
                    qry.Append(purged_return_type2DbString + ",");
                    qry.Append(purged_return_type3DbString + ",");
                    qry.Append(purged_return_type4DbString + ",");
                    qry.Append(purged_return_type5DbString + ",");
                    qry.Append(purged_return_type6DbString + ",");
                    qry.Append(purged_return_type7DbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(atm_idChanged || closing_balanceChanged || withdrawalsChanged || pre_withdrawalsChanged || trxn_datetimeChanged || return_amountChanged || replenishment_amountChanged || summary_idChanged || cash_remaining1Changed || cash_remaining2Changed || cash_remaining3Changed || cash_remaining4Changed || cash_remaining5Changed || cash_remaining6Changed || cash_remaining7Changed || return_type1Changed || return_type2Changed || return_type3Changed || return_type4Changed || return_type5Changed || return_type6Changed || return_type7Changed || cash_added1Changed || cash_added2Changed || cash_added3Changed || cash_added4Changed || cash_added5Changed || cash_added6Changed || cash_added7Changed || generated_atChanged || opening_balanceChanged || purged_return_type1Changed || purged_return_type2Changed || purged_return_type3Changed || purged_return_type4Changed || purged_return_type5Changed || purged_return_type6Changed || purged_return_type7Changed))
                        return;
                    qry.Append("UPDATE Summary set "); if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (closing_balanceChanged)
                    {
                        qry.Append("closing_balance =" + closing_balanceDbString);
                        qry.Append(",");
                    }

                    if (withdrawalsChanged)
                    {
                        qry.Append("withdrawals =" + withdrawalsDbString);
                        qry.Append(",");
                    }

                    if (pre_withdrawalsChanged)
                    {
                        qry.Append("pre_withdrawals =" + pre_withdrawalsDbString);
                        qry.Append(",");
                    }

                    if (trxn_datetimeChanged)
                    {
                        qry.Append("trxn_datetime =" + trxn_datetimeDbString);
                        qry.Append(",");
                    }

                    if (return_amountChanged)
                    {
                        qry.Append("return_amount =" + return_amountDbString);
                        qry.Append(",");
                    }

                    if (replenishment_amountChanged)
                    {
                        qry.Append("replenishment_amount =" + replenishment_amountDbString);
                        qry.Append(",");
                    }

                    if (cash_remaining1Changed)
                    {
                        qry.Append("cash_remaining1 =" + cash_remaining1DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining2Changed)
                    {
                        qry.Append("cash_remaining2 =" + cash_remaining2DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining3Changed)
                    {
                        qry.Append("cash_remaining3 =" + cash_remaining3DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining4Changed)
                    {
                        qry.Append("cash_remaining4 =" + cash_remaining4DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining5Changed)
                    {
                        qry.Append("cash_remaining5 =" + cash_remaining5DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining6Changed)
                    {
                        qry.Append("cash_remaining6 =" + cash_remaining6DbString);
                        qry.Append(",");
                    }

                    if (cash_remaining7Changed)
                    {
                        qry.Append("cash_remaining7 =" + cash_remaining7DbString);
                        qry.Append(",");
                    }

                    if (return_type1Changed)
                    {
                        qry.Append("return_type1 =" + return_type1DbString);
                        qry.Append(",");
                    }

                    if (return_type2Changed)
                    {
                        qry.Append("return_type2 =" + return_type2DbString);
                        qry.Append(",");
                    }

                    if (return_type3Changed)
                    {
                        qry.Append("return_type3 =" + return_type3DbString);
                        qry.Append(",");
                    }

                    if (return_type4Changed)
                    {
                        qry.Append("return_type4 =" + return_type4DbString);
                        qry.Append(",");
                    }

                    if (return_type5Changed)
                    {
                        qry.Append("return_type5 =" + return_type5DbString);
                        qry.Append(",");
                    }

                    if (return_type6Changed)
                    {
                        qry.Append("return_type6 =" + return_type6DbString);
                        qry.Append(",");
                    }

                    if (return_type7Changed)
                    {
                        qry.Append("return_type7 =" + return_type7DbString);
                        qry.Append(",");
                    }

                    if (cash_added1Changed)
                    {
                        qry.Append("cash_added1 =" + cash_added1DbString);
                        qry.Append(",");
                    }

                    if (cash_added2Changed)
                    {
                        qry.Append("cash_added2 =" + cash_added2DbString);
                        qry.Append(",");
                    }

                    if (cash_added3Changed)
                    {
                        qry.Append("cash_added3 =" + cash_added3DbString);
                        qry.Append(",");
                    }

                    if (cash_added4Changed)
                    {
                        qry.Append("cash_added4 =" + cash_added4DbString);
                        qry.Append(",");
                    }

                    if (cash_added5Changed)
                    {
                        qry.Append("cash_added5 =" + cash_added5DbString);
                        qry.Append(",");
                    }

                    if (cash_added6Changed)
                    {
                        qry.Append("cash_added6 =" + cash_added6DbString);
                        qry.Append(",");
                    }

                    if (cash_added7Changed)
                    {
                        qry.Append("cash_added7 =" + cash_added7DbString);
                        qry.Append(",");
                    }

                    if (generated_atChanged)
                    {
                        qry.Append("generated_at =" + generated_atDbString);
                        qry.Append(",");
                    }

                    if (opening_balanceChanged)
                    {
                        qry.Append("opening_balance =" + opening_balanceDbString);
                        qry.Append(",");
                    }

                    if (purged_return_type1Changed)
                    {
                        qry.Append("purged_return_type1 =" + purged_return_type1DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type2Changed)
                    {
                        qry.Append("purged_return_type2 =" + purged_return_type2DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type3Changed)
                    {
                        qry.Append("purged_return_type3 =" + purged_return_type3DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type4Changed)
                    {
                        qry.Append("purged_return_type4 =" + purged_return_type4DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type5Changed)
                    {
                        qry.Append("purged_return_type5 =" + purged_return_type5DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type6Changed)
                    {
                        qry.Append("purged_return_type6 =" + purged_return_type6DbString);
                        qry.Append(",");
                    }

                    if (purged_return_type7Changed)
                    {
                        qry.Append("purged_return_type7 =" + purged_return_type7DbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("summary_id = " + summary_idDbString);
                }

                cmd.CommandText = qry.ToString();
                bool closeConnection = false;
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                    closeConnection = true;
                }
                if (this.isNewEntity)
                {
                    cmd.ExecuteNonQuery();
                    isNewEntity = false;
                }
                else
                    cmd.ExecuteNonQuery();

                if (closeConnection)
                    cmd.Connection.Close();
            }
        }

        public void Delete()
        {
            Delete(ConnectionFactory.GetNewConnection(DatabaseName.Cash));
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Summary wheresummary_id= " + summary_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteSummarys(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Summary where " + where, DatabaseName.Cash);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            atm_id = 0,
            closing_balance = 1,
            withdrawals = 2,
            pre_withdrawals = 3,
            trxn_datetime = 4,
            return_amount = 5,
            replenishment_amount = 6,
            summary_id = 7,
            cash_remaining1 = 8,
            cash_remaining2 = 9,
            cash_remaining3 = 10,
            cash_remaining4 = 11,
            cash_remaining5 = 12,
            cash_remaining6 = 13,
            cash_remaining7 = 14,
            return_type1 = 15,
            return_type2 = 16,
            return_type3 = 17,
            return_type4 = 18,
            return_type5 = 19,
            return_type6 = 20,
            return_type7 = 21,
            cash_added1 = 22,
            cash_added2 = 23,
            cash_added3 = 24,
            cash_added4 = 25,
            cash_added5 = 26,
            cash_added6 = 27,
            cash_added7 = 28,
            generated_at = 29,
            opening_balance = 30,
            purged_return_type1 = 31,
            purged_return_type2 = 32,
            purged_return_type3 = 33,
            purged_return_type4 = 34,
            purged_return_type5 = 35,
            purged_return_type6 = 36,
            purged_return_type7 = 37
        }
        #endregion
        public DataTable BulkSave(List<Summary> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(ConnectionFactory.connectionStringCash);
            bulk.DestinationTableName = "Summary";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(Summary.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<Summary> transList, ref DataTable dt)
        {
            foreach (Summary tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["atm_id"] = tran.AtmId;
                Row["closing_balance"] = tran.ClosingBalance;
                Row["withdrawals"] = tran.Withdrawals;
                Row["pre_withdrawals"] = tran.PreWithdrawals;
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["return_amount"] = tran.ReturnAmount;
                Row["replenishment_amount"] = tran.ReplenishmentAmount;
                Row["summary_id"] = ConnectionFactory.GetNextId(DatabaseName.Cash);
                Row["cash_remaining1"] = tran.CashRemaining1;
                Row["cash_remaining2"] = tran.CashRemaining2;
                Row["cash_remaining3"] = tran.CashRemaining3;
                Row["cash_remaining4"] = tran.CashRemaining4;
                Row["cash_remaining5"] = tran.CashRemaining5;
                Row["cash_remaining6"] = tran.CashRemaining6;
                Row["cash_remaining7"] = tran.CashRemaining7;
                Row["return_type1"] = tran.ReturnType1;
                Row["return_type2"] = tran.ReturnType2;
                Row["return_type3"] = tran.ReturnType3;
                Row["return_type4"] = tran.ReturnType4;
                Row["return_type5"] = tran.ReturnType5;
                Row["return_type6"] = tran.ReturnType6;
                Row["return_type7"] = tran.ReturnType7;
                Row["cash_added1"] = tran.CashAdded1;
                Row["cash_added2"] = tran.CashAdded2;
                Row["cash_added3"] = tran.CashAdded3;
                Row["cash_added4"] = tran.CashAdded4;
                Row["cash_added5"] = tran.CashAdded5;
                Row["cash_added6"] = tran.CashAdded6;
                Row["cash_added7"] = tran.CashAdded7;
                Row["generated_at"] = tran.GeneratedAt;
                Row["opening_balance"] = tran.OpeningBalance;
                Row["purged_return_type1"] = tran.PurgedReturnType1;
                Row["purged_return_type2"] = tran.PurgedReturnType2;
                Row["purged_return_type3"] = tran.PurgedReturnType3;
                Row["purged_return_type4"] = tran.PurgedReturnType4;
                Row["purged_return_type5"] = tran.PurgedReturnType5;
                Row["purged_return_type6"] = tran.PurgedReturnType6;
                Row["purged_return_type7"] = tran.PurgedReturnType7;
                dt.Rows.Add(Row);
            }
        }
    }
}

 