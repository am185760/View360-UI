using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;

namespace Avanza.CCMS.DAL
{
    [Serializable()]
    public class EjParsedTransactions
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public EjParsedTransactions() { }
        public EjParsedTransactions(int ej_parsed_transactions_id, bool is_dispensed_from_recycler)
        {
            this.is_dispensed_from_recycler = is_dispensed_from_recycler;
            this.is_dispensed_from_recyclerChanged = true;
        }
        public EjParsedTransactions(string tsn, string pan, DateTime? trxn_datetime, decimal? amount, int? notes_dispensed_type1, int? notes_dispensed_type2, int? notes_dispensed_type3, int? notes_dispensed_type4, int? atm_id, int? task_id, int? mstate_id, int? comment_id, int? transaction_type_id, decimal? available_balance, DateTime? processing_datetime, int? start_index, int? end_index, int? status, decimal? donation_amount, decimal? transferred_amount, int? notes_remaining_type1, int? notes_remaining_type2, int? notes_remaining_type3, int? notes_remaining_type4, int? notes_dispensed_type5, int? notes_dispensed_type6, int? notes_dispensed_type7, DateTime? transaction_start_time, string transaction_end_time, string card_taken_time, string account_type, string result, string consumer_message_id, string dispute_status, string terminal_id, bool? is_disputed_transaction, DateTime? posting_date, string currency, bool? is_eligible, string network, int? notes_rejected_type1, int? notes_rejected_type2, int? notes_rejected_type3, int? notes_rejected_type4, string host_tsn, bool? is_cardless, int? notes_remaining_type5, int? notes_remaining_type6, int? notes_remaining_type7, int? notes_rejected_type5, int? notes_rejected_type6, int? notes_rejected_type7, string account_no, string bank_name, bool is_dispensed_from_recycler)
        {
            this.tsn = tsn;
            this.tsnChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.notes_dispensed_type1 = notes_dispensed_type1;
            this.notes_dispensed_type1Changed = true;
            this.notes_dispensed_type2 = notes_dispensed_type2;
            this.notes_dispensed_type2Changed = true;
            this.notes_dispensed_type3 = notes_dispensed_type3;
            this.notes_dispensed_type3Changed = true;
            this.notes_dispensed_type4 = notes_dispensed_type4;
            this.notes_dispensed_type4Changed = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.mstate_id = mstate_id;
            this.mstate_idChanged = true;
            this.comment_id = comment_id;
            this.comment_idChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.available_balance = available_balance;
            this.available_balanceChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.donation_amount = donation_amount;
            this.donation_amountChanged = true;
            this.transferred_amount = transferred_amount;
            this.transferred_amountChanged = true;
            this.notes_remaining_type1 = notes_remaining_type1;
            this.notes_remaining_type1Changed = true;
            this.notes_remaining_type2 = notes_remaining_type2;
            this.notes_remaining_type2Changed = true;
            this.notes_remaining_type3 = notes_remaining_type3;
            this.notes_remaining_type3Changed = true;
            this.notes_remaining_type4 = notes_remaining_type4;
            this.notes_remaining_type4Changed = true;
            this.notes_dispensed_type5 = notes_dispensed_type5;
            this.notes_dispensed_type5Changed = true;
            this.notes_dispensed_type6 = notes_dispensed_type6;
            this.notes_dispensed_type6Changed = true;
            this.notes_dispensed_type7 = notes_dispensed_type7;
            this.notes_dispensed_type7Changed = true;
            this.transaction_start_time = transaction_start_time;
            this.transaction_start_timeChanged = true;
            this.transaction_end_time = transaction_end_time;
            this.transaction_end_timeChanged = true;
            this.card_taken_time = card_taken_time;
            this.card_taken_timeChanged = true;
            this.account_type = account_type;
            this.account_typeChanged = true;
            this.result = result;
            this.resultChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.terminal_id = terminal_id;
            this.terminal_idChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.posting_date = posting_date;
            this.posting_dateChanged = true;
            this.currency = currency;
            this.currencyChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.network = network;
            this.networkChanged = true;
            this.notes_rejected_type1 = notes_rejected_type1;
            this.notes_rejected_type1Changed = true;
            this.notes_rejected_type2 = notes_rejected_type2;
            this.notes_rejected_type2Changed = true;
            this.notes_rejected_type3 = notes_rejected_type3;
            this.notes_rejected_type3Changed = true;
            this.notes_rejected_type4 = notes_rejected_type4;
            this.notes_rejected_type4Changed = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.notes_remaining_type5 = notes_remaining_type5;
            this.notes_remaining_type5Changed = true;
            this.notes_remaining_type6 = notes_remaining_type6;
            this.notes_remaining_type6Changed = true;
            this.notes_remaining_type7 = notes_remaining_type7;
            this.notes_remaining_type7Changed = true;
            this.notes_rejected_type5 = notes_rejected_type5;
            this.notes_rejected_type5Changed = true;
            this.notes_rejected_type6 = notes_rejected_type6;
            this.notes_rejected_type6Changed = true;
            this.notes_rejected_type7 = notes_rejected_type7;
            this.notes_rejected_type7Changed = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.is_dispensed_from_recycler = is_dispensed_from_recycler;
            this.is_dispensed_from_recyclerChanged = true;
        }
        private EjParsedTransactions(int ej_parsed_transactions_id, string tsn, string pan, DateTime? trxn_datetime, decimal? amount, int? notes_dispensed_type1, int? notes_dispensed_type2, int? notes_dispensed_type3, int? notes_dispensed_type4, int? atm_id, int? task_id, int? mstate_id, int? comment_id, int? transaction_type_id, decimal? available_balance, DateTime? processing_datetime, int? start_index, int? end_index, int? status, decimal? donation_amount, decimal? transferred_amount, int? notes_remaining_type1, int? notes_remaining_type2, int? notes_remaining_type3, int? notes_remaining_type4, int? notes_dispensed_type5, int? notes_dispensed_type6, int? notes_dispensed_type7, DateTime? transaction_start_time, string transaction_end_time, string card_taken_time, string account_type, string result, string consumer_message_id, string dispute_status, string terminal_id, bool? is_disputed_transaction, DateTime? posting_date, string currency, bool? is_eligible, string network, int? notes_rejected_type1, int? notes_rejected_type2, int? notes_rejected_type3, int? notes_rejected_type4, string host_tsn, bool? is_cardless, int? notes_remaining_type5, int? notes_remaining_type6, int? notes_remaining_type7, int? notes_rejected_type5, int? notes_rejected_type6, int? notes_rejected_type7, string account_no, string bank_name, bool is_dispensed_from_recycler)
        {
            this.ej_parsed_transactions_id = ej_parsed_transactions_id;
            this.ej_parsed_transactions_idChanged = true;
            this.tsn = tsn;
            this.tsnChanged = true;
            this.pan = pan;
            this.panChanged = true;
            this.trxn_datetime = trxn_datetime;
            this.trxn_datetimeChanged = true;
            this.amount = amount;
            this.amountChanged = true;
            this.notes_dispensed_type1 = notes_dispensed_type1;
            this.notes_dispensed_type1Changed = true;
            this.notes_dispensed_type2 = notes_dispensed_type2;
            this.notes_dispensed_type2Changed = true;
            this.notes_dispensed_type3 = notes_dispensed_type3;
            this.notes_dispensed_type3Changed = true;
            this.notes_dispensed_type4 = notes_dispensed_type4;
            this.notes_dispensed_type4Changed = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.mstate_id = mstate_id;
            this.mstate_idChanged = true;
            this.comment_id = comment_id;
            this.comment_idChanged = true;
            this.transaction_type_id = transaction_type_id;
            this.transaction_type_idChanged = true;
            this.available_balance = available_balance;
            this.available_balanceChanged = true;
            this.processing_datetime = processing_datetime;
            this.processing_datetimeChanged = true;
            this.start_index = start_index;
            this.start_indexChanged = true;
            this.end_index = end_index;
            this.end_indexChanged = true;
            this.status = status;
            this.statusChanged = true;
            this.donation_amount = donation_amount;
            this.donation_amountChanged = true;
            this.transferred_amount = transferred_amount;
            this.transferred_amountChanged = true;
            this.notes_remaining_type1 = notes_remaining_type1;
            this.notes_remaining_type1Changed = true;
            this.notes_remaining_type2 = notes_remaining_type2;
            this.notes_remaining_type2Changed = true;
            this.notes_remaining_type3 = notes_remaining_type3;
            this.notes_remaining_type3Changed = true;
            this.notes_remaining_type4 = notes_remaining_type4;
            this.notes_remaining_type4Changed = true;
            this.notes_dispensed_type5 = notes_dispensed_type5;
            this.notes_dispensed_type5Changed = true;
            this.notes_dispensed_type6 = notes_dispensed_type6;
            this.notes_dispensed_type6Changed = true;
            this.notes_dispensed_type7 = notes_dispensed_type7;
            this.notes_dispensed_type7Changed = true;
            this.transaction_start_time = transaction_start_time;
            this.transaction_start_timeChanged = true;
            this.transaction_end_time = transaction_end_time;
            this.transaction_end_timeChanged = true;
            this.card_taken_time = card_taken_time;
            this.card_taken_timeChanged = true;
            this.account_type = account_type;
            this.account_typeChanged = true;
            this.result = result;
            this.resultChanged = true;
            this.consumer_message_id = consumer_message_id;
            this.consumer_message_idChanged = true;
            this.dispute_status = dispute_status;
            this.dispute_statusChanged = true;
            this.terminal_id = terminal_id;
            this.terminal_idChanged = true;
            this.is_disputed_transaction = is_disputed_transaction;
            this.is_disputed_transactionChanged = true;
            this.posting_date = posting_date;
            this.posting_dateChanged = true;
            this.currency = currency;
            this.currencyChanged = true;
            this.is_eligible = is_eligible;
            this.is_eligibleChanged = true;
            this.network = network;
            this.networkChanged = true;
            this.notes_rejected_type1 = notes_rejected_type1;
            this.notes_rejected_type1Changed = true;
            this.notes_rejected_type2 = notes_rejected_type2;
            this.notes_rejected_type2Changed = true;
            this.notes_rejected_type3 = notes_rejected_type3;
            this.notes_rejected_type3Changed = true;
            this.notes_rejected_type4 = notes_rejected_type4;
            this.notes_rejected_type4Changed = true;
            this.host_tsn = host_tsn;
            this.host_tsnChanged = true;
            this.is_cardless = is_cardless;
            this.is_cardlessChanged = true;
            this.notes_remaining_type5 = notes_remaining_type5;
            this.notes_remaining_type5Changed = true;
            this.notes_remaining_type6 = notes_remaining_type6;
            this.notes_remaining_type6Changed = true;
            this.notes_remaining_type7 = notes_remaining_type7;
            this.notes_remaining_type7Changed = true;
            this.notes_rejected_type5 = notes_rejected_type5;
            this.notes_rejected_type5Changed = true;
            this.notes_rejected_type6 = notes_rejected_type6;
            this.notes_rejected_type6Changed = true;
            this.notes_rejected_type7 = notes_rejected_type7;
            this.notes_rejected_type7Changed = true;
            this.account_no = account_no;
            this.account_noChanged = true;
            this.bank_name = bank_name;
            this.bank_nameChanged = true;
            this.is_dispensed_from_recycler = is_dispensed_from_recycler;
            this.is_dispensed_from_recyclerChanged = true;
        }

        #region members and properties for columns

        #region EjParsedTransactionsId
        private bool ej_parsed_transactions_idChanged = false;
        private int ej_parsed_transactions_id;
        public int EjParsedTransactionsId
        {
            get { return ej_parsed_transactions_id; }
            set
            {
                ej_parsed_transactions_id = value;
                ej_parsed_transactions_idChanged = true;
            }
        }
        private string ej_parsed_transactions_idDbString
        {
            get
            {
                return ej_parsed_transactions_id.ToString();
            }
        }
        #endregion
        #region Tsn
        private bool tsnChanged = false;
        private string tsn;
        public string Tsn
        {
            get { return tsn; }
            set
            {
                tsn = value;
                tsnChanged = true;
            }
        }
        private string tsnDbString
        {
            get
            {
                if (this.tsn != null)
                    return string.Format("'{0}'", tsn);
                else
                    return "null";
            }
        }
        #endregion
        #region Pan
        private bool panChanged = false;
        private string pan;
        public string Pan
        {
            get { return pan; }
            set
            {
                pan = value;
                panChanged = true;
            }
        }
        private string panDbString
        {
            get
            {
                if (this.pan != null)
                    return string.Format("'{0}'", pan);
                else
                    return "null";
            }
        }
        #endregion
        #region TrxnDatetime
        private bool trxn_datetimeChanged = false;
        private DateTime? trxn_datetime;
        public DateTime? TrxnDatetime
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
                if (this.trxn_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", trxn_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Amount
        private bool amountChanged = false;
        private decimal? amount;
        public decimal? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                amountChanged = true;
            }
        }
        private string amountDbString
        {
            get
            {
                if (this.amount.HasValue)
                    return amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType1
        private bool notes_dispensed_type1Changed = false;
        private int? notes_dispensed_type1;
        public int? NotesDispensedType1
        {
            get { return notes_dispensed_type1; }
            set
            {
                notes_dispensed_type1 = value;
                notes_dispensed_type1Changed = true;
            }
        }
        private string notes_dispensed_type1DbString
        {
            get
            {
                if (this.notes_dispensed_type1.HasValue)
                    return notes_dispensed_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType2
        private bool notes_dispensed_type2Changed = false;
        private int? notes_dispensed_type2;
        public int? NotesDispensedType2
        {
            get { return notes_dispensed_type2; }
            set
            {
                notes_dispensed_type2 = value;
                notes_dispensed_type2Changed = true;
            }
        }
        private string notes_dispensed_type2DbString
        {
            get
            {
                if (this.notes_dispensed_type2.HasValue)
                    return notes_dispensed_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType3
        private bool notes_dispensed_type3Changed = false;
        private int? notes_dispensed_type3;
        public int? NotesDispensedType3
        {
            get { return notes_dispensed_type3; }
            set
            {
                notes_dispensed_type3 = value;
                notes_dispensed_type3Changed = true;
            }
        }
        private string notes_dispensed_type3DbString
        {
            get
            {
                if (this.notes_dispensed_type3.HasValue)
                    return notes_dispensed_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType4
        private bool notes_dispensed_type4Changed = false;
        private int? notes_dispensed_type4;
        public int? NotesDispensedType4
        {
            get { return notes_dispensed_type4; }
            set
            {
                notes_dispensed_type4 = value;
                notes_dispensed_type4Changed = true;
            }
        }
        private string notes_dispensed_type4DbString
        {
            get
            {
                if (this.notes_dispensed_type4.HasValue)
                    return notes_dispensed_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private int? atm_id;
        public int? AtmId
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
                if (this.atm_id.HasValue)
                    return atm_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TaskId
        private bool task_idChanged = false;
        private int? task_id;
        public int? TaskId
        {
            get { return task_id; }
            set
            {
                task_id = value;
                task_idChanged = true;
            }
        }
        private string task_idDbString
        {
            get
            {
                if (this.task_id.HasValue)
                    return task_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region MstateId
        private bool mstate_idChanged = false;
        private int? mstate_id;
        public int? MstateId
        {
            get { return mstate_id; }
            set
            {
                mstate_id = value;
                mstate_idChanged = true;
            }
        }
        private string mstate_idDbString
        {
            get
            {
                if (this.mstate_id.HasValue)
                    return mstate_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region CommentId
        private bool comment_idChanged = false;
        private int? comment_id;
        public int? CommentId
        {
            get { return comment_id; }
            set
            {
                comment_id = value;
                comment_idChanged = true;
            }
        }
        private string comment_idDbString
        {
            get
            {
                if (this.comment_id.HasValue)
                    return comment_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionTypeId
        private bool transaction_type_idChanged = false;
        private int? transaction_type_id;
        public int? TransactionTypeId
        {
            get { return transaction_type_id; }
            set
            {
                transaction_type_id = value;
                transaction_type_idChanged = true;
            }
        }
        private string transaction_type_idDbString
        {
            get
            {
                if (this.transaction_type_id.HasValue)
                    return transaction_type_id.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AvailableBalance
        private bool available_balanceChanged = false;
        private decimal? available_balance;
        public decimal? AvailableBalance
        {
            get { return available_balance; }
            set
            {
                available_balance = value;
                available_balanceChanged = true;
            }
        }
        private string available_balanceDbString
        {
            get
            {
                if (this.available_balance.HasValue)
                    return available_balance.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region ProcessingDatetime
        private bool processing_datetimeChanged = false;
        private DateTime? processing_datetime;
        public DateTime? ProcessingDatetime
        {
            get { return processing_datetime; }
            set
            {
                processing_datetime = value;
                processing_datetimeChanged = true;
            }
        }
        private string processing_datetimeDbString
        {
            get
            {
                if (this.processing_datetime.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", processing_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region StartIndex
        private bool start_indexChanged = false;
        private int? start_index;
        public int? StartIndex
        {
            get { return start_index; }
            set
            {
                start_index = value;
                start_indexChanged = true;
            }
        }
        private string start_indexDbString
        {
            get
            {
                if (this.start_index.HasValue)
                    return start_index.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region EndIndex
        private bool end_indexChanged = false;
        private int? end_index;
        public int? EndIndex
        {
            get { return end_index; }
            set
            {
                end_index = value;
                end_indexChanged = true;
            }
        }
        private string end_indexDbString
        {
            get
            {
                if (this.end_index.HasValue)
                    return end_index.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Status
        private bool statusChanged = false;
        private int? status;
        public int? Status
        {
            get { return status; }
            set
            {
                status = value;
                statusChanged = true;
            }
        }
        private string statusDbString
        {
            get
            {
                if (this.status.HasValue)
                    return status.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region DonationAmount
        private bool donation_amountChanged = false;
        private decimal? donation_amount;
        public decimal? DonationAmount
        {
            get { return donation_amount; }
            set
            {
                donation_amount = value;
                donation_amountChanged = true;
            }
        }
        private string donation_amountDbString
        {
            get
            {
                if (this.donation_amount.HasValue)
                    return donation_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TransferredAmount
        private bool transferred_amountChanged = false;
        private decimal? transferred_amount;
        public decimal? TransferredAmount
        {
            get { return transferred_amount; }
            set
            {
                transferred_amount = value;
                transferred_amountChanged = true;
            }
        }
        private string transferred_amountDbString
        {
            get
            {
                if (this.transferred_amount.HasValue)
                    return transferred_amount.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType1
        private bool notes_remaining_type1Changed = false;
        private int? notes_remaining_type1;
        public int? NotesRemainingType1
        {
            get { return notes_remaining_type1; }
            set
            {
                notes_remaining_type1 = value;
                notes_remaining_type1Changed = true;
            }
        }
        private string notes_remaining_type1DbString
        {
            get
            {
                if (this.notes_remaining_type1.HasValue)
                    return notes_remaining_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType2
        private bool notes_remaining_type2Changed = false;
        private int? notes_remaining_type2;
        public int? NotesRemainingType2
        {
            get { return notes_remaining_type2; }
            set
            {
                notes_remaining_type2 = value;
                notes_remaining_type2Changed = true;
            }
        }
        private string notes_remaining_type2DbString
        {
            get
            {
                if (this.notes_remaining_type2.HasValue)
                    return notes_remaining_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType3
        private bool notes_remaining_type3Changed = false;
        private int? notes_remaining_type3;
        public int? NotesRemainingType3
        {
            get { return notes_remaining_type3; }
            set
            {
                notes_remaining_type3 = value;
                notes_remaining_type3Changed = true;
            }
        }
        private string notes_remaining_type3DbString
        {
            get
            {
                if (this.notes_remaining_type3.HasValue)
                    return notes_remaining_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType4
        private bool notes_remaining_type4Changed = false;
        private int? notes_remaining_type4;
        public int? NotesRemainingType4
        {
            get { return notes_remaining_type4; }
            set
            {
                notes_remaining_type4 = value;
                notes_remaining_type4Changed = true;
            }
        }
        private string notes_remaining_type4DbString
        {
            get
            {
                if (this.notes_remaining_type4.HasValue)
                    return notes_remaining_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType5
        private bool notes_dispensed_type5Changed = false;
        private int? notes_dispensed_type5;
        public int? NotesDispensedType5
        {
            get { return notes_dispensed_type5; }
            set
            {
                notes_dispensed_type5 = value;
                notes_dispensed_type5Changed = true;
            }
        }
        private string notes_dispensed_type5DbString
        {
            get
            {
                if (this.notes_dispensed_type5.HasValue)
                    return notes_dispensed_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType6
        private bool notes_dispensed_type6Changed = false;
        private int? notes_dispensed_type6;
        public int? NotesDispensedType6
        {
            get { return notes_dispensed_type6; }
            set
            {
                notes_dispensed_type6 = value;
                notes_dispensed_type6Changed = true;
            }
        }
        private string notes_dispensed_type6DbString
        {
            get
            {
                if (this.notes_dispensed_type6.HasValue)
                    return notes_dispensed_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesDispensedType7
        private bool notes_dispensed_type7Changed = false;
        private int? notes_dispensed_type7;
        public int? NotesDispensedType7
        {
            get { return notes_dispensed_type7; }
            set
            {
                notes_dispensed_type7 = value;
                notes_dispensed_type7Changed = true;
            }
        }
        private string notes_dispensed_type7DbString
        {
            get
            {
                if (this.notes_dispensed_type7.HasValue)
                    return notes_dispensed_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionStartTime
        private bool transaction_start_timeChanged = false;
        private DateTime? transaction_start_time;
        public DateTime? TransactionStartTime
        {
            get { return transaction_start_time; }
            set
            {
                transaction_start_time = value;
                transaction_start_timeChanged = true;
            }
        }
        private string transaction_start_timeDbString
        {
            get
            {
                if (this.transaction_start_time.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", transaction_start_time.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region TransactionEndTime
        private bool transaction_end_timeChanged = false;
        private string transaction_end_time;
        public string TransactionEndTime
        {
            get { return transaction_end_time; }
            set
            {
                transaction_end_time = value;
                transaction_end_timeChanged = true;
            }
        }
        private string transaction_end_timeDbString
        {
            get
            {
                if (this.transaction_end_time != null)
                    return string.Format("'{0}'", transaction_end_time);
                else
                    return "null";
            }
        }
        #endregion
        #region CardTakenTime
        private bool card_taken_timeChanged = false;
        private string card_taken_time;
        public string CardTakenTime
        {
            get { return card_taken_time; }
            set
            {
                card_taken_time = value;
                card_taken_timeChanged = true;
            }
        }
        private string card_taken_timeDbString
        {
            get
            {
                if (this.card_taken_time != null)
                    return string.Format("'{0}'", card_taken_time);
                else
                    return "null";
            }
        }
        #endregion
        #region AccountType
        private bool account_typeChanged = false;
        private string account_type;
        public string AccountType
        {
            get { return account_type; }
            set
            {
                account_type = value;
                account_typeChanged = true;
            }
        }
        private string account_typeDbString
        {
            get
            {
                if (this.account_type != null)
                    return string.Format("'{0}'", account_type);
                else
                    return "null";
            }
        }
        #endregion
        #region Result
        private bool resultChanged = false;
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                resultChanged = true;
            }
        }
        private string resultDbString
        {
            get
            {
                if (this.result != null)
                    return string.Format("'{0}'", result);
                else
                    return "null";
            }
        }
        #endregion
        #region ConsumerMessageId
        private bool consumer_message_idChanged = false;
        private string consumer_message_id;
        public string ConsumerMessageId
        {
            get { return consumer_message_id; }
            set
            {
                consumer_message_id = value;
                consumer_message_idChanged = true;
            }
        }
        private string consumer_message_idDbString
        {
            get
            {
                if (this.consumer_message_id != null)
                    return string.Format("'{0}'", consumer_message_id);
                else
                    return "null";
            }
        }
        #endregion
        #region DisputeStatus
        private bool dispute_statusChanged = false;
        private string dispute_status;
        public string DisputeStatus
        {
            get { return dispute_status; }
            set
            {
                dispute_status = value;
                dispute_statusChanged = true;
            }
        }
        private string dispute_statusDbString
        {
            get
            {
                if (this.dispute_status != null)
                    return string.Format("'{0}'", dispute_status);
                else
                    return "null";
            }
        }
        #endregion
        #region TerminalId
        private bool terminal_idChanged = false;
        private string terminal_id;
        public string TerminalId
        {
            get { return terminal_id; }
            set
            {
                terminal_id = value;
                terminal_idChanged = true;
            }
        }
        private string terminal_idDbString
        {
            get
            {
                if (this.terminal_id != null)
                    return string.Format("'{0}'", terminal_id);
                else
                    return "null";
            }
        }
        #endregion
        #region IsDisputedTransaction
        private bool is_disputed_transactionChanged = false;
        private bool? is_disputed_transaction;
        public bool? IsDisputedTransaction
        {
            get { return is_disputed_transaction; }
            set
            {
                is_disputed_transaction = value;
                is_disputed_transactionChanged = true;
            }
        }
        private string is_disputed_transactionDbString
        {
            get
            {
                if (this.is_disputed_transaction.HasValue)
                    return is_disputed_transaction.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region PostingDate
        private bool posting_dateChanged = false;
        private DateTime? posting_date;
        public DateTime? PostingDate
        {
            get { return posting_date; }
            set
            {
                posting_date = value;
                posting_dateChanged = true;
            }
        }
        private string posting_dateDbString
        {
            get
            {
                if (this.posting_date.HasValue)
                    return string.Format("Convert(datetime,'{0}',121)", posting_date.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                else
                    return "null";
            }
        }
        #endregion
        #region Currency
        private bool currencyChanged = false;
        private string currency;
        public string Currency
        {
            get { return currency; }
            set
            {
                currency = value;
                currencyChanged = true;
            }
        }
        private string currencyDbString
        {
            get
            {
                if (this.currency != null)
                    return string.Format("'{0}'", currency);
                else
                    return "null";
            }
        }
        #endregion
        #region IsEligible
        private bool is_eligibleChanged = false;
        private bool? is_eligible;
        public bool? IsEligible
        {
            get { return is_eligible; }
            set
            {
                is_eligible = value;
                is_eligibleChanged = true;
            }
        }
        private string is_eligibleDbString
        {
            get
            {
                if (this.is_eligible.HasValue)
                    return is_eligible.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region Network
        private bool networkChanged = false;
        private string network;
        public string Network
        {
            get { return network; }
            set
            {
                network = value;
                networkChanged = true;
            }
        }
        private string networkDbString
        {
            get
            {
                if (this.network != null)
                    return string.Format("'{0}'", network);
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType1
        private bool notes_rejected_type1Changed = false;
        private int? notes_rejected_type1;
        public int? NotesRejectedType1
        {
            get { return notes_rejected_type1; }
            set
            {
                notes_rejected_type1 = value;
                notes_rejected_type1Changed = true;
            }
        }
        private string notes_rejected_type1DbString
        {
            get
            {
                if (this.notes_rejected_type1.HasValue)
                    return notes_rejected_type1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType2
        private bool notes_rejected_type2Changed = false;
        private int? notes_rejected_type2;
        public int? NotesRejectedType2
        {
            get { return notes_rejected_type2; }
            set
            {
                notes_rejected_type2 = value;
                notes_rejected_type2Changed = true;
            }
        }
        private string notes_rejected_type2DbString
        {
            get
            {
                if (this.notes_rejected_type2.HasValue)
                    return notes_rejected_type2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType3
        private bool notes_rejected_type3Changed = false;
        private int? notes_rejected_type3;
        public int? NotesRejectedType3
        {
            get { return notes_rejected_type3; }
            set
            {
                notes_rejected_type3 = value;
                notes_rejected_type3Changed = true;
            }
        }
        private string notes_rejected_type3DbString
        {
            get
            {
                if (this.notes_rejected_type3.HasValue)
                    return notes_rejected_type3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType4
        private bool notes_rejected_type4Changed = false;
        private int? notes_rejected_type4;
        public int? NotesRejectedType4
        {
            get { return notes_rejected_type4; }
            set
            {
                notes_rejected_type4 = value;
                notes_rejected_type4Changed = true;
            }
        }
        private string notes_rejected_type4DbString
        {
            get
            {
                if (this.notes_rejected_type4.HasValue)
                    return notes_rejected_type4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region HostTsn
        private bool host_tsnChanged = false;
        private string host_tsn;
        public string HostTsn
        {
            get { return host_tsn; }
            set
            {
                host_tsn = value;
                host_tsnChanged = true;
            }
        }
        private string host_tsnDbString
        {
            get
            {
                if (this.host_tsn != null)
                    return string.Format("'{0}'", host_tsn);
                else
                    return "null";
            }
        }
        #endregion
        #region IsCardless
        private bool is_cardlessChanged = false;
        private bool? is_cardless;
        public bool? IsCardless
        {
            get { return is_cardless; }
            set
            {
                is_cardless = value;
                is_cardlessChanged = true;
            }
        }
        private string is_cardlessDbString
        {
            get
            {
                if (this.is_cardless.HasValue)
                    return is_cardless.Value ? "1" : "0";
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType5
        private bool notes_remaining_type5Changed = false;
        private int? notes_remaining_type5;
        public int? NotesRemainingType5
        {
            get { return notes_remaining_type5; }
            set
            {
                notes_remaining_type5 = value;
                notes_remaining_type5Changed = true;
            }
        }
        private string notes_remaining_type5DbString
        {
            get
            {
                if (this.notes_remaining_type5.HasValue)
                    return notes_remaining_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType6
        private bool notes_remaining_type6Changed = false;
        private int? notes_remaining_type6;
        public int? NotesRemainingType6
        {
            get { return notes_remaining_type6; }
            set
            {
                notes_remaining_type6 = value;
                notes_remaining_type6Changed = true;
            }
        }
        private string notes_remaining_type6DbString
        {
            get
            {
                if (this.notes_remaining_type6.HasValue)
                    return notes_remaining_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRemainingType7
        private bool notes_remaining_type7Changed = false;
        private int? notes_remaining_type7;
        public int? NotesRemainingType7
        {
            get { return notes_remaining_type7; }
            set
            {
                notes_remaining_type7 = value;
                notes_remaining_type7Changed = true;
            }
        }
        private string notes_remaining_type7DbString
        {
            get
            {
                if (this.notes_remaining_type7.HasValue)
                    return notes_remaining_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType5
        private bool notes_rejected_type5Changed = false;
        private int? notes_rejected_type5;
        public int? NotesRejectedType5
        {
            get { return notes_rejected_type5; }
            set
            {
                notes_rejected_type5 = value;
                notes_rejected_type5Changed = true;
            }
        }
        private string notes_rejected_type5DbString
        {
            get
            {
                if (this.notes_rejected_type5.HasValue)
                    return notes_rejected_type5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType6
        private bool notes_rejected_type6Changed = false;
        private int? notes_rejected_type6;
        public int? NotesRejectedType6
        {
            get { return notes_rejected_type6; }
            set
            {
                notes_rejected_type6 = value;
                notes_rejected_type6Changed = true;
            }
        }
        private string notes_rejected_type6DbString
        {
            get
            {
                if (this.notes_rejected_type6.HasValue)
                    return notes_rejected_type6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region NotesRejectedType7
        private bool notes_rejected_type7Changed = false;
        private int? notes_rejected_type7;
        public int? NotesRejectedType7
        {
            get { return notes_rejected_type7; }
            set
            {
                notes_rejected_type7 = value;
                notes_rejected_type7Changed = true;
            }
        }
        private string notes_rejected_type7DbString
        {
            get
            {
                if (this.notes_rejected_type7.HasValue)
                    return notes_rejected_type7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region AccountNo
        private bool account_noChanged = false;
        private string account_no;
        public string AccountNo
        {
            get { return account_no; }
            set
            {
                account_no = value;
                account_noChanged = true;
            }
        }
        private string account_noDbString
        {
            get
            {
                if (this.account_no != null)
                    return string.Format("'{0}'", account_no);
                else
                    return "null";
            }
        }
        #endregion
        #region BankName
        private bool bank_nameChanged = false;
        private string bank_name;
        public string BankName
        {
            get { return bank_name; }
            set
            {
                bank_name = value;
                bank_nameChanged = true;
            }
        }
        private string bank_nameDbString
        {
            get
            {
                if (this.bank_name != null)
                    return string.Format("'{0}'", bank_name);
                else
                    return "null";
            }
        }
        #endregion
        #region IsDispensedFromRecycler
        private bool is_dispensed_from_recyclerChanged = false;
        private bool is_dispensed_from_recycler;
        public bool IsDispensedFromRecycler
        {
            get { return is_dispensed_from_recycler; }
            set
            {
                is_dispensed_from_recycler = value;
                is_dispensed_from_recyclerChanged = true;
            }
        }
        private string is_dispensed_from_recyclerDbString
        {
            get
            {
                return is_dispensed_from_recycler ? "1" : "0";
            }
        }
        #endregion
        #endregion

        #region EjParsedTransactionsReader
        public class EjParsedTransactionsReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            EjParsedTransactions currentEjParsedTransactions;
            Columns columns;
            bool partialRead = false;
            private EjParsedTransactionsReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public EjParsedTransactionsReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public EjParsedTransactionsReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentEjParsedTransactions; }

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
                    currentEjParsedTransactions = new EjParsedTransactions();
                    if (partialRead)
                    {
                        if ((columns & Columns.ej_parsed_transactions_id) == Columns.ej_parsed_transactions_id && reader["ej_parsed_transactions_id"] != DBNull.Value)
                            currentEjParsedTransactions.ej_parsed_transactions_id = (int)reader["ej_parsed_transactions_id"];
                        if ((columns & Columns.tsn) == Columns.tsn && reader["tsn"] != DBNull.Value)
                            currentEjParsedTransactions.tsn = (string)reader["tsn"];
                        if ((columns & Columns.pan) == Columns.pan && reader["pan"] != DBNull.Value)
                            currentEjParsedTransactions.pan = (string)reader["pan"];
                        if ((columns & Columns.trxn_datetime) == Columns.trxn_datetime && reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedTransactions.trxn_datetime = (DateTime?)reader["trxn_datetime"];
                        if ((columns & Columns.amount) == Columns.amount && reader["amount"] != DBNull.Value)
                            currentEjParsedTransactions.amount = (decimal?)reader["amount"];
                        if ((columns & Columns.notes_dispensed_type1) == Columns.notes_dispensed_type1 && reader["notes_dispensed_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type1 = (int?)reader["notes_dispensed_type1"];
                        if ((columns & Columns.notes_dispensed_type2) == Columns.notes_dispensed_type2 && reader["notes_dispensed_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type2 = (int?)reader["notes_dispensed_type2"];
                        if ((columns & Columns.notes_dispensed_type3) == Columns.notes_dispensed_type3 && reader["notes_dispensed_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type3 = (int?)reader["notes_dispensed_type3"];
                        if ((columns & Columns.notes_dispensed_type4) == Columns.notes_dispensed_type4 && reader["notes_dispensed_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type4 = (int?)reader["notes_dispensed_type4"];
                        if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"] != DBNull.Value)
                            currentEjParsedTransactions.atm_id = (int?)reader["atm_id"];
                        if ((columns & Columns.task_id) == Columns.task_id && reader["task_id"] != DBNull.Value)
                            currentEjParsedTransactions.task_id = (int?)reader["task_id"];
                        if ((columns & Columns.mstate_id) == Columns.mstate_id && reader["mstate_id"] != DBNull.Value)
                            currentEjParsedTransactions.mstate_id = (int?)reader["mstate_id"];
                        if ((columns & Columns.comment_id) == Columns.comment_id && reader["comment_id"] != DBNull.Value)
                            currentEjParsedTransactions.comment_id = (int?)reader["comment_id"];
                        if ((columns & Columns.transaction_type_id) == Columns.transaction_type_id && reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_type_id = (int?)reader["transaction_type_id"];
                        if ((columns & Columns.available_balance) == Columns.available_balance && reader["available_balance"] != DBNull.Value)
                            currentEjParsedTransactions.available_balance = (decimal?)reader["available_balance"];
                        if ((columns & Columns.processing_datetime) == Columns.processing_datetime && reader["processing_datetime"] != DBNull.Value)
                            currentEjParsedTransactions.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if ((columns & Columns.start_index) == Columns.start_index && reader["start_index"] != DBNull.Value)
                            currentEjParsedTransactions.start_index = (int?)reader["start_index"];
                        if ((columns & Columns.end_index) == Columns.end_index && reader["end_index"] != DBNull.Value)
                            currentEjParsedTransactions.end_index = (int?)reader["end_index"];
                        if ((columns & Columns.status) == Columns.status && reader["status"] != DBNull.Value)
                            currentEjParsedTransactions.status = (int?)reader["status"];
                        if ((columns & Columns.donation_amount) == Columns.donation_amount && reader["donation_amount"] != DBNull.Value)
                            currentEjParsedTransactions.donation_amount = (decimal?)reader["donation_amount"];
                        if ((columns & Columns.transferred_amount) == Columns.transferred_amount && reader["transferred_amount"] != DBNull.Value)
                            currentEjParsedTransactions.transferred_amount = (decimal?)reader["transferred_amount"];
                        if ((columns & Columns.notes_remaining_type1) == Columns.notes_remaining_type1 && reader["notes_remaining_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type1 = (int?)reader["notes_remaining_type1"];
                        if ((columns & Columns.notes_remaining_type2) == Columns.notes_remaining_type2 && reader["notes_remaining_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type2 = (int?)reader["notes_remaining_type2"];
                        if ((columns & Columns.notes_remaining_type3) == Columns.notes_remaining_type3 && reader["notes_remaining_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type3 = (int?)reader["notes_remaining_type3"];
                        if ((columns & Columns.notes_remaining_type4) == Columns.notes_remaining_type4 && reader["notes_remaining_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type4 = (int?)reader["notes_remaining_type4"];
                        if ((columns & Columns.notes_dispensed_type5) == Columns.notes_dispensed_type5 && reader["notes_dispensed_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type5 = (int?)reader["notes_dispensed_type5"];
                        if ((columns & Columns.notes_dispensed_type6) == Columns.notes_dispensed_type6 && reader["notes_dispensed_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type6 = (int?)reader["notes_dispensed_type6"];
                        if ((columns & Columns.notes_dispensed_type7) == Columns.notes_dispensed_type7 && reader["notes_dispensed_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type7 = (int?)reader["notes_dispensed_type7"];
                        if ((columns & Columns.transaction_start_time) == Columns.transaction_start_time && reader["transaction_start_time"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_start_time = (DateTime?)reader["transaction_start_time"];
                        if ((columns & Columns.transaction_end_time) == Columns.transaction_end_time && reader["transaction_end_time"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_end_time = (string)reader["transaction_end_time"];
                        if ((columns & Columns.card_taken_time) == Columns.card_taken_time && reader["card_taken_time"] != DBNull.Value)
                            currentEjParsedTransactions.card_taken_time = (string)reader["card_taken_time"];
                        if ((columns & Columns.account_type) == Columns.account_type && reader["account_type"] != DBNull.Value)
                            currentEjParsedTransactions.account_type = (string)reader["account_type"];
                        if ((columns & Columns.result) == Columns.result && reader["result"] != DBNull.Value)
                            currentEjParsedTransactions.result = (string)reader["result"];
                        if ((columns & Columns.consumer_message_id) == Columns.consumer_message_id && reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedTransactions.consumer_message_id = (string)reader["consumer_message_id"];
                        if ((columns & Columns.dispute_status) == Columns.dispute_status && reader["dispute_status"] != DBNull.Value)
                            currentEjParsedTransactions.dispute_status = (string)reader["dispute_status"];
                        if ((columns & Columns.terminal_id) == Columns.terminal_id && reader["terminal_id"] != DBNull.Value)
                            currentEjParsedTransactions.terminal_id = (string)reader["terminal_id"];
                        if ((columns & Columns.is_disputed_transaction) == Columns.is_disputed_transaction && reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedTransactions.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if ((columns & Columns.posting_date) == Columns.posting_date && reader["posting_date"] != DBNull.Value)
                            currentEjParsedTransactions.posting_date = (DateTime?)reader["posting_date"];
                        if ((columns & Columns.currency) == Columns.currency && reader["currency"] != DBNull.Value)
                            currentEjParsedTransactions.currency = (string)reader["currency"];
                        if ((columns & Columns.is_eligible) == Columns.is_eligible && reader["is_eligible"] != DBNull.Value)
                            currentEjParsedTransactions.is_eligible = (bool?)reader["is_eligible"];
                        if ((columns & Columns.network) == Columns.network && reader["network"] != DBNull.Value)
                            currentEjParsedTransactions.network = (string)reader["network"];
                        if ((columns & Columns.notes_rejected_type1) == Columns.notes_rejected_type1 && reader["notes_rejected_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type1 = (int?)reader["notes_rejected_type1"];
                        if ((columns & Columns.notes_rejected_type2) == Columns.notes_rejected_type2 && reader["notes_rejected_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type2 = (int?)reader["notes_rejected_type2"];
                        if ((columns & Columns.notes_rejected_type3) == Columns.notes_rejected_type3 && reader["notes_rejected_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type3 = (int?)reader["notes_rejected_type3"];
                        if ((columns & Columns.notes_rejected_type4) == Columns.notes_rejected_type4 && reader["notes_rejected_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type4 = (int?)reader["notes_rejected_type4"];
                        if ((columns & Columns.host_tsn) == Columns.host_tsn && reader["host_tsn"] != DBNull.Value)
                            currentEjParsedTransactions.host_tsn = (string)reader["host_tsn"];
                        if ((columns & Columns.is_cardless) == Columns.is_cardless && reader["is_cardless"] != DBNull.Value)
                            currentEjParsedTransactions.is_cardless = (bool?)reader["is_cardless"];
                        if ((columns & Columns.notes_remaining_type5) == Columns.notes_remaining_type5 && reader["notes_remaining_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type5 = (int?)reader["notes_remaining_type5"];
                        if ((columns & Columns.notes_remaining_type6) == Columns.notes_remaining_type6 && reader["notes_remaining_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type6 = (int?)reader["notes_remaining_type6"];
                        if ((columns & Columns.notes_remaining_type7) == Columns.notes_remaining_type7 && reader["notes_remaining_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type7 = (int?)reader["notes_remaining_type7"];
                        if ((columns & Columns.notes_rejected_type5) == Columns.notes_rejected_type5 && reader["notes_rejected_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type5 = (int?)reader["notes_rejected_type5"];
                        if ((columns & Columns.notes_rejected_type6) == Columns.notes_rejected_type6 && reader["notes_rejected_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type6 = (int?)reader["notes_rejected_type6"];
                        if ((columns & Columns.notes_rejected_type7) == Columns.notes_rejected_type7 && reader["notes_rejected_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type7 = (int?)reader["notes_rejected_type7"];
                        if ((columns & Columns.account_no) == Columns.account_no && reader["account_no"] != DBNull.Value)
                            currentEjParsedTransactions.account_no = (string)reader["account_no"];
                        if ((columns & Columns.bank_name) == Columns.bank_name && reader["bank_name"] != DBNull.Value)
                            currentEjParsedTransactions.bank_name = (string)reader["bank_name"];
                        if ((columns & Columns.is_dispensed_from_recycler) == Columns.is_dispensed_from_recycler && reader["is_dispensed_from_recycler"] != DBNull.Value)
                            currentEjParsedTransactions.is_dispensed_from_recycler = (bool)reader["is_dispensed_from_recycler"];

                    }
                    else
                    {
                        if (reader["ej_parsed_transactions_id"] != DBNull.Value)
                            currentEjParsedTransactions.ej_parsed_transactions_id = (int)reader["ej_parsed_transactions_id"];
                        if (reader["tsn"] != DBNull.Value)
                            currentEjParsedTransactions.tsn = (string)reader["tsn"];
                        if (reader["pan"] != DBNull.Value)
                            currentEjParsedTransactions.pan = (string)reader["pan"];
                        if (reader["trxn_datetime"] != DBNull.Value)
                            currentEjParsedTransactions.trxn_datetime = (DateTime?)reader["trxn_datetime"];
                        if (reader["amount"] != DBNull.Value)
                            currentEjParsedTransactions.amount = (decimal?)reader["amount"];
                        if (reader["notes_dispensed_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type1 = (int?)reader["notes_dispensed_type1"];
                        if (reader["notes_dispensed_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type2 = (int?)reader["notes_dispensed_type2"];
                        if (reader["notes_dispensed_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type3 = (int?)reader["notes_dispensed_type3"];
                        if (reader["notes_dispensed_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type4 = (int?)reader["notes_dispensed_type4"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentEjParsedTransactions.atm_id = (int?)reader["atm_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentEjParsedTransactions.task_id = (int?)reader["task_id"];
                        if (reader["mstate_id"] != DBNull.Value)
                            currentEjParsedTransactions.mstate_id = (int?)reader["mstate_id"];
                        if (reader["comment_id"] != DBNull.Value)
                            currentEjParsedTransactions.comment_id = (int?)reader["comment_id"];
                        if (reader["transaction_type_id"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_type_id = (int?)reader["transaction_type_id"];
                        if (reader["available_balance"] != DBNull.Value)
                            currentEjParsedTransactions.available_balance = (decimal?)reader["available_balance"];
                        if (reader["processing_datetime"] != DBNull.Value)
                            currentEjParsedTransactions.processing_datetime = (DateTime?)reader["processing_datetime"];
                        if (reader["start_index"] != DBNull.Value)
                            currentEjParsedTransactions.start_index = (int?)reader["start_index"];
                        if (reader["end_index"] != DBNull.Value)
                            currentEjParsedTransactions.end_index = (int?)reader["end_index"];
                        if (reader["status"] != DBNull.Value)
                            currentEjParsedTransactions.status = (int?)reader["status"];
                        if (reader["donation_amount"] != DBNull.Value)
                            currentEjParsedTransactions.donation_amount = (decimal?)reader["donation_amount"];
                        if (reader["transferred_amount"] != DBNull.Value)
                            currentEjParsedTransactions.transferred_amount = (decimal?)reader["transferred_amount"];
                        if (reader["notes_remaining_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type1 = (int?)reader["notes_remaining_type1"];
                        if (reader["notes_remaining_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type2 = (int?)reader["notes_remaining_type2"];
                        if (reader["notes_remaining_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type3 = (int?)reader["notes_remaining_type3"];
                        if (reader["notes_remaining_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type4 = (int?)reader["notes_remaining_type4"];
                        if (reader["notes_dispensed_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type5 = (int?)reader["notes_dispensed_type5"];
                        if (reader["notes_dispensed_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type6 = (int?)reader["notes_dispensed_type6"];
                        if (reader["notes_dispensed_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_dispensed_type7 = (int?)reader["notes_dispensed_type7"];
                        if (reader["transaction_start_time"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_start_time = (DateTime?)reader["transaction_start_time"];
                        if (reader["transaction_end_time"] != DBNull.Value)
                            currentEjParsedTransactions.transaction_end_time = (string)reader["transaction_end_time"];
                        if (reader["card_taken_time"] != DBNull.Value)
                            currentEjParsedTransactions.card_taken_time = (string)reader["card_taken_time"];
                        if (reader["account_type"] != DBNull.Value)
                            currentEjParsedTransactions.account_type = (string)reader["account_type"];
                        if (reader["result"] != DBNull.Value)
                            currentEjParsedTransactions.result = (string)reader["result"];
                        if (reader["consumer_message_id"] != DBNull.Value)
                            currentEjParsedTransactions.consumer_message_id = (string)reader["consumer_message_id"];
                        if (reader["dispute_status"] != DBNull.Value)
                            currentEjParsedTransactions.dispute_status = (string)reader["dispute_status"];
                        if (reader["terminal_id"] != DBNull.Value)
                            currentEjParsedTransactions.terminal_id = (string)reader["terminal_id"];
                        if (reader["is_disputed_transaction"] != DBNull.Value)
                            currentEjParsedTransactions.is_disputed_transaction = (bool?)reader["is_disputed_transaction"];
                        if (reader["posting_date"] != DBNull.Value)
                            currentEjParsedTransactions.posting_date = (DateTime?)reader["posting_date"];
                        if (reader["currency"] != DBNull.Value)
                            currentEjParsedTransactions.currency = (string)reader["currency"];
                        if (reader["is_eligible"] != DBNull.Value)
                            currentEjParsedTransactions.is_eligible = (bool?)reader["is_eligible"];
                        if (reader["network"] != DBNull.Value)
                            currentEjParsedTransactions.network = (string)reader["network"];
                        if (reader["notes_rejected_type1"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type1 = (int?)reader["notes_rejected_type1"];
                        if (reader["notes_rejected_type2"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type2 = (int?)reader["notes_rejected_type2"];
                        if (reader["notes_rejected_type3"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type3 = (int?)reader["notes_rejected_type3"];
                        if (reader["notes_rejected_type4"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type4 = (int?)reader["notes_rejected_type4"];
                        if (reader["host_tsn"] != DBNull.Value)
                            currentEjParsedTransactions.host_tsn = (string)reader["host_tsn"];
                        if (reader["is_cardless"] != DBNull.Value)
                            currentEjParsedTransactions.is_cardless = (bool?)reader["is_cardless"];
                        if (reader["notes_remaining_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type5 = (int?)reader["notes_remaining_type5"];
                        if (reader["notes_remaining_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type6 = (int?)reader["notes_remaining_type6"];
                        if (reader["notes_remaining_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_remaining_type7 = (int?)reader["notes_remaining_type7"];
                        if (reader["notes_rejected_type5"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type5 = (int?)reader["notes_rejected_type5"];
                        if (reader["notes_rejected_type6"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type6 = (int?)reader["notes_rejected_type6"];
                        if (reader["notes_rejected_type7"] != DBNull.Value)
                            currentEjParsedTransactions.notes_rejected_type7 = (int?)reader["notes_rejected_type7"];
                        if (reader["account_no"] != DBNull.Value)
                            currentEjParsedTransactions.account_no = (string)reader["account_no"];
                        if (reader["bank_name"] != DBNull.Value)
                            currentEjParsedTransactions.bank_name = (string)reader["bank_name"];
                        if (reader["is_dispensed_from_recycler"] != DBNull.Value)
                            currentEjParsedTransactions.is_dispensed_from_recycler = (bool)reader["is_dispensed_from_recycler"];
                    }

                    currentEjParsedTransactions.isNewEntity = false;
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

            public EjParsedTransactions CurrentEjParsedTransactions
            {
                get { return currentEjParsedTransactions; }
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


        #region EjParsedTransactions functions

        public static EjParsedTransactionsReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.ej_parsed_transactions_id == (Columns.ej_parsed_transactions_id & columns))
                qry.Append("ej_parsed_transactions_id,");
            if (Columns.tsn == (Columns.tsn & columns))
                qry.Append("tsn,");
            if (Columns.pan == (Columns.pan & columns))
                qry.Append("pan,");
            if (Columns.trxn_datetime == (Columns.trxn_datetime & columns))
                qry.Append("trxn_datetime,");
            if (Columns.amount == (Columns.amount & columns))
                qry.Append("amount,");
            if (Columns.notes_dispensed_type1 == (Columns.notes_dispensed_type1 & columns))
                qry.Append("notes_dispensed_type1,");
            if (Columns.notes_dispensed_type2 == (Columns.notes_dispensed_type2 & columns))
                qry.Append("notes_dispensed_type2,");
            if (Columns.notes_dispensed_type3 == (Columns.notes_dispensed_type3 & columns))
                qry.Append("notes_dispensed_type3,");
            if (Columns.notes_dispensed_type4 == (Columns.notes_dispensed_type4 & columns))
                qry.Append("notes_dispensed_type4,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.mstate_id == (Columns.mstate_id & columns))
                qry.Append("mstate_id,");
            if (Columns.comment_id == (Columns.comment_id & columns))
                qry.Append("comment_id,");
            if (Columns.transaction_type_id == (Columns.transaction_type_id & columns))
                qry.Append("transaction_type_id,");
            if (Columns.available_balance == (Columns.available_balance & columns))
                qry.Append("available_balance,");
            if (Columns.processing_datetime == (Columns.processing_datetime & columns))
                qry.Append("processing_datetime,");
            if (Columns.start_index == (Columns.start_index & columns))
                qry.Append("start_index,");
            if (Columns.end_index == (Columns.end_index & columns))
                qry.Append("end_index,");
            if (Columns.status == (Columns.status & columns))
                qry.Append("status,");
            if (Columns.donation_amount == (Columns.donation_amount & columns))
                qry.Append("donation_amount,");
            if (Columns.transferred_amount == (Columns.transferred_amount & columns))
                qry.Append("transferred_amount,");
            if (Columns.notes_remaining_type1 == (Columns.notes_remaining_type1 & columns))
                qry.Append("notes_remaining_type1,");
            if (Columns.notes_remaining_type2 == (Columns.notes_remaining_type2 & columns))
                qry.Append("notes_remaining_type2,");
            if (Columns.notes_remaining_type3 == (Columns.notes_remaining_type3 & columns))
                qry.Append("notes_remaining_type3,");
            if (Columns.notes_remaining_type4 == (Columns.notes_remaining_type4 & columns))
                qry.Append("notes_remaining_type4,");
            if (Columns.notes_dispensed_type5 == (Columns.notes_dispensed_type5 & columns))
                qry.Append("notes_dispensed_type5,");
            if (Columns.notes_dispensed_type6 == (Columns.notes_dispensed_type6 & columns))
                qry.Append("notes_dispensed_type6,");
            if (Columns.notes_dispensed_type7 == (Columns.notes_dispensed_type7 & columns))
                qry.Append("notes_dispensed_type7,");
            if (Columns.transaction_start_time == (Columns.transaction_start_time & columns))
                qry.Append("transaction_start_time,");
            if (Columns.transaction_end_time == (Columns.transaction_end_time & columns))
                qry.Append("transaction_end_time,");
            if (Columns.card_taken_time == (Columns.card_taken_time & columns))
                qry.Append("card_taken_time,");
            if (Columns.account_type == (Columns.account_type & columns))
                qry.Append("account_type,");
            if (Columns.result == (Columns.result & columns))
                qry.Append("result,");
            if (Columns.consumer_message_id == (Columns.consumer_message_id & columns))
                qry.Append("consumer_message_id,");
            if (Columns.dispute_status == (Columns.dispute_status & columns))
                qry.Append("dispute_status,");
            if (Columns.terminal_id == (Columns.terminal_id & columns))
                qry.Append("terminal_id,");
            if (Columns.is_disputed_transaction == (Columns.is_disputed_transaction & columns))
                qry.Append("is_disputed_transaction,");
            if (Columns.posting_date == (Columns.posting_date & columns))
                qry.Append("posting_date,");
            if (Columns.currency == (Columns.currency & columns))
                qry.Append("currency,");
            if (Columns.is_eligible == (Columns.is_eligible & columns))
                qry.Append("is_eligible,");
            if (Columns.network == (Columns.network & columns))
                qry.Append("network,");
            if (Columns.notes_rejected_type1 == (Columns.notes_rejected_type1 & columns))
                qry.Append("notes_rejected_type1,");
            if (Columns.notes_rejected_type2 == (Columns.notes_rejected_type2 & columns))
                qry.Append("notes_rejected_type2,");
            if (Columns.notes_rejected_type3 == (Columns.notes_rejected_type3 & columns))
                qry.Append("notes_rejected_type3,");
            if (Columns.notes_rejected_type4 == (Columns.notes_rejected_type4 & columns))
                qry.Append("notes_rejected_type4,");
            if (Columns.host_tsn == (Columns.host_tsn & columns))
                qry.Append("host_tsn,");
            if (Columns.is_cardless == (Columns.is_cardless & columns))
                qry.Append("is_cardless,");
            if (Columns.notes_remaining_type5 == (Columns.notes_remaining_type5 & columns))
                qry.Append("notes_remaining_type5,");
            if (Columns.notes_remaining_type6 == (Columns.notes_remaining_type6 & columns))
                qry.Append("notes_remaining_type6,");
            if (Columns.notes_remaining_type7 == (Columns.notes_remaining_type7 & columns))
                qry.Append("notes_remaining_type7,");
            if (Columns.notes_rejected_type5 == (Columns.notes_rejected_type5 & columns))
                qry.Append("notes_rejected_type5,");
            if (Columns.notes_rejected_type6 == (Columns.notes_rejected_type6 & columns))
                qry.Append("notes_rejected_type6,");
            if (Columns.notes_rejected_type7 == (Columns.notes_rejected_type7 & columns))
                qry.Append("notes_rejected_type7,");
            if (Columns.account_no == (Columns.account_no & columns))
                qry.Append("account_no,");
            if (Columns.bank_name == (Columns.bank_name & columns))
                qry.Append("bank_name,");
            if (Columns.is_dispensed_from_recycler == (Columns.is_dispensed_from_recycler & columns))
                qry.Append("is_dispensed_from_recycler,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Ej_parsed_transactions ");

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
            return new EjParsedTransactionsReader(cmd.ExecuteReader(), conn, columns);
        }

        static public EjParsedTransactionsReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static EjParsedTransactionsReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select ej_parsed_transactions_id,tsn,pan,trxn_datetime,amount,notes_dispensed_type1,notes_dispensed_type2,notes_dispensed_type3,notes_dispensed_type4,atm_id,task_id,mstate_id,comment_id,transaction_type_id,available_balance,processing_datetime,start_index,end_index,status,donation_amount,transferred_amount,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,notes_dispensed_type5,notes_dispensed_type6,notes_dispensed_type7,transaction_start_time,transaction_end_time,card_taken_time,account_type,result,consumer_message_id,dispute_status,terminal_id,is_disputed_transaction,posting_date,currency,is_eligible,network,notes_rejected_type1,notes_rejected_type2,notes_rejected_type3,notes_rejected_type4,host_tsn,is_cardless,notes_remaining_type5,notes_remaining_type6,notes_remaining_type7,notes_rejected_type5,notes_rejected_type6,notes_rejected_type7,account_no,bank_name,is_dispensed_from_recycler from Ej_parsed_transactions ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new EjParsedTransactionsReader(cmd.ExecuteReader(), conn);
        }

        static public EjParsedTransactionsReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static EjParsedTransactions LoadEjParsedTransactions(string where)
        {
            EjParsedTransactionsReader reader = EjParsedTransactions.ExecuteReader(where);
            EjParsedTransactions _ejparsedtransactions = null;
            if (reader.Read())
                _ejparsedtransactions = reader.CurrentEjParsedTransactions;
            reader.Close();
            return _ejparsedtransactions;
        }

        public static EjParsedTransactions LoadEjParsedTransactions(string where, IDbConnection conn)
        {
            EjParsedTransactionsReader reader = EjParsedTransactions.ExecuteReader(where, conn);
            EjParsedTransactions _ejparsedtransactions = null;
            if (reader.Read())
                _ejparsedtransactions = reader.CurrentEjParsedTransactions;
            reader.Close(false);
            return _ejparsedtransactions;
        }

        public static EjParsedTransactions LoadEjParsedTransactionsByPk(int ej_parsed_transactions_id)
        {
            return LoadEjParsedTransactions("ej_parsed_transactions_id=" + ej_parsed_transactions_id);
        }

        public static EjParsedTransactions LoadEjParsedTransactionsByPk(int ej_parsed_transactions_id, IDbConnection conn)
        {
            return LoadEjParsedTransactions(" ej_parsed_transactions_id=" + ej_parsed_transactions_id, conn);
        }

        public void Save()
        {
            if (ej_parsed_transactions_idChanged || tsnChanged || panChanged || trxn_datetimeChanged || amountChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || mstate_idChanged || comment_idChanged || transaction_type_idChanged || available_balanceChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || statusChanged || donation_amountChanged || transferred_amountChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || account_typeChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || terminal_idChanged || is_disputed_transactionChanged || posting_dateChanged || currencyChanged || is_eligibleChanged || networkChanged || notes_rejected_type1Changed || notes_rejected_type2Changed || notes_rejected_type3Changed || notes_rejected_type4Changed || host_tsnChanged || is_cardlessChanged || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed || notes_rejected_type5Changed || notes_rejected_type6Changed || notes_rejected_type7Changed || account_noChanged || bank_nameChanged || is_dispensed_from_recyclerChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
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
            if (ej_parsed_transactions_idChanged || tsnChanged || panChanged || trxn_datetimeChanged || amountChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || mstate_idChanged || comment_idChanged || transaction_type_idChanged || available_balanceChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || statusChanged || donation_amountChanged || transferred_amountChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || account_typeChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || terminal_idChanged || is_disputed_transactionChanged || posting_dateChanged || currencyChanged || is_eligibleChanged || networkChanged || notes_rejected_type1Changed || notes_rejected_type2Changed || notes_rejected_type3Changed || notes_rejected_type4Changed || host_tsnChanged || is_cardlessChanged || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed || notes_rejected_type5Changed || notes_rejected_type6Changed || notes_rejected_type7Changed || account_noChanged || bank_nameChanged || is_dispensed_from_recyclerChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Ej_parsed_transactions(ej_parsed_transactions_id,tsn,pan,trxn_datetime,amount,notes_dispensed_type1,notes_dispensed_type2,notes_dispensed_type3,notes_dispensed_type4,atm_id,task_id,mstate_id,comment_id,transaction_type_id,available_balance,processing_datetime,start_index,end_index,status,donation_amount,transferred_amount,notes_remaining_type1,notes_remaining_type2,notes_remaining_type3,notes_remaining_type4,notes_dispensed_type5,notes_dispensed_type6,notes_dispensed_type7,transaction_start_time,transaction_end_time,card_taken_time,account_type,result,consumer_message_id,dispute_status,terminal_id,is_disputed_transaction,posting_date,currency,is_eligible,network,notes_rejected_type1,notes_rejected_type2,notes_rejected_type3,notes_rejected_type4,host_tsn,is_cardless,notes_remaining_type5,notes_remaining_type6,notes_remaining_type7,notes_rejected_type5,notes_rejected_type6,notes_rejected_type7,account_no,bank_name,is_dispensed_from_recycler) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.ej_parsed_transactions_id = ConnectionFactory.GetNextId();
                        qry.Append(this.ej_parsed_transactions_id);
                    } qry.Append(",");
                    qry.Append(tsnDbString + ",");
                    qry.Append(panDbString + ",");
                    qry.Append(trxn_datetimeDbString + ",");
                    qry.Append(amountDbString + ",");
                    qry.Append(notes_dispensed_type1DbString + ",");
                    qry.Append(notes_dispensed_type2DbString + ",");
                    qry.Append(notes_dispensed_type3DbString + ",");
                    qry.Append(notes_dispensed_type4DbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(mstate_idDbString + ",");
                    qry.Append(comment_idDbString + ",");
                    qry.Append(transaction_type_idDbString + ",");
                    qry.Append(available_balanceDbString + ",");
                    qry.Append(processing_datetimeDbString + ",");
                    qry.Append(start_indexDbString + ",");
                    qry.Append(end_indexDbString + ",");
                    qry.Append(statusDbString + ",");
                    qry.Append(donation_amountDbString + ",");
                    qry.Append(transferred_amountDbString + ",");
                    qry.Append(notes_remaining_type1DbString + ",");
                    qry.Append(notes_remaining_type2DbString + ",");
                    qry.Append(notes_remaining_type3DbString + ",");
                    qry.Append(notes_remaining_type4DbString + ",");
                    qry.Append(notes_dispensed_type5DbString + ",");
                    qry.Append(notes_dispensed_type6DbString + ",");
                    qry.Append(notes_dispensed_type7DbString + ",");
                    qry.Append(transaction_start_timeDbString + ",");
                    qry.Append(transaction_end_timeDbString + ",");
                    qry.Append(card_taken_timeDbString + ",");
                    qry.Append(account_typeDbString + ",");
                    qry.Append(resultDbString + ",");
                    qry.Append(consumer_message_idDbString + ",");
                    qry.Append(dispute_statusDbString + ",");
                    qry.Append(terminal_idDbString + ",");
                    qry.Append(is_disputed_transactionDbString + ",");
                    qry.Append(posting_dateDbString + ",");
                    qry.Append(currencyDbString + ",");
                    qry.Append(is_eligibleDbString + ",");
                    qry.Append(networkDbString + ",");
                    qry.Append(notes_rejected_type1DbString + ",");
                    qry.Append(notes_rejected_type2DbString + ",");
                    qry.Append(notes_rejected_type3DbString + ",");
                    qry.Append(notes_rejected_type4DbString + ",");
                    qry.Append(host_tsnDbString + ",");
                    qry.Append(is_cardlessDbString + ",");
                    qry.Append(notes_remaining_type5DbString + ",");
                    qry.Append(notes_remaining_type6DbString + ",");
                    qry.Append(notes_remaining_type7DbString + ",");
                    qry.Append(notes_rejected_type5DbString + ",");
                    qry.Append(notes_rejected_type6DbString + ",");
                    qry.Append(notes_rejected_type7DbString + ",");
                    qry.Append(account_noDbString + ",");
                    qry.Append(bank_nameDbString + ",");
                    qry.Append(is_dispensed_from_recyclerDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(ej_parsed_transactions_idChanged || tsnChanged || panChanged || trxn_datetimeChanged || amountChanged || notes_dispensed_type1Changed || notes_dispensed_type2Changed || notes_dispensed_type3Changed || notes_dispensed_type4Changed || atm_idChanged || task_idChanged || mstate_idChanged || comment_idChanged || transaction_type_idChanged || available_balanceChanged || processing_datetimeChanged || start_indexChanged || end_indexChanged || statusChanged || donation_amountChanged || transferred_amountChanged || notes_remaining_type1Changed || notes_remaining_type2Changed || notes_remaining_type3Changed || notes_remaining_type4Changed || notes_dispensed_type5Changed || notes_dispensed_type6Changed || notes_dispensed_type7Changed || transaction_start_timeChanged || transaction_end_timeChanged || card_taken_timeChanged || account_typeChanged || resultChanged || consumer_message_idChanged || dispute_statusChanged || terminal_idChanged || is_disputed_transactionChanged || posting_dateChanged || currencyChanged || is_eligibleChanged || networkChanged || notes_rejected_type1Changed || notes_rejected_type2Changed || notes_rejected_type3Changed || notes_rejected_type4Changed || host_tsnChanged || is_cardlessChanged || notes_remaining_type5Changed || notes_remaining_type6Changed || notes_remaining_type7Changed || notes_rejected_type5Changed || notes_rejected_type6Changed || notes_rejected_type7Changed || account_noChanged || bank_nameChanged || is_dispensed_from_recyclerChanged))
                        return;
                    qry.Append("UPDATE Ej_parsed_transactions set "); if (tsnChanged)
                    {
                        qry.Append("tsn =" + tsnDbString);
                        qry.Append(",");
                    }

                    if (panChanged)
                    {
                        qry.Append("pan =" + panDbString);
                        qry.Append(",");
                    }

                    if (trxn_datetimeChanged)
                    {
                        qry.Append("trxn_datetime =" + trxn_datetimeDbString);
                        qry.Append(",");
                    }

                    if (amountChanged)
                    {
                        qry.Append("amount =" + amountDbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type1Changed)
                    {
                        qry.Append("notes_dispensed_type1 =" + notes_dispensed_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type2Changed)
                    {
                        qry.Append("notes_dispensed_type2 =" + notes_dispensed_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type3Changed)
                    {
                        qry.Append("notes_dispensed_type3 =" + notes_dispensed_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type4Changed)
                    {
                        qry.Append("notes_dispensed_type4 =" + notes_dispensed_type4DbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (mstate_idChanged)
                    {
                        qry.Append("mstate_id =" + mstate_idDbString);
                        qry.Append(",");
                    }

                    if (comment_idChanged)
                    {
                        qry.Append("comment_id =" + comment_idDbString);
                        qry.Append(",");
                    }

                    if (transaction_type_idChanged)
                    {
                        qry.Append("transaction_type_id =" + transaction_type_idDbString);
                        qry.Append(",");
                    }

                    if (available_balanceChanged)
                    {
                        qry.Append("available_balance =" + available_balanceDbString);
                        qry.Append(",");
                    }

                    if (processing_datetimeChanged)
                    {
                        qry.Append("processing_datetime =" + processing_datetimeDbString);
                        qry.Append(",");
                    }

                    if (start_indexChanged)
                    {
                        qry.Append("start_index =" + start_indexDbString);
                        qry.Append(",");
                    }

                    if (end_indexChanged)
                    {
                        qry.Append("end_index =" + end_indexDbString);
                        qry.Append(",");
                    }

                    if (statusChanged)
                    {
                        qry.Append("status =" + statusDbString);
                        qry.Append(",");
                    }

                    if (donation_amountChanged)
                    {
                        qry.Append("donation_amount =" + donation_amountDbString);
                        qry.Append(",");
                    }

                    if (transferred_amountChanged)
                    {
                        qry.Append("transferred_amount =" + transferred_amountDbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type1Changed)
                    {
                        qry.Append("notes_remaining_type1 =" + notes_remaining_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type2Changed)
                    {
                        qry.Append("notes_remaining_type2 =" + notes_remaining_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type3Changed)
                    {
                        qry.Append("notes_remaining_type3 =" + notes_remaining_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type4Changed)
                    {
                        qry.Append("notes_remaining_type4 =" + notes_remaining_type4DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type5Changed)
                    {
                        qry.Append("notes_dispensed_type5 =" + notes_dispensed_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type6Changed)
                    {
                        qry.Append("notes_dispensed_type6 =" + notes_dispensed_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_dispensed_type7Changed)
                    {
                        qry.Append("notes_dispensed_type7 =" + notes_dispensed_type7DbString);
                        qry.Append(",");
                    }

                    if (transaction_start_timeChanged)
                    {
                        qry.Append("transaction_start_time =" + transaction_start_timeDbString);
                        qry.Append(",");
                    }

                    if (transaction_end_timeChanged)
                    {
                        qry.Append("transaction_end_time =" + transaction_end_timeDbString);
                        qry.Append(",");
                    }

                    if (card_taken_timeChanged)
                    {
                        qry.Append("card_taken_time =" + card_taken_timeDbString);
                        qry.Append(",");
                    }

                    if (account_typeChanged)
                    {
                        qry.Append("account_type =" + account_typeDbString);
                        qry.Append(",");
                    }

                    if (resultChanged)
                    {
                        qry.Append("result =" + resultDbString);
                        qry.Append(",");
                    }

                    if (consumer_message_idChanged)
                    {
                        qry.Append("consumer_message_id =" + consumer_message_idDbString);
                        qry.Append(",");
                    }

                    if (dispute_statusChanged)
                    {
                        qry.Append("dispute_status =" + dispute_statusDbString);
                        qry.Append(",");
                    }

                    if (terminal_idChanged)
                    {
                        qry.Append("terminal_id =" + terminal_idDbString);
                        qry.Append(",");
                    }

                    if (is_disputed_transactionChanged)
                    {
                        qry.Append("is_disputed_transaction =" + is_disputed_transactionDbString);
                        qry.Append(",");
                    }

                    if (posting_dateChanged)
                    {
                        qry.Append("posting_date =" + posting_dateDbString);
                        qry.Append(",");
                    }

                    if (currencyChanged)
                    {
                        qry.Append("currency =" + currencyDbString);
                        qry.Append(",");
                    }

                    if (is_eligibleChanged)
                    {
                        qry.Append("is_eligible =" + is_eligibleDbString);
                        qry.Append(",");
                    }

                    if (networkChanged)
                    {
                        qry.Append("network =" + networkDbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type1Changed)
                    {
                        qry.Append("notes_rejected_type1 =" + notes_rejected_type1DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type2Changed)
                    {
                        qry.Append("notes_rejected_type2 =" + notes_rejected_type2DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type3Changed)
                    {
                        qry.Append("notes_rejected_type3 =" + notes_rejected_type3DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type4Changed)
                    {
                        qry.Append("notes_rejected_type4 =" + notes_rejected_type4DbString);
                        qry.Append(",");
                    }

                    if (host_tsnChanged)
                    {
                        qry.Append("host_tsn =" + host_tsnDbString);
                        qry.Append(",");
                    }

                    if (is_cardlessChanged)
                    {
                        qry.Append("is_cardless =" + is_cardlessDbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type5Changed)
                    {
                        qry.Append("notes_remaining_type5 =" + notes_remaining_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type6Changed)
                    {
                        qry.Append("notes_remaining_type6 =" + notes_remaining_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_remaining_type7Changed)
                    {
                        qry.Append("notes_remaining_type7 =" + notes_remaining_type7DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type5Changed)
                    {
                        qry.Append("notes_rejected_type5 =" + notes_rejected_type5DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type6Changed)
                    {
                        qry.Append("notes_rejected_type6 =" + notes_rejected_type6DbString);
                        qry.Append(",");
                    }

                    if (notes_rejected_type7Changed)
                    {
                        qry.Append("notes_rejected_type7 =" + notes_rejected_type7DbString);
                        qry.Append(",");
                    }

                    if (account_noChanged)
                    {
                        qry.Append("account_no =" + account_noDbString);
                        qry.Append(",");
                    }

                    if (bank_nameChanged)
                    {
                        qry.Append("bank_name =" + bank_nameDbString);
                        qry.Append(",");
                    }

                    if (is_dispensed_from_recyclerChanged)
                    {
                        qry.Append("is_dispensed_from_recycler =" + is_dispensed_from_recyclerDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("ej_parsed_transactions_id = " + ej_parsed_transactions_idDbString);
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
            Delete(ConnectionFactory.GetNewConnection());
        }

        public void Delete(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE Ej_parsed_transactions whereej_parsed_transactions_id= " + ej_parsed_transactions_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteEjParsedTransactionss(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Ej_parsed_transactions where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            ej_parsed_transactions_id = 1,
            tsn = 2,
            pan = 4,
            trxn_datetime = 8,
            amount = 16,
            notes_dispensed_type1 = 32,
            notes_dispensed_type2 = 64,
            notes_dispensed_type3 = 128,
            notes_dispensed_type4 = 256,
            atm_id = 512,
            task_id = 1024,
            mstate_id = 2048,
            comment_id = 4096,
            transaction_type_id = 8192,
            available_balance = 16384,
            processing_datetime = 32768,
            start_index = 65536,
            end_index = 131072,
            status = 262144,
            donation_amount = 524288,
            transferred_amount = 1048576,
            notes_remaining_type1 = 2097152,
            notes_remaining_type2 = 4194304,
            notes_remaining_type3 = 8388608,
            notes_remaining_type4 = 16777216,
            notes_dispensed_type5 = 33554432,
            notes_dispensed_type6 = 67108864,
            notes_dispensed_type7 = 134217728,
            transaction_start_time = 268435456,
            transaction_end_time = 536870912,
            card_taken_time = 1073741824,
            account_type = 2147483648,
            result = 4294967296,
            consumer_message_id = 8589934592,
            dispute_status = 17179869184,
            terminal_id = 34359738368,
            is_disputed_transaction = 68719476736,
            posting_date = 137438953472,
            currency = 274877906944,
            is_eligible = 549755813888,
            network = 1099511627776,
            notes_rejected_type1 = 2199023255552,
            notes_rejected_type2 = 4398046511104,
            notes_rejected_type3 = 8796093022208,
            notes_rejected_type4 = 17592186044416,
            host_tsn = 35184372088832,
            is_cardless = 70368744177664,
            notes_remaining_type5 = 140737488355328,
            notes_remaining_type6 = 281474976710656,
            notes_remaining_type7 = 562949953421312,
            notes_rejected_type5 = 1125899906842624 + 15,
            notes_rejected_type6 = 2251799813685248,
            notes_rejected_type7 = 4503599627370496,
            account_no = 9007199254740992,
            bank_name = 18014398509481980,
            is_dispensed_from_recycler = 36028797018963960
        }
        #endregion
        public DataTable BulkSave(List<EjParsedTransactions> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Ej_parsed_transactions";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(EjParsedTransactions.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<EjParsedTransactions> transList, ref DataTable dt)
        {
            foreach (EjParsedTransactions tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["ej_parsed_transactions_id"] = ConnectionFactory.GetNextId();
                Row["tsn"] = tran.Tsn;
                Row["pan"] = tran.Pan;
                Row["trxn_datetime"] = tran.TrxnDatetime;
                Row["amount"] = tran.Amount;
                Row["notes_dispensed_type1"] = tran.NotesDispensedType1;
                Row["notes_dispensed_type2"] = tran.NotesDispensedType2;
                Row["notes_dispensed_type3"] = tran.NotesDispensedType3;
                Row["notes_dispensed_type4"] = tran.NotesDispensedType4;
                Row["atm_id"] = tran.AtmId;
                Row["task_id"] = tran.TaskId;
                Row["mstate_id"] = tran.MstateId;
                Row["comment_id"] = tran.CommentId;
                Row["transaction_type_id"] = tran.TransactionTypeId;
                Row["available_balance"] = tran.AvailableBalance;
                Row["processing_datetime"] = tran.ProcessingDatetime;
                Row["start_index"] = tran.StartIndex;
                Row["end_index"] = tran.EndIndex;
                Row["status"] = tran.Status;
                Row["donation_amount"] = tran.DonationAmount;
                Row["transferred_amount"] = tran.TransferredAmount;
                Row["notes_remaining_type1"] = tran.NotesRemainingType1;
                Row["notes_remaining_type2"] = tran.NotesRemainingType2;
                Row["notes_remaining_type3"] = tran.NotesRemainingType3;
                Row["notes_remaining_type4"] = tran.NotesRemainingType4;
                Row["notes_dispensed_type5"] = tran.NotesDispensedType5;
                Row["notes_dispensed_type6"] = tran.NotesDispensedType6;
                Row["notes_dispensed_type7"] = tran.NotesDispensedType7;
                Row["transaction_start_time"] = tran.TransactionStartTime;
                Row["transaction_end_time"] = tran.TransactionEndTime;
                Row["card_taken_time"] = tran.CardTakenTime;
                Row["account_type"] = tran.AccountType;
                Row["result"] = tran.Result;
                Row["consumer_message_id"] = tran.ConsumerMessageId;
                Row["dispute_status"] = tran.DisputeStatus;
                Row["terminal_id"] = tran.TerminalId;
                Row["is_disputed_transaction"] = tran.IsDisputedTransaction;
                Row["posting_date"] = tran.PostingDate;
                Row["currency"] = tran.Currency;
                Row["is_eligible"] = tran.IsEligible;
                Row["network"] = tran.Network;
                Row["notes_rejected_type1"] = tran.NotesRejectedType1;
                Row["notes_rejected_type2"] = tran.NotesRejectedType2;
                Row["notes_rejected_type3"] = tran.NotesRejectedType3;
                Row["notes_rejected_type4"] = tran.NotesRejectedType4;
                Row["host_tsn"] = tran.HostTsn;
                Row["is_cardless"] = tran.IsCardless;
                Row["notes_remaining_type5"] = tran.NotesRemainingType5;
                Row["notes_remaining_type6"] = tran.NotesRemainingType6;
                Row["notes_remaining_type7"] = tran.NotesRemainingType7;
                Row["notes_rejected_type5"] = tran.NotesRejectedType5;
                Row["notes_rejected_type6"] = tran.NotesRejectedType6;
                Row["notes_rejected_type7"] = tran.NotesRejectedType7;
                Row["account_no"] = tran.AccountNo;
                Row["bank_name"] = tran.BankName;
                Row["is_dispensed_from_recycler"] = tran.IsDispensedFromRecycler;
                dt.Rows.Add(Row);
            }
        }
    }
}