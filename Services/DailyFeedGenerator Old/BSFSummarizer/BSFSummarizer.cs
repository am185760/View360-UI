using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data;
using Avanza.CCMS;
using System.Reflection;
using System.Linq;
using System.IO;
using ServicesDAL;

public class DFFVersion2Helper
{
    public string title;
    public DateTime dt;
    public bool dateModified = false;
    public bool readFromCashPosition = false;
    public string closingBalanceFromCashPosition;
    public string rejectedCounters;
    public string currentDayWithdrawalNotes;
    public string preWithdrawalNotes;
    public string repNotes;
    public string returnAmount;
    public string yesterdayBalanceNotes;


}

class Replenishment
{
    public int cashAdded1;
    public int cashAdded2;
    public int cashAdded3;
    public int cashAdded4;
    public int cashAdded5;
    public int cashAdded6;
    public int cashAdded7;

    public int actualCashAdded1;
    public int actualCashAdded2;
    public int actualCashAdded3;
    public int actualCashAdded4;
    public int actualCashAdded5;
    public int actualCashAdded6;
    public int actualCashAdded7;

    public int den1;
    public int den2;
    public int den3;
    public int den4;
    public int den5;
    public int den6;
    public int den7;

    public DateTime? lastReplenishmentDateTime = null;
    public DateTime replenishmentDateTime;
    int totalAmount = 0;
    int totalCount = 0;
    public bool isSwap = false;
    public int GetTotalAmount()
    {
        return cashAdded1 * den1 + cashAdded2 * den2 + cashAdded3 * den3 + cashAdded4 * den4 + cashAdded5 * den5 +
            cashAdded6 * den6 + cashAdded7 * den7;

    }
    public int GetTotalCount()
    {
        return cashAdded1 + cashAdded2 + cashAdded3 + cashAdded4 + cashAdded5 + cashAdded6 + cashAdded7;
    }

    public Replenishment(int CashAdded1, int CashAdded2, int CashAdded3, int CashAdded4,
        int CashAdded5, int CashAdded6, int CashAdded7,
                        int Denomination1, int Denomination2, int Denomination3, int Denomination4,
        int Denomination5, int Denomination6, int Denomination7, bool isSwap, DateTime repDateTime)
    {
        this.cashAdded1 = CashAdded1;
        this.cashAdded2 = CashAdded2;
        this.cashAdded3 = CashAdded3;
        this.cashAdded4 = CashAdded4;
        this.cashAdded5 = CashAdded5;
        this.cashAdded6 = CashAdded6;
        this.cashAdded7 = CashAdded7;

        this.den1 = Denomination1;
        this.den2 = Denomination2;
        this.den3 = Denomination3;
        this.den4 = Denomination4;
        this.den5 = Denomination5;
        this.den6 = Denomination6;
        this.den7 = Denomination7;

        actualCashAdded1 = cashAdded1;
        actualCashAdded2 = cashAdded2;
        actualCashAdded3 = cashAdded3;
        actualCashAdded4 = cashAdded4;
        actualCashAdded5 = cashAdded5;
        actualCashAdded6 = cashAdded6;
        actualCashAdded7 = cashAdded7;

        this.isSwap = isSwap;
        //totalCount = CashAdded1 + CashAdded2 + CashAdded3 + CashAdded4 + CashAdded5 + CashAdded6 + CashAdded7;
        //totalAmount = CashAdded1 * Denomination1 + CashAdded2 * Denomination2 + CashAdded3 * Denomination3 +
        //        CashAdded4 * Denomination4 + CashAdded5 * Denomination5 + CashAdded6 * Denomination6 + CashAdded7 * Denomination7;
        replenishmentDateTime = repDateTime;
    }
}
public static class DFFInfo
{
    public static string DFFOutputPath;
    public static string DFPrefix;
}

public class CMS
{
    string[] repNotes = null;
    public bool isEmptyDataGenerated = false;
    string field8 = null;
    int footerCount = 0;
    //decimal rejectedCountsForRepDay = 0;
    Atm atm = null;
    DateTime tempDay;
    bool dateModified = false;
    //SqlTransaction trxn = null;
    StringBuilder builder = new StringBuilder();
    System.Collections.Hashtable ReplenishmentByDay;
    SqlCommand cmd = null;
    NoteSetType noteSetType = null;
    int atmCount = 0;
    public List<DFFVersion2Helper> listDFFHelper = null;
    public DFFVersion2Helper dFFVersion2Helper = null;
    decimal totalWithdrawals = 0;
    string preWithdrawalNotes = "";
    string yesterdayBalanceNotes = "";
    string currentDayBalanceNotes = "";
    string currentDayWithdrawalsNotes = "";
    decimal totalPreWithdrawals = 0;
    bool isAddCashOnCurrentDay = false;
    public DateTime oldMaxRepDate = new DateTime(1900, 1, 1);

    List<DepositTransaction> depositTransactions = new List<DepositTransaction>();
    List<DepositTransaction> PreDepositTransactions = new List<DepositTransaction>();
    List<List<DepositTransaction>> AllDepositTransactions = new List<List<DepositTransaction>>();
    int[] recycledWithdrawalSummary = new int[7];
    int[] preRecycledWithdrawalSummary = new int[7];
    List<int[]> AllRecycledWithdrawalSummary = new List<int[]>();
    int[] recycledWithdrawalSummaryYesterday = new int[7];

    public void Initialize()
    {
        builder = new StringBuilder();

    }

    DateTime Day;
    long atm_id;
    public DateTime SetSummaryDay
    {
        set { Day = value; }


    }

    private string GetRejectedCountDueToTestCash(DateTime day)
    {
        int purged_cassette_1 = 0;
        int purged_cassette_2 = 0;
        int purged_cassette_3 = 0;
        int purged_cassette_4 = 0;
        int purged_cassette_5 = 0;
        int purged_cassette_6 = 0;
        int purged_cassette_7 = 0;


        TestCashPurgedNotes.TestCashPurgedNotesReader reader =
         TestCashPurgedNotes.ExecuteReader(string.Format(@"atm_id={0} 
                            and test_cash_datetime >= convert(datetime,'{1}',103) 
                            and test_cash_datetime <=convert(datetime,'{2} 23:59:59',103)",
                          atm_id, day.ToString("dd/MM/yyyy"), day.ToString("dd/MM/yyyy")));
        while (reader.Read())
        {
            purged_cassette_1 += reader.CurrentTestCashPurgedNotes.CashPurged1;
            purged_cassette_2 += reader.CurrentTestCashPurgedNotes.CashPurged2;
            purged_cassette_3 += reader.CurrentTestCashPurgedNotes.CashPurged3;
            purged_cassette_4 += reader.CurrentTestCashPurgedNotes.CashPurged4;
            purged_cassette_5 += reader.CurrentTestCashPurgedNotes.CashPurged5;
            purged_cassette_6 += reader.CurrentTestCashPurgedNotes.CashPurged6;
            purged_cassette_7 += reader.CurrentTestCashPurgedNotes.CashPurged7;

        }

        return purged_cassette_1 + "|" + purged_cassette_2 + "|" + purged_cassette_3 + "|" + purged_cassette_4 + "|" + purged_cassette_5 + "|" + purged_cassette_6 + "|" + purged_cassette_7;

    }

    private decimal GetRejectedCountForRepDay(DateTime day)
    {
        decimal amt = 0;
        ParsedTransaction.ParsedTransactionReader reader =
            ParsedTransaction.ExecuteReader(string.Format(@"atm_id={0} 
                            and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2}',103)",
                             atm_id, day.ToString("dd/MM/yyyy"), day.ToString("dd/MM/yyyy HH:mm:ss")));
        while (reader.Read())
        {

            amt += (decimal)(reader.CurrentParsedTransaction.CashPurged1 * atm.Cassette1Denomination
            + reader.CurrentParsedTransaction.CashPurged2 * atm.Cassette2Denomination
            + reader.CurrentParsedTransaction.CashPurged3 * atm.Cassette3Denomination
            + reader.CurrentParsedTransaction.CashPurged4 * atm.Cassette4Denomination
            + reader.CurrentParsedTransaction.CashPurged5 * atm.Cassette5Denomination
            + reader.CurrentParsedTransaction.CashPurged6 * atm.Cassette6Denomination
            + reader.CurrentParsedTransaction.CashPurged7 * atm.Cassette7Denomination);

        }
        reader.Close();
        return amt;
    }

    private int[] GetTestCashPurgedBinValue(DateTime day)
    {
        int cassette1PurgedCount = 0;
        int cassette2PurgedCount = 0;
        int cassette3PurgedCount = 0;
        int cassette4PurgedCount = 0;
        int cassette5PurgedCount = 0;
        int cassette6PurgedCount = 0;
        int cassette7PurgedCount = 0;
        RevertCommandObjToRunTextQuery();
        cmd.CommandText = string.Format(@"select max(rep_datetime) from replenishment where atm_id={0} 
                            and rep_datetime <=convert(datetime,'{1} 23:59:59',103)",
                             atm_id, day.ToString("dd/MM/yyyy"));

        object result = cmd.ExecuteScalar();
        if (result != DBNull.Value)
        {
            TestCashPurgedNotes.TestCashPurgedNotesReader testCashreader =
            TestCashPurgedNotes.ExecuteReader(string.Format(@"atm_id={0} 
                            and test_cash_datetime >= convert(datetime,'{1}',103) 
                            and test_cash_datetime <=convert(datetime,'{2} 23:59:59',103)",
                             atm_id, DateTime.Parse(result.ToString()).ToString("dd/MM/yyyy"), day.ToString("dd/MM/yyyy")));
            while (testCashreader.Read())
            {
                cassette1PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged1;
                cassette2PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged2;
                cassette3PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged3;
                cassette4PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged4;
                cassette5PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged5;
                cassette6PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged6;
                cassette7PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged7;

            }
            testCashreader.Close();

        }
        int[] purgedNotes = new int[7];
        purgedNotes[0] = cassette1PurgedCount;
        purgedNotes[1] = cassette2PurgedCount;
        purgedNotes[2] = cassette3PurgedCount;
        purgedNotes[3] = cassette4PurgedCount;
        purgedNotes[4] = cassette5PurgedCount;
        purgedNotes[5] = cassette6PurgedCount;
        purgedNotes[6] = cassette7PurgedCount;

        return purgedNotes;
    }

    private decimal GetRejectedCountForDay(DateTime day, int[] purgedNotes)
    {
        int cassette1PurgedCount = 0;
        int cassette2PurgedCount = 0;
        int cassette3PurgedCount = 0;
        int cassette4PurgedCount = 0;
        int cassette5PurgedCount = 0;
        int cassette6PurgedCount = 0;
        int cassette7PurgedCount = 0;

        decimal amt = 0;
        ParsedTransaction.ParsedTransactionReader reader =
            ParsedTransaction.ExecuteReader(string.Format(@"atm_id={0} 
                            and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2} 23:59:59',103)",
                             atm_id, day.ToString("dd/MM/yyyy"), day.ToString("dd/MM/yyyy")));
        while (reader.Read())
        {
            amt += (decimal)(reader.CurrentParsedTransaction.CashPurged1 * atm.Cassette1Denomination
            + reader.CurrentParsedTransaction.CashPurged2 * atm.Cassette2Denomination
            + reader.CurrentParsedTransaction.CashPurged3 * atm.Cassette3Denomination
            + reader.CurrentParsedTransaction.CashPurged4 * atm.Cassette4Denomination
            + reader.CurrentParsedTransaction.CashPurged5 * atm.Cassette5Denomination
            + reader.CurrentParsedTransaction.CashPurged6 * atm.Cassette6Denomination
            + reader.CurrentParsedTransaction.CashPurged7 * atm.Cassette7Denomination);

            cassette1PurgedCount += reader.CurrentParsedTransaction.CashPurged1;
            cassette2PurgedCount += reader.CurrentParsedTransaction.CashPurged2;
            cassette3PurgedCount += reader.CurrentParsedTransaction.CashPurged3;
            cassette4PurgedCount += reader.CurrentParsedTransaction.CashPurged4;
            cassette5PurgedCount += reader.CurrentParsedTransaction.CashPurged5;
            cassette6PurgedCount += reader.CurrentParsedTransaction.CashPurged6;
            cassette7PurgedCount += reader.CurrentParsedTransaction.CashPurged7;


        }
        reader.Close();




        //New stuff... to include test cash purged counts in current day purged....
        TestCashPurgedNotes.TestCashPurgedNotesReader testCashreader =
            TestCashPurgedNotes.ExecuteReader(string.Format(@"atm_id={0} 
                            and test_cash_datetime >= convert(datetime,'{1}',103) 
                            and test_cash_datetime <=convert(datetime,'{2} 23:59:59',103)",
                             atm_id, day.ToString("dd/MM/yyyy"), day.ToString("dd/MM/yyyy")));
        while (testCashreader.Read())
        {
            amt += (decimal)(testCashreader.CurrentTestCashPurgedNotes.CashPurged1 * atm.Cassette1Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged2 * atm.Cassette2Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged3 * atm.Cassette3Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged4 * atm.Cassette4Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged5 * atm.Cassette5Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged6 * atm.Cassette6Denomination
            + testCashreader.CurrentTestCashPurgedNotes.CashPurged7 * atm.Cassette7Denomination);

            cassette1PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged1;
            cassette2PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged2;
            cassette3PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged3;
            cassette4PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged4;
            cassette5PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged5;
            cassette6PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged6;
            cassette7PurgedCount += testCashreader.CurrentTestCashPurgedNotes.CashPurged7;


        }
        testCashreader.Close();






        purgedNotes[0] = cassette1PurgedCount;
        purgedNotes[1] = cassette2PurgedCount;
        purgedNotes[2] = cassette3PurgedCount;
        purgedNotes[3] = cassette4PurgedCount;
        purgedNotes[4] = cassette5PurgedCount;
        purgedNotes[5] = cassette6PurgedCount;
        purgedNotes[6] = cassette7PurgedCount;

        return amt;


    }

    public void StartGeneration(LogableTask task, long atm_id)
    {

        repNotes = null;
        //dFFVersion2Helper.repNotes = "";

        LogableTask.LogMonoActivityTask("StartGen", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing Atm having Id : " + atm_id);
        ReplenishmentByDay = new System.Collections.Hashtable(51);
        totalWithdrawals = 0;
        totalPreWithdrawals = 0;
        preWithdrawalNotes = "";
        yesterdayBalanceNotes = "";
        currentDayBalanceNotes = "";
        currentDayWithdrawalsNotes = "";

        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise withdrawals");
        //EA:23-01-2022
        //currentDayWithdrawalsNotes = ExtractDayWiseWithdrawalsInTermsOfNotes(Day);
        currentDayWithdrawalsNotes = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
        dFFVersion2Helper.currentDayWithdrawalNotes = currentDayWithdrawalsNotes;
        string[] parts = currentDayWithdrawalsNotes.Split('|');
        totalWithdrawals = decimal.Parse((noteSetType.DenominationType1 * int.Parse(parts[0]) +
            noteSetType.DenominationType2 * int.Parse(parts[1]) +
            noteSetType.DenominationType3 * int.Parse(parts[2]) +
            noteSetType.DenominationType4 * int.Parse(parts[3]) +
            noteSetType.DenominationType5 * int.Parse(parts[4]) +
            noteSetType.DenominationType6 * int.Parse(parts[5]) +
            noteSetType.DenominationType7 * int.Parse(parts[6])).ToString());

        //ExtractDayWiseWithdrawals();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //EA:23-01-2022
        //task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise replenishment");
        //ExtractDayWiseReplenishment();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise pre-withdrawals");
        //Change done on 30/01/2014//Get Amount from Notes function
        //EA: 17-01-2022 to catch exceptions related to pre withdrawals while no rep
        try
        {
            //EA:23-01-2022
            //preWithdrawalNotes = ExtractDayWisePreWithdrawalsInTermsOfNotes(Day);
            preWithdrawalNotes = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            dFFVersion2Helper.preWithdrawalNotes = preWithdrawalNotes;
            parts = preWithdrawalNotes.Split('|');
            totalPreWithdrawals = decimal.Parse((noteSetType.DenominationType1 * int.Parse(parts[0]) +
                noteSetType.DenominationType2 * int.Parse(parts[1]) +
                noteSetType.DenominationType3 * int.Parse(parts[2]) +
                noteSetType.DenominationType4 * int.Parse(parts[3]) +
                noteSetType.DenominationType5 * int.Parse(parts[4]) +
                noteSetType.DenominationType6 * int.Parse(parts[5]) +
                noteSetType.DenominationType7 * int.Parse(parts[6])).ToString());

        }
        catch (Exception ex)
        {
            dFFVersion2Helper.preWithdrawalNotes = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            totalPreWithdrawals = 0;
            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, "Error while extracting pre-withdrawals for ATM id " + atm_id);
            LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Error, "Error while extracting pre-withdrawals for ATM id " + atm_id);
            LogableTask.LogMonoActivityTask("StartGen", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
        }
        //ExtractDayWisePreWithdrawals();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "day wise pre-withdrawals extracted");
        LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "day wise pre-withdrawals extracted");
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Generating output for Atm having Id :" + atm_id);
        LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Generating output for Atm having Id :" + atm_id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ConstructOutput(cmd.Connection);
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Output Generated for Atm having Id :" + atm_id);

    }

    private void DoAnalyzeTrxn(string eventDatetime, int atmID, ref bool notesIncreased, ref bool dataExists)//, ref bool trxnAnalysisCanBeDone
    {
        int count = 0;
        cmd.CommandText = @"select top 1 cash_remaining1, cash_remaining2,cash_remaining3,cash_remaining4 
                                                    from parsed_transaction 
                                                    where trxn_datetime < convert(datetime,'" + DateTime.ParseExact(eventDatetime, "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atmID + " order by trxn_datetime desc";

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dtLastTrxn = new DataTable();
        adapter.Fill(dtLastTrxn);

        cmd.CommandText = @"select top 3 cash_remaining1, cash_remaining2,cash_remaining3,cash_remaining4 
                                                    from parsed_transaction 
                                                    where trxn_datetime > convert(datetime,'" + DateTime.ParseExact(eventDatetime, "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atmID + " order by trxn_datetime asc";

        adapter = new SqlDataAdapter(cmd);
        DataTable dtFirstTrxn = new DataTable();
        adapter.Fill(dtFirstTrxn);

        if (dtFirstTrxn.Rows.Count == 3 && dtLastTrxn.Rows.Count > 0)
        {
            dataExists = true;
            int lastRemainingType1 = int.Parse(dtLastTrxn.Rows[0][0].ToString());
            int lastRemainingType2 = int.Parse(dtLastTrxn.Rows[0][1].ToString());
            int lastRemainingType3 = int.Parse(dtLastTrxn.Rows[0][2].ToString());
            int lastRemainingType4 = int.Parse(dtLastTrxn.Rows[0][3].ToString());

            // trxnAnalysisCanBeDone = true;
            for (int k = 0; k < 3; k++)
            {
                if (
                    int.Parse(dtFirstTrxn.Rows[k][0].ToString()) > lastRemainingType1 ||
                int.Parse(dtFirstTrxn.Rows[k][1].ToString()) > lastRemainingType2 ||
                int.Parse(dtFirstTrxn.Rows[k][2].ToString()) > lastRemainingType3 ||
                int.Parse(dtFirstTrxn.Rows[k][3].ToString()) > lastRemainingType4)
                    count++;
            }

            if (count == 3)
                notesIncreased = true;
            else
                notesIncreased = false;
        }
        else
            dataExists = false;
        //else
        //    trxnAnalysisCanBeDone = false;

        //return false;
    }

    //private void AutoResolveUserTasks(SqlCommand cmd, SqlTransaction trxn, LogableTask task)
    //{
    //    bool dataExists = true;
    //    bool notesIncreased = true;
    //    List<int> ATMsHalted = new List<int>();
    //    cmd.CommandText = "select atm_id from atm where is_dff_generation_halt=1 and is_active=1";
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "All DFF stopped ATMs Fetched");
    //    while (reader.Read())
    //        ATMsHalted.Add(reader.GetInt32(0));
    //    reader.Close();

    //    foreach (int atmID in ATMsHalted)
    //    {
    //        LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Processing ATM ID :" + atmID);
    //        UserTask.UserTaskReader userTaskReader = UserTask.ExecuteReader("atm_id=" + atmID + " and status = 'Pending' and task_type_id = 12");
    //        while (userTaskReader.Read())
    //        {
    //            LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Processing User Task ID :" + userTaskReader.CurrentUserTask.UserTaskId);
    //            dataExists = true;
    //            notesIncreased = true;
    //            LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to read ATM Alert ID :" + userTaskReader.CurrentUserTask.AtmAlertId.Value);
    //            AtmAlert atmAlert = AtmAlert.LoadAtmAlertByPk(userTaskReader.CurrentUserTask.AtmAlertId.Value);
    //            if (atmAlert != null)
    //            {
    //                LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to read ATM :" + atmAlert.AtmId.Value);
    //                Atm atm = Atm.LoadAtmByPk(atmAlert.AtmId.Value);
    //                string[] parts = atmAlert.AlertMsg.Split(new char[] { '|' });
    //                //LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to read Replenishment");
    //                //Avanza.CCMS.DAL.Replenishment.ReplenishmentReader repReader = Avanza.CCMS.DAL.Replenishment.ExecuteReader(
    //                //       " rep_datetime in (select max(rep_Datetime) from replenishment where atm_id = " + atmAlert.AtmId.Value + ")");
    //                //LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Reader read executing");
    //                //repReader.Read();
    //                //if (atmAlert.AlertTypeId == (int)EnumAlertType.AddCashReplenishmentDetected)
    //                //{
    //                //    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Rep Type identified.its Add Cash Replenishment");
    //                //    int[] remainingCounters = { int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]) };
    //                //    int[] dispensedCounters = { int.Parse(parts[13]), int.Parse(parts[14]), int.Parse(parts[15]), int.Parse(parts[16]) };
    //                //    int[] purgedCounters = { int.Parse(parts[20]), int.Parse(parts[21]), int.Parse(parts[22]), int.Parse(parts[23]) };
    //                //    int[] addedCounters = { int.Parse(parts[27]), int.Parse(parts[28]), int.Parse(parts[29]), int.Parse(parts[30]) };

    //                //    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Checking current Replenishment");
    //                //    if (repReader.CurrentReplenishment != null)
    //                //    {
    //                //        if (
    //                //            repReader.CurrentReplenishment.RepDatetime > DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null))
    //                //        {
    //                //            LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment date > date currently processing");
    //                //            userTaskReader.CurrentUserTask.Status = ApprovalStatus.Rejected.ToString();
    //                //            userTaskReader.CurrentUserTask.Save();
    //                //            ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + userTaskReader.CurrentUserTask.AtmId);
    //                //            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Add Cash Rep Resolved based on system current datetime.System already have replenishment posted.This entry is generated because of file fetched by server and custodian was doing replenishment");
    //                //        }
    //                //        else
    //                //        {
    //                //            LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to Analyze transactions");
    //                //            DoAnalyzeTrxn(parts[0], atm.ATMId, ref notesIncreased, ref dataExists);
    //                //            if (dataExists)
    //                //            {
    //                //                if (notesIncreased)
    //                //                {
    //                //                    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to process Replenishments");
    //                //                    ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, addedCounters[0],
    //                //                        addedCounters[1], addedCounters[2], addedCounters[3], parts[0]);

    //                //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment Extracted after verifying transactions");
    //                //                }
    //                //            }
    //                //        }
    //                //    }
    //                //    else
    //                //    {
    //                //        LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to Analyze transactions");
    //                //        DoAnalyzeTrxn(parts[0], atm.ATMId, ref notesIncreased, ref dataExists);
    //                //        if (dataExists)
    //                //        {
    //                //            if (notesIncreased)
    //                //            {
    //                //                LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to process Replenishments");
    //                //                ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, addedCounters[0],
    //                //                    addedCounters[1], addedCounters[2], addedCounters[3], parts[0]);

    //                //                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment Extracted after verifying transactions");
    //                //            }
    //                //        }
    //                //    }
    //                //}
    //                //else{
    //                //LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Rep Type identified.its NOT Add Cash Replenishment");

    //                int[] lastRemainingCounters = { int.Parse(parts[11]), int.Parse(parts[12]), int.Parse(parts[13]), int.Parse(parts[14]) };
    //                int[] lastDispensedCounters = { int.Parse(parts[0x12]), int.Parse(parts[0x13]), int.Parse(parts[20]), int.Parse(parts[0x15]) };
    //                int[] lastPurgedCounters = { int.Parse(parts[0x19]), int.Parse(parts[0x1a]), int.Parse(parts[0x1b]), int.Parse(parts[0x1c]) };
    //                int[] lastAddedCounters = { int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]) };

    //                int[] currentRemainingCounters = { int.Parse(parts[0x27]), int.Parse(parts[40]), int.Parse(parts[0x29]), int.Parse(parts[0x2a]) };
    //                int[] currentDispensedCounters = { int.Parse(parts[0x2e]), int.Parse(parts[0x2f]), int.Parse(parts[0x30]), int.Parse(parts[0x31]) };
    //                int[] currentPurgedCounters = { int.Parse(parts[0x35]), int.Parse(parts[0x36]), int.Parse(parts[0x37]), int.Parse(parts[0x38]) };
    //                int[] currentAddedCounters = { int.Parse(parts[0x20]), int.Parse(parts[0x21]), int.Parse(parts[0x22]), int.Parse(parts[0x23]) };

    //                //int defaultMaxNotesPerCassette = 2000;

    //                //if (atm.MaxNotesPerCassette == null)
    //                //{
    //                //    atm.MaxNotesPerCassette = defaultMaxNotesPerCassette;
    //                //    atm.Save();
    //                //    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Max Notes Per Cassette updated for atm" + atm.ATMId);
    //                //}
    //                //************************************************************************************************************************************************
    //                //Changes done on 2-jan-2014.
    //                //************************************************************************************************************************************************
    //                if (currentDispensedCounters[0] == 0 && currentDispensedCounters[1] == 0 && currentDispensedCounters[2] == 0 && currentDispensedCounters[3] == 0)
    //                {
    //                    Avanza.CCMS.DAL.Replenishment replenishment = ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentRemainingCounters[0],
    //                                       currentRemainingCounters[1], currentRemainingCounters[2], currentRemainingCounters[3], parts[0],trxn);

    //                    Avanza.CCMS.DAL.Replenishment lastReplenishment =
    //                        Avanza.CCMS.DAL.Replenishment.LoadReplenishment(string.Format(" rep_datetime in (select max(rep_Datetime) from replenishment where rep_datetime>=convert(datetime,'{0}',103)" +
    //                        " and rep_datetime<convert(datetime,'{2}',103) and atm_id={1}) and atm_id={1}",
    //                        DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"), atmAlert.AtmId,
    //                        DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss")));


    //                    if (lastReplenishment != null)
    //                    {//if counters are same or difference in rep time is <= 30 minutes..
    //                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Last Replenishment extracted counters are " + lastReplenishment.CashAdded1 + " " + lastReplenishment.CashAdded2 + " " + lastReplenishment.CashAdded3 + " " + lastReplenishment.CashAdded4);
    //                        if (lastReplenishment.CashAdded1 == replenishment.CashAdded1 &&
    //                              lastReplenishment.CashAdded2 == replenishment.CashAdded2 &&
    //                                  lastReplenishment.CashAdded3 == replenishment.CashAdded3 &&
    //                                      lastReplenishment.CashAdded4 == replenishment.CashAdded4 &&
    //                                          lastReplenishment.CashAdded5 == replenishment.CashAdded5 &&
    //                                              lastReplenishment.CashAdded6 == replenishment.CashAdded6 &&
    //                                                  lastReplenishment.CashAdded7 == replenishment.CashAdded7
    //                             || (Math.Abs((lastReplenishment.RepDatetime - replenishment.RepDatetime).TotalMinutes) <= int.Parse(appSetting.RepTimeDiff))

    //                            )
    //                        {
    //                            ConnectionFactory.ExecuteQuery("insert into replenishmentHistory select * from replenishment where replenishment_id = " + lastReplenishment.ReplenishmentId, trxn);
    //                            replenishment.RepDatetime = lastReplenishment.RepDatetime; // Time is overwrite to fetch correct withdrawals entry to update replenishment counters
    //                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Last replenishment deleted");
    //                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Counter [{0}],[{1}],[{2}],[{3}]", lastReplenishment.CashAdded1, lastReplenishment.CashAdded2, lastReplenishment.CashAdded3, lastReplenishment.CashAdded4));
    //                            lastReplenishment.Delete(trxn.Connection, trxn);

    //                            AtmAlert.AtmAlertReader atmAlertReader = AtmAlert.ExecuteReader("entity_id=" + lastReplenishment.ReplenishmentId);
    //                            while (atmAlertReader.Read())
    //                            {
    //                                CcmsIntegratedAlert ccmsIntalert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlertReader.CurrentAtmAlert.AtmAlertId);
    //                                if (ccmsIntalert != null)
    //                                {
    //                                    ccmsIntalert.Delete(trxn.Connection, trxn);
    //                                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert in ccms_integrated_alert also deleted");
    //                                }
    //                                atmAlertReader.CurrentAtmAlert.Delete(trxn.Connection, trxn);
    //                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert also deleted");
    //                            }
    //                            atmAlertReader.Close();
    //                        }

    //                    }


    //                }


    //                //if (currentRemainingCounters[0] > (atm.MaxNotesPerCassette.Value * 2)
    //                //    || currentRemainingCounters[1] > (atm.MaxNotesPerCassette.Value * 2)
    //                //    || currentRemainingCounters[2] > (atm.MaxNotesPerCassette.Value * 2)
    //                //    || currentRemainingCounters[3] > (atm.MaxNotesPerCassette.Value * 2))
    //                //{
    //                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Max Notes Per Cassette Exceeded.So ignoring it");
    //                //    continue;
    //                //}
    //                //else if (currentRemainingCounters[0] > lastRemainingCounters[0] ||
    //                //    currentRemainingCounters[1] > lastRemainingCounters[1] ||
    //                //    currentRemainingCounters[2] > lastRemainingCounters[2] ||
    //                //    currentRemainingCounters[3] > lastRemainingCounters[3])
    //                //{
    //                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Current Notes Count > Last Notes Count");

    //                //    //Get post withdrawals.
    //                //    if (repReader.CurrentReplenishment != null)
    //                //    {
    //                //        if (repReader.CurrentReplenishment.RepDatetime > DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null)
    //                //            || repReader.CurrentReplenishment.RepDatetime.Date == DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).Date)
    //                //        {
    //                //            if (repReader.CurrentReplenishment.CashAdded1 == 0 && repReader.CurrentReplenishment.CashAdded2 == 0
    //                //                && repReader.CurrentReplenishment.CashAdded3 == 0 && repReader.CurrentReplenishment.CashAdded4 == 0)
    //                //            {
    //                //                LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to Analyze transactions");
    //                //                DoAnalyzeTrxn(parts[0], atm.ATMId, ref notesIncreased, ref dataExists);
    //                //                if (dataExists)
    //                //                {
    //                //                    if (notesIncreased)
    //                //                    {

    //                //                        LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to process replenishments");
    //                //                        ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentRemainingCounters[0],
    //                //                         currentRemainingCounters[1], currentRemainingCounters[2], currentRemainingCounters[3], parts[0]);

    //                //                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment Extracted after verifying transactions");
    //                //                    }
    //                //                    else
    //                //                    {
    //                //                        //Comparson failed but transaction analysis has performed.
    //                //                        userTaskReader.CurrentUserTask.Status = ApprovalStatus.Rejected.ToString();
    //                //                        userTaskReader.CurrentUserTask.Save();
    //                //                        ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + userTaskReader.CurrentUserTask.AtmId);
    //                //                    }
    //                //                }
    //                //            }
    //                //            else
    //                //            {
    //                //                userTaskReader.CurrentUserTask.Status = ApprovalStatus.Rejected.ToString();
    //                //                userTaskReader.CurrentUserTask.Save();
    //                //                ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + userTaskReader.CurrentUserTask.AtmId);
    //                //            }
    //                //        }
    //                //        else
    //                //        {
    //                //            LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to analyze transactions");
    //                //            DoAnalyzeTrxn(parts[0], atm.ATMId, ref notesIncreased, ref dataExists);
    //                //            if (dataExists)
    //                //            {
    //                //                if (notesIncreased)
    //                //                {
    //                //                    LogableTask.LogMonoActivityTask("AutoResolveUserTasks", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to process replenishments");
    //                //                    ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentRemainingCounters[0],
    //                //                     currentRemainingCounters[1], currentRemainingCounters[2], currentRemainingCounters[3], parts[0]);

    //                //                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment Extracted after verifying transactions");
    //                //                }
    //                //                else
    //                //                {
    //                //                    //Comparson failed but transaction analysis has performed.
    //                //                    userTaskReader.CurrentUserTask.Status = ApprovalStatus.Rejected.ToString();
    //                //                    userTaskReader.CurrentUserTask.Save();
    //                //                    ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + userTaskReader.CurrentUserTask.AtmId);
    //                //                }
    //                //            }
    //                //        }
    //                //    }
    //                //    else
    //                //    {
    //                //        //Get last and first transaction after replenishment.
    //                //        //                                cmd.CommandText = @"select top 1 cash_remaining1, cash_remaining2,cash_remaining3,cash_remaining4 
    //                //        //                                                    from parsed_transaction 
    //                //        //                                                    where trxn_datetime < convert(datetime,'" + DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atmAlert.AtmId.Value + " order by trxn_datetime desc";

    //                //        //                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //                //        //                                DataTable dtLastTrxn = new DataTable();
    //                //        //                                adapter.Fill(dtLastTrxn);

    //                //        //                                cmd.CommandText = @"select top 1 cash_remaining1, cash_remaining2,cash_remaining3,cash_remaining4 
    //                //        //                                                    from parsed_transaction 
    //                //        //                                                    where trxn_datetime > convert(datetime,'" + DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atmAlert.AtmId.Value + " order by trxn_datetime asc";

    //                //        //                                adapter = new SqlDataAdapter(cmd);
    //                //        //                                DataTable dtFirstTrxn = new DataTable();
    //                //        //                                adapter.Fill(dtFirstTrxn);

    //                //        //                                if (dtFirstTrxn.Rows.Count > 0 && dtLastTrxn.Rows.Count > 0)
    //                //        //                                {
    //                //        //                                    if (int.Parse(dtFirstTrxn.Rows[0][0].ToString()) > int.Parse(dtLastTrxn.Rows[0][0].ToString()) ||
    //                //        //                                        int.Parse(dtFirstTrxn.Rows[0][1].ToString()) > int.Parse(dtLastTrxn.Rows[0][1].ToString()) ||
    //                //        //                                        int.Parse(dtFirstTrxn.Rows[0][2].ToString()) > int.Parse(dtLastTrxn.Rows[0][2].ToString()) ||
    //                //        //                                        int.Parse(dtFirstTrxn.Rows[0][3].ToString()) > int.Parse(dtLastTrxn.Rows[0][3].ToString())
    //                //        //                                        )
    //                //        //                                    {
    //                //        DoAnalyzeTrxn(parts[0], atm.ATMId, ref notesIncreased, ref dataExists);
    //                //        if (dataExists)
    //                //        {
    //                //            if (notesIncreased)
    //                //            {
    //                //                ProcessReplenishment(atmAlert, atm, userTaskReader.CurrentUserTask, currentRemainingCounters[0],
    //                //                 currentRemainingCounters[1], currentRemainingCounters[2], currentRemainingCounters[3], parts[0]);

    //                //                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Replenishment Extracted after verifying transactions");
    //                //            }
    //                //            else
    //                //            {
    //                //                //Comparson failed but transaction analysis has performed.
    //                //                userTaskReader.CurrentUserTask.Status = ApprovalStatus.Rejected.ToString();
    //                //                userTaskReader.CurrentUserTask.Save();
    //                //                ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + userTaskReader.CurrentUserTask.AtmId);
    //                //            }
    //                //        }
    //                //        //                                    }
    //                //        //                              }

    //                //        //rep_datetime in (select max(rep_Datetime) from replenishment where atm_id = " + atmAlert.AtmId.Value);

    //                //    }
    //                //}

    //                ////}

    //            }
    //        }
    //        userTaskReader.Close();
    //    }


    //}
    private static int MakeNumberDivisibleBy10(int number)
    {
        while ((number % 10) != 0)
        {
            number++;
        }
        return number;
    }

    private ServicesDAL.Replenishment ProcessReplenishment(AtmAlert atmAlert, Atm atm,  int counterType1, int counterType2, int counterType3, int counterType4, string alertDatetime, SqlTransaction trxn)
    {
        //        bool isTrxnCommited = false;
        LogableTask task = LogableTask.NewTask("ProcessReplenishments");
        //SqlTransaction trx = null;
        //SqlConnection conn = null;
        try
        {
            //conn = ConnectionFactory.GetNewConnection();
            //conn.Open();
            //trx = conn.BeginTransaction();

            //AtmAlert atmAlert = AtmAlert.LoadAtmAlertByPk(int.Parse(base.Request.QueryString["aid"]));
            //Atm atm = Atm.LoadAtmByPk(atmAlert.AtmId.Value);
            NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
            ServicesDAL.Replenishment replenishment;
            AtmAlert atmAlert1;


            //if (atmAlert.AlertTypeId == (int)EnumAlertType.AddCashReplenishmentDetected)
            //{
            replenishment = new ServicesDAL.Replenishment
            {
                AtmId = atm.ATMId,
                RepDatetime = DateTime.ParseExact(alertDatetime, "MM/dd/yyyy HH:mm:ss", null),
                CashAdded1 = MakeNumberDivisibleBy10(counterType1),
                CashAdded2 = MakeNumberDivisibleBy10(counterType2),
                CashAdded3 = MakeNumberDivisibleBy10(counterType3),
                CashAdded4 = MakeNumberDivisibleBy10(counterType4),
                CashAdded5 = 0,
                CashAdded6 = 0,
                CashAdded7 = 0,
                RepStatus = "OrderMissing",
                IsSwap = true,
                TaskId = atmAlert.TaskId.Value,
                CashOrderId = -1,
            };
            //}
            //else
            //{
            //    replenishment = new Avanza.CCMS.DAL.Replenishment
            //    {
            //        AtmId = atm.ATMId,
            //        RepDatetime = DateTime.ParseExact(this.Label_date.Text, "dd/MM/yyyy HH:mm:ss", null),
            //        CashAdded1 = MakeNumberDivisibleBy10(int.Parse(this.Label_CurrentTotalType1.Text)),
            //        CashAdded2 = MakeNumberDivisibleBy10(int.Parse(this.Label_CurrentTotalType2.Text)),
            //        CashAdded3 = MakeNumberDivisibleBy10(int.Parse(this.Label_CurrentTotalType3.Text)),
            //        CashAdded4 = MakeNumberDivisibleBy10(int.Parse(this.Label_CurrentTotalType4.Text)),
            //        CashAdded5 = 0,
            //        CashAdded6 = 0,
            //        CashAdded7 = 0,
            //        RepStatus = "OrderMissing",
            //        IsSwap = (this.RadioButtonList_RepType.SelectedIndex == 0) ? false : true,
            //        TaskId = atmAlert.TaskId.Value,
            //        CashOrderId = -1,
            //    };
            //}
            replenishment.Save(trxn.Connection, trxn);


            AlertManager.GenerateTerminalAlert(atm.ATMId, (int)EnumAlertType.ReplenishmentAtATM, "Repenishment At ATM", trxn, Event_Type.Information, atmAlert.TaskId.Value, replenishment.ReplenishmentId, "Replenishment");

            //if (this.CheckBox_PurgeBinThreshold.Checked && replenishment.IsSwap)
            //{
            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch purge bin alert for atm_id = " + atm.ATMId);
            atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 0x16, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
            if (atmAlert1 != null)
            {
                atmAlert1.ResolveAt = new DateTime?(DateTime.Now);
                atmAlert1.Save(trxn.Connection, trxn);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert resolved for atm_id = " + atm.ATMId);
               // CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                //if (ccmsIntAlert != null)
                //{

                //    //cmd = conn.CreateCommand();
                //    //cmd.Transaction = trx;
                //    cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                //    cmd.ExecuteNonQuery();

                //    //ccmsIntAlert.ResolvedAt = DateTime.Now;
                //    //ccmsIntAlert.Save(trxn.Connection, trxn);
                //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                //}
            }
            //            }
            decimal replenishedAmount = (decimal)(replenishment.CashAdded1 * noteSetType.DenominationType1 +
                replenishment.CashAdded2 * noteSetType.DenominationType2 +
                replenishment.CashAdded3 * noteSetType.DenominationType3 +
                replenishment.CashAdded4 * noteSetType.DenominationType4 +
                replenishment.CashAdded5 * noteSetType.DenominationType5 +
                replenishment.CashAdded6 * noteSetType.DenominationType6 +
                replenishment.CashAdded7 * noteSetType.DenominationType7);


            if (replenishedAmount > atm.MinOperatingBalance)
            {
                atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 0x15, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
                if (atmAlert1 != null)
                {
                    atmAlert1.ResolveAt = DateTime.Now;
                    atmAlert1.Save(trxn.Connection, trxn);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert resolved for atm_id = " + atm.ATMId);
                    //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                    //if (ccmsIntAlert != null)
                    //{
                    //    //ccmsIntAlert.ResolvedAt = DateTime.Now;
                    //    //ConnectionFactory.ExecuteQuery("update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id,trxn);
                    //    //cmd = conn.CreateCommand();
                    //    //cmd.Transaction = trx;
                    //    cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                    //    cmd.ExecuteNonQuery();
                    //    //ccmsIntAlert.Save(conn,trxn);
                    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                    //}
                }
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch low balance alert for atm_id = " + atm.ATMId);
                atmAlert1 = AtmAlert.LoadAtmAlert(string.Concat(new object[] { "alert_type_id=", 20, " and atm_id=", atm.ATMId, " and resolve_at is null" }));
                if (atmAlert1 != null)
                {
                    atmAlert1.ResolveAt = DateTime.Now;
                    atmAlert1.Save(trxn.Connection, trxn);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert resolved for atm_id = " + atm.ATMId);
                    //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert1.AtmAlertId);
                    //if (ccmsIntAlert != null)
                    //{
                    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Transaction Object is null=" + (trxn.Connection == null ? "true" : "false"));


                    //    //ConnectionFactory.ExecuteQuery("update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id, trxn);
                    //    //cmd = conn.CreateCommand();
                    //    //cmd.Transaction = trx;
                    //    cmd.CommandText = "update Ccms_integrated_alert set resolved_at= convert(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103) where id=" + ccmsIntAlert.Id;
                    //    cmd.ExecuteNonQuery();


                    //    //ccmsIntAlert.ResolvedAt = DateTime.Now;
                    //    //ccmsIntAlert.Save(conn, trxn);
                    //    // ccmsIntAlert.Save(trxn.Connection, trxn);
                    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                    //}

                }
            }
            //Avanza.CCMS.DAL.UserTask userTask = Avanza.CCMS.DAL.UserTask.LoadUserTaskByPk(int.Parse(base.Request.QueryString["tid"]));
            //userTask.Status = ApprovalStatus.Approved.ToString();
            //userTask.Save(trxn.Connection, trxn);
            //trx.Commit();
            //isTrxnCommited = true;
            ConnectionFactory.ExecuteQuery("update atm set is_dff_generation_halt = 0 where atm_id = " + atm.ATMId, trxn);
            return replenishment;


        }
        catch (Exception ex)
        {
            //if (!isTrxnCommited)
            //    trx.Rollback();

            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            throw;
        }
        finally
        {
            //if (conn != null)
            //    conn.Close();
            task.EndTask();
        }
    }

    public bool BuildSummary(LogableTask task, List<long> reqATMs, bool? executingForOneATM, bool deleteOldData, bool enableDFFGeneration)
    {

        listDFFHelper = new List<DFFVersion2Helper>();
        footerCount = 0;
        List<long> AtmIds = new List<long>();
        SqlDataReader reader = null;

        try
        {
            cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
            cmd.CommandTimeout = 20 * 60;
            //trxn = cmd.Connection.BeginTransaction();
            //cmd.Transaction = trxn;
            // task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to resolve user task automatically.");
            //AutoResolveUserTasks(cmd, trxn,task);

            if (executingForOneATM.HasValue)
                cmd.CommandText = "delete summary where trxn_datetime =convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) and atm_id=" + reqATMs[0];
            else
            {
                if (deleteOldData)
                    cmd.CommandText = "delete summary where trxn_datetime =convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)";

            }
            if (cmd.CommandText.Length > 0)
                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, cmd.ExecuteNonQuery() + " Row(s) deleted from summary table for the Day " + Day.ToString("dd/MM/yyyy"));




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDistinctAtmID";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";




            //            cmd.CommandText = string.Format(@"select distinct atm_id 
            //                            from parsed_transaction 
            //                            where trxn_datetime >=convert(datetime,'{0}',103) 
            //                            and trxn_datetime<=convert(datetime,'{1}',103)",
            //                                Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
            reader = cmd.ExecuteReader();
            long id = -1;
            while (reader.Read())
            {
                id = reader.GetInt64(0);
                if (reqATMs.Contains(id))
                    AtmIds.Add(id);
            }
            reader.Close();

            //done to catch at least replenishment data if trxns are missing.
            cmd.CommandText = "GetDistinctAtmIDForRep";

            //            cmd.CommandText = string.Format(@"select distinct atm_id 
            //                            from replenishment 
            //                            where rep_datetime >=convert(datetime,'{0}',103) 
            //                            and rep_datetime<=convert(datetime,'{1}',103)",
            //                                      Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt64(0);
                if (reqATMs.Contains(id))
                {
                    if (!AtmIds.Contains(id))
                        AtmIds.Add(id);
                }

            }
            reader.Close();
            RevertCommandObjToRunTextQuery();
            atmCount = reqATMs.Count;
            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "ATMs in queue:" + reqATMs.Count);




            for (int i = 0; i < AtmIds.Count; i++)
            {
                dateModified = false;
                oldMaxRepDate = new DateTime(1900, 1, 1);
                atm_id = AtmIds[i];
                //Commented on 31/01/2014
                atm = Atm.LoadAtmByPk(atm_id);
                //if (atm == null)
                //{
                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "atm defination is absent" + atm_id);
                //    continue;
                //} //throw new Exception("atm defination is absent" + atm_id);

                //if (!atm.IsActive)
                //{
                //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Inactive ATM found so ignoring it:" + atm.Title);
                //    continue;
                //}
                //if (enableDFFGeneration)
                //{
                //    if (atm.IsDffGenerationHalt.HasValue)
                //    {
                //        if (atm.IsDffGenerationHalt.Value)
                //        {
                //            atm.IsDffGenerationHalt = false;
                //            atm.Save(trxn.Connection, trxn);
                //            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "DFF generation enabled:" + atm.Title);
                //        }
                //    }

                //}

                //Commented on 31/01/2014
                //if (atm.IsDffGenerationHalt.HasValue)
                //{
                //    if (atm.IsDffGenerationHalt.Value)
                //    {
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "DFF generation halted so ignoring it:" + atm.Title);
                //        continue;
                //    }
                //}

                //Commented on 31/01/2014
                //if (atm.ExcludeDff.HasValue)
                //{
                //    if (atm.ExcludeDff.Value)
                //    {
                //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Excluding DFF flag is set so ignoring it:" + atm.Title);
                //        continue;
                //    }
                //}

                Summary existingSummary = Summary.LoadSummary("atm_id=" + atm.ATMId + " and trxn_datetime=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)");
                if (existingSummary != null)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Summary already exists for ATM " + atm.Title + " so ignoring it");
                    continue;
                }


                noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                if (noteSetType == null)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Note Set Type does not exists" + atm_id);
                    continue;
                    //throw new Exception("Note Set Type does not exists" + atm_id);
                }

                try
                {
                    dFFVersion2Helper = new DFFVersion2Helper();
                    dFFVersion2Helper.title = atm.Title;
                    StartGeneration(task, atm_id);
                    listDFFHelper.Add(dFFVersion2Helper);
                    footerCount++;

                }
                catch (Exception ex)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                }
            }

            for (int i = 0; i < reqATMs.Count; i++)
            {
                try
                {

                    if (!AtmIds.Contains(reqATMs[i]))
                    {
                        dateModified = false;
                        oldMaxRepDate = new DateTime(1900, 1, 1);
                        atm_id = reqATMs[i];
                        atm = Atm.LoadAtmByPk(atm_id);
                        //Commented on 31/01/2014
                        //if (atm == null)
                        //{
                        //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Warning, "atm defination is absent" + atm_id);
                        //    //throw new Exception("atm defination is absent" + atm_id);
                        //    continue;
                        //}
                        //if (!atm.IsActive)
                        //{
                        //    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Inactive ATM found so ignoring it:" + atm.Title);
                        //    continue;
                        //}
                        //if (enableDFFGeneration)
                        //{
                        //    if (atm.IsDffGenerationHalt.HasValue)
                        //    {
                        //        if (atm.IsDffGenerationHalt.Value)
                        //        {
                        //            atm.IsDffGenerationHalt = false;
                        //            atm.Save(trxn.Connection, trxn);
                        //            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "DFF generation enabled:" + atm.Title);
                        //        }
                        //    }

                        //}


                        //if (atm.IsDffGenerationHalt.HasValue)
                        //{
                        //    if (atm.IsDffGenerationHalt.Value)
                        //    {
                        //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "DFF generation halted so ignoring it:" + atm.Title);
                        //        continue;
                        //    }
                        //}

                        //if (atm.ExcludeDff.HasValue)
                        //{
                        //    if (atm.ExcludeDff.Value)
                        //    {
                        //        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Excluding DFF flag is set so ignoring it:" + atm.Title);
                        //        continue;
                        //    }
                        //}

                        noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                        if (noteSetType == null)
                        {
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Note Set Type does not exists" + atm_id);
                            continue;

                        }
                        footerCount++;
                        dFFVersion2Helper = new DFFVersion2Helper();
                        dFFVersion2Helper.title = atm.Title;
                        ConstructFakeOutput(task);
                        listDFFHelper.Add(dFFVersion2Helper);
                    }
                }
                catch (Exception ex)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                }
            }
            //trxn.Commit();
        }
        catch (Exception ex)
        {
            //if (trxn != null)
            //    trxn.Rollback();
            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            throw;
        }
        finally
        {
            if (reader != null)
                reader.Close();
            //comment if DFF version2 is needed.
            if (cmd.Connection != null)
                cmd.Connection.Close();
        }
        return true;

    }

    private int GetLastReplenishmentCount()
    {
        List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[ReplenishmentByDay.Count - 1];
        // need to check whether the last entry has max data
        if (replenishmentsForOneDay == null)
            return 0;
        else
            return replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalCount();
    }

    private string GetActualReplenishedNotes(DateTime dt)
    {
        Replenishment replenishment = null;
        //decimal replenishmentAmount = 0;
        List<int> replenishmentType = new List<int>(); // to track whether replenishment is add or swap
        List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
        if (replenishmentsForOneDay == null)
            return "0|0|0|0|0|0|0";

        if (replenishmentsForOneDay.Count == 1)
        {
            replenishment = replenishmentsForOneDay[0];


            //*************

            //            if (!replenishment.isSwap)
            //            {
            //                cmd.CommandText = @"select replenishment_id 
            //                        from replenishment where rep_datetime in 
            //                        (select max(rep_datetime) from replenishment 
            //                         where atm_id = " + atm_id
            //                   + " and rep_datetime < convert(datetime,'" + replenishment.replenishmentDateTime.ToString("dd/MM/yyyy") + " 00:00:00',103))";
            //                object obj = cmd.ExecuteScalar();

            //                //null : when first time system is deployed.
            //                if (obj != DBNull.Value) //no replenishment
            //                {
            //                    Avanza.CCMS.DAL.Replenishment lastReplenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(obj.ToString()));
            //                    replenishment.cashAdded1 += lastReplenishment.CashAdded1;
            //                    replenishment.cashAdded2 += lastReplenishment.CashAdded2;
            //                    replenishment.cashAdded3 += lastReplenishment.CashAdded3;
            //                    replenishment.cashAdded4 += lastReplenishment.CashAdded4;
            //                    replenishment.cashAdded5 += lastReplenishment.CashAdded5;
            //                    replenishment.cashAdded6 += lastReplenishment.CashAdded6;
            //                    replenishment.cashAdded7 += lastReplenishment.CashAdded7;

            //                }
            //                else
            //                {

            //                }

            //            }
            //*************
            return replenishment.actualCashAdded1 + "|" +
               replenishment.actualCashAdded2 + "|" +
               replenishment.actualCashAdded3 + "|" +
               replenishment.actualCashAdded4 + "|" +
               replenishment.actualCashAdded5 + "|" +
               replenishment.actualCashAdded6 + "|" +
               replenishment.actualCashAdded7;


        }
        else
        {

            for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            {
                replenishment = replenishmentsForOneDay[counter];
                if (replenishmentsForOneDay[counter].isSwap)
                    replenishmentType.Add(1);
                else
                    replenishmentType.Add(2);
            }



            if (!replenishmentType.Contains(2)) //swap 
            {

                replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];

                return replenishment.cashAdded1 + "|" +
        replenishment.cashAdded2 + "|" +
        replenishment.cashAdded3 + "|" +
        replenishment.cashAdded4 + "|" +
        replenishment.cashAdded5 + "|" +
        replenishment.cashAdded6 + "|" +
        replenishment.cashAdded7;
                //replenishmentAmount = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
            }

            else if (!replenishmentType.Contains(1)) //add
            {
                int[] rep = new int[7];
                foreach (Replenishment _replenishment in replenishmentsForOneDay)
                {
                    rep[0] += _replenishment.cashAdded1;
                    rep[1] += _replenishment.cashAdded2;
                    rep[2] += _replenishment.cashAdded3;
                    rep[3] += _replenishment.cashAdded4;
                    rep[4] += _replenishment.cashAdded5;
                    rep[5] += _replenishment.cashAdded6;
                    rep[6] += _replenishment.cashAdded7;

                    // replenishmentAmount += rep.GetTotalAmount();
                }
                return rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];
            }
            else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            {
                if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last {
                {
                    replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];

                    return replenishment.cashAdded1 + "|" +
            replenishment.cashAdded2 + "|" +
            replenishment.cashAdded3 + "|" +
            replenishment.cashAdded4 + "|" +
            replenishment.cashAdded5 + "|" +
            replenishment.cashAdded6 + "|" +
            replenishment.cashAdded7;

                    //                    replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
                }


                if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
                {
                    int index = replenishmentType.LastIndexOf(1);
                    int[] rep = new int[7];

                    for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
                    {
                        replenishment = replenishmentsForOneDay[counter];
                        rep[0] += replenishment.cashAdded1;
                        rep[1] += replenishment.cashAdded2;
                        rep[2] += replenishment.cashAdded3;
                        rep[3] += replenishment.cashAdded4;
                        rep[4] += replenishment.cashAdded5;
                        rep[5] += replenishment.cashAdded6;
                        rep[6] += replenishment.cashAdded7;

                    }
                    return rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];

                }
            }





            //for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            //{
            //    Replenishment replenishment = replenishmentsForOneDay[counter];
            //    //replenishmentAmount += replenishment.GetTotalAmount();

            //    if (replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalCount() % 100 == 0)
            //        replenishmentType.Add(1);

            //    else if (((Math.Abs(replenishment.GetTotalCount() - GetLastReplenishmentCount())) % 100) == 0)
            //        replenishmentType.Add(2);
            //    else
            //        replenishmentType.Add(1);
            //}
            //if (!replenishmentType.Contains(2)) //swap
            //    return replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();

            //else if (!replenishmentType.Contains(1)) //add
            //{
            //    foreach (Replenishment rep in replenishmentsForOneDay)
            //        replenishmentAmount += rep.GetTotalAmount();

            //}
            //else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            //{
            //    if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last
            //        replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();

            //    if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
            //    {
            //        int index = replenishmentType.LastIndexOf("1");
            //        for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
            //            replenishmentAmount += replenishmentsForOneDay[counter].GetTotalAmount();
            //    }
            //}
        }
        return null;

    }

    private string GetReplenishmentAmountInTermsOfNotes(DateTime dt)
    {
        string result = null;
        Replenishment replenishment = null;
        //decimal replenishmentAmount = 0;
        List<int> replenishmentType = new List<int>(); // to track whether replenishment is add or swap
        List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
        if (replenishmentsForOneDay == null)
            result = "0|0|0|0|0|0|0";

        else if (replenishmentsForOneDay.Count == 1)
        {
            replenishment = replenishmentsForOneDay[0];
            isAddCashOnCurrentDay = !replenishment.isSwap;

            result = replenishment.cashAdded1 + "|" + replenishment.cashAdded2 + "|" + replenishment.cashAdded3 + "|" +
                   replenishment.cashAdded4 + "|" + replenishment.cashAdded5 + "|" + replenishment.cashAdded6 + "|" +
                   replenishment.cashAdded7;

        }
        else
        {
            for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            {
                replenishment = replenishmentsForOneDay[counter];
                if (replenishmentsForOneDay[counter].isSwap)
                    replenishmentType.Add(1);
                else
                {
                    replenishmentType.Add(2);
                    isAddCashOnCurrentDay = !replenishment.isSwap;
                }

            }



            if (!replenishmentType.Contains(2)) //swap 
            {
                replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];
                isAddCashOnCurrentDay = false;
                result = replenishment.cashAdded1 + "|" + replenishment.cashAdded2 + "|" + replenishment.cashAdded3 + "|" +
        replenishment.cashAdded4 + "|" + replenishment.cashAdded5 + "|" + replenishment.cashAdded6 + "|" +
        replenishment.cashAdded7;
                //replenishmentAmount = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
            }

            else if (!replenishmentType.Contains(1)) //add
            {
                int[] rep = new int[7];
                isAddCashOnCurrentDay = true;
                foreach (Replenishment _replenishment in replenishmentsForOneDay)
                {
                    rep[0] += _replenishment.cashAdded1;
                    rep[1] += _replenishment.cashAdded2;
                    rep[2] += _replenishment.cashAdded3;
                    rep[3] += _replenishment.cashAdded4;
                    rep[4] += _replenishment.cashAdded5;
                    rep[5] += _replenishment.cashAdded6;
                    rep[6] += _replenishment.cashAdded7;

                    // replenishmentAmount += rep.GetTotalAmount();
                }
                result = rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];
            }
            else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            {
                isAddCashOnCurrentDay = false;
                if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last {
                {
                    replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];

                    result = replenishment.cashAdded1 + "|" + replenishment.cashAdded2 + "|" + replenishment.cashAdded3 + "|" +
            replenishment.cashAdded4 + "|" + replenishment.cashAdded5 + "|" + replenishment.cashAdded6 + "|" +
            replenishment.cashAdded7;
                }


                else if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
                {
                    int index = replenishmentType.LastIndexOf(1);
                    int[] rep = new int[7];

                    for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
                    {
                        replenishment = replenishmentsForOneDay[counter];
                        rep[0] += replenishment.cashAdded1;
                        rep[1] += replenishment.cashAdded2;
                        rep[2] += replenishment.cashAdded3;
                        rep[3] += replenishment.cashAdded4;
                        rep[4] += replenishment.cashAdded5;
                        rep[5] += replenishment.cashAdded6;
                        rep[6] += replenishment.cashAdded7;

                    }
                    result = rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];

                }
            }

            //Replenishment replenishment = null;
            ////decimal replenishmentAmount = 0;
            //List<int> replenishmentType = new List<int>(); // to track whether replenishment is add or swap
            //List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
            //if (replenishmentsForOneDay == null)
            //    return "0|0|0|0|0|0|0";

            //if (replenishmentsForOneDay.Count == 1)
            //{
            //    replenishment = replenishmentsForOneDay[0];


            //    //*************

            //    //            if (!replenishment.isSwap)
            //    //            {
            //    //                cmd.CommandText = @"select replenishment_id 
            //    //                        from replenishment where rep_datetime in 
            //    //                        (select max(rep_datetime) from replenishment 
            //    //                         where atm_id = " + atm_id
            //    //                   + " and rep_datetime < convert(datetime,'" + replenishment.replenishmentDateTime.ToString("dd/MM/yyyy") + " 00:00:00',103))";
            //    //                object obj = cmd.ExecuteScalar();

            //    //                //null : when first time system is deployed.
            //    //                if (obj != DBNull.Value) //no replenishment
            //    //                {
            //    //                    Avanza.CCMS.DAL.Replenishment lastReplenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(obj.ToString()));
            //    //                    replenishment.cashAdded1 += lastReplenishment.CashAdded1;
            //    //                    replenishment.cashAdded2 += lastReplenishment.CashAdded2;
            //    //                    replenishment.cashAdded3 += lastReplenishment.CashAdded3;
            //    //                    replenishment.cashAdded4 += lastReplenishment.CashAdded4;
            //    //                    replenishment.cashAdded5 += lastReplenishment.CashAdded5;
            //    //                    replenishment.cashAdded6 += lastReplenishment.CashAdded6;
            //    //                    replenishment.cashAdded7 += lastReplenishment.CashAdded7;

            //    //                }
            //    //                else
            //    //                {

            //    //                }

            //    //            }
            //    //*************
            //    return replenishment.cashAdded1 + "|" +
            //       replenishment.cashAdded2 + "|" +
            //       replenishment.cashAdded3 + "|" +
            //       replenishment.cashAdded4 + "|" +
            //       replenishment.cashAdded5 + "|" +
            //       replenishment.cashAdded6 + "|" +
            //       replenishment.cashAdded7;


            //}
            //else
            //{

            //    for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            //    {
            //        replenishment = replenishmentsForOneDay[counter];
            //        if (replenishmentsForOneDay[counter].isSwap)
            //            replenishmentType.Add(1);
            //        else
            //            replenishmentType.Add(2);
            //    }



            //    if (!replenishmentType.Contains(2)) //swap 
            //    {

            //        replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];

            //        return replenishment.cashAdded1 + "|" +
            //replenishment.cashAdded2 + "|" +
            //replenishment.cashAdded3 + "|" +
            //replenishment.cashAdded4 + "|" +
            //replenishment.cashAdded5 + "|" +
            //replenishment.cashAdded6 + "|" +
            //replenishment.cashAdded7;
            //        //replenishmentAmount = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
            //    }

            //    else if (!replenishmentType.Contains(1)) //add
            //    {
            //        int[] rep = new int[7];
            //        foreach (Replenishment _replenishment in replenishmentsForOneDay)
            //        {
            //            rep[0] += _replenishment.cashAdded1;
            //            rep[1] += _replenishment.cashAdded2;
            //            rep[2] += _replenishment.cashAdded3;
            //            rep[3] += _replenishment.cashAdded4;
            //            rep[4] += _replenishment.cashAdded5;
            //            rep[5] += _replenishment.cashAdded6;
            //            rep[6] += _replenishment.cashAdded7;

            //            // replenishmentAmount += rep.GetTotalAmount();
            //        }
            //        return rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];
            //    }
            //    else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            //    {
            //        if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last {
            //        {
            //            replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];

            //            return replenishment.cashAdded1 + "|" +
            //    replenishment.cashAdded2 + "|" +
            //    replenishment.cashAdded3 + "|" +
            //    replenishment.cashAdded4 + "|" +
            //    replenishment.cashAdded5 + "|" +
            //    replenishment.cashAdded6 + "|" +
            //    replenishment.cashAdded7;

            //            //                    replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
            //        }


            //        if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
            //        {
            //            int index = replenishmentType.LastIndexOf(1);
            //            int[] rep = new int[7];

            //            for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
            //            {
            //                replenishment = replenishmentsForOneDay[counter];
            //                rep[0] += replenishment.cashAdded1;
            //                rep[1] += replenishment.cashAdded2;
            //                rep[2] += replenishment.cashAdded3;
            //                rep[3] += replenishment.cashAdded4;
            //                rep[4] += replenishment.cashAdded5;
            //                rep[5] += replenishment.cashAdded6;
            //                rep[6] += replenishment.cashAdded7;

            //            }
            //            return rep[0] + "|" + rep[1] + "|" + rep[2] + "|" + rep[3] + "|" + rep[4] + "|" + rep[5] + "|" + rep[6];

            //        }
            //    }





            //    //for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            //    //{
            //    //    Replenishment replenishment = replenishmentsForOneDay[counter];
            //    //    //replenishmentAmount += replenishment.GetTotalAmount();

            //    //    if (replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalCount() % 100 == 0)
            //    //        replenishmentType.Add(1);

            //    //    else if (((Math.Abs(replenishment.GetTotalCount() - GetLastReplenishmentCount())) % 100) == 0)
            //    //        replenishmentType.Add(2);
            //    //    else
            //    //        replenishmentType.Add(1);
            //    //}
            //    //if (!replenishmentType.Contains(2)) //swap
            //    //    return replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();

            //    //else if (!replenishmentType.Contains(1)) //add
            //    //{
            //    //    foreach (Replenishment rep in replenishmentsForOneDay)
            //    //        replenishmentAmount += rep.GetTotalAmount();

            //    //}
            //    //else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            //    //{
            //    //    if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last
            //    //        replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();

            //    //    if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
            //    //    {
            //    //        int index = replenishmentType.LastIndexOf("1");
            //    //        for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
            //    //            replenishmentAmount += replenishmentsForOneDay[counter].GetTotalAmount();
            //    //    }
            //    //}
            //}
            //return null;
        }
        return result;
    }

    private decimal GetReplenishmentAmount(DateTime dt)
    {
        decimal replenishmentAmount = 0;
        List<int> replenishmentType = new List<int>(); // to track whether replenishment is add or swap
        List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
        Replenishment replenishment = null;
        if (replenishmentsForOneDay == null)
            return 0;

        if (replenishmentsForOneDay.Count == 1)
        {
            replenishment = replenishmentsForOneDay[0];
            isAddCashOnCurrentDay = !replenishment.isSwap;
            replenishmentAmount = replenishment.GetTotalAmount();
            if (replenishmentAmount == 0)
                throw new Exception("Replenishment with all zero counters posted for the machine " + atm.Title + " for the day " + replenishment.replenishmentDateTime.ToString());
            else
                return replenishmentAmount;
        }
        else
        {
            for (int counter = 0; counter < replenishmentsForOneDay.Count; counter++)
            {
                replenishment = replenishmentsForOneDay[counter];
                if (replenishmentsForOneDay[counter].isSwap)
                    replenishmentType.Add(1);
                else
                    replenishmentType.Add(2);
            }
            if (!replenishmentType.Contains(2)) //swap 
            {
                replenishmentAmount = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();
                isAddCashOnCurrentDay = false;
            }
            else if (!replenishmentType.Contains(1)) //add
            {
                foreach (Replenishment rep in replenishmentsForOneDay)
                    replenishmentAmount += rep.GetTotalAmount();
                isAddCashOnCurrentDay = true;
            }
            else if (replenishmentType.Contains(1) && replenishmentType.Contains(2))
            {
                if ((int)replenishmentType[replenishmentType.Count - 1] == 1) //swap last
                    replenishmentAmount = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].GetTotalAmount();

                if ((int)replenishmentType[replenishmentType.Count - 1] == 2) //add last
                {
                    int index = replenishmentType.LastIndexOf(1);
                    for (int counter = index; counter < replenishmentsForOneDay.Count; counter++)
                        replenishmentAmount += replenishmentsForOneDay[counter].GetTotalAmount();
                }
            }
            if (replenishmentAmount == 0)
                throw new Exception("Replenishment with all zero counters posted for the machine " + atm.Title + " for the day " + replenishment.replenishmentDateTime.ToString());
        }
        return replenishmentAmount;

    }

    private void ExtractDayWiseReplenishment()
    {
        List<Replenishment> replenishmentList = new List<Replenishment>();

        ServicesDAL.Replenishment.ReplenishmentReader reader = ServicesDAL.Replenishment.ExecuteReader("atm_id =" + atm_id + " and rep_datetime>=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 00:00:00',103) and rep_datetime<=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103) order by rep_datetime");
        try
        {
            while (reader.Read())
            {
                Replenishment replenishment = new Replenishment(
                                    reader.CurrentReplenishment.CashAdded1,
                                    reader.CurrentReplenishment.CashAdded2,
                                    reader.CurrentReplenishment.CashAdded3,
                                    reader.CurrentReplenishment.CashAdded4,
                                    reader.CurrentReplenishment.CashAdded5,
                                    reader.CurrentReplenishment.CashAdded6,
                                    reader.CurrentReplenishment.CashAdded7,
                                    noteSetType.DenominationType1.Value, noteSetType.DenominationType2.Value,
                                    noteSetType.DenominationType3.Value,
                                    noteSetType.DenominationType4.Value,
                                    noteSetType.DenominationType5.Value,
                                    noteSetType.DenominationType6.Value,
                                    noteSetType.DenominationType7.Value, reader.CurrentReplenishment.IsSwap, reader.CurrentReplenishment.RepDatetime);
                replenishmentList.Add(replenishment);
            }
            reader.Close();
            //            if (replenishmentList.Count == 1)
            //            {
            //                Replenishment rep = (Replenishment)replenishmentList[0];
            //                if (!rep.isSwap)
            //                {

            //                    cmd.CommandText = @"select replenishment_id 
            //                        from replenishment where rep_datetime in 
            //                        (select max(rep_datetime) from replenishment 
            //                         where atm_id = " + atm_id
            //                       + " and rep_datetime < convert(datetime,'" + rep.replenishmentDateTime.ToString("dd/MM/yyyy") + " 00:00:00',103))";
            //                    object obj = cmd.ExecuteScalar();

            //                    //null : when first time system is deployed.
            //                    if (obj != null) //no replenishment
            //                    {

            //                        Avanza.CCMS.DAL.Replenishment lastReplenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(obj.ToString()));
            //                        if (rep.replenishmentDateTime.ToString("dd/MM/yyyy") != lastReplenishment.RepDatetime.ToString("dd/MM/yyyy"))
            //                        {
            //                            rep.lastReplenishmentDateTime = lastReplenishment.RepDatetime;
            //                            rep.lastCashAdded1 = lastReplenishment.CashAdded1;
            //                            rep.lastCashAdded2 = lastReplenishment.CashAdded2;
            //                            rep.lastCashAdded3 = lastReplenishment.CashAdded3;
            //                            rep.lastCashAdded4 = lastReplenishment.CashAdded4;
            //                            rep.lastCashAdded5 = lastReplenishment.CashAdded5;
            //                            rep.lastCashAdded6 = lastReplenishment.CashAdded6;
            //                            rep.lastCashAdded7 = lastReplenishment.CashAdded7;
            //                        }

            //                        rep.cashAdded1 += lastReplenishment.CashAdded1;
            //                        rep.cashAdded2 += lastReplenishment.CashAdded2;
            //                        rep.cashAdded3 += lastReplenishment.CashAdded3;
            //                        rep.cashAdded4 += lastReplenishment.CashAdded4;
            //                        rep.cashAdded5 += lastReplenishment.CashAdded5;
            //                        rep.cashAdded6 += lastReplenishment.CashAdded6;
            //                        rep.cashAdded7 += lastReplenishment.CashAdded7;


            //                    }
            //                    else
            //                    {

            //                    }
            //                }
            //            }
            if (replenishmentList.Count > 0)
                ReplenishmentByDay.Add(Day, replenishmentList);
        }
        catch (Exception ex)
        {
            if (reader != null)
                reader.Close();
            throw ex;
        }

    }

    private void ExtractDayWiseReplenishment(DateTime dt)
    {
        List<Replenishment> replenishmentList = new List<Replenishment>();
        //ReplenishmentByDay = new Hashtable();
        ServicesDAL.Replenishment.ReplenishmentReader reader = ServicesDAL.Replenishment.ExecuteReader("atm_id =" + atm_id + " and rep_datetime>=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + " 00:00:00',103) and rep_datetime<=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + " 23:59:59',103)");
        try
        {
            while (reader.Read())
            {
                Replenishment replenishment = new Replenishment(
                                    reader.CurrentReplenishment.CashAdded1,
                                    reader.CurrentReplenishment.CashAdded2,
                                    reader.CurrentReplenishment.CashAdded3,
                                    reader.CurrentReplenishment.CashAdded4,
                                    reader.CurrentReplenishment.CashAdded5,
                                    reader.CurrentReplenishment.CashAdded6,
                                    reader.CurrentReplenishment.CashAdded7,
                                    noteSetType.DenominationType1.Value, noteSetType.DenominationType2.Value,
                                    noteSetType.DenominationType3.Value,
                                    noteSetType.DenominationType4.Value,
                                    noteSetType.DenominationType5.Value,
                                    noteSetType.DenominationType6.Value,
                                    noteSetType.DenominationType7.Value, reader.CurrentReplenishment.IsSwap, reader.CurrentReplenishment.RepDatetime);
                replenishmentList.Add(replenishment);
            }
            reader.Close();
            //            if (replenishmentList.Count == 1)
            //            {
            //                Replenishment rep = (Replenishment)replenishmentList[0];
            //                if (!rep.isSwap)
            //                {
            //                    cmd.CommandText = @"select replenishment_id 
            //                        from replenishment where rep_datetime in 
            //                        (select max(rep_datetime) from replenishment 
            //                         where atm_id = " + atm_id
            //                       + " and rep_datetime < convert(datetime,'" + rep.replenishmentDateTime.ToString("dd/MM/yyyy") + " 00:00:00',103))";
            //                    object obj = cmd.ExecuteScalar();

            //                    //null : when first time system is deployed.
            //                    if (obj != null) //no replenishment
            //                    {

            //                        Avanza.CCMS.DAL.Replenishment lastReplenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(obj.ToString()));
            //                        if (rep.replenishmentDateTime.ToString("dd/MM/yyyy") != lastReplenishment.RepDatetime.ToString("dd/MM/yyyy"))
            //                        {
            //                            rep.lastReplenishmentDateTime = lastReplenishment.RepDatetime;
            //                            rep.lastCashAdded1 = lastReplenishment.CashAdded1;
            //                            rep.lastCashAdded2 = lastReplenishment.CashAdded2;
            //                            rep.lastCashAdded3 = lastReplenishment.CashAdded3;
            //                            rep.lastCashAdded4 = lastReplenishment.CashAdded4;
            //                            rep.lastCashAdded5 = lastReplenishment.CashAdded5;
            //                            rep.lastCashAdded6 = lastReplenishment.CashAdded6;
            //                            rep.lastCashAdded7 = lastReplenishment.CashAdded7;
            //                        }

            //                        rep.cashAdded1 += lastReplenishment.CashAdded1;
            //                        rep.cashAdded2 += lastReplenishment.CashAdded2;
            //                        rep.cashAdded3 += lastReplenishment.CashAdded3;
            //                        rep.cashAdded4 += lastReplenishment.CashAdded4;
            //                        rep.cashAdded5 += lastReplenishment.CashAdded5;
            //                        rep.cashAdded6 += lastReplenishment.CashAdded6;
            //                        rep.cashAdded7 += lastReplenishment.CashAdded7;


            //                    }
            //                    else
            //                    {

            //                    }
            //                }
            //            }
            if (replenishmentList.Count > 0)
            {
                if (!ReplenishmentByDay.Contains(dt))
                    ReplenishmentByDay.Add(dt, replenishmentList);
            }
        }
        catch (Exception ex)
        {
            if (reader != null)
                reader.Close();
            throw ex;
        }
    }

    public string GetDeposits(DateTime datetime, Atm atm)
    {
        cmd.CommandText = @"select sum(cassette1_counter_1
)+sum(cassette1_counter_2)+sum(cassette1_counter_3)+sum(cassette1_counter_4)+sum(cassette1_counter_5
)+sum(cassette1_counter_6)+sum(cassette1_counter_7)+sum(cassette1_counter_8)+sum(cassette1_counter_9
)+sum(cassette1_counter_10)+sum(cassette1_counter_11)+sum(cassette1_counter_12)+sum(cassette1_counter_13
)+sum(cassette1_counter_14)+sum(cassette1_counter_15)+sum(cassette1_counter_16)+sum(cassette1_counter_17)+
sum(cassette1_counter_18)+sum(cassette1_counter_19)+sum(cassette1_counter_20)+sum(cassette1_counter_21)+
sum(cassette1_counter_22)+sum(cassette1_counter_23)+sum(cassette1_counter_24)+sum(cassette1_counter_25
)+sum(cassette1_counter_26)+sum(cassette1_counter_27)+sum(cassette1_counter_28)+sum(cassette1_counter_29
)+sum(cassette1_counter_30)+sum(cassette1_counter_31)+sum(cassette1_counter_32)+sum(cassette1_counter_33
)+sum(cassette1_counter_34)+sum(cassette1_counter_35)+sum(cassette1_counter_36)+sum(cassette1_counter_37)+
sum(cassette1_counter_38)+sum(cassette1_counter_39)+sum(cassette1_counter_40)+sum(cassette1_counter_41
)+sum(cassette1_counter_42)+sum(cassette1_counter_43)+sum(cassette1_counter_44)+sum(cassette1_counter_45
)+sum(cassette1_counter_46)+sum(cassette1_counter_47)+sum(cassette1_counter_48)+sum(cassette1_counter_49
)+sum(cassette1_counter_50) cassette_1_deposit,
sum(cassette2_counter_1
)+sum(cassette2_counter_2)+sum(cassette2_counter_3)+sum(cassette2_counter_4)+sum(cassette2_counter_5
)+sum(cassette2_counter_6)+sum(cassette2_counter_7)+sum(cassette2_counter_8)+sum(cassette2_counter_9
)+sum(cassette2_counter_10)+sum(cassette2_counter_11)+sum(cassette2_counter_12)+sum(cassette2_counter_13
)+sum(cassette2_counter_14)+sum(cassette2_counter_15)+sum(cassette2_counter_16)+sum(cassette2_counter_17)+
sum(cassette2_counter_18)+sum(cassette2_counter_19)+sum(cassette2_counter_20)+sum(cassette2_counter_21)+
sum(cassette2_counter_22)+sum(cassette2_counter_23)+sum(cassette2_counter_24)+sum(cassette2_counter_25
)+sum(cassette2_counter_26)+sum(cassette2_counter_27)+sum(cassette2_counter_28)+sum(cassette2_counter_29
)+sum(cassette2_counter_30)+sum(cassette2_counter_31)+sum(cassette2_counter_32)+sum(cassette2_counter_33
)+sum(cassette2_counter_34)+sum(cassette2_counter_35)+sum(cassette2_counter_36)+sum(cassette2_counter_37)+
sum(cassette2_counter_38)+sum(cassette2_counter_39)+sum(cassette2_counter_40)+sum(cassette2_counter_41
)+sum(cassette2_counter_42)+sum(cassette2_counter_43)+sum(cassette2_counter_44)+sum(cassette2_counter_45
)+sum(cassette2_counter_46)+sum(cassette2_counter_47)+sum(cassette2_counter_48)+sum(cassette2_counter_49
)+sum(cassette2_counter_50) cassette_2_deposit,
sum(cassette3_counter_1
)+sum(cassette3_counter_2)+sum(cassette3_counter_3)+sum(cassette3_counter_4)+sum(cassette3_counter_5
)+sum(cassette3_counter_6)+sum(cassette3_counter_7)+sum(cassette3_counter_8)+sum(cassette3_counter_9
)+sum(cassette3_counter_10)+sum(cassette3_counter_11)+sum(cassette3_counter_12)+sum(cassette3_counter_13
)+sum(cassette3_counter_14)+sum(cassette3_counter_15)+sum(cassette3_counter_16)+sum(cassette3_counter_17)+
sum(cassette3_counter_18)+sum(cassette3_counter_19)+sum(cassette3_counter_20)+sum(cassette3_counter_21)+
sum(cassette3_counter_22)+sum(cassette3_counter_23)+sum(cassette3_counter_24)+sum(cassette3_counter_25
)+sum(cassette3_counter_26)+sum(cassette3_counter_27)+sum(cassette3_counter_28)+sum(cassette3_counter_29
)+sum(cassette3_counter_30)+sum(cassette3_counter_31)+sum(cassette3_counter_32)+sum(cassette3_counter_33
)+sum(cassette3_counter_34)+sum(cassette3_counter_35)+sum(cassette3_counter_36)+sum(cassette3_counter_37)+
sum(cassette3_counter_38)+sum(cassette3_counter_39)+sum(cassette3_counter_40)+sum(cassette3_counter_41
)+sum(cassette3_counter_42)+sum(cassette3_counter_43)+sum(cassette3_counter_44)+sum(cassette3_counter_45
)+sum(cassette3_counter_46)+sum(cassette3_counter_47)+sum(cassette3_counter_48)+sum(cassette3_counter_49
)+sum(cassette3_counter_50) cassette_3_deposit,
sum(cassette4_counter_1
)+sum(cassette4_counter_2)+sum(cassette4_counter_3)+sum(cassette4_counter_4)+sum(cassette4_counter_5
)+sum(cassette4_counter_6)+sum(cassette4_counter_7)+sum(cassette4_counter_8)+sum(cassette4_counter_9
)+sum(cassette4_counter_10)+sum(cassette4_counter_11)+sum(cassette4_counter_12)+sum(cassette4_counter_13
)+sum(cassette4_counter_14)+sum(cassette4_counter_15)+sum(cassette4_counter_16)+sum(cassette4_counter_17)+
sum(cassette4_counter_18)+sum(cassette4_counter_19)+sum(cassette4_counter_20)+sum(cassette4_counter_21)+
sum(cassette4_counter_22)+sum(cassette4_counter_23)+sum(cassette4_counter_24)+sum(cassette4_counter_25
)+sum(cassette4_counter_26)+sum(cassette4_counter_27)+sum(cassette4_counter_28)+sum(cassette4_counter_29
)+sum(cassette4_counter_30)+sum(cassette4_counter_31)+sum(cassette4_counter_32)+sum(cassette4_counter_33
)+sum(cassette4_counter_34)+sum(cassette4_counter_35)+sum(cassette4_counter_36)+sum(cassette4_counter_37)+
sum(cassette4_counter_38)+sum(cassette4_counter_39)+sum(cassette4_counter_40)+sum(cassette4_counter_41
)+sum(cassette4_counter_42)+sum(cassette4_counter_43)+sum(cassette4_counter_44)+sum(cassette4_counter_45
)+sum(cassette4_counter_46)+sum(cassette4_counter_47)+sum(cassette4_counter_48)+sum(cassette4_counter_49
)+sum(cassette4_counter_50) cassette_4_deposit,
sum(purge_counter_1
)+sum(purge_counter_2)+sum(purge_counter_3)+sum(purge_counter_4)+sum(purge_counter_5
)+sum(purge_counter_6)+sum(purge_counter_7)+sum(purge_counter_8)+sum(purge_counter_9
)+sum(purge_counter_10)+sum(purge_counter_11)+sum(purge_counter_12)+sum(purge_counter_13
)+sum(purge_counter_14)+sum(purge_counter_15)+sum(purge_counter_16)+sum(purge_counter_17)+
sum(purge_counter_18)+sum(purge_counter_19)+sum(purge_counter_20)+sum(purge_counter_21)+
sum(purge_counter_22)+sum(purge_counter_23)+sum(purge_counter_24)+sum(purge_counter_25
)+sum(purge_counter_26)+sum(purge_counter_27)+sum(purge_counter_28)+sum(purge_counter_29
)+sum(purge_counter_30)+sum(purge_counter_31)+sum(purge_counter_32)+sum(purge_counter_33
)+sum(purge_counter_34)+sum(purge_counter_35)+sum(purge_counter_36)+sum(purge_counter_37)+
sum(purge_counter_38)+sum(purge_counter_39)+sum(purge_counter_40)+sum(purge_counter_41
)+sum(purge_counter_42)+sum(purge_counter_43)+sum(purge_counter_44)+sum(purge_counter_45
)+sum(purge_counter_46)+sum(purge_counter_47)+sum(purge_counter_48)+sum(purge_counter_49
)+sum(purge_counter_50) purge_counter
from parsed_bna_counter
where atm_id = " + atm.ATMId + " and last_deposit_at>=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) and last_deposit_at<=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " HH:mm:ss',103)";

        return null;
    }

    public DFFVersion2Helper GetHelper(string title)
    {
        for (int i = 0; i < listDFFHelper.Count; i++)
            if (listDFFHelper[i].title == title)
            {
                dFFVersion2Helper = listDFFHelper[i];
                break;
            }
        return dFFVersion2Helper;
    }

    public bool IsRecyclerCassette(NoteSetType NoteSet, int CassetteNote)
    {
        if (NoteSet.DenominationType1 == CassetteNote && NoteSet.IsType1Recycler)
            return true;
        else if (NoteSet.DenominationType2 == CassetteNote && NoteSet.IsType2Recycler)
            return true;
        else if (NoteSet.DenominationType3 == CassetteNote && NoteSet.IsType3Recycler)
            return true;
        else if (NoteSet.DenominationType4 == CassetteNote && NoteSet.IsType4Recycler)
            return true;
        else if (NoteSet.DenominationType5 == CassetteNote && NoteSet.IsType5Recycler)
            return true;
        else if (NoteSet.DenominationType6 == CassetteNote && NoteSet.IsType6Recycler)
            return true;
        else if (NoteSet.DenominationType7 == CassetteNote && NoteSet.IsType7Recycler)
            return true;
        else
            return false;
    }
    public Summary InitSummary(Summary summary)
    {
        summary.CashRemaining1 = 0;
        summary.CashRemaining2 = 0;
        summary.CashRemaining3 = 0;
        summary.CashRemaining4 = 0;
        summary.CashRemaining5 = 0;
        summary.CashRemaining6 = 0;
        summary.CashRemaining7 = 0;

        summary.CashAdded1 = 0;
        summary.CashAdded2 = 0;
        summary.CashAdded3 = 0;
        summary.CashAdded4 = 0;
        summary.CashAdded5 = 0;
        summary.CashAdded6 = 0;
        summary.CashAdded7 = 0;


        summary.ReturnType1 = 0;
        summary.ReturnType2 = 0;
        summary.ReturnType3 = 0;
        summary.ReturnType4 = 0;
        summary.ReturnType5 = 0;
        summary.ReturnType6 = 0;
        summary.ReturnType7 = 0;
        return summary;
    }
    public string GetPreviousDayDetails(DateTime day, string line)
    {
        string details = "";
        List<string> FileContent = new List<string>();
        byte[] data = new byte[1024];
        
        string FilePath = "";
        //string outputFilePath = regionReader.CurrentRegion.DailyFeedOutputFilePath + "\\" + dailyFeedConfig.DailyFeedFilePrefix + SummaryDay.ToString("yyyyMMdd") + ".atm.wrk";
        string fileName = DFFInfo.DFPrefix + day.ToString("yyyyMMdd") + ".atm.wrk";
        string filePendingPath = Path.Combine(DFFInfo.DFFOutputPath, "PendingUpload",fileName);
        string fileOutputArchPath = Path.Combine(DFFInfo.DFFOutputPath, "OutputArchive", fileName);
        try
        {
            String strLine;

            if (File.Exists(filePendingPath))
                FilePath = filePendingPath;
            else if (File.Exists(fileOutputArchPath))
                FilePath = fileOutputArchPath;

            if (!String.IsNullOrEmpty(FilePath))
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while ((strLine = sr.ReadLine()) != null)
                            FileContent.Add(strLine);
                    }
                }
            }
            else
            {
                LogableTask.LogMonoActivityTask("GetPreviousDaySummary", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "--previous day DFF not exists in both folders!");
            }

            if (FileContent.Count > 0)
            {
                details = FileContent.FirstOrDefault(x => x.StartsWith(line));
                if (String.IsNullOrEmpty(details))
                    details = "";
            }
        }
        catch(Exception ex)
        {
            LogableTask.LogMonoActivityTask("GetPreviousDaySummary", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            details = "";
        }
        return details;
    }

    public int CalculateDepositFromWDOfRecyclerTrxn(List<string>WDTrxnList, int noteIndex)
    {
        int result = 0;
        List<int> currentTempList = new List<int>();
        List<int> PreTempList = new List<int>();
        int current = 0;
        int previous = 0;
        try
        {
            for (int i = 0; i < WDTrxnList.Count-1; i++)
            {
                currentTempList = WDTrxnList[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).Select(s=>int.Parse(s)).ToList();
                PreTempList = WDTrxnList[i+1].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).Select(s=>int.Parse(s)).ToList();
                current = currentTempList[noteIndex + 4];
                previous = PreTempList[noteIndex + 4];
                if(current-previous>=0)
                    result += (current - previous);
            }
        }
        catch(Exception ex)
        {
            LogableTask.LogMonoActivityTask("CalculateDeposit", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            result = 0;
        }
        return result;
    }
    public int CalculateDepositFromLastDepositTrxn(int [] DepositsNotes, int denomination)
    {
        int result = 0;
        try
        {
            for (int i = 0; i < DepositsNotes.Count() && i < 4; i++)
            {
                if (DepositsNotes[i] == denomination)
                {
                    result = DepositsNotes[i + 4];
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            LogableTask.LogMonoActivityTask("CalculateDepositFromLastDepositTrxn", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            result = 0;
        }
        return result;
    }
    public int[] GetCounterDepositsNotes(DateTime trxnDate, bool getPre)
    {
        try
        {
            int[] data = new int[8];
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCounterDepositsNotes";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters.Add("@GetPre", SqlDbType.Bit);
            cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
            cmd.Parameters[2].Value = atm_id;
            cmd.Parameters[3].Value = getPre;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            RevertCommandObjToRunTextQuery();
            int row = 0, col = 0;
            if (dt.Rows == null || dt.Rows.Count == 0)
                return new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            while (col < dt.Columns.Count)
            {
                //QNB acutal deposit data
                string cellVal = dt.Rows[row][col].ToString();
                if (string.IsNullOrEmpty(cellVal))
                    cellVal = "0";
                data[col] = int.Parse(cellVal);
                col++;
            }
            return data;
        }
        catch (Exception ex)
        {
            LogableTask.LogMonoActivityTask("GetCounterDepositsNotes", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            return new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }

    public int[] GetCurrentDayDepositsNotes(int[] yesterdayDepoists, int[] todayDeposits)
    {
        int[] result = new List<int>(todayDeposits).ToArray();
        try
        {
            result[4] = (todayDeposits[4] > yesterdayDepoists[4]) ? (todayDeposits[4] - yesterdayDepoists[4]) : 0;
            result[5] = (todayDeposits[5] > yesterdayDepoists[5]) ? (todayDeposits[5] - yesterdayDepoists[5]) : 0;
            result[6] = (todayDeposits[6] > yesterdayDepoists[6]) ? (todayDeposits[6] - yesterdayDepoists[6]) : 0;
            result[7] = (todayDeposits[7] > yesterdayDepoists[7]) ? (todayDeposits[7] - yesterdayDepoists[7]) : 0;
        }
        catch(Exception ex)
        {
            LogableTask.LogMonoActivityTask("GetCurrentDayDepositsNotes", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            result = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        return result;
    }
    public string FormatToDFFVersion2()
    {
        try
        {
            List<string> atmAlreadyProcessed = new List<string>();
            StringBuilder DFFVersion2Builder = new StringBuilder();
            string[] parts = builder.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<KeyValuePair<string, bool>> listCurrencies = null;
            List<int> listCurrenciesIndexes = null;
            List<int> todayClosingBalance = null;
            string yesterdayClosingBalance = null;
            string[] yesterdayClosingBalanceParts = null;
            string replenishment = null;
            string allReps = null;
            List<string> AllReplenishmentsNotes = new List<string>();
            List<string> AllWDFromRecyclerTrxn = new List<string>();
            List<string> PreWDFromRecyclerTrxns = new List<string>();
            List<int> ClosingOfRecycler = new List<int>();
            string LastWDFromRecycler = null;
            string[] replenishmentParts = null;
            string prewithdrawals = null;
            string[] prewithdrawalsParts = null;
            string withdrawals = null;
            string[] withdrawalsParts = null;
            string rejectedCounter = null;
            string[] rejectedCounterParts = null;
            bool replenishmentDay = false;
            int iYesterdayClosingBalance = 0;
            int iReplenishment = 0;
            int iPrewithdrawals = 0;
            int iWithdrawals = 0;
            int iSwapReturnAmount = 0;
            int iRejectedCounter = 0;

            int totalDepositTransactions = 0;

            int iYesterdayClosingBalanceTotal = 0;
            int iReplenishmentTotal = 0;
            int iPrewithdrawalsTotal = 0;
            int iWithdrawalsTotal = 0;
            int iSwapReturnAmountTotal = 0;
            int iClosingBalanceTotal = 0;
            int iClosingBalanceTotalAmount = 0;

            int dispensableNotes = 0;
            int dispensableNotesSum = 0;

            int depositAmount = 0;
            int depositNotes = 0;
            int preDepositAmount = 0;
            int preDepositNotes = 0;

            int iTotalDeposit = 0;
            int iTotalDepositNotes = 0;

            int iRecyclableDeposit = 0;
            int iRecyclableDepositNotes = 0;
            int iNonRecyclableDeposit = 0;
            int iNonRecyclableDepositNotes = 0;
            int balEsc = 0;

            string cashPointType = "";
            int temp = 0;
            bool isATM = false;
            bool isBNA = false;
            string[] closingBalancePartsFromCashPosition = null;
            List<DepositTransaction> YesterDayDepositTrxns = new List<DepositTransaction>();
            List<string> YesterdaySummaryDetails = new List<string>();
            DateTime LastBNACleared = DateTime.MinValue;
            //List<string> specialTypes = new List<string> { "brm", "gbru" };
            List<string> specialTypes = new List<string> { "123" };

            int[] CounterDeposits = new int[8];
            int[] CounterPreDeposits = new int[8];

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            //DFFVersion2Builder.Append("CASHP_ID\tCP_TYPE\tCYCLE_TYPE\tCRNCY_ID\tCRCY_TYP\tCOMP_ID\tDENOM_ID\tDATE\tCASSETTE\tOPEN_BAL\tNOPEN_BAL\tNORM_DEL\tNNORM_DEL\tNORM_RTR\tNNORM_RTR\tUNPL_DEL\tNUNPL_DEL\tUNPL_RTR\tNUNPL_RTR\tWITH_TRAN\tWTHDRWLS\tNWTHDRWLS\tPRE_SRV\tNPRE_SRV\tDEP_TRAN\tDEPOSITS\tNDEPOSITS\tCLOS_BAL\tNCLOS_BAL\tBAL_DISP\tBAL_ESCR\tBAL_UNAV\tOPR_STAT\tEXCLD_FL\r\n");
            foreach (string part in parts)
            {
                Summary summary = null;
                try
                {
                    int totalRecyclerClosing = 0;
                    int totalRecyclerClosingNotes = 0;
                    int totalPreDeposits = 0;
                    int totalPreDepositNotes = 0;

                    PreWDFromRecyclerTrxns = new List<string>();
                    preRecycledWithdrawalSummary = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                    AllDepositTransactions = new List<List<DepositTransaction>>();
                    AllRecycledWithdrawalSummary = new List<int[]>();
                    CounterDeposits = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    CounterPreDeposits = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

                    isAddCashOnCurrentDay = false;
                    isATM = false;
                    isBNA = false;
                    cashPointType = "";
                    ReplenishmentByDay = new System.Collections.Hashtable(51);
                    recycledWithdrawalSummary = new int[7];
                    recycledWithdrawalSummaryYesterday = new int[7];

                    string field2 = part.Substring(8, 8);
                    string field8 = part.Substring(61, 1);
                    atm = Atm.LoadAtm("title='" + field2 + "'");
                    if (atm == null)
                    {
                        //Comment added on 27/10 
                        LogableTask.LogMonoActivityTask("AtmNotDefined", MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATM Not defined " + field2);
                        continue;
                    }

                    if (!atmAlreadyProcessed.Contains(field2))
                        atmAlreadyProcessed.Add(field2);
                    else
                    {
                        LogableTask.LogMonoActivityTask("DuplicateATM", MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATM Already processed " + field2);
                        continue;
                    }

                    noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                    dFFVersion2Helper = GetHelper(atm.Title);
                    Day = dFFVersion2Helper.dt;
                    atm_id = atm.ATMId;
                    listCurrencies = new List<KeyValuePair<string, bool>>();
                    listCurrenciesIndexes = new List<int>();
                    todayClosingBalance = new List<int>();
                    if (dFFVersion2Helper.closingBalanceFromCashPosition != null)
                        closingBalancePartsFromCashPosition = dFFVersion2Helper.closingBalanceFromCashPosition.Split('|');
                    //yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));
                    //yesterdayClosingBalanceParts = yesterdayClosingBalance.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    ExtractDayWiseReplenishment(Day);

                    replenishment = GetReplenishmentAmountInTermsOfNotes(Day);

                    if (replenishment == null)
                        replenishment = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";

                    //EA: 09-01-2022 for new all reps
                    //allReps = GetAllReplenishmentsNotesWithinDay(Day);
                    //if(String.IsNullOrEmpty(allReps))
                    //    allReps = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
                    //AllReplenishmentsNotes = allReps.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    //if (replenishment != "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
                    //    prewithdrawals = dFFVersion2Helper.preWithdrawalNotes;



                    //if (dFFVersion2Helper.preWithdrawalNotes != null)
                    //prewithdrawals = dFFVersion2Helper.preWithdrawalNotes;

                    //ExtractDayWiseReplenishment(Day);

                    prewithdrawals = ExtractDayWisePreWithdrawalsInTermsOfNotes(Day);

                    if (prewithdrawals == null)
                        prewithdrawals = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";

                    prewithdrawalsParts = prewithdrawals.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    replenishmentParts = replenishment.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    withdrawals = ExtractDayWiseWithdrawalsInTermsOfNotes(Day);

                    //Based on Izhar request as we get deposit details only for recycler atms
                    //if (atm.IsCdm.GetValueOrDefault())
                    if (atm.IsRecycler.GetValueOrDefault())
                    {
                        bool flag = replenishmentParts.Any(x => !string.IsNullOrWhiteSpace(x) && x != "0");

                        AllDepositTransactions = ExtractDayWiseDepositsInTermsOfNotes(Day, flag);
                        depositTransactions = AllDepositTransactions[0];
                        var tempYesterdayDep = GetCounterDepositsNotes(Day.AddDays(-1), false);
                        var tempTodayDep = GetCounterDepositsNotes(Day, false);
                        if (flag)
                        {
                            CounterDeposits = new List<int>(tempTodayDep).ToArray();
                            PreDepositTransactions = AllDepositTransactions[1];
                            var tempTodayPreDeposits = GetCounterDepositsNotes(Day, true);
                            CounterPreDeposits = GetCurrentDayDepositsNotes(tempYesterdayDep, tempTodayPreDeposits);
                        }
                        else
                        {
                            PreDepositTransactions = new List<DepositTransaction>();
                            CounterPreDeposits = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                            CounterDeposits = GetCurrentDayDepositsNotes(tempYesterdayDep, tempTodayDep);
                        }
                        YesterDayDepositTrxns = ExtractDayWiseDepositsInTermsOfNotes(Day.AddDays(-1),false)[0];
                        
                        totalDepositTransactions = depositTransactions.Select(x => x.ej_parsed_bna_transaction_id).Distinct().Count();
                        totalDepositTransactions += PreDepositTransactions.Select(x => x.ej_parsed_bna_transaction_id).Distinct().Count();

                        AllRecycledWithdrawalSummary = GetEjRecycledNotesSummary(Day, flag);
                        recycledWithdrawalSummary = AllRecycledWithdrawalSummary[0];
                        if (flag)
                            preRecycledWithdrawalSummary = AllRecycledWithdrawalSummary[1];
                        else
                            preRecycledWithdrawalSummary = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                        recycledWithdrawalSummaryYesterday = GetEjRecycledNotesSummary(Day.AddDays(-1),false)[0];

                        //EA 06-09-2022 ==================
                        //AllWDFromRecyclerTrxn = GetAllWDFromRecycler(Day, false);
                        //LastWDFromRecycler = AllWDFromRecyclerTrxn[0];
                        //ClosingOfRecycler = LastWDFromRecycler.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();

                        //if (replenishmentParts.Any(x => !string.IsNullOrWhiteSpace(x) && x != "0"))
                        //{
                        //    PreWDFromRecyclerTrxns = GetAllWDFromRecycler(Day, true);
                        //}
                        //========================================
                        object result = null;
                        try
                        {
                            result = ConnectionFactory.ExecuteScalar("SELECT convert(varchar, MAX(counts_cleared_at),103) from vBnaCountsCleared where atm_id = " + atm.ATMId + " and counts_cleared_at < convert(datetime,'" + Day.AddDays(1).ToString("dd'/'MM'/'yyyy") + "',103)", DatabaseName.Cash);
                            LastBNACleared = (result != DBNull.Value && result != null) ? DateTime.ParseExact(result.ToString(),"dd/MM/yyyy",null) : DateTime.MinValue;
                            //20-12-2021 for BNA clear not extracted issue
                            object LastSwapRep = ConnectionFactory.ExecuteScalar("SELECT convert(varchar, MAX(rep_datetime),103) from Replenishment where atm_id = " + atm.ATMId + "and is_swap = 1 and rep_datetime < convert(datetime,'" + Day.AddDays(1).ToString("dd'/'MM'/'yyyy") + "',103)", DatabaseName.Cash);
                            DateTime LastSwapRepDate = (LastSwapRep != DBNull.Value && LastSwapRep != null) ? DateTime.ParseExact(LastSwapRep.ToString(), "dd/MM/yyyy", null) : DateTime.MinValue;
                            if (replenishmentParts.Any(x=>!string.IsNullOrWhiteSpace(x) && x!="0") && Day.Date > LastBNACleared && LastSwapRepDate!=DateTime.MinValue)
                            {
                                LastBNACleared = LastSwapRepDate;
                            }
                        }
                        catch(Exception ex)
                        {
                            if(result!=null && result!=DBNull.Value)
                                LogableTask.LogMonoActivityTask("LastBNACountCleared -- ", MethodBase.GetCurrentMethod(), TraceLevel.Error, result.ToString());
                            throw ex;
                        }
                    }

                    //dFFVersion2Helper.currentDayWithdrawalNotes;
                    //ExtractDayWiseWithdrawalsInTermsOfNotes(Day);
                    if (withdrawals == null)
                        withdrawals = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";

                    withdrawalsParts = withdrawals.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    int swapReturnAmount = 0;
                    rejectedCounter = GetRejectedCountDueToTestCash(Day);
                    rejectedCounterParts = rejectedCounter.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    replenishmentDay = false;
                    //this will change helper object
                    if (field8 == "2")
                        yesterdayClosingBalance = "0|0|0|0|0|0|0";
                    else
                    {
                        Summary yesterdaySummary = Summary.LoadSummary("atm_id = " + atm.ATMId + " and trxn_datetime = convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + "',103)");
                        if (yesterdaySummary != null)
                            yesterdayClosingBalance = yesterdaySummary.CashRemaining1 + "|" + yesterdaySummary.CashRemaining2 + "|" + yesterdaySummary.CashRemaining3 + "|" + yesterdaySummary.CashRemaining4 + "|" +
                                yesterdaySummary.CashRemaining5 + "|" + yesterdaySummary.CashRemaining6 + "|" + yesterdaySummary.CashRemaining7;
                        else
                            yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));
                    }
                    //yesterdayClosingBalance = dFFVersion2Helper.yesterdayBalanceNotes;// GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));

                    //if (yesterdayClosingBalance == null)
                    //    yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));

                    //if (yesterdayClosingBalance==null)                
                    //    yesterdayClosingBalance = "0|0|0|0|0|0|0";
                    yesterdayClosingBalanceParts = yesterdayClosingBalance.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    /*LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATM--" + atm.ATMId + "--YesterdayClosingParts.Count-->"
                        + yesterdayClosingBalanceParts.Count().ToString());
                    LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATM--" + atm.ATMId + "--YesterdayClosingParts->"
                         + string.Join("|", yesterdayClosingBalanceParts) + "-- yesterdayClosingBalance --> " + yesterdayClosingBalance);
                    */
                    summary = Summary.LoadSummary("atm_id = " + atm.ATMId + " and trxn_datetime = convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)");
                    if (summary != null)
                    {
                        summary.OpeningBalance = ((int.Parse(yesterdayClosingBalanceParts[0]) * noteSetType.DenominationType1 +
                            int.Parse(yesterdayClosingBalanceParts[1]) * noteSetType.DenominationType2 +
                             int.Parse(yesterdayClosingBalanceParts[2]) * noteSetType.DenominationType3 +
                              int.Parse(yesterdayClosingBalanceParts[3]) * noteSetType.DenominationType4));

                        //if (summary.ReplenishmentAmount == 0&& summary.OpeningBalance.Value - summary.Withdrawals>0)
                        //    summary.ClosingBalance = summary.OpeningBalance.Value - summary.Withdrawals;
                        //EA:23-01-2022
                        //summary.Save();
                    }
                    //EA:23-01-2022
                    else
                    {
                        summary = new Summary();
                        //EA:02-02-2022
                        summary = InitSummary(summary);
                        summary.GeneratedAt = DateTime.Now;
                        summary.AtmId = atm_id;
                        if (dateModified)
                            summary.TrxnDatetime = new DateTime(tempDay.Year, tempDay.Month, tempDay.Day);
                        else
                            summary.TrxnDatetime = new DateTime(Day.Year, Day.Month, Day.Day);
                    }
                    /////////////////////////////
                    for (int j = 0; j < replenishmentParts.Length; j++)
                    {
                        if (replenishmentParts[j] != "0")
                        {
                            replenishmentDay = true;
                        }
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType1Title) || noteSetType.DenominationType1Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType1Title, noteSetType.IsType1Recycler));
                        listCurrenciesIndexes.Add(0);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType2Title) && noteSetType.DenominationType2Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType2Title, noteSetType.IsType2Recycler));
                        listCurrenciesIndexes.Add(1);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType3Title) && noteSetType.DenominationType3Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType3Title, noteSetType.IsType3Recycler));
                        listCurrenciesIndexes.Add(2);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType4Title) && noteSetType.DenominationType4Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType4Title, noteSetType.IsType4Recycler));
                        listCurrenciesIndexes.Add(3);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType5Title) && noteSetType.DenominationType5Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType5Title, noteSetType.IsType5Recycler));
                        listCurrenciesIndexes.Add(4);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType6Title) && noteSetType.DenominationType6Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType6Title, noteSetType.IsType6Recycler));
                        listCurrenciesIndexes.Add(5);
                    }
                    if (!string.IsNullOrEmpty(noteSetType.DenominationType7Title) && noteSetType.DenominationType7Title.Length != 0)
                    {
                        listCurrencies.Add(new KeyValuePair<string, bool>(noteSetType.DenominationType7Title, noteSetType.IsType7Recycler));
                        listCurrenciesIndexes.Add(6);
                    }
                    //string subString = null;
                    int TotalDepoistNonRecyclerCassttes = 0;
                    int TotalDepoistNotesNonRecyclerCassttes = 0;
                    int TotalYesterdayDeposits = 0;
                    int TotalYesterdayDepositNotes = 0;

                    iYesterdayClosingBalance = 0;
                    iReplenishment = 0;
                    iPrewithdrawals = 0;
                    iWithdrawals = 0;
                    iSwapReturnAmount = 0;
                    iRejectedCounter = 0;
                    dispensableNotes = 0;
                    dispensableNotesSum = 0;

                    iYesterdayClosingBalanceTotal = 0;
                    iReplenishmentTotal = 0;
                    iPrewithdrawalsTotal = 0;
                    iWithdrawalsTotal = 0;
                    iSwapReturnAmountTotal = 0;
                    iClosingBalanceTotal = 0;
                    iClosingBalanceTotalAmount = 0;

                    iTotalDeposit = 0;
                    iTotalDepositNotes = 0;
                    iRecyclableDeposit = 0;
                    iNonRecyclableDeposit = 0;
                    iRecyclableDepositNotes = 0;
                    iNonRecyclableDepositNotes = 0;
                    balEsc = 0;
                    YesterdaySummaryDetails = new List<string>();
                    for (int i = 0; i < listCurrencies.Count; i++)
                    {
                        swapReturnAmount = 0;
                        YesterdaySummaryDetails = new List<string>();
                        depositAmount = 0;
                        depositNotes = 0;
                        int denominationValue = int.Parse(listCurrencies[i].Key.Substring(3));
                        //subString = field2.Substring(3);
                        //if (subString.Length > 8)
                        //    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4, 8) + "\t");
                        //else
                        //    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4) + "\t");
                        //Field1
                        
                        if(!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                            DFFVersion2Builder.Append(field2 + "\t");
                        //Field2
                        //*****************************************

                        //Uncomment it later.
                        //Commented on 03/03/2014
                        isATM = atm.IsAtm.GetValueOrDefault();
                        isBNA = atm.IsCdm.GetValueOrDefault();

                        if (isATM && !isBNA && !specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            DFFVersion2Builder.Append("ATM\t");
                            cashPointType = "ATM";
                        }
                        else if (isBNA && !specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            if (atm.IsRecycler.GetValueOrDefault())
                            {
                                DFFVersion2Builder.Append("RATM\t");
                                cashPointType = "RATM";
                            }
                            else
                            {
                                DFFVersion2Builder.Append("ATM\t");
                                cashPointType = "ATM";
                            }
                        }
                        //isATM = true;
                        //DFFVersion2Builder.Append("ATM\t");
                        //cashPointType = "ATM";
                        //*****************************************
                        if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            DFFVersion2Builder.Append("F\t");
                            DFFVersion2Builder.Append(listCurrencies[i].Key.Substring(0, 3) + "\t");
                            DFFVersion2Builder.Append("01\t00\t");

                            DFFVersion2Builder.Append(listCurrencies[i].Key + "\t");
                            DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + ":03:00\t");
                            //******************
                            //CassetteID
                            //******************

                            DFFVersion2Builder.Append((i + 1).ToString() + "\t");
                        }
                        //if (atm.Cassette1Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("1\t");
                        //else if (atm.Cassette2Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("2\t");
                        //else if (atm.Cassette3Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("3\t");
                        //else if (atm.Cassette4Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("4\t");
                        //else if (atm.Cassette5Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("5\t");
                        //else if (atm.Cassette6Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("6\t");
                        //else if (atm.Cassette7Denomination == int.Parse(listCurrencies[i].Substring(3)))
                        //    DFFVersion2Builder.Append("7\t");
                        //else
                        //    DFFVersion2Builder.Append("0\t");
                        //******************

                        temp = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) * denominationValue;
                        var YesterdayDep = 0;
                        if(atm.IsRecycler.GetValueOrDefault())
                        {
                            YesterdayDep = YesterDayDepositTrxns.Where(x => x.note_type == denominationValue).Sum(x => x.amount);
                            YesterdayDep -= recycledWithdrawalSummaryYesterday[i] * denominationValue;
                            if (YesterdayDep < 0)
                                YesterdayDep = 0;
                            if (!listCurrencies[i].Value)
                            {
                                TotalYesterdayDeposits += YesterdayDep;
                                TotalYesterdayDepositNotes += (YesterdayDep / denominationValue);
                            }
                        }

                        //if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;
                        if (temp < 0) temp = 0;
                        //open balance
                        //DFFVersion2Builder.Append(temp + YesterdayDep + "\t");
                        
                        if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            DFFVersion2Builder.Append(temp + "\t");
                            //**********
                            //Notes
                            //**********
                            //nopen balance
                            //DFFVersion2Builder.Append((temp + YesterdayDep) / denominationValue + "\t");
                            DFFVersion2Builder.Append(temp / denominationValue + "\t");
                            //iYesterdayClosingBalanceTotal += (temp + YesterdayDep) / denominationValue;
                            iYesterdayClosingBalanceTotal += (temp / denominationValue);
                            //iYesterdayClosingBalance += temp + YesterdayDep;// int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) * denominationValue;
                            iYesterdayClosingBalance += temp;// int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) * denominationValue;

                            //EA: 09-01-2022 for new all reps
                            //temp = int.Parse(AllReplenishmentsNotes[listCurrenciesIndexes[i]]) * denominationValue;
                            temp = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) * denominationValue;
                            if (temp < 0) temp = 0;
                            //Norm Del
                            DFFVersion2Builder.Append(temp + "\t");

                            //**********
                            //Notes
                            //**********
                            //NNorm Del
                            DFFVersion2Builder.Append(temp / denominationValue + "\t");
                            iReplenishmentTotal += temp / denominationValue;
                            iReplenishment += temp;// int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) * denominationValue;

                            if (replenishmentDay && !isAddCashOnCurrentDay)
                                swapReturnAmount = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) - (int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]) - preRecycledWithdrawalSummary[i]);

                            temp = swapReturnAmount * denominationValue;
                            if (temp < 0) temp = 0;
                            //Norm RTR
                            DFFVersion2Builder.Append(temp + "\t");
                            //EA:23-01-2022
                            if (i == 0)
                            {
                                summary.CashAdded1 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                summary.ReturnType1 = temp / denominationValue;
                            }
                            else if (i == 1)
                            {
                                summary.CashAdded2 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                summary.ReturnType2 = temp / denominationValue;
                            }
                            else if (i == 2)
                            {
                                summary.CashAdded3 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                summary.ReturnType3 = temp / denominationValue;
                            }
                            else if (i == 3)
                            {
                                summary.CashAdded4 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                summary.ReturnType4 = temp / denominationValue;
                            }
                            //**********
                            //Notes
                            //**********
                            //NNorm RTR
                            DFFVersion2Builder.Append(temp / denominationValue + "\t");
                            iSwapReturnAmountTotal += temp / denominationValue;
                            iSwapReturnAmount += temp;// swapReturnAmount* denominationValue;
                                                      //unpl Del, nunpl del, unpl RTR, nunpl RTR
                            DFFVersion2Builder.Append("0\t0\t0\t0\t");

                            //No Of Withdrawals = Count
                            //cmd.CommandText = string.Format("select count(parsed_transaction_id) from parsed_transaction where trxn_datetime>='{0}' and trxn_datetime<='{1}' and atm_id={2}",Day.ToString("dd/MM/yyyy"),Day.ToString("dd/MM/yyyy") + " 23:59:59",atm.ATMId);

                            //DFFVersion2Builder.Append(cmd.ExecuteScalar().ToString()+"\t");
                            //with Trxn
                            DFFVersion2Builder.Append("0\t");
                            ///////////////////////////////////
                            temp = int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) * denominationValue;
                            if (temp < 0) temp = 0;
                            //withdrawals
                            if (listCurrencies[i].Value && temp > 0 && temp >= ((recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i]) * denominationValue))
                                DFFVersion2Builder.Append(temp - ((recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i]) * denominationValue) + "\t");
                            else
                                DFFVersion2Builder.Append(temp + "\t");
                            //**********
                            //Notes
                            //**********
                            //NWithdrawals
                            if (listCurrencies[i].Value && temp > 0 && (temp / denominationValue) >= recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i])
                                DFFVersion2Builder.Append((temp / denominationValue) - (recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i]) + "\t");
                            else
                                DFFVersion2Builder.Append(temp / denominationValue + "\t");

                            iWithdrawalsTotal += temp / denominationValue;
                            iWithdrawals += temp;// int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) * denominationValue;
                            temp = (int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]) - preRecycledWithdrawalSummary[i]) * denominationValue;
                            if (temp < 0) temp = 0;
                            //pre serv
                            DFFVersion2Builder.Append(temp + "\t");
                            //**********
                            //Notes
                            //**********
                            //npre serv
                            DFFVersion2Builder.Append(temp / denominationValue + "\t");
                            iPrewithdrawalsTotal += temp / denominationValue;
                            iPrewithdrawals += temp;
                        }
                        //Deposit trans number - deposit amount - notes deposited 
                        if (isBNA && atm.IsRecycler.GetValueOrDefault())
                        {
                            //ES:14-04
                            //depositAmount = depositTransactions.Where(x => x.note_type == denominationValue).Sum(x => x.notes_count * denominationValue);
                           
                            depositNotes = depositTransactions.Where(x => x.note_type == denominationValue).Sum(x => x.notes_count);
                            depositNotes += PreDepositTransactions.Where(x => x.note_type == denominationValue).Sum(x => x.notes_count);

                            //depositNotes = CalculateDepositFromWDOfRecyclerTrxn(AllWDFromRecyclerTrxn, i);
                            //depositNotes = CalculateDepositFromLastDepositTrxn(CounterDeposits, denominationValue);
                            depositAmount = depositNotes * denominationValue;
                            if (listCurrencies[i].Value && !specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                DFFVersion2Builder.Append("0\t0\t0\t");
                            //DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, depositAmount, depositNotes));
                            else
                            {
                                TotalDepoistNonRecyclerCassttes += depositAmount;
                                TotalDepoistNotesNonRecyclerCassttes += depositNotes;
                                if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                    DFFVersion2Builder.Append("0\t0\t0\t");

                            }
                        }
                        else if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                            DFFVersion2Builder.Append("0\t0\t0\t");
                        if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            DFFVersion2Builder.Append("CLOSINGBALANCE\t");
                            DFFVersion2Builder.Append("NOTES\t");

                            int notesConsumed = int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) + int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) + int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]);
                            if (replenishmentDay)
                            {
                                if (!isAddCashOnCurrentDay)
                                {
                                    dispensableNotes = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) - (int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) - int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]));
                                }
                                else if (isAddCashOnCurrentDay)
                                {
                                    dispensableNotes = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) + int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) - int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]);
                                }
                                if (atm.IsRecycler.GetValueOrDefault() && listCurrencies[i].Value)
                                    dispensableNotes += recycledWithdrawalSummary[i];
                                dispensableNotes -= int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) + int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]);

                            }
                            else if (atm.IsRecycler.GetValueOrDefault() && listCurrencies[i].Value)
                                dispensableNotes = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) - notesConsumed + recycledWithdrawalSummary[i];
                            else
                                dispensableNotes = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) - notesConsumed;

                            if (dFFVersion2Helper.readFromCashPosition)
                                dispensableNotes = int.Parse(closingBalancePartsFromCashPosition[listCurrenciesIndexes[i]]);

                            temp = dispensableNotes * denominationValue;
                            if (temp < 0) temp = 0;

                            DFFVersion2Builder.Append(temp + "\t");
                            dispensableNotesSum += temp;
                        }
                        //BAL_ESC
                        if (isBNA)
                        {
                            if (atm.IsRecycler.GetValueOrDefault() && listCurrencies[i].Value)
                            {
                                iTotalDeposit += depositAmount;
                                iTotalDepositNotes += depositNotes;
                                //EA:14-04
                                //balEsc = ClosingOfRecycler[i + 4] * denominationValue;
                                balEsc = depositAmount - ((preRecycledWithdrawalSummary[i]+recycledWithdrawalSummary[i]) * denominationValue);
                                totalRecyclerClosing += balEsc;
                                totalRecyclerClosingNotes += balEsc / denominationValue;
                                //totalRecyclerClosingNotes += ClosingOfRecycler[i + 4];
                                //iRecyclableDeposit += balEsc;
                                //iRecyclableDepositNotes += (depositNotes - recycledWithdrawalSummary[i]);
                                //DFFVersion2Builder.Append(string.Format("{0}\t", balEsc));
                                if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                    DFFVersion2Builder.Append("0\t");
                            }
                            else
                            {
                                //iTotalDeposit += depositAmount;
                                //iTotalDepositNotes += depositNotes;
                                iNonRecyclableDeposit += depositAmount;
                                iNonRecyclableDepositNotes += depositNotes;
                                if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                    DFFVersion2Builder.Append("0\t");
                            }
                        }
                        else if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                            DFFVersion2Builder.Append("0\t");
                        //END BAL_ESC

                        int temp1 = 0;
                        if (dFFVersion2Helper.readFromCashPosition)
                            temp1 = int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue;

                        else
                            temp1 = int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue +
                               +int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]) * denominationValue;

                        if (temp1 < 0) temp1 = 0;

                        //DFFVersion2Builder.Append(temp1 + iNonRecyclableDeposit + "\t");
                        if (!specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                        {
                            DFFVersion2Builder.Append(temp1 + "\t");
                            iRejectedCounter += temp1;

                            temp = temp + temp1;// int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue +
                                                //int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]) * denominationValue + dispensableNotes * denominationValue;
                            if (temp < 0) temp = 0;
                            //DFFVersion2Builder.Replace("CLOSINGBALANCE", (temp + balEsc).ToString());
                            DFFVersion2Builder.Replace("CLOSINGBALANCE", (temp).ToString());
                            //DFFVersion2Builder.Replace("NOTES", ((temp + balEsc) / denominationValue).ToString());
                            DFFVersion2Builder.Replace("NOTES", (temp / denominationValue).ToString());
                            iClosingBalanceTotal += temp / denominationValue;
                            iClosingBalanceTotalAmount += temp;

                            if (i == 0)
                                summary.CashRemaining1 = temp / denominationValue;
                            else if (i == 1)
                                summary.CashRemaining2 = temp / denominationValue;
                            else if (i == 2)
                                summary.CashRemaining3 = temp / denominationValue;
                            else if (i == 3)
                                summary.CashRemaining4 = temp / denominationValue;


                            //bool isAnyCassetteEmpty = false;
                            //for (int j = 0; j < listCurrenciesIndexes.Count; j++)
                            //    if (int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[j]]) == 0)

                            //        isAnyCassetteEmpty = true;
                            //if (!isAnyCassetteEmpty)
                            //if (dispensableNotes > 0)
                            //    DFFVersion2Builder.Append("0\t0\t");
                            //else
                            DFFVersion2Builder.Append("1\t" + (field8 == "2" ? "1" : "0") + "\t");
                            DFFVersion2Builder.Append("\r\n");
                        }
                        //================================
                        //For Recycler cassttes
                        //================================
                        if(atm.IsRecycler.GetValueOrDefault() && listCurrencies[i].Value)
                        {
                            int tempRem = 0;
                            int tempRep = 0;
                            string tempParam = field2+"\t"+"RATM\tF\t"+listCurrencies[i].Key.Substring(0,3)+ "\t01\t02\t"+listCurrencies[i].Key+"\t"
                                +Day.AddDays(-1).ToString("ddMMyyyy") + ":03:00\t" + (i + 1).ToString() + "\t";
                            string Details = GetPreviousDayDetails(Day.AddDays(-1), tempParam);
                            if (!String.IsNullOrEmpty(Details))
                            {
                                //YesterdaySummaryDetails = Details.Split("\t".ToCharArray()).ToList();
                                YesterdaySummaryDetails = Details.Split(new string[] { "\t" }, StringSplitOptions.None).ToList();
                            }
                            DFFVersion2Builder.Append(field2 + "\t");
                            DFFVersion2Builder.Append("RATM\t");
                            DFFVersion2Builder.Append("F\t");
                            DFFVersion2Builder.Append(listCurrencies[i].Key.Substring(0, 3) + "\t");
                            DFFVersion2Builder.Append("01\t02\t");
                            DFFVersion2Builder.Append(listCurrencies[i].Key + "\t");
                            DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + ":03:00\t");
                            DFFVersion2Builder.Append((i + 1).ToString() + "\t");
                            //DFFVersion2Builder.Append(YesterdayDep + "\t");
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                            {
                                DFFVersion2Builder.Append(YesterdaySummaryDetails[27] + "\t");
                                iYesterdayClosingBalance += Convert.ToInt32(YesterdaySummaryDetails[27]);
                            }
                            else
                                DFFVersion2Builder.Append("0\t");

                            //DFFVersion2Builder.Append(YesterdayDep / denominationValue + "\t");
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[28]) && Convert.ToInt32(YesterdaySummaryDetails[28]) > 0)
                            { 
                                DFFVersion2Builder.Append(YesterdaySummaryDetails[28] + "\t");
                                iYesterdayClosingBalanceTotal += Convert.ToInt32(YesterdaySummaryDetails[28]);
                            }
                            else
                                DFFVersion2Builder.Append("0\t");

                            //Rep
                            if (specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                            {
                                tempRep = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) * denominationValue;
                                if (tempRep < 0) tempRep = 0;
                                //Norm Del
                                DFFVersion2Builder.Append(tempRep + "\t");
                                //NNorm Del
                                DFFVersion2Builder.Append(tempRep / denominationValue + "\t");
                                iReplenishmentTotal += tempRep / denominationValue;
                                iReplenishment += tempRep;
                            }
                            else
                                DFFVersion2Builder.Append("0\t0\t");
                            //edits for RTR in recycler 
                            int tempRTR = 0;
                            preDepositAmount = 0;
                            preDepositNotes = 0;
                            //EA:14-04
                            //preDepositAmount = PreDepositTransactions.Where(x => x.note_type == denominationValue).Sum(x => x.notes_count * denominationValue);
                            preDepositNotes = PreDepositTransactions.Where(x => x.note_type == denominationValue).Sum(x => x.notes_count);
                            //preDepositNotes = CalculateDepositFromWDOfRecyclerTrxn(PreWDFromRecyclerTrxns, i);
                            //preDepositNotes = CalculateDepositFromLastDepositTrxn(CounterPreDeposits, denominationValue);
                            preDepositAmount = preDepositNotes * denominationValue;
                            totalPreDeposits += preDepositAmount;
                            totalPreDepositNotes += preDepositNotes;

                            if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                            {
                                if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && (Convert.ToInt32(YesterdaySummaryDetails[27])) >= 0)
                                    tempRTR = int.Parse(YesterdaySummaryDetails[27]) + preDepositAmount - (preRecycledWithdrawalSummary[i] * denominationValue);
                                else
                                    tempRTR = YesterdayDep + preDepositAmount - (preRecycledWithdrawalSummary[i] * denominationValue);

                                if (tempRTR < 0) tempRTR = 0;
                                DFFVersion2Builder.Append(tempRTR + "\t");
                                DFFVersion2Builder.Append(tempRTR/denominationValue + "\t");
                                iSwapReturnAmount += tempRTR;
                                iSwapReturnAmountTotal += (tempRTR/denominationValue);
                                
                            }
                            else
                                DFFVersion2Builder.Append("0\t0\t");

                            DFFVersion2Builder.Append("0\t0\t0\t0\t0\t");

                            DFFVersion2Builder.Append((recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i]) * denominationValue + "\t");
                            DFFVersion2Builder.Append(recycledWithdrawalSummary[i] + preRecycledWithdrawalSummary[i] + "\t");
                            
                            //iWithdrawals += preRecycledWithdrawalSummary[i] * denominationValue;
                            //iWithdrawalsTotal += preRecycledWithdrawalSummary[i];
                            iPrewithdrawals += preRecycledWithdrawalSummary[i] * denominationValue;
                            iPrewithdrawalsTotal += preRecycledWithdrawalSummary[i];
                            //DFFVersion2Builder.Append("0\t0\t");
                            //DFFVersion2Builder.Append(preRecycledWithdrawalSummary[i] * denominationValue + "\t");
                            //DFFVersion2Builder.Append(preRecycledWithdrawalSummary[i] + "\t");
                            DFFVersion2Builder.Append(preDepositNotes * denominationValue + "\t");
                            DFFVersion2Builder.Append(preDepositNotes + "\t");

                            
                             totalDepositTransactions = 0;
                            totalDepositTransactions = depositTransactions.Where(x => x.note_type == denominationValue).Count();
                            totalDepositTransactions += PreDepositTransactions.Where(x => x.note_type == denominationValue).Count();

                            //DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, depositAmount + preDepositAmount, depositNotes + preDepositNotes));
                            DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, depositAmount, depositNotes));

                            //DFFVersion2Builder.Append(YesterdayDep + balEsc + "\t");
                            //closing
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && (Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc) > 0)
                            {
                                if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                {
                                    //if (balEsc < 0) balEsc = 0;
                                    //temp => is the replenishment in case BRM/GBRU
                                    if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                        DFFVersion2Builder.Append(tempRep + balEsc + "\t");
                                    else if (balEsc >= 0)
                                        DFFVersion2Builder.Append(balEsc + "\t");
                                    else
                                        DFFVersion2Builder.Append("0\t");
                                }
                                else
                                    DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc + "\t");
                            }
                            else if ((balEsc + tempRep) >= 0 && replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                            {
                                if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                    DFFVersion2Builder.Append(tempRep + balEsc + "\t");
                                else
                                    DFFVersion2Builder.Append(balEsc + "\t");
                            }
                            else if (balEsc >= 0)
                                DFFVersion2Builder.Append(balEsc + "\t");
                            else
                                DFFVersion2Builder.Append("0\t");

                            //DFFVersion2Builder.Append((YesterdayDep + balEsc)/denominationValue + "\t");
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[28]) && (Convert.ToInt32(YesterdaySummaryDetails[28]) + (balEsc / denominationValue)) > 0)
                            {
                                if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                {
                                    //if (balEsc < 0) balEsc = 0;
                                    //temp => is the replenishment in case BRM/GBRU
                                    if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                    {
                                        DFFVersion2Builder.Append((tempRep + balEsc) / denominationValue + "\t");
                                        iRecyclableDeposit += (tempRep + balEsc);
                                        iRecyclableDepositNotes += ((tempRep + balEsc) / denominationValue);
                                    }
                                    else if (balEsc >= 0)
                                    {
                                        DFFVersion2Builder.Append((balEsc / denominationValue) + "\t");
                                        iRecyclableDeposit += balEsc;
                                        iRecyclableDepositNotes += (balEsc / denominationValue);
                                    }
                                    else
                                        DFFVersion2Builder.Append("0\t");
                                }
                                else
                                {
                                    DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[28]) + (balEsc / denominationValue) + "\t");
                                    iRecyclableDeposit += Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc;
                                    iRecyclableDepositNotes += Convert.ToInt32(YesterdaySummaryDetails[28]) + (balEsc / denominationValue);
                                }
                            }
                            else if ((balEsc + tempRep) >= 0 && replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                            {
                                if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                {
                                    DFFVersion2Builder.Append((tempRep + balEsc) / denominationValue + "\t");
                                    iRecyclableDeposit += (tempRep + balEsc);
                                    iRecyclableDepositNotes += ((tempRep + balEsc) / denominationValue);
                                }
                                else
                                {
                                    DFFVersion2Builder.Append(balEsc / denominationValue + "\t");
                                    iRecyclableDeposit += balEsc;
                                    iRecyclableDepositNotes += (balEsc / denominationValue);
                                }
                            }
                            else if (balEsc >= 0)
                            {
                                DFFVersion2Builder.Append(balEsc / denominationValue + "\t");
                                iRecyclableDeposit += balEsc;
                                iRecyclableDepositNotes += (balEsc / denominationValue);
                            }
                            else
                                DFFVersion2Builder.Append("0\t");
                            //balance_display
                            DFFVersion2Builder.Append("0\t");
                            //DFFVersion2Builder.Append(balEsc + "\t");
                            //Bal_ESCR
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && (Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc) > 0)
                            {
                                if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                {
                                    //if (balEsc < 0) balEsc = 0;
                                    //temp => is the replenishment in case BRM/GBRU
                                    if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                    {
                                        DFFVersion2Builder.Append(tempRep + balEsc + "\t");
                                        tempRem = (tempRep + balEsc);
                                    }
                                    else if (balEsc >= 0)
                                    {
                                        DFFVersion2Builder.Append(balEsc + "\t");
                                        tempRem = balEsc;
                                    }
                                    else
                                    {
                                        DFFVersion2Builder.Append("0\t");
                                        tempRem = 0;
                                    }
                                }
                                else
                                {
                                    DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc + "\t");
                                    tempRem = Convert.ToInt32(YesterdaySummaryDetails[27]) + balEsc;
                                }
                            }
                            else if ((balEsc + tempRep) >= 0 && replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                            {
                                if (specialTypes.Any(t => atm.AtmType.ToLower().Contains(t)))
                                {
                                    DFFVersion2Builder.Append(tempRep + balEsc + "\t");
                                    tempRem = (tempRep + balEsc);
                                }
                                else
                                {
                                    DFFVersion2Builder.Append(balEsc + "\t");
                                    tempRem = balEsc;
                                }
                            }
                            else if (balEsc >= 0)
                            {
                                DFFVersion2Builder.Append(balEsc + "\t");
                                tempRem = balEsc;
                            }
                            else
                                DFFVersion2Builder.Append("0\t");
                            //BAL_UNAV
                            DFFVersion2Builder.Append("0\t");
                            DFFVersion2Builder.Append("1\t" + (field8 == "2" ? "1" : "0") + "\t");
                            DFFVersion2Builder.Append("\r\n");

                            if (i == 0)
                            {
                                summary.ReturnType1 += tempRTR;
                                if (specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                {
                                    summary.CashAdded1 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                    summary.CashRemaining1 = tempRem;
                                }
                            }
                            else if (i == 1)
                            {
                                summary.ReturnType2 += tempRTR;
                                if (specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                {
                                    summary.CashAdded2 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                    summary.CashRemaining2 = tempRem;
                                }
                            }
                            else if (i == 2)
                            {
                                summary.ReturnType3 += tempRTR;
                                if (specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                {
                                    summary.CashAdded3 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                    summary.CashRemaining3 = tempRem;
                                }
                            }
                            else if (i == 3)
                            {
                                summary.ReturnType4 += tempRTR;
                                if (specialTypes.Any(t=> atm.AtmType.ToLower().Contains(t)))
                                {
                                    summary.CashAdded4 = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]);
                                    summary.CashRemaining4 = tempRem;
                                }
                            }
                        }
                    }
                    //For mixed row that contains sum of all deposit data only for recycler atms
                    YesterdaySummaryDetails = new List<string>();
                    int MixDep = 0;
                    int MixDepNotes = 0;
                    //will manage later
                    if (atm.IsRecycler.GetValueOrDefault() && 1==2)
                    {
                        string temp_param = field2 + "\t" + "RATM\tF\t" + listCurrencies[0].Key.Substring(0, 3) + "\t01\t01\t" + "MIXED\t"
                                + Day.AddDays(-1).ToString("ddMMyyyy") + ":03:00\t" + "0\t";
                        string tmpDetails = GetPreviousDayDetails(Day.AddDays(-1), temp_param);
                        if (!String.IsNullOrEmpty(tmpDetails))
                        {
                            YesterdaySummaryDetails = tmpDetails.Split(new string[] { "\t" }, StringSplitOptions.None).ToList();
                        }
                        DFFVersion2Builder.Append(field2 + "\t");
                        DFFVersion2Builder.Append("RATM\t");
                        DFFVersion2Builder.Append("F\t");
                        DFFVersion2Builder.Append(listCurrencies[0].Key.Substring(0, 3) + "\t");
                        DFFVersion2Builder.Append("01\t01\t");
                        DFFVersion2Builder.Append("MIXED\t");
                        DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + ":03:00\t");
                        DFFVersion2Builder.Append("0\t");
                        //DFFVersion2Builder.Append(TotalYesterdayDeposits + "\t");
                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                        {
                            DFFVersion2Builder.Append(YesterdaySummaryDetails[27] + "\t");
                            //EA:14-04 remove mix from balance investigation
                            //iYesterdayClosingBalance += Convert.ToInt32(YesterdaySummaryDetails[27]);
                        }
                        else
                            DFFVersion2Builder.Append("0\t");

                        //DFFVersion2Builder.Append("0\t");
                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[28]) && Convert.ToInt32(YesterdaySummaryDetails[28]) > 0)
                        {
                            DFFVersion2Builder.Append(YesterdaySummaryDetails[28] + "\t");
                            //EA:14-04 remove mix from balance investigation
                            //iYesterdayClosingBalanceTotal += Convert.ToInt32(YesterdaySummaryDetails[28]);
                        }
                        else
                            DFFVersion2Builder.Append("0\t");

                        DFFVersion2Builder.Append("0\t0\t");
                        //edits for RTR in recycler
                        //EA:14-04
                        List<int> Notes = listCurrencies.Select(x => int.Parse(x.Key.Substring(3))).ToList();
                        List<DepositTransaction> mixPreDepositsTrxn = PreDepositTransactions.Where(x => !Notes.Contains(x.note_type)).ToList();
                        int mixPreDepositsAmount = mixPreDepositsTrxn.Sum(x => x.amount);
                        int mixPreDepositsNotes = mixPreDepositsTrxn.Sum(x => x.notes_count);
                        //List<DepositTransaction> mixPreDepositsTrxn = PreDepositTransactions.Where(x => !Notes.Contains(x.note_type)).ToList();

                        //**************************Changd by izhar..did not understand so uncommenting above code
                        //int mixPreDepositsAmount = PreDepositTransactions.Sum(x => x.amount) - totalPreDeposits;
                        //int mixPreDepositsNotes = PreDepositTransactions.Sum(x => x.notes_count) - totalPreDepositNotes;

                        LogableTask.LogMonoActivityTask("mix", MethodBase.GetCurrentMethod(), TraceLevel.Info, atm.ATMId +" total pre-dep amount="+ PreDepositTransactions.Sum(x => x.amount)
                            + " total recycler pre-dep amount ="+ totalPreDeposits);

                        int tempMixRTR = 0;
                        if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                        {
                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                                tempMixRTR = Convert.ToInt32(YesterdaySummaryDetails[27]) + mixPreDepositsAmount;
                            else
                                tempMixRTR = 0;

                            DFFVersion2Builder.Append(tempMixRTR + "\t");
                            //EA:14-04 remove mix from balance investigation
                            //iSwapReturnAmount += tempMixRTR;

                            if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[28]) && Convert.ToInt32(YesterdaySummaryDetails[28]) > 0)
                            {
                                tempMixRTR = Convert.ToInt32(YesterdaySummaryDetails[28]) + mixPreDepositsNotes;
                            }
                            else
                                tempMixRTR = 0;
                            DFFVersion2Builder.Append(tempMixRTR + "\t");
                            //EA:14-04 remove mix from balance investigation
                            //iSwapReturnAmountTotal += tempMixRTR;
                        }
                        else
                            DFFVersion2Builder.Append("0\t0\t");

                        DFFVersion2Builder.Append("0\t0\t0\t0\t0\t");

                        DFFVersion2Builder.Append("0\t0\t");
                        //DFFVersion2Builder.Append("0\t0\t");
                        DFFVersion2Builder.Append(mixPreDepositsAmount + "\t" + mixPreDepositsNotes + "\t");
                        //DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, TotalDepoistNonRecyclerCassttes, TotalDepoistNotesNonRecyclerCassttes));
                        //EA:14-04
                        //MixDep = depositTransactions.Sum(x => x.amount) - iTotalDeposit + iNonRecyclableDeposit;
                        //MixDepNotes = depositTransactions.Sum(x => x.notes_count) - iTotalDepositNotes + iNonRecyclableDepositNotes;
                        //MixDep = depositTransactions.Sum(x => x.amount) - totalRecyclerClosing;
                        //MixDepNotes = depositTransactions.Sum(x => x.notes_count) - totalRecyclerClosingNotes;
                        MixDep = depositTransactions.Sum(x => x.amount) - iTotalDeposit;
                        MixDepNotes = depositTransactions.Sum(x => x.notes_count) - iTotalDepositNotes;
                        LogableTask.LogMonoActivityTask("mix", MethodBase.GetCurrentMethod(), TraceLevel.Info, atm.ATMId + " total dep amount=" + depositTransactions.Sum(x => x.amount)
                            + " recycler dep amount =" + iTotalDeposit);

                        if (MixDep < 0) MixDep = 0;
                        if (MixDepNotes < 0) MixDepNotes = 0;
                        DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, MixDep + mixPreDepositsAmount, MixDepNotes + mixPreDepositsNotes));

                        //DFFVersion2Builder.Append(TotalYesterdayDeposits + TotalDepoistNonRecyclerCassttes + "\t");
                        //int MixClosing = depositTransactions.Sum(x => x.amount) - totalRecyclerClosing;
                        //int MixClosingNotes = depositTransactions.Sum(x => x.notes_count) - totalRecyclerClosingNotes;

                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) >= 0)
                        {
                            if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                DFFVersion2Builder.Append(MixDep + "\t");
                                //DFFVersion2Builder.Append(MixClosing + "\t");
                            else
                                DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + "\t");
                                //DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixClosing + "\t");
                        }
                        else
                            DFFVersion2Builder.Append(MixDep + "\t");
                            //DFFVersion2Builder.Append(MixClosing + "\t");

                        //DFFVersion2Builder.Append(TotalYesterdayDepositNotes + TotalDepoistNotesNonRecyclerCassttes + "\t");
                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[28]) && Convert.ToInt32(YesterdaySummaryDetails[28]) >= 0)
                        {
                            if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                DFFVersion2Builder.Append(MixDepNotes + "\t");
                                //DFFVersion2Builder.Append(MixClosingNotes + "\t");
                            else    
                                DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[28]) + MixDepNotes + "\t");
                                //DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[28]) + MixClosingNotes + "\t");
                        }
                        else
                            DFFVersion2Builder.Append(MixDepNotes + "\t");
                            //DFFVersion2Builder.Append(MixClosingNotes + "\t");

                        DFFVersion2Builder.Append("0\t0\t");
                        //DFFVersion2Builder.Append(TotalYesterdayDeposits + TotalDepoistNonRecyclerCassttes + "\t");
                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) >= 0)
                        {
                            if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                                DFFVersion2Builder.Append(MixDep + "\t");
                                //DFFVersion2Builder.Append(MixClosing + "\t");
                            else
                                DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + "\t");
                                //DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixClosing + "\t");
                        }
                        else
                            DFFVersion2Builder.Append(MixDep + "\t");
                            //DFFVersion2Builder.Append(MixClosing + "\t");

                        DFFVersion2Builder.Append("1\t" + (field8 == "2" ? "1" : "0") + "\t");
                        DFFVersion2Builder.Append("\r\n");
                    }
                    //subString = field2.Substring(3);
                    //if (subString.Length > 8)
                    //    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4, 8) + "\t");
                    //else
                    //    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4) + "\t");
                    
                    //EA: 14-04 remove total row from DFF
                    //DFFVersion2Builder.Append(field2 + "\t");
                    //DFFVersion2Builder.Append(cashPointType + "\t");
                    //DFFVersion2Builder.Append("F\t");
                    ////DFFVersion2Builder.Append(listCurrencies[0].Key.Substring(0, 3) + "\t01\t00\t");
                    //DFFVersion2Builder.Append("\t01\t00\t");
                    //DFFVersion2Builder.Append("\t");

                    //DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + ":03:00\t0\t");

                    //DFFVersion2Builder.Append(iYesterdayClosingBalance + "\t" + iYesterdayClosingBalanceTotal + "\t");
                    summary.OpeningBalance = iYesterdayClosingBalance;

                    //DFFVersion2Builder.Append(iReplenishment + "\t" + iReplenishmentTotal + "\t");
                    //EA:23-01-2022
                    summary.ReplenishmentAmount = iReplenishment;
                    //DFFVersion2Builder.Append(iSwapReturnAmount + "\t" + iSwapReturnAmountTotal + "\t0\t0\t0\t0\t0\t");
                    //EA:23-01-2022
                    summary.ReturnAmount = iSwapReturnAmount;
                    ////DFFVersion2Builder.Append("0\t");
                    ////DFFVersion2Builder.Append("0\t");
                    //DFFVersion2Builder.Append(iWithdrawals + "\t" + iWithdrawalsTotal + "\t");
                    //EA:23-01-2022
                    summary.Withdrawals = iWithdrawals;
                    summary.PreWithdrawals = iPrewithdrawals;
                    //DFFVersion2Builder.Append(iPrewithdrawals + "\t" + iPrewithdrawalsTotal + "\t");
                    //if (isBNA && atm.IsRecycler.GetValueOrDefault())
                        //DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, depositTransactions.Sum(x => x.amount) + PreDepositTransactions.Sum(x => x.amount)
                           // , depositTransactions.Sum(x => x.notes_count) + PreDepositTransactions.Sum(x => x.notes_count)));
                    ////DFFVersion2Builder.Append(string.Format("{0}\t{1}\t{2}\t", totalDepositTransactions, iTotalDeposit, iTotalDepositNotes));
                    //else
                       // DFFVersion2Builder.Append("0\t0\t0\t");

                    //closing balance
                    if (isBNA && atm.IsRecycler.GetValueOrDefault())
                    {
                        if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                        {
                            if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                            {
                                //DFFVersion2Builder.Append(MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit + "\t");
                                //DFFVersion2Builder.Append(MixDepNotes + iClosingBalanceTotal + iRecyclableDepositNotes + "\t");
                                //summary.ClosingBalance = MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                                summary.ClosingBalance = dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                            }
                            else
                            {
                                //DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit + "\t");
                                //DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[28]) + MixDepNotes + iClosingBalanceTotal + iRecyclableDepositNotes + "\t");
                                //summary.ClosingBalance = Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                                summary.ClosingBalance = Convert.ToInt32(YesterdaySummaryDetails[27]) + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                            }
                        }
                        else
                        {
                            //DFFVersion2Builder.Append(MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit + "\t");
                            //DFFVersion2Builder.Append(MixDepNotes + iClosingBalanceTotal + iRecyclableDepositNotes + "\t");
                            //summary.ClosingBalance = MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                            summary.ClosingBalance =  dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                        }
                    }
                    else
                    {
                        //DFFVersion2Builder.Append(string.Format("{0}\t{1}\t", dispensableNotesSum + iRejectedCounter, iClosingBalanceTotal));
                        summary.ClosingBalance = dispensableNotesSum + iRejectedCounter;
                    }

                    //DFFVersion2Builder.Append(dispensableNotesSum + "\t");

                    ////if (isBNA && atm.IsRecycler.GetValueOrDefault())
                    ////    DFFVersion2Builder.Append(string.Format("{0}\t", iRecyclableDeposit));
                    ////else
                    ////    DFFVersion2Builder.Append("0\t");

                    //if (isBNA && atm.IsRecycler.GetValueOrDefault() && iRecyclableDeposit >= 0)
                    //    DFFVersion2Builder.Append(iRecyclableDeposit + "\t");
                    //else
                    //    DFFVersion2Builder.Append("0\t");

                    //Balance unavailable
                    //if (isBNA && atm.IsRecycler.GetValueOrDefault())
                    //{
                    //    if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                    //    {
                    //        if (replenishmentDay && !isAddCashOnCurrentDay && LastBNACleared != DateTime.MinValue && LastBNACleared.Date == Day.Date)
                    //            DFFVersion2Builder.Append(MixDep + iRejectedCounter + "\t");
                    //        else
                    //            DFFVersion2Builder.Append(Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + iRejectedCounter + "\t");
                    //    }
                    //    else
                    //        DFFVersion2Builder.Append(iRejectedCounter + MixDep + "\t");
                    //}
                    //else
                    //    DFFVersion2Builder.Append(iRejectedCounter + "\t");

                    ////DFFVersion2Builder.Append("1\t0");

                    //DFFVersion2Builder.Append("1\t" + (field8 == "2" ? "1" : "0"));
                    //DFFVersion2Builder.Append("\r\n");
                    ////summary.ClosingBalance = dispensableNotesSum + iRejectedCounter + YesterDayDepositTrxns.Sum(x => x.amount) + depositTransactions.Sum(x => x.amount);
                    ////Eslam
                    ////if (isBNA && atm.IsRecycler.GetValueOrDefault())
                    ////{
                    ////    if (YesterdaySummaryDetails.Count > 0 && !String.IsNullOrEmpty(YesterdaySummaryDetails[27]) && Convert.ToInt32(YesterdaySummaryDetails[27]) > 0)
                    ////        summary.ClosingBalance = Convert.ToInt32(YesterdaySummaryDetails[27]) + MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                    ////    else
                    ////        summary.ClosingBalance = MixDep + dispensableNotesSum + iRejectedCounter + iRecyclableDeposit;
                    ////}
                    ////else
                    ////    summary.ClosingBalance = dispensableNotesSum + iRejectedCounter;

                    ////summary.ClosingBalance = dispensableNotesSum + Diff + iRejectedCounter + iRecyclableDeposit + iNonRecyclableDeposit;
                    summary.Save();
                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("GenSummary", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                    if(!DFFVersion2Builder.ToString().EndsWith("\r\n"))
                        DFFVersion2Builder.Append("\r\n");
                }

            }
            return DFFVersion2Builder.ToString();


        }
        finally
        {
            if (cmd.Connection != null)
                cmd.Connection.Close();
        }

    }

    public string GetOutput()
    {
        string header = "HEADER" + Day.ToString("ddMMyyyy");
        header = header.PadRight(header.Length + 212, ' ') + Environment.NewLine;
        string footer = "FOOTER" + footerCount.ToString().PadLeft(8, '0');
        footer = footer.PadRight(footer.Length + 212, ' ') + Environment.NewLine;
        return header + builder.ToString() + footer;


    }

    private decimal GetWithdrawals()
    {
        decimal withdrawals = 0;

        cmd.CommandText = @"select max(rep_datetime)
                            from replenishment
                            where atm_id = " + atm_id
                            + " and rep_datetime < convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 00:00:00',103)";
        object obj = cmd.ExecuteScalar();

        //null : when first time system is deployed.
        if (obj != DBNull.Value) //no replenishment
        {
            cmd.CommandText = @"select isnull(sum(amount),0)
                            from parsed_transaction
                            where atm_id = " + atm_id +
                          " and trxn_datetime >=convert(datetime,'" + DateTime.Parse(obj.ToString()).ToString("dd/MM/yyyy") + "',103) " +
                          " and trxn_datetime <= convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + "',103) and is_prewithdrawal = 0";
            withdrawals = (decimal)cmd.ExecuteScalar();
        }
        return withdrawals;
    }

    private decimal GetTotalWithdrawals(DateTime dt)
    {
        cmd.CommandText = "select withdrawals from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + "',103)";
        return GetValue(cmd.ExecuteScalar());
    }

    private void ConstructFakeOutput(LogableTask task)
    {
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "atm_id = " + atm_id + " and ejDateTime=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)");

        /*      EjStatus existingEjStatus = EjStatus.LoadEjStatus("atm_id = " + atm_id + " and ejDateTime=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)");

              if (existingEjStatus == null)
              {
                  dFFVersion2Helper.dt = Day;
                  string field1 = "00000000";
                  string field2 = atm.Title;
                  string field3 = "000000000";
                  string field4 = "000000000";
                  string field5 = "000000000";
                  string field6 = "000000000";
                  string field7 = "000000000";
                  string field8 = "2"; //in service;
                  string last = "0";
                  last = last.PadLeft(150, '0');
                  builder.Append(field1 + field2 + field3 + field4 + field5 + field6 + field7 + field8 + last + Environment.NewLine);
                  task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, string.Format("empty data generated successfully for atm[{0}]", atm_id));

                  isEmptyDataGenerated = true;
                  DailyFeedSchedule dailyFeedSchedule = DailyFeedSchedule.LoadDailyFeedSchedule("atm_id=" + atm_id + " and date_from>=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) " +
                      " and date_to<=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103) ");
                  if (dailyFeedSchedule == null)
                  {
                      dailyFeedSchedule = new DailyFeedSchedule();
                      dailyFeedSchedule.CreationTime = DateTime.Now;
                      dailyFeedSchedule.DateFrom = Day;
                      dailyFeedSchedule.DateTo = Day;
                      dailyFeedSchedule.IsExecuted = false;
                      dailyFeedSchedule.RetryCount = 3;
                      dailyFeedSchedule.ScheduleDate = Day.AddDays(1);
                      dailyFeedSchedule.AtmId = atm_id;
                      dailyFeedSchedule.Mcn = "";
                      dailyFeedSchedule.CreatedBy = 1;
                      dailyFeedSchedule.DeleteCurrentData = false;
                      dailyFeedSchedule.EnableDffGeneration = false;
                      dailyFeedSchedule.Save();
                      task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, string.Format("Regenerate summary task scheduled for atm[{0}]", atm_id));
                  }
                  else
                  {
                      dailyFeedSchedule.ScheduleDate = dailyFeedSchedule.ScheduleDate.Value.AddDays(1);
                      dailyFeedSchedule.Save();
                      task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, string.Format("Regenerate summary task ALREADY scheduled for atm[{0}]", atm_id));
                  }




              }
              else
              {
      */
        //Added on 19/02/2014
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.CommandText = "GetMaxTransactionDateLessThanGivenDate";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters[0].Value = Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[1].Value = atm.ATMId;

        //cmd.CommandText = "select max(trxn_datetime) from parsed_transaction where atm_id = " + atm_id + " and trxn_datetime<=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";
        object lastMaxTrxnDateTime = cmd.ExecuteScalar();
        if (lastMaxTrxnDateTime != DBNull.Value)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "GetMaxReplenishmentDateLessThanGivenDate";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
            cmd.Parameters[1].Value = atm.ATMId;
            //cmd.Parameters.Add("AtmId",atm_id);

            //cmd.CommandText = "select max(rep_datetime) from replenishment where atm_id = " + atm_id + " and rep_datetime<=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";
            object lastMaxRepDateTime = cmd.ExecuteScalar();
            if (lastMaxRepDateTime != DBNull.Value)
                if (DateTime.Parse(lastMaxRepDateTime.ToString()) > DateTime.Parse(lastMaxTrxnDateTime.ToString()))
                    lastMaxTrxnDateTime = lastMaxRepDateTime;

            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, string.Format("Ej file not found or the file is empty.So Data from day[{2}] will be used to generate summary for this atm[{0}] for this day [{1}]", atm_id, Day, lastMaxTrxnDateTime));
            tempDay = Day;
            Day = DateTime.Parse(lastMaxTrxnDateTime.ToString());// Day.AddDays(-1);
            dateModified = true;
            dFFVersion2Helper.dateModified = true;
            //ConstructOutput(cmd.Connection, trxn);
            //Added on 27/10/2014 to restore date to the summary date even in case of failure..
            try
            {
                StartGeneration(task, atm_id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Day = tempDay;
            }

            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Warning, string.Format("Summary data generated successfully for atm[{0}]", atm_id));
        }
        else
        {


            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCountersFromDispenserEndOfDayBalance";
            //cmd.Parameters.AddWithValue("FromDate", Day.ToString("dd/MM/yyyy"));
            //cmd.Parameters.AddWithValue("AtmId", atm_id);
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = atm.ATMId;





            //                cmd.CommandText = @"select cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,
            //                                    cassette6_remaining_notes,cassette7_remaining_notes,
            //                                    cassette1_dispensed_notes,cassette2_dispensed_notes,cassette3_dispensed_notes,cassette4_dispensed_notes,cassette5_dispensed_notes,
            //                                    cassette6_dispensed_notes,cassette7_dispensed_notes,
            //                                    cassette1_purged_notes,cassette2_purged_notes,cassette3_purged_notes,cassette4_purged_notes,cassette5_purged_notes,
            //                                    cassette6_purged_notes,cassette7_purged_notes from dispenser_end_of_day_balance 
            //                                    where counter_file_datetime =convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) "
            //                                    + " and atm_id = " + atm_id;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dFFVersion2Helper.dt = Day;
                string field1 = "00000000";
                string field2 = atm.Title;
                string field3 = "000000000";
                string field4 = "000000000";
                string field5 = "000000000";
                string field6 = "000000000";
                int notesInCassette1 = int.Parse(dt.Rows[0][0].ToString()) + int.Parse(dt.Rows[0][14].ToString());
                int notesInCassette2 = int.Parse(dt.Rows[0][1].ToString()) + int.Parse(dt.Rows[0][15].ToString());
                int notesInCassette3 = int.Parse(dt.Rows[0][2].ToString()) + int.Parse(dt.Rows[0][16].ToString());
                int notesInCassette4 = int.Parse(dt.Rows[0][3].ToString()) + int.Parse(dt.Rows[0][17].ToString());
                int notesInCassette5 = int.Parse(dt.Rows[0][4].ToString()) + int.Parse(dt.Rows[0][18].ToString());
                int notesInCassette6 = int.Parse(dt.Rows[0][5].ToString()) + int.Parse(dt.Rows[0][19].ToString());
                //int notesInCassette7 = int.Parse(dt.Rows[0][6].ToString()) + int.Parse(dt.Rows[0][20].ToString());

                string field7 = (notesInCassette1 * noteSetType.DenominationType1
                                + notesInCassette2 * noteSetType.DenominationType2
                                + notesInCassette3 * noteSetType.DenominationType3
                                 + notesInCassette4 * noteSetType.DenominationType4
                                  + notesInCassette5 * noteSetType.DenominationType5
                                   + notesInCassette6 * noteSetType.DenominationType6
                                   ).ToString().PadLeft(9, '0');
                string field8 = "0"; //in service;


                string temp = noteSetType.DenominationType1.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette1.ToString()) +
                     noteSetType.DenominationType2.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette2.ToString()) +
                     noteSetType.DenominationType3.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette3.ToString()) +
                     noteSetType.DenominationType4.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette4.ToString()) +
                     noteSetType.DenominationType5.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette5.ToString()) +
                     noteSetType.DenominationType6.Value.ToString().PadLeft(6, '0') + "0".PadLeft(9, '0') + GetDenominationState(notesInCassette6.ToString());



                builder.Append(field1 + field2 + field3 + field4 + field5 + field6 + field7 + field8 + temp + notesInCassette1.ToString().PadLeft(9, '0') +
                   notesInCassette2.ToString().PadLeft(9, '0') + notesInCassette3.ToString().PadLeft(9, '0') + notesInCassette4.ToString().PadLeft(9, '0') +
                   notesInCassette5.ToString().PadLeft(9, '0') + notesInCassette6.ToString().PadLeft(9, '0') + Environment.NewLine);

                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, string.Format("Data generated using EOD Balance for atm[{0}]", atm_id));
            }
            else
                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "No data found to generate summary for atm " + atm_id + "for the day <=" + Day.AddDays(-1).ToString());
        }

        //}

    }

    private int GetDenominationState(string remainingNotesCount)
    {
        if (int.Parse(remainingNotesCount) > 0)
            return 0;
        else if (remainingNotesCount == "0" && field8 == "0")
            return 1;
        else
            return 2;

    }
    private string AddCashDispensedToOutput(string[] parts)
    {
        //        cmd.CommandText = @"select cash_dispensed1,cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6
        //                           from dispensed where atm_id = " + atm_id + " and clearing_datetime>= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 00:00:00',103) and  clearing_datetime<= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103) ";
        string[] currentDayNotesparts = currentDayWithdrawalsNotes.Split('|');
        //        cmd.CommandText = @"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
        //                isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0)
        //                           from parsed_transaction where atm_id = " + atm_id +
        //                " and trxn_datetime>= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)  " +
        //                " and  trxn_datetime<= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103) ";


        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);


        //        if (dt.Rows.Count > 0)
        //        {
        //for (int i = 0; i < 6; i++)
        //    if (int.Parse(dt.Rows[0][i].ToString()) < 0)
        //        dt.Rows[0][i] = 0;

        return noteSetType.DenominationType1.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[0]) * noteSetType.DenominationType1.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[0]) +
        noteSetType.DenominationType2.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[1]) * noteSetType.DenominationType2.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[1]) +
        noteSetType.DenominationType3.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[2]) * noteSetType.DenominationType3.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[2]) +
        noteSetType.DenominationType4.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[3]) * noteSetType.DenominationType4.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[3]) +
        noteSetType.DenominationType5.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[4]) * noteSetType.DenominationType5.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[4]) +
        noteSetType.DenominationType6.Value.ToString().PadLeft(6, '0') + (int.Parse(currentDayNotesparts[5]) * noteSetType.DenominationType6.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[5]);

        //}
        //else
        //    return "0";
        //DispensedRegex.Match(
    }
    private void ConstructOutput(SqlConnection conn)
    {

        int[] purgedCounters = null;
        decimal yesterdayClosingBalance = 0;
        decimal closingBalance = 0;
        string field1 = "00000000";
        string field2 = atm.Title;
        string field3 = null;
        string field4 = null;
        string field5 = null;
        string field6 = null;
        string field7 = null;
        string last = "0";
        if (!dateModified)
            dFFVersion2Helper.dt = Day;
        else
            dFFVersion2Helper.dt = tempDay;
        //decimal yesterdayClosingBalance = 0;

        if (!dateModified)
        {
            //if ((List<Replenishment>)ReplenishmentByDay[Day]).)
            //yesterdayClosingBalance=GetClosingBalance(Day.AddDays(-1));
            string notes = GetReplenishmentAmountInTermsOfNotes(Day);
            repNotes = notes.Split('|');
            dFFVersion2Helper.repNotes = notes;
            field3 = (noteSetType.DenominationType1 * int.Parse(repNotes[0]) +
                noteSetType.DenominationType2 * int.Parse(repNotes[1]) +
                noteSetType.DenominationType3 * int.Parse(repNotes[2]) +
                noteSetType.DenominationType4 * int.Parse(repNotes[3]) +
                noteSetType.DenominationType5 * int.Parse(repNotes[4]) +
                noteSetType.DenominationType6 * int.Parse(repNotes[5]) +
                noteSetType.DenominationType7 * int.Parse(repNotes[6])).ToString().PadLeft(9, '0');


            //((int)GetReplenishmentAmount(Day)).ToString().PadLeft(9, '0');

        }
        else
            field3 = "0".PadLeft(9, '0');


        if (!dateModified)
        {
            decimal returnAmount = 0;
            if (!isAddCashOnCurrentDay)
                returnAmount = 0;
                //EA:23-01-2022
                //returnAmount = GetReturnAmount(Day, ref yesterdayClosingBalance);
            //+rejectedCountsForRepDay;
            //GetRejectedCountOfTestCashForRepDay(Day);
            if (returnAmount < 0)
                returnAmount = 0;

            field4 = returnAmount.ToString().PadLeft(9, '0');
        }
        else
            field4 = "0".PadLeft(9, '0');

        if (!dateModified)
            field5 = totalWithdrawals.ToString().PadLeft(9, '0');
        else
        {
            field5 = "0".PadLeft(9, '0');
            totalWithdrawals = 0;
        }

        //string field6 = (GetClosingBalance(Day.AddDays(-1)) + totalPreWithdrawals).ToString().PadLeft(9, '0');
        //int consumptionBetweenTwoRep = (int)(GetWithdrawals() + totalPreWithdrawals);
        //if (consumptionBetweenTwoRep < 0)
        //    consumptionBetweenTwoRep = 0;

        //string field6 = consumptionBetweenTwoRep.ToString().PadLeft(9, '0');
        if (!dateModified)
            field6 = totalPreWithdrawals.ToString().PadLeft(9, '0');
        else
        {
            field6 = "0".PadLeft(9, '0');
            totalPreWithdrawals = 0;
            dFFVersion2Helper.preWithdrawalNotes = null;
        }


        //if (!dateModified)
        //{
        //EA:23-01-2021
        //currentDayBalanceNotes = GetClosingBalanceInTermsOfNotes(Day);
        currentDayBalanceNotes = "0|0|0|0|0|0|0";
        string[] parts = currentDayBalanceNotes.Split('|');
        closingBalance = decimal.Parse((noteSetType.DenominationType1 * int.Parse(parts[0]) +
            noteSetType.DenominationType2 * int.Parse(parts[1]) +
            noteSetType.DenominationType3 * int.Parse(parts[2]) +
            noteSetType.DenominationType4 * int.Parse(parts[3]) +
            noteSetType.DenominationType5 * int.Parse(parts[4]) +
            noteSetType.DenominationType6 * int.Parse(parts[5]) +
            noteSetType.DenominationType7 * int.Parse(parts[6])).ToString());

        //closingBalance = GetClosingBalance(Day);
        bool readFromCashPosition = false;
        CashPosition cashPosition = null;
        //GetRejectedCountForDay(Day);
        //EA:23-01-2021
        //if (closingBalance <= 0) // if yesterday closing balance is 0 since we don't have cash positions.
        if (closingBalance < 0) // if yesterday closing balance is 0 since we don't have cash positions.
        {
            //  if (atm.CreationTime.ToString("dd/MM/yyyy") == Day.ToString("dd/MM/yyyy"))
            //Get from cash positios if any
            // {
            cashPosition = CashPosition.LoadCashPosition("atm_id =" + atm_id + " and last_trxn_at >=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) " +
                " and last_trxn_at <=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103)");

            if (cashPosition != null)
            {
                purgedCounters = new int[7];
                closingBalance = cashPosition.Cassette1Notes.Value * noteSetType.DenominationType1.Value +
                    cashPosition.Cassette2Notes.Value * noteSetType.DenominationType2.Value +
                    cashPosition.Cassette3Notes.Value * noteSetType.DenominationType3.Value +
                    cashPosition.Cassette4Notes.Value * noteSetType.DenominationType4.Value +
                    cashPosition.Cassette5Notes.Value * noteSetType.DenominationType5.Value +
                    cashPosition.Cassette6Notes.Value * noteSetType.DenominationType6.Value +
                    cashPosition.Cassette7Notes.Value * noteSetType.DenominationType7.Value + GetRejectedCountForDay(Day, purgedCounters);

                if (closingBalance <= 0)
                {
                    closingBalance = 0;
                }
                else
                {
                    readFromCashPosition = true;
                    dFFVersion2Helper.readFromCashPosition = true;
                }

            }
            else
                closingBalance = 0;
            // }
            //else
            //  closingBalance = 0;
        }

        field7 = closingBalance.ToString().PadLeft(9, '0');

        //}
        //else
        //    field7 = "0".PadLeft(9, '0');

        field8 = "0"; //in service;

        //if (!dateModified)
        //    last = AddCashDispensedToOutput();

        //if (!dateModified)


        string closingBalanceNotes = null;
        parts = null;
        if (readFromCashPosition)
        {

            dFFVersion2Helper.rejectedCounters = purgedCounters[0] + "|" + purgedCounters[1] + "|" + purgedCounters[2] + "|" + purgedCounters[3] + "|" + purgedCounters[4] + "|" +
                                                            purgedCounters[5] + "|" + purgedCounters[6];
            dFFVersion2Helper.closingBalanceFromCashPosition = cashPosition.Cassette1Notes.Value + "|" +
                cashPosition.Cassette2Notes.Value + "|" +
                cashPosition.Cassette3Notes.Value + "|" +
                cashPosition.Cassette4Notes.Value + "|" +
                cashPosition.Cassette5Notes.Value + "|" +
                cashPosition.Cassette6Notes.Value + "|" +
                cashPosition.Cassette7Notes.Value;

            parts = ((cashPosition.Cassette1Notes.Value + purgedCounters[0]).ToString() + "|" +
                (cashPosition.Cassette2Notes.Value + purgedCounters[1]).ToString() + "|" +
                (cashPosition.Cassette3Notes.Value + purgedCounters[2]).ToString() + "|" +
                (cashPosition.Cassette4Notes.Value + purgedCounters[3]).ToString() + "|" +
                (cashPosition.Cassette5Notes.Value + purgedCounters[4]).ToString() + "|" +
                (cashPosition.Cassette6Notes.Value + purgedCounters[5]).ToString() + "|" +
                (cashPosition.Cassette7Notes.Value + purgedCounters[6]).ToString()).Split('|');

        }
        else
        {
            //Change done on 30/01/2014
            closingBalanceNotes = currentDayBalanceNotes;
            //GetClosingBalanceInTermsOfNotes(Day);


            parts = closingBalanceNotes.Split('|');
        }

        for (int i = 0; i < 7; i++)
            if (int.Parse(parts[i]) < 0)
                parts[i] = "0";

        last = AddCashDispensedToOutput(parts);





        //  last = last.PadRight(150, '0');
        int index = 0;
        builder.Append(field1 + field2 + field3 + field4 + field5 + field6 + field7 + field8 + last +
            (int.Parse(parts[index++]) * noteSetType.DenominationType1.Value).ToString().PadLeft(9, '0') +
            (int.Parse(parts[index++]) * noteSetType.DenominationType2.Value).ToString().PadLeft(9, '0') +
            (int.Parse(parts[index++]) * noteSetType.DenominationType3.Value).ToString().PadLeft(9, '0') +
            (int.Parse(parts[index++]) * noteSetType.DenominationType4.Value).ToString().PadLeft(9, '0') +
            (int.Parse(parts[index++]) * noteSetType.DenominationType5.Value).ToString().PadLeft(9, '0') +
            (int.Parse(parts[index++]) * noteSetType.DenominationType6.Value).ToString().PadLeft(9, '0') + Environment.NewLine);

        Summary summary = new Summary();
        summary.GeneratedAt = DateTime.Now;
        summary.AtmId = atm_id;
        summary.ClosingBalance = closingBalance;
        summary.PreWithdrawals = totalPreWithdrawals;
        summary.Withdrawals = totalWithdrawals;
        //LogableTask.LogMonoActivityTask("PrintRepAmount", MethodBase.GetCurrentMethod(), TraceLevel.Info, field3);
        summary.ReplenishmentAmount = Convert.ToInt32(field3);
        if (summary.ReplenishmentAmount == 0)
        {
            dFFVersion2Helper.preWithdrawalNotes = null;
        }
        summary.ReturnAmount = int.Parse(field4);
        //string closingBalanceNotes = GetClosingBalanceInTermsOfNotes(Day);
        //string[] parts =closingBalanceNotes.Split('|');
        summary.CashRemaining1 = int.Parse(parts[0]);
        summary.CashRemaining2 = int.Parse(parts[1]);
        summary.CashRemaining3 = int.Parse(parts[2]);
        summary.CashRemaining4 = int.Parse(parts[3]);
        summary.CashRemaining5 = int.Parse(parts[4]);
        summary.CashRemaining6 = int.Parse(parts[5]);
        summary.CashRemaining7 = int.Parse(parts[6]);

        //Not getting following logic.
        //if (!isAddCashOnCurrentDay)
        //{
        // //   repNotes = GetReplenishmentAmountInTermsOfNotes(Day).Split('|');
        //}
        //else
        //    repNotes = GetActualReplenishedNotes(Day).Split('|');
        if (repNotes != null)
        {
            summary.CashAdded1 = int.Parse(repNotes[0]);
            summary.CashAdded2 = int.Parse(repNotes[1]);
            summary.CashAdded3 = int.Parse(repNotes[2]);
            summary.CashAdded4 = int.Parse(repNotes[3]);
            summary.CashAdded5 = int.Parse(repNotes[4]);
            summary.CashAdded6 = int.Parse(repNotes[5]);
            summary.CashAdded7 = int.Parse(repNotes[6]);
        }
        else
        {
            summary.CashAdded1 = 0;
            summary.CashAdded2 = 0;
            summary.CashAdded3 = 0;
            summary.CashAdded4 = 0;
            summary.CashAdded5 = 0;
            summary.CashAdded6 = 0;
            summary.CashAdded7 = 0;
        }


        if (summary.ReplenishmentAmount > 0)
        {

            if (isAddCashOnCurrentDay)
            {

                summary.ReturnType1 = 0;
                summary.ReturnType2 = 0;
                summary.ReturnType3 = 0;
                summary.ReturnType4 = 0;
                summary.ReturnType5 = 0;
                summary.ReturnType6 = 0;
                summary.ReturnType7 = 0;

            }
            else
            {

                string preWithdrawal = preWithdrawalNotes;
                //Changes done on 30/01/2014.
                // ExtractDayWisePreWithdrawalsInTermsOfNotes(Day);
                string _yesterdayClosingBalance = yesterdayBalanceNotes;
                //Added on 24/02/2014...to handle case when _yesterdayClosingBalance is ""(empty)
                if (_yesterdayClosingBalance.Length == 0)
                    _yesterdayClosingBalance = "0|0|0|0|0|0|0";
                    //EA:23-01-2022
                    //_yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));

                string[] preWithdrawalParts = preWithdrawal.Split('|');
                string[] yesterdayClosingBalanceParts = _yesterdayClosingBalance.Split('|');

                summary.ReturnType1 = int.Parse(yesterdayClosingBalanceParts[0]) - int.Parse(preWithdrawalParts[0]);
                if (summary.ReturnType1 < 0)
                    summary.ReturnType1 = 0;

                summary.ReturnType2 = int.Parse(yesterdayClosingBalanceParts[1]) - int.Parse(preWithdrawalParts[1]);
                if (summary.ReturnType2 < 0)
                    summary.ReturnType2 = 0;

                summary.ReturnType3 = int.Parse(yesterdayClosingBalanceParts[2]) - int.Parse(preWithdrawalParts[2]);
                if (summary.ReturnType3 < 0)
                    summary.ReturnType3 = 0;

                summary.ReturnType4 = int.Parse(yesterdayClosingBalanceParts[3]) - int.Parse(preWithdrawalParts[3]);
                if (summary.ReturnType4 < 0)
                    summary.ReturnType4 = 0;

                summary.ReturnType5 = int.Parse(yesterdayClosingBalanceParts[4]) - int.Parse(preWithdrawalParts[4]);
                if (summary.ReturnType5 < 0)
                    summary.ReturnType5 = 0;

                summary.ReturnType6 = int.Parse(yesterdayClosingBalanceParts[5]) - int.Parse(preWithdrawalParts[5]);
                if (summary.ReturnType6 < 0)
                    summary.ReturnType6 = 0;

                summary.ReturnType7 = int.Parse(yesterdayClosingBalanceParts[6]) - int.Parse(preWithdrawalParts[6]);
                if (summary.ReturnType7 < 0)
                    summary.ReturnType7 = 0;

            }
        }






        if (dateModified)
            summary.TrxnDatetime = new DateTime(tempDay.Year, tempDay.Month, tempDay.Day);// DateTime.Parse(tempDay.ToString("dd/MM/yyyy"));
        else
            summary.TrxnDatetime = new DateTime(Day.Year, Day.Month, Day.Day);//.ToString("dd/MM/yyyy")); 

        //AppSetting appSetting = AppSetting.LoadAppSetting("1=1");

        //if (cashPosition == null)
        //    cashPosition = CashPosition.LoadCashPosition("atm_id =" + atm_id + " and last_trxn_at >=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) " +
        //            " and last_trxn_at <=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103)");

        //if (cashPosition != null)
        //{

        //    if (purgedCounters == null)
        //        purgedCounters = new int[7];
        //    GetRejectedCountForDay(Day, purgedCounters);
        //    int[] testCashNotes = GetTestCashPurgedBinValue(Day);

        //    if ((cashPosition.Cassette1Notes + purgedCounters[0] != summary.CashRemaining1)
        //        || (cashPosition.Cassette2Notes + purgedCounters[1] != summary.CashRemaining2)
        //        || (cashPosition.Cassette3Notes + purgedCounters[2] != summary.CashRemaining3)
        //    || (cashPosition.Cassette4Notes + purgedCounters[3] != summary.CashRemaining4)
        //    || (cashPosition.Cassette5Notes + purgedCounters[4] != summary.CashRemaining5)
        //    || (cashPosition.Cassette6Notes + purgedCounters[5] != summary.CashRemaining6)
        //    || (cashPosition.Cassette7Notes + purgedCounters[6] != summary.CashRemaining7))

        //        if ((cashPosition.Cassette1Notes + cashPosition.PurgeCassette1Notes + testCashNotes[0] != summary.CashRemaining1)
        //           || (cashPosition.Cassette2Notes + cashPosition.PurgeCassette2Notes + testCashNotes[1] != summary.CashRemaining2)
        //           || (cashPosition.Cassette3Notes + cashPosition.PurgeCassette3Notes + testCashNotes[2] != summary.CashRemaining3)
        //       || (cashPosition.Cassette4Notes + cashPosition.PurgeCassette4Notes + testCashNotes[3] != summary.CashRemaining4)
        //       || (cashPosition.Cassette5Notes + cashPosition.PurgeCassette5Notes + testCashNotes[4] != summary.CashRemaining5)
        //       || (cashPosition.Cassette6Notes + cashPosition.PurgeCassette6Notes + testCashNotes[5] != summary.CashRemaining6)
        //       || (cashPosition.Cassette7Notes + cashPosition.PurgeCassette7Notes + testCashNotes[6] != summary.CashRemaining7))


        //            try
        //            {
        //                AlertManager.GenerateTerminalAlert(atm_id, (int)EnumAlertType.DFFSuspect, "Discrepency found in computing closing balance and balance found from ATM current position,Date of cash position " + cashPosition.LastTrxnAt.ToString(), trxn, appSetting.AlertExpirationTime.Value, 10);
        //            }

        //            catch (Exception ex)
        //            {

        //                try
        //                {
        //                    EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace);
        //                }
        //                catch
        //                {
        //                }

        //            }

        //}


        //Change done on 30/01/2014 ..
        //This value will come from Return Amount function.

        //decimal yesterdayClosingBalance = GetClosingBalance(Day.AddDays(-1));
        //if ((yesterdayClosingBalance < summary.Withdrawals) && (summary.ReplenishmentAmount == 0))
        //{
        //    try
        //    {

        //        AlertManager.GenerateTerminalAlert(atm_id, (int)EnumAlertType.DFFSuspect, "Opening balance" + yesterdayClosingBalance
        //            + " is less than withdrawals " + summary.Withdrawals

        //            , trxn, appSetting.AlertExpirationTime.Value, 10);
        //    }
        //    catch (Exception ex)
        //    {

        //        try
        //        {
        //            EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace);
        //        }
        //        catch
        //        {
        //        }

        //    }

        //}

        summary.Save(conn);




    }



    //public void WriteFile()
    //{
    //    string outputFileName = AppDomain.CurrentDomain.BaseDirectory + "\\output.txt";
    //    StreamWriter writer = null;
    //    try
    //    {
    //        writer = new StreamWriter(outputFileName);
    //        //writing header
    //        //string header = "HEADER" + files[0].Name.Substring(9, 2) + files[0].Name.Substring(7, 2) +
    //        //    files[0].Name.Substring(3, 4);
    //        //writer.WriteLine(header.PadRight(header.Length + 198, ' '));
    //        DateTime[] dte = new DateTime[WithdrawalsByDay.Count];

    //        WithdrawalsByDay.Keys.CopyTo(dte, 0);
    //        Array.Sort(dte);

    //        foreach (DateTime dt in dte)
    //        {
    //            string field1 = "00000000";
    //            //field1 = field1.PadLeft(8, '0');

    //            string field2 = "ATM99999";
    //            string field3 = ((int)GetReplenishmentAmount(dt)).ToString().PadLeft(9, '0');

    //            string field4 = ((int)GetReturnAmount(dt)).ToString().PadLeft(9, '0');

    //            string field5 = Convert.ToInt32(WithdrawalsByDay[dt]).ToString().PadLeft(9, '0');
    //            string field6 = (((int)GetClosingBalance(dt.AddDays(-1))) + Convert.ToInt32(PreWithdrawalsByDay[dt])).ToString().PadLeft(9, '0');

    //            string field7 = ((int)GetClosingBalance(dt)).ToString().PadLeft(9, '0');
    //            string field8 = "0"; //in service;
    //            string last = "0";
    //            last = last.PadLeft(150, '0');

    //            writer.WriteLine(field1 + field2 + field3 + field4 + field5 + field6 + field7 + field8 + last);
    //            //writing footer;
    //            //string footer = "FOOTER" + files.Length.ToString().PadLeft(8, '0');
    //            //writer.WriteLine(footer.PadRight(footer.Length + 198, ' '));
    //        }
    //    }
    //    finally
    //    {
    //        if (writer != null)
    //            writer.Close();
    //    }

    //}

    private decimal GetSwapReturnAmount() { return 0; }

    private List<string> GetAllWDFromRecycler(DateTime trxnDate, bool getPre)
    {
        List<string> result = new List<string>();
        string temp = "";
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetWDTrxnFromRecycler";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters.Add("@GetPre", SqlDbType.Bit);
        cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;
        cmd.Parameters[3].Value = getPre;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        RevertCommandObjToRunTextQuery();
        if (dt.Rows == null || dt.Rows.Count == 0)
            return new List<string>{ "0|0|0|0|0|0|0|0"};

        for (int row = 0; row < dt.Rows.Count; row++)
        {
            temp = dt.Rows[row][0] + "|" + dt.Rows[row][1] + "|"
            + dt.Rows[row][2] + "|" + dt.Rows[row][3] + "|"
            + dt.Rows[row][4] + "|" + dt.Rows[row][5] + "|" + dt.Rows[row][6] + "|" + dt.Rows[row][7];

            result.Add(temp);
        }
        return result;
    }
    //EA: 09-01-2022 for new all reps
    private string GetAllReplenishmentsNotesWithinDay(DateTime trxnDate)
    {
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllReplenishmentsNotesWithinDay";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        RevertCommandObjToRunTextQuery();
        int row = 0, col = 0;
        if (dt.Rows == null || dt.Rows.Count == 0)
            return "0|0|0|0|0|0|0";
        return dt.Rows[row][col++] + "|" +
            dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++];
    }

    private string ExtractDayWiseWithdrawalsInTermsOfNotes(DateTime trxnDate)
    {
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;



        //        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
        //isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
        //isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
        //isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
        //                            from parsed_transaction
        //                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
        //                            and trxn_datetime <=convert(datetime,'{2}',103)",
        //                            atm_id, trxnDate.ToString("dd/MM/yyyy"), trxnDate.ToString("dd/MM/yyyy") + " 23:59:59");
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            RevertCommandObjToRunTextQuery();
            int row = 0, col = 0;
            if (dt.Rows.Count == 0)
                return "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            return dt.Rows[row][col++] + "|" +
                dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|" +

                dt.Rows[row][col++] + "|" +
                dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|"
                + dt.Rows[row][col++] + "|";
        }
        catch (Exception ex)
        {
            LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Error, trxnDate.ToString() + "--dt rows for atm--" + atm.ATMId + "-->" + dt.Rows.Count.ToString());
            LogableTask.LogMonoActivityTask(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
            return "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
        }
        //totalWithdrawals = GetValue(cmd.ExecuteScalar());
    }

    private List<int[]> GetEjRecycledNotesSummary(DateTime trxnDate, bool getPre)
    {
        List<int[]> result = new List<int[]>();
        int[] data = new int[7];
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetEjRecycledNotesSummary";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters.Add("@GetPre", SqlDbType.Bit);
        cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;
        cmd.Parameters[3].Value = getPre;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        RevertCommandObjToRunTextQuery();
        int row = 0, col = 0;
        //EA:01-02-2022
        if (ds.Tables == null || ds.Tables.Count == 0)
            return new List<int[]> { new int[7] { 0, 0, 0, 0, 0, 0, 0 }, new int[7] { 0, 0, 0, 0, 0, 0, 0 } };

        while (col < ds.Tables[0].Columns.Count)
        {
            data[col] = int.Parse(ds.Tables[0].Rows[row][col++].ToString());
        }
        result.Add(data);
        if (getPre == true)
        {
            int[] data1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            col = 0;
            while (col < ds.Tables[1].Columns.Count)
            {
                data1[col] = int.Parse(ds.Tables[1].Rows[row][col++].ToString());
            }
            result.Add(data1);
        }
        return result;
    }

    private List<List<DepositTransaction>> ExtractDayWiseDepositsInTermsOfNotes(DateTime trxnDate,bool getPre)
    {
        List<List<DepositTransaction>> result = new List<List<DepositTransaction>>();
        List<DepositTransaction> val = new List<DepositTransaction>();
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetEjDepositNotesSummary";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters.Add("@GetPre", SqlDbType.Bit);
        cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;
        cmd.Parameters[3].Value = getPre;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        RevertCommandObjToRunTextQuery();

        for (int i = 0; i < ds.Tables.Count; i++)
        {
            val = (from DataRow dr in ds.Tables[i].Rows
                   select new DepositTransaction()
                   {
                       ej_parsed_bna_transaction_id = Convert.ToInt32(dr["ej_parsed_bna_transaction_id"]),
                       note_type = Convert.ToInt32(dr["note_type"]),
                       notes_count = Convert.ToInt32(dr["notes_count"])
                   }
                     ).ToList();
            result.Add(val);
        }
        return result;
    }
    
    private decimal ExtractDayWiseWithdrawals(DateTime dt)
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ExtractDayWiseWithdrawals";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters[0].Value = dt.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = dt.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;

        decimal result = decimal.Parse(cmd.ExecuteScalar().ToString());
        RevertCommandObjToRunTextQuery();
        return result;
        //Revert all so that existing code is not affected. 
        ////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////



        //        cmd.CommandText = string.Format(@"select sum(amount)
        //                            from parsed_transaction
        //                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
        //                            and trxn_datetime <=convert(datetime,'{2}',103)",
        //                            atm_id, dt.ToString("dd/MM/yyyy"), dt.ToString("dd/MM/yyyy") + " 23:59:59");
        //        return GetValue(cmd.ExecuteScalar());
    }

    private void RevertCommandObjToRunTextQuery()
    {
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
    }

    private void ExtractDayWiseWithdrawals()
    {
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ExtractDayWiseWithdrawals";
        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
        cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
        cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
        cmd.Parameters[2].Value = atm_id;
        totalWithdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());
        //Revert all so that existing code is not affected. 
        ////////////////////////////////////////////////////////////////
        RevertCommandObjToRunTextQuery();
        ///////////////////////////////////////////////////////////////

        //        cmd.CommandText = string.Format(@"select sum(amount)
        //                            from parsed_transaction
        //                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
        //                            and trxn_datetime <=convert(datetime,'{2}',103)",
        //                            atm_id, Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
        //        totalWithdrawals = GetValue(cmd.ExecuteScalar());
    }

    private decimal GetLastReportedBalance() { return 0; }

    private string ExtractDayWisePreWithdrawalsInTermsOfNotes(DateTime trxnDate)
    {
        if (ReplenishmentByDay[trxnDate] == null)
            totalPreWithdrawals = 0;
        else
        {
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();


            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMinReplenishmentDate";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = trxnDate.ToString("dd/MM/yyyy") + " 23:59:59";
            cmd.Parameters[2].Value = atm_id;


            //            cmd.CommandText = string.Format(@"select min(rep_datetime)
            //                                from replenishment
            //                                where atm_id = {0} and rep_datetime >=convert(datetime,'{1} 00:00:00',103) 
            //and rep_datetime <=convert(datetime,'{1} 23:59:59',103) ",
            //                                atm_id, trxnDate.ToString("dd/MM/yyyy"));
            //EA: 17-01-2022 to handle if no Rep
            object RepDate = cmd.ExecuteScalar();
            if (RepDate == DBNull.Value || String.IsNullOrEmpty(RepDate.ToString()))
                return "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            LogableTask.LogMonoActivityTask("PreWithdrawals", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "--GET REP Date to be used in pre-withdrawals for ATM--"+ atm.ATMId+"-->"+ RepDate.ToString());

            DateTime replenishmentDateTime = DateTime.Parse(RepDate.ToString());
            //DateTime replenishmentDateTime = DateTime.Parse(cmd.ExecuteScalar().ToString());

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = trxnDate.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            cmd.Parameters[2].Value = atm_id;




            //            cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
            //isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
            //isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
            //isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
            //                            from parsed_transaction
            //                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
            //                            and trxn_datetime <=convert(datetime,'{2}',103)",
            //                    atm_id, trxnDate.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            RevertCommandObjToRunTextQuery();
            int row = 0, col = 0;
            if (dt.Rows.Count == 0)
                return "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            return dt.Rows[row][col++] + "|" +
            dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|" +

            dt.Rows[row][col++] + "|" +
            dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|"
            + dt.Rows[row][col++] + "|";


            //            cmd.CommandText = string.Format(@"select sum(amount)
            //                                 from parsed_transaction
            //                                 where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) " +
            //                               " and trxn_datetime <=convert(datetime,'{2}',103)", atm_id, Day.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            //            totalPreWithdrawals = GetValue(cmd.ExecuteScalar());
            //            rejectedCountsForRepDay = GetRejectedCountForRepDay(replenishmentDateTime);


        }
        return "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
    }

    private string GetClosingBalanceInTermsOfNotes(DateTime dt)
    {
        string closingBalanceNotes = "";
        int[] notesAdded = new int[7];
        string[] repParts = null;
        DataTable dtPreWithdrawal = new DataTable();
        DataTable dtWithdrawals = new DataTable();
        bool isAdd = true;
        int[] data = null;
        decimal repAmount = 0;
        int infiniteLoopCounter = 0;

        if (ReplenishmentByDay[dt] == null)
            ExtractDayWiseReplenishment(dt);

        repAmount = GetReplenishmentAmount(dt);
        //ExtractDayWiseReplenishment(dt);
        if (repAmount > 0)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Handling cases when there is a replenishment on current day.
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
            if (!replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].isSwap) // If its ADD CASH then
            {
                //if (dt == Day) // Day == Summary Day..Day for which we are generating summary..
                //    isAddCashOnCurrentDay = true;
                int swapReplenishmentIndex = -1;
                //1.Check do we have SWAP in replenishmentsForOneDay list or we have to query DB
                for (int i = 0; i < replenishmentsForOneDay.Count; i++)
                {
                    if (replenishmentsForOneDay[i].isSwap)
                        swapReplenishmentIndex = i;
                }
                if (swapReplenishmentIndex == -1)
                {
                    //There is no swap replenishment.Query DB.We have to look for SWAP replenishment in DB.
                    DateTime replenishmentDateTime = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1].replenishmentDateTime;
                    Replenishment addCashReplenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count - 1];
                    while (isAdd)
                    {
                        if (infiniteLoopCounter == 100)
                            throw new Exception("This loop is infinite.So breaking it.Machine ID " + atm.ATMId + " Rep Datetime" + addCashReplenishment.replenishmentDateTime);

                        //Looking for SWAP replenishment before this replenishment.
                        cmd.CommandText = "GetReplenishmentExecBeforeDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                        cmd.Parameters[0].Value = replenishmentDateTime.ToString("dd/MM/yyyy");
                        cmd.Parameters[1].Value = atm_id;


                        object repID = cmd.ExecuteScalar();
                        RevertCommandObjToRunTextQuery();
                        //ConnectionFactory.ExecuteScalar(
                        //    string.Format("select replenishment_id from replenishment where rep_datetime< convert(datetime,'{0}',103) and atm_id = {1}",
                        //                  replenishmentDateTime.ToString("dd/MM/yyyy"), atm_id));
                        if (repID != null)
                        {
                            ServicesDAL.Replenishment replenishment = ServicesDAL.Replenishment.LoadReplenishment(" replenishment_id = " + int.Parse(repID.ToString()));
                            if (replenishment != null)
                            {
                                addCashReplenishment.lastReplenishmentDateTime = replenishment.RepDatetime;
                                addCashReplenishment.cashAdded1 = addCashReplenishment.cashAdded1 + replenishment.CashAdded1;
                                addCashReplenishment.cashAdded2 = addCashReplenishment.cashAdded2 + replenishment.CashAdded2;
                                addCashReplenishment.cashAdded3 = addCashReplenishment.cashAdded3 + replenishment.CashAdded3;
                                addCashReplenishment.cashAdded4 = addCashReplenishment.cashAdded4 + replenishment.CashAdded4;
                                addCashReplenishment.cashAdded5 = addCashReplenishment.cashAdded5 + replenishment.CashAdded5;
                                addCashReplenishment.cashAdded6 = addCashReplenishment.cashAdded6 + replenishment.CashAdded6;
                                addCashReplenishment.cashAdded7 = addCashReplenishment.cashAdded7 + replenishment.CashAdded7;

                                if (replenishment.IsSwap)
                                {

                                    isAdd = false;
                                    //SWAP Replenishment PREWITHDRAWALS

                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                                    cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                                    cmd.Parameters[1].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss");
                                    cmd.Parameters[2].Value = atm_id;
                                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                    adapter.Fill(dtPreWithdrawal);

                                    //Withdrawals till today
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                                    cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                                    //cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
                                    //Changed on 5/2/2015
                                    cmd.Parameters[1].Value = dt.ToString("dd/MM/yyyy") + " 23:59:59";
                                    cmd.Parameters[2].Value = atm_id;
                                    adapter = new SqlDataAdapter(cmd);
                                    adapter.Fill(dtWithdrawals);
                                    RevertCommandObjToRunTextQuery();
                                    int[] result = new int[7];
                                    notesAdded[0] = addCashReplenishment.cashAdded1;
                                    notesAdded[1] = addCashReplenishment.cashAdded2;
                                    notesAdded[2] = addCashReplenishment.cashAdded3;
                                    notesAdded[3] = addCashReplenishment.cashAdded4;
                                    notesAdded[4] = addCashReplenishment.cashAdded5;
                                    notesAdded[5] = addCashReplenishment.cashAdded6;
                                    notesAdded[6] = addCashReplenishment.cashAdded7;

                                    //EA:01-02-2022
                                    if (dtWithdrawals.Rows == null || dtWithdrawals.Rows.Count == 0 || dtPreWithdrawal.Rows == null || dtPreWithdrawal.Rows.Count == 0)
                                        return "0|0|0|0|0|0|0";
                                    for (int i = 0; i < 7; i++)
                                    {
                                        //if (dtWithdrawals.Rows.Count > 0 && dtPreWithdrawal.Rows.Count > 0)
                                        result[i] = notesAdded[i] - (int.Parse(dtWithdrawals.Rows[0][i].ToString()) - int.Parse(dtPreWithdrawal.Rows[0][i].ToString()));
                                        //else if (dtWithdrawals.Rows.Count > 0)
                                        //    result[i] = notesAdded[i] - int.Parse(dtWithdrawals.Rows[0][i].ToString());
                                        //else if (dtPreWithdrawal.Rows.Count > 0)
                                        //    result[i] = notesAdded[i] - int.Parse(dtPreWithdrawal.Rows[0][i].ToString());

                                        //result[i] = notesAdded[i] - (int.Parse(dtWithdrawals.Rows[0][i].ToString()) - int.Parse(dtPreWithdrawal.Rows[0][i].ToString()));
                                    }
                                    return result[0] + "|" + result[1] + "|" + result[2] + "|" + result[3] + "|" + result[4] + "|" + result[5] + "|" + result[6];





                                    //                                decimal preWithdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                                    //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                                    //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                                    //                                     and trxn_datetime<=convert(datetime,'{2}',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss")));

                                    //                                decimal withdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                                    //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                                    //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                                    //                                     and trxn_datetime<=convert(datetime,'{2} 23:59:59',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy")));


                                    //closingBalance = (addCashReplenishment.cashAdded1 * addCashReplenishment.den1 +
                                    //                 addCashReplenishment.cashAdded2 * addCashReplenishment.den2 +
                                    //                 addCashReplenishment.cashAdded3 * addCashReplenishment.den3 +
                                    //                 addCashReplenishment.cashAdded4 * addCashReplenishment.den4) - (withdrawals - preWithdrawals);


                                }

                                else
                                    replenishmentDateTime = replenishment.RepDatetime;
                            }
                        }
                        else
                        {
                            throw new Exception("SWAP Replenishment not found to compute balance for the machine ID " + atm.ATMId + " Current ADD Rep datetime" + addCashReplenishment.replenishmentDateTime);
                        }
                        infiniteLoopCounter++;

                    }

                }
                else
                {
                    for (int j = swapReplenishmentIndex; j < replenishmentsForOneDay.Count; j++)
                    {
                        Replenishment temp = replenishmentsForOneDay[j];
                        notesAdded[0] += temp.cashAdded1;
                        notesAdded[1] += temp.cashAdded2;
                        notesAdded[2] += temp.cashAdded3;
                        notesAdded[3] += temp.cashAdded4;
                        notesAdded[4] += temp.cashAdded5;
                        notesAdded[5] += temp.cashAdded6;
                        notesAdded[6] += temp.cashAdded7;
                    }
                    //Added on 24/02/2014 to handle this error.
                    //Failed to convert parameter value from string to int32
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                    cmd.Parameters[0].Value = replenishmentsForOneDay[swapReplenishmentIndex].replenishmentDateTime.ToString("dd/MM/yyyy");
                    cmd.Parameters[1].Value = replenishmentsForOneDay[swapReplenishmentIndex].replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    cmd.Parameters[2].Value = atm_id;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtPreWithdrawal);

                    //Withdrawals till today
                    cmd.Parameters.Clear();
                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                    cmd.Parameters[0].Value = replenishmentsForOneDay[swapReplenishmentIndex].replenishmentDateTime.ToString("dd/MM/yyyy");
                    cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
                    cmd.Parameters[2].Value = atm_id;
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtWithdrawals);
                    RevertCommandObjToRunTextQuery();
                    int[] result = new int[7];
                    //EA:01-02-2022
                    if (dtWithdrawals.Rows == null || dtWithdrawals.Rows.Count == 0 || dtPreWithdrawal.Rows == null || dtPreWithdrawal.Rows.Count == 0)
                        return "0|0|0|0|0|0|0";
                    for (int i = 0; i < 7; i++)
                    {
                        //if (dtWithdrawals.Rows.Count>0 && dtPreWithdrawal.Rows.Count>0)
                        result[i] = notesAdded[i] - (int.Parse(dtWithdrawals.Rows[0][i].ToString()) - int.Parse(dtPreWithdrawal.Rows[0][i].ToString()));
                        //else if (dtWithdrawals.Rows.Count>0)
                        //    result[i] = notesAdded[i] - int.Parse(dtWithdrawals.Rows[0][i].ToString());
                        //else if (dtPreWithdrawal.Rows.Count > 0)
                        //    result[i] = notesAdded[i] - int.Parse(dtPreWithdrawal.Rows[0][i].ToString());
                    }
                    return result[0] + "|" + result[1] + "|" + result[2] + "|" + result[3] + "|" + result[4] + "|" + result[5] + "|" + result[6];

                    //We have SWAP replenishment.
                }
                //Replenishment BaseReplenishment = replenishmentsForOneDay[0];
                //notesAdded[0] = BaseReplenishment.cashAdded1;
                //notesAdded[1] = BaseReplenishment.cashAdded2;
                //notesAdded[2] = BaseReplenishment.cashAdded3;
                //notesAdded[3] = BaseReplenishment.cashAdded4;
                //notesAdded[4] = BaseReplenishment.cashAdded5;
                //notesAdded[5] = BaseReplenishment.cashAdded6;
                //notesAdded[6] = BaseReplenishment.cashAdded7;


                //DateTime AddCashReplenishmentDateTime = replenishmentsForOneDay[0].replenishmentDateTime;
                //Replenishment BaseReplenishment = replenishmentsForOneDay[0];
                //while (isAdd)
                //{

                //    if (infiniteLoopCounter == 100)
                //        throw new Exception("This loop is infinite.So breaking it.Machine ID " + atm.ATMId + " Rep Datetime" + BaseReplenishment.replenishmentDateTime);

                //    //Looking for replenishment before this replenishment.
                //    object repID = ConnectionFactory.ExecuteScalar(
                //        string.Format("select replenishment_id from replenishment where rep_datetime< convert(datetime,'{0}',103) and atm_id = {1}",
                //                      AddCashReplenishmentDateTime.ToString("dd/MM/yyyy"), atm_id));
                //    if (repID != null)
                //    {
                //        Avanza.CCMS.DAL.Replenishment replenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(repID.ToString()));
                //        if (replenishment != null)
                //        {
                //            BaseReplenishment.lastReplenishmentDateTime = replenishment.RepDatetime;
                //            BaseReplenishment.cashAdded1 = BaseReplenishment.cashAdded1 + replenishment.CashAdded1;
                //            BaseReplenishment.cashAdded2 = BaseReplenishment.cashAdded2 + replenishment.CashAdded2;
                //            BaseReplenishment.cashAdded3 = BaseReplenishment.cashAdded3 + replenishment.CashAdded3;
                //            BaseReplenishment.cashAdded4 = BaseReplenishment.cashAdded4 + replenishment.CashAdded4;
                //            BaseReplenishment.cashAdded5 = BaseReplenishment.cashAdded5 + replenishment.CashAdded5;
                //            BaseReplenishment.cashAdded6 = BaseReplenishment.cashAdded6 + replenishment.CashAdded6;
                //            BaseReplenishment.cashAdded7 = BaseReplenishment.cashAdded7 + replenishment.CashAdded7;


                //            if (replenishment.IsSwap)
                //            {
                //                isAdd = false;
                //                //SWAP Replenishment PREWITHDRAWALS

                //                cmd.CommandType = CommandType.StoredProcedure;
                //                cmd.CommandText = "ExtractDayWiseWithdrawals";
                //                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                //                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                //                cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                //                cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                //                cmd.Parameters[1].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss");
                //                cmd.Parameters[2].Value = atm_id;
                //                decimal preWithdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());

                //                cmd.Parameters.Clear();
                //                cmd.CommandText = "ExtractDayWiseWithdrawals";
                //                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                //                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                //                cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                //                cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                //                cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy");
                //                cmd.Parameters[2].Value = atm_id;
                //                decimal withdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());

                //                //                                decimal preWithdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                //                //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                //                //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                //                //                                     and trxn_datetime<=convert(datetime,'{2}',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss")));

                //                //                                decimal withdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                //                //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                //                //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                //                //                                     and trxn_datetime<=convert(datetime,'{2} 23:59:59',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy")));


                //                closingBalance = (BaseReplenishment.cashAdded1 * BaseReplenishment.den1 +
                //                                 BaseReplenishment.cashAdded2 * BaseReplenishment.den2 +
                //                                 BaseReplenishment.cashAdded3 * BaseReplenishment.den3 +
                //                                 BaseReplenishment.cashAdded4 * BaseReplenishment.den4) - (withdrawals - preWithdrawals);
                //                RevertCommandObjToRunTextQuery();
                //            }

                //            else
                //                AddCashReplenishmentDateTime = replenishment.RepDatetime;
                //        }
                //    }
                //    else
                //    {
                //        throw new Exception("SWAP Replenishment not found to compute balance for the machine ID " + atm.ATMId + " Current ADD Rep datetime" + BaseReplenishment.replenishmentDateTime);
                //    }
                //    infiniteLoopCounter++;

                //}



                //cmd.Parameters.Clear();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                //cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                //cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                //cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                //cmd.Parameters[0].Value = replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy");
                //cmd.Parameters[1].Value = replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
                //cmd.Parameters[2].Value = atm_id;


                ////                cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
                ////                                                                    isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
                ////                                                                    isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
                ////                                                                    isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
                ////                                                                    from parsed_transaction where atm_id={0} 
                ////                                                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                ////                                                                     and trxn_datetime<=convert(datetime,'{2}',103)", atm_id, replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy"), replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy HH:mm:ss"));

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(dtPreWithdrawal);


                //cmd.Parameters.Clear();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                //cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                //cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                //cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                //cmd.Parameters[0].Value = replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy");
                //cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy");
                //cmd.Parameters[2].Value = atm_id;




                ////                cmd.CommandText =
                ////                    string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
                ////isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
                ////isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
                ////isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
                ////from parsed_transaction where atm_id={0} 
                ////                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                ////                                     and trxn_datetime<=convert(datetime,'{2} 23:59:59',103)", atm_id, replenishmentsForOneDay[0].lastReplenishmentDateTime.Value.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy"));
                //adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(dtWithdrawals);
                //RevertCommandObjToRunTextQuery();
                ////while (isAdd)
                ////{
                ////    //Looking for replenishment before this replenishment.
                ////    object repID = ConnectionFactory.ExecuteScalar(
                ////        string.Format("select replenishment_id from replenishment where rep_datetime< convert(datetime,'{0}',103) and atm_id = {1}",
                ////                      AddCashReplenishmentDateTime.ToString("dd/MM/yyyy"), atm_id));
                ////    if (repID != null)
                ////    {
                ////        Avanza.CCMS.DAL.Replenishment replenishment = Avanza.CCMS.DAL.Replenishment.LoadReplenishmentByPk(int.Parse(repID.ToString()));
                ////        if (replenishment != null)
                ////        {
                ////            BaseReplenishment.cashAdded1 = BaseReplenishment.cashAdded1 + replenishment.CashAdded1;
                ////            BaseReplenishment.cashAdded2 = BaseReplenishment.cashAdded2 + replenishment.CashAdded2;
                ////            BaseReplenishment.cashAdded3 = BaseReplenishment.cashAdded3 + replenishment.CashAdded3;
                ////            BaseReplenishment.cashAdded4 = BaseReplenishment.cashAdded4 + replenishment.CashAdded4;
                ////            BaseReplenishment.cashAdded5 = BaseReplenishment.cashAdded5 + replenishment.CashAdded5;
                ////            BaseReplenishment.cashAdded6 = BaseReplenishment.cashAdded6 + replenishment.CashAdded6;
                ////            BaseReplenishment.cashAdded7 = BaseReplenishment.cashAdded7 + replenishment.CashAdded7;


                ////            if (replenishment.IsSwap)
                ////            {


                ////                isAdd = false;
                ////                //SWAP Replenishment PREWITHDRAWALS


                ////            }

                ////            else
                ////                AddCashReplenishmentDateTime = replenishment.RepDatetime;
                ////        }
                ////    }
                ////}


                //int[] result = new int[7];

                //for (i = 0; i < 7; i++)
                //{
                //    result[i] = notesAdded[i] - (int.Parse(dtWithdrawals.Rows[0][i].ToString()) - int.Parse(dtPreWithdrawal.Rows[0][i].ToString()));
                //}
                //i = 0;

                //return result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" +
                //    result[i++] + "|" + result[i++];


            }
            else
            {
                //Handling SWAP CASES AS HANDLED EARLIER.
                string GetReplenishmentNotes = GetReplenishmentAmountInTermsOfNotes(dt);
                string GetWithdrawalsNotes = ExtractDayWiseWithdrawalsInTermsOfNotes(dt);
                string GetPreWithdrawals = ExtractDayWisePreWithdrawalsInTermsOfNotes(dt);

                repParts = GetReplenishmentNotes.Split('|');
                string[] withdrawalParts = GetWithdrawalsNotes.Split('|');
                string[] preWithdrawalsParts = GetPreWithdrawals.Split('|');

                int[] result = new int[7];
                int i = 0;
                for (i = 0; i < 7; i++)
                {
                    result[i] = int.Parse(repParts[i]) - (int.Parse(withdrawalParts[i]) - int.Parse(preWithdrawalsParts[i]));
                }
                i = 0;

                return result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" +
                    result[i++] + "|" + result[i++];
            }
        }
        else//    if (repAmount > 0)
        {


            //problem in the following function
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Commented on 31/01/2014            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //if (Day == dt)
            //{
            cmd.Parameters.Clear();
            cmd.CommandText = "GetClosingBalanceForDay";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = dt.AddDays(-1).ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = atm_id;


            //cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";
            object result = cmd.ExecuteScalar();
            RevertCommandObjToRunTextQuery();
            #region Revalidate
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("cash_remaining1", typeof(int));
            dt3.Columns.Add("cash_remaining2", typeof(int));
            dt3.Columns.Add("cash_remaining3", typeof(int));
            dt3.Columns.Add("cash_remaining4", typeof(int));
            dt3.Columns.Add("cash_remaining5", typeof(int));
            dt3.Columns.Add("cash_remaining6", typeof(int));
            dt3.Columns.Add("cash_remaining7", typeof(int));
            //If yesterday summary exists then
            if (result != null)
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMaxRepExecBeforeDay";
                cmd.Parameters.Add("@Date", SqlDbType.VarChar);
                cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
                cmd.Parameters[1].Value = atm_id;


                //                cmd.CommandText = string.Format(@"select max(rep_datetime)
                //                                           from replenishment 
                //                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)", atm_id,
                //                                      Day.ToString("dd/MM/yyyy"));

                object maxRepDate = cmd.ExecuteScalar();
                if (maxRepDate != DBNull.Value)
                {
                    if (oldMaxRepDate.Year == 1900)
                        oldMaxRepDate = DateTime.Parse(maxRepDate.ToString());
                    else
                    {
                        if (oldMaxRepDate == DateTime.Parse(maxRepDate.ToString()))
                        {
                            throw new Exception("incorrect replenishment posted for the atm :" + atm.Title + " for the date : " + maxRepDate);
                        }
                    }
                    LogableTask.LogMonoActivityTask("CheckRec", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Sending call for rep " + maxRepDate.ToString());
                    string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(maxRepDate.ToString())).Split('|');

                    DataRow dr = dt3.NewRow();
                    for (int i = 0; i < 7; i++)
                        dr[i] = parts[i];
                    dt3.Rows.Add(dr);
                    LogableTask.LogMonoActivityTask("CheckRepAmoung", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                        string.Format("Rep Notes = {0} {1} {2} {3}", parts[0], parts[1], parts[2], parts[3]));



                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                    cmd.Parameters[0].Value = DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                    //cmd.Parameters[1].Value = dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
                    cmd.Parameters[1].Value = dt.ToString("dd/MM/yyyy") + " 23:59:59";
                    cmd.Parameters[2].Value = atm_id;

                    LogableTask.LogMonoActivityTask("CheckDate", MethodBase.GetCurrentMethod(), TraceLevel.Info,
                        string.Format("from[{0}] -  to[{1}] ", cmd.Parameters[0].Value, cmd.Parameters[1].Value));


                    //                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
                    //isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                    //                                                        from parsed_transaction
                    //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                    //                and trxn_datetime <=convert(datetime,'{2}',103)",
                    //                atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt4 = new DataTable();
                    adapter.Fill(dt4);
                    RevertCommandObjToRunTextQuery();
                    //EA:01-02-2022
                    if (dt3.Rows == null || dt3.Rows.Count == 0 || dt4.Rows == null || dt4.Rows.Count == 0)
                        return "0|0|0|0|0|0|0";
                    data = new int[7];
                    data[0] = int.Parse(dt3.Rows[0][0].ToString()) - int.Parse(dt4.Rows[0][0].ToString());
                    data[1] = int.Parse(dt3.Rows[0][1].ToString()) - int.Parse(dt4.Rows[0][1].ToString());
                    data[2] = int.Parse(dt3.Rows[0][2].ToString()) - int.Parse(dt4.Rows[0][2].ToString());
                    data[3] = int.Parse(dt3.Rows[0][3].ToString()) - int.Parse(dt4.Rows[0][3].ToString());
                    data[4] = int.Parse(dt3.Rows[0][4].ToString()) - int.Parse(dt4.Rows[0][4].ToString());
                    data[5] = int.Parse(dt3.Rows[0][5].ToString()) - int.Parse(dt4.Rows[0][5].ToString());
                    data[6] = int.Parse(dt3.Rows[0][6].ToString()) - int.Parse(dt4.Rows[0][6].ToString());

                    closingBalanceNotes = data[0] + "|" + data[1] + "|" + data[2] + "|" + data[3] + "|" + data[4] + "|" +
                    data[5] + "|" + data[6];

                    //Now we have yesteday balance in terms of notes on data array 


                }
                else
                {
                    RevertCommandObjToRunTextQuery();
                    //Yesterday summary exists but there is no replenishment to verify it .
                    //thinking...closing balance will be computed by taking yesterday balance - current day withdrawals.
                    //We need to seggregate when computing return amount and when computing current day closing balance..
                    //When computing current day balance => withdrawals till today(DAY) should be called to get balance.
                    //In case of return withdrawal will be computed using ExtractDayWiseWithdrawalsInTermsOfNotes(dt)
                    cmd.CommandText = @"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),                    
                                        isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),
                                        isnull(cash_remaining6,0),isnull(cash_remaining7,0) 
                                        from summary where atm_id=" + atm_id +
                                   " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    adapter.Fill(dt1);
                    data = new int[7];
                    data[0] = int.Parse(dt1.Rows[0][0].ToString());
                    data[1] = int.Parse(dt1.Rows[0][1].ToString());
                    data[2] = int.Parse(dt1.Rows[0][2].ToString());
                    data[3] = int.Parse(dt1.Rows[0][3].ToString());
                    data[4] = int.Parse(dt1.Rows[0][4].ToString());
                    data[5] = int.Parse(dt1.Rows[0][5].ToString());
                    data[6] = int.Parse(dt1.Rows[0][6].ToString());
                    string[] parts = null;
                    if (Day == dt) // means computing balance for currrent day 
                        parts = ExtractDayWiseWithdrawalsInTermsOfNotes(Day).Split('|');
                    else
                        parts = ExtractDayWiseWithdrawalsInTermsOfNotes(dt).Split('|');
                    //EA:01-02-2022
                    if (dt1.Rows == null || dt1.Rows.Count == 0)
                        return "0|0|0|0|0|0|0";
                    return (data[0] - int.Parse(parts[0].ToString())) + "|" + (data[1] - int.Parse(parts[1].ToString())) + "|" +
                        (data[2] - int.Parse(parts[2].ToString())) + "|" + (data[3] - int.Parse(parts[3].ToString())) + "|" +
                        (data[4] - int.Parse(parts[4].ToString())) + "|" + (data[5] - int.Parse(parts[5].ToString())) + "|" +
                        (data[6] - int.Parse(parts[6].ToString()));

                }
            }

            #endregion
            //If there is no yesterday summary
            //Change done on 31/01/2014
            else //if (result == DBNull.Value || result == null)
            {
                cmd.CommandText = string.Format(@"select max(trxn_datetime)
                                                      from summary 
                                                      where atm_id = {0} 
                                                      and trxn_datetime <convert(datetime,'{1}',103)", atm_id, dt.ToString("dd/MM/yyyy"));
                object lastSummaryTrxnDate = cmd.ExecuteScalar();
                if (lastSummaryTrxnDate == DBNull.Value) // If there is no data in summary table
                    return "0|0|0|0|0|0|0";
                else
                {
                    //If there is summary for some day before yesterday then
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("cash_remaining1", typeof(int));
                    dt2.Columns.Add("cash_remaining2", typeof(int));
                    dt2.Columns.Add("cash_remaining3", typeof(int));
                    dt2.Columns.Add("cash_remaining4", typeof(int));
                    dt2.Columns.Add("cash_remaining5", typeof(int));
                    dt2.Columns.Add("cash_remaining6", typeof(int));
                    dt2.Columns.Add("cash_remaining7", typeof(int));


                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetMaxRepExecBetweenDays";
                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                    cmd.Parameters[0].Value = DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                    cmd.Parameters[1].Value = Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
                    cmd.Parameters[2].Value = atm_id;

                    //                    cmd.CommandText = string.Format(@"select max(rep_datetime)
                    //                                                          from replenishment 
                    //                                                          where atm_id = {0} and rep_datetime >=convert(datetime,'{1}',103) 
                    //                                                          and rep_datetime <=convert(datetime,'{2}',103)", atm_id,
                    //                                                      DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"),
                    //                                                      Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                    object repDate = cmd.ExecuteScalar();
                    RevertCommandObjToRunTextQuery();
                    //                        decimal newClosingBalance = -1;
                    //If there is replenishment 
                    if (repDate != DBNull.Value)
                    {
                        string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString())).Split('|');
                        DataRow dr = dt2.NewRow();
                        for (int i = 0; i < 7; i++)
                            dr[i] = parts[i];
                        dt2.Rows.Add(dr);

                        //                            newClosingBalance = 0;// GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString()));
                        lastSummaryTrxnDate = repDate;
                    }
                    else
                    {
                        //Get counters from summary ...
                        cmd.CommandText = string.Format(@"
                            select isnull(cash_remaining1,0),isnull(cash_remaining2,0), isnull(cash_remaining3,0),
                            isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0)
                            from summary 
                            where atm_id = {0} and trxn_datetime in (  
                            select max(trxn_datetime)
                            from summary 
                            where atm_id = {0} 
                            and trxn_datetime <convert(datetime,'{1}',103))", atm_id, dt.ToString("dd/MM/yyyy"));


                        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                        dt2 = new DataTable();
                        adapter1.Fill(dt2);
                    }

                    //Get all withdrawals till today
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ExtractWithdrawalsInTermsOfNotes";
                    cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                    cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                    cmd.Parameters[0].Value = DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");

                    if (Day == dt)
                        cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
                    else
                        cmd.Parameters[1].Value = dt.ToString("dd/MM/yyyy") + " 23:59:59";

                    cmd.Parameters[2].Value = atm_id;



                    //                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
                    //isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                    //                                                        from parsed_transaction
                    //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                    //                and trxn_datetime <=convert(datetime,'{2}',103)",
                    //                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    adapter.Fill(dt1);
                    RevertCommandObjToRunTextQuery();


                    int row = 0;
                    //EA:01-02-2022
                    if (dt1.Rows == null || dt1.Rows.Count == 0 || dt2.Rows == null || dt2.Rows.Count == 0)
                        return "0|0|0|0|0|0|0";
                    return (int.Parse(dt2.Rows[row][0].ToString()) - int.Parse(dt1.Rows[row][0].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][1].ToString()) - int.Parse(dt1.Rows[row][1].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][2].ToString()) - int.Parse(dt1.Rows[row][2].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][3].ToString()) - int.Parse(dt1.Rows[row][3].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][4].ToString()) - int.Parse(dt1.Rows[row][4].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][5].ToString()) - int.Parse(dt1.Rows[row][5].ToString())) + "|" +
                        (int.Parse(dt2.Rows[row][6].ToString()) - int.Parse(dt1.Rows[row][6].ToString()));
                }

                //cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

                //No closing balance row found
            }//Commented on 31/01/2014

            //                else
            //                {

            //                    if (data == null)
            //                    {
            //                        cmd.CommandText = @"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),
            //                    
            //                                        isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0) from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

            //                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //                        DataTable dt1 = new DataTable();
            //                        adapter.Fill(dt1);
            //                        data = new int[7];
            //                        data[0] = int.Parse(dt1.Rows[0][0].ToString());
            //                        data[1] = int.Parse(dt1.Rows[0][1].ToString());
            //                        data[2] = int.Parse(dt1.Rows[0][2].ToString());
            //                        data[3] = int.Parse(dt1.Rows[0][3].ToString());
            //                        data[4] = int.Parse(dt1.Rows[0][4].ToString());
            //                        data[5] = int.Parse(dt1.Rows[0][5].ToString());
            //                        data[6] = int.Parse(dt1.Rows[0][6].ToString());

            //                    }
            //                    string[] parts = ExtractDayWiseWithdrawalsInTermsOfNotes(Day).Split('|');


            //                    return (data[0] - int.Parse(parts[0].ToString())) + "|" +
            //                        (data[1] - int.Parse(parts[1].ToString())) + "|" +
            //                        (data[2] - int.Parse(parts[2].ToString())) + "|" +
            //                        (data[3] - int.Parse(parts[3].ToString())) + "|" +

            //                        (data[4] - int.Parse(parts[4].ToString())) + "|" +
            //                        (data[5] - int.Parse(parts[5].ToString())) + "|" +
            //                        (data[6] - int.Parse(parts[6].ToString()));


            //                }
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Commented on 31/01/2014/..No need to seggregate between computing current day balance and yesterday balance
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //if (ClosingBalanceByDay[dt] == null)
            //{
            //    if (ClosingBalanceByDay[dt.AddDays(-1)] != null)
            //        closingBalance = (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt]);
            //    else
            //        closingBalance = (decimal)ConnectionFactory.ExecuteScalar("select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + "',103)") - (decimal)WithdrawalsByDay[dt];

            //    ClosingBalanceByDay.Add(dt, closingBalance);
            //    return closingBalance;
            //}
            //else
            //    return (decimal)ClosingBalanceByDay[dt];
        }
        //return closingBalance;
        return closingBalanceNotes;
    }

    private void ExtractDayWisePreWithdrawals()
    {
        if (ReplenishmentByDay[Day] == null)
            totalPreWithdrawals = 0;
        else
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMinReplenishmentDate";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
            cmd.Parameters[2].Value = atm_id;

            //            cmd.CommandText = string.Format(@"select min(rep_datetime)
            //                                from replenishment
            //                                where atm_id = {0} and rep_datetime >=convert(datetime,'{1} 00:00:00',103) 
            //and rep_datetime <=convert(datetime,'{1} 23:59:59',103) ",
            //                                atm_id, Day.ToString("dd/MM/yyyy"));
            DateTime replenishmentDateTime = (DateTime)cmd.ExecuteScalar();

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ExtractDayWiseWithdrawals";
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = Day.ToString("dd/MM/yyyy");
            cmd.Parameters[1].Value = replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            cmd.Parameters[2].Value = atm_id;
            totalPreWithdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());
            RevertCommandObjToRunTextQuery();




            //            cmd.CommandText = string.Format(@"select sum(amount)
            //                                 from parsed_transaction
            //                                 where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) " +
            //                               " and trxn_datetime <=convert(datetime,'{2}',103)", atm_id, Day.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            //            totalPreWithdrawals = GetValue(cmd.ExecuteScalar());



        }

    }
    private decimal ExtractDayWisePreWithdrawals(DateTime dt)
    {
        if (ReplenishmentByDay[dt] == null)
            return 0;
        else
        {

            cmd.CommandText = string.Format(@"select min(rep_datetime)
                                from replenishment
                                where atm_id = {0} and rep_datetime >=convert(datetime,'{1} 00:00:00',103) 
and rep_datetime <=convert(datetime,'{1} 23:59:59',103) ",
                                atm_id, dt.ToString("dd/MM/yyyy"));
            DateTime replenishmentDateTime = (DateTime)cmd.ExecuteScalar();
            cmd.CommandText = string.Format(@"select sum(amount)
                                 from parsed_transaction
                                 where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) " +
                               " and trxn_datetime <=convert(datetime,'{2}',103)", atm_id, dt.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            return GetValue(cmd.ExecuteScalar());
            ///rejectedCountsForRepDay = GetRejectedCountForRepDay(replenishmentDateTime);


        }

    }
    private decimal GetReturnAmount(DateTime dt, ref decimal yesterdayClosingBalance)
    {

        if (ReplenishmentByDay[dt] == null)
            return 0;

        else
        {
            //    return (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - totalPreWithdrawals;
            yesterdayBalanceNotes = GetClosingBalanceInTermsOfNotes(dt.AddDays(-1));
            dFFVersion2Helper.yesterdayBalanceNotes = yesterdayBalanceNotes;
            string[] parts = yesterdayBalanceNotes.Split('|');

            yesterdayClosingBalance = decimal.Parse((noteSetType.DenominationType1 * int.Parse(parts[0]) +
                noteSetType.DenominationType2 * int.Parse(parts[1]) +
                noteSetType.DenominationType3 * int.Parse(parts[2]) +
                noteSetType.DenominationType4 * int.Parse(parts[3]) +
                noteSetType.DenominationType5 * int.Parse(parts[4]) +
                noteSetType.DenominationType6 * int.Parse(parts[5]) +
                noteSetType.DenominationType7 * int.Parse(parts[6])).ToString());

            return yesterdayClosingBalance - totalPreWithdrawals;
        }


        //if (((List<Replenishment>)ReplenishmentByDay[dt]).Count > 0)
        //{
        //    if (ClosingBalanceByDay[dt.AddDays(-1)] != null)//(ClosingBalanceByDay.Count > 0)
        //    {
        //        if (PreWithdrawalsByDay[dt] == null)
        //            returnAmount = (decimal)ClosingBalanceByDay[dt.AddDays(-1)];
        //        else
        //            returnAmount = (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - (decimal)PreWithdrawalsByDay[dt];

        //    }
        //    else
        //        returnAmount = -1;// Math.Abs(0 - (decimal)PreWithdrawalsByDay[dt]);
        //}
        //return returnAmount;
    }
    private decimal GetValue(object arg)
    {
        if (arg != DBNull.Value && arg != null)
            return (decimal)arg;
        else
            return 0;
    }

    private decimal GetClosingBalance(DateTime dt)
    {
        int infiniteLoopCounter = 0;

        bool isAdd = true;
        decimal repAmount = 0;
        decimal closingBalance = 0;
        if (ReplenishmentByDay[dt] == null)
            ExtractDayWiseReplenishment(dt);

        repAmount = GetReplenishmentAmount(dt);
        if (repAmount > 0)
        {
            List<Replenishment> replenishmentsForOneDay = (List<Replenishment>)ReplenishmentByDay[dt];
            if (replenishmentsForOneDay.Count == 1 && !replenishmentsForOneDay[0].isSwap) // ADD CASH
            {
                if (dt == Day) // Day == Summary Day..Day for which we are generating summary..
                    isAddCashOnCurrentDay = true;

                DateTime AddCashReplenishmentDateTime = replenishmentsForOneDay[0].replenishmentDateTime;
                Replenishment BaseReplenishment = replenishmentsForOneDay[0];
                while (isAdd)
                {

                    if (infiniteLoopCounter == 100)
                        throw new Exception("This loop is infinite.So breaking it.Machine ID " + atm.ATMId + " Rep Datetime" + BaseReplenishment.replenishmentDateTime);

                    //Looking for replenishment before this replenishment.
                    object repID = ConnectionFactory.ExecuteScalar(
                        string.Format("select replenishment_id from replenishment where rep_datetime< convert(datetime,'{0}',103) and atm_id = {1}",
                                      AddCashReplenishmentDateTime.ToString("dd/MM/yyyy"), atm_id), DatabaseName.Cash);
                    if (repID != null)
                    {
                        ServicesDAL.Replenishment replenishment = ServicesDAL.Replenishment.LoadReplenishment(" replenishment_id = " +int.Parse(repID.ToString()));
                        if (replenishment != null)
                        {
                            BaseReplenishment.lastReplenishmentDateTime = replenishment.RepDatetime;
                            BaseReplenishment.cashAdded1 = BaseReplenishment.cashAdded1 + replenishment.CashAdded1;
                            BaseReplenishment.cashAdded2 = BaseReplenishment.cashAdded2 + replenishment.CashAdded2;
                            BaseReplenishment.cashAdded3 = BaseReplenishment.cashAdded3 + replenishment.CashAdded3;
                            BaseReplenishment.cashAdded4 = BaseReplenishment.cashAdded4 + replenishment.CashAdded4;
                            BaseReplenishment.cashAdded5 = BaseReplenishment.cashAdded5 + replenishment.CashAdded5;
                            BaseReplenishment.cashAdded6 = BaseReplenishment.cashAdded6 + replenishment.CashAdded6;
                            BaseReplenishment.cashAdded7 = BaseReplenishment.cashAdded7 + replenishment.CashAdded7;


                            if (replenishment.IsSwap)
                            {
                                isAdd = false;
                                //SWAP Replenishment PREWITHDRAWALS

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "ExtractDayWiseWithdrawals";
                                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                                cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                                cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                                cmd.Parameters[1].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss");
                                cmd.Parameters[2].Value = atm_id;
                                decimal preWithdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());

                                cmd.Parameters.Clear();
                                cmd.CommandText = "ExtractDayWiseWithdrawals";
                                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                                cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                                cmd.Parameters[0].Value = replenishment.RepDatetime.ToString("dd/MM/yyyy");
                                cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy");
                                cmd.Parameters[2].Value = atm_id;
                                decimal withdrawals = decimal.Parse(cmd.ExecuteScalar().ToString());

                                //                                decimal preWithdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                                //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                                //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                                //                                     and trxn_datetime<=convert(datetime,'{2}',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss")));

                                //                                decimal withdrawals = (decimal)ConnectionFactory.ExecuteScalar(
                                //                                    string.Format(@"select isnull(sum(amount),0) from parsed_transaction where atm_id={0} 
                                //                                     and trxn_datetime>=convert(datetime,'{1}',103) 
                                //                                     and trxn_datetime<=convert(datetime,'{2} 23:59:59',103)", atm_id, replenishment.RepDatetime.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy")));


                                closingBalance = (BaseReplenishment.cashAdded1 * BaseReplenishment.den1 +
                                                 BaseReplenishment.cashAdded2 * BaseReplenishment.den2 +
                                                 BaseReplenishment.cashAdded3 * BaseReplenishment.den3 +
                                                 BaseReplenishment.cashAdded4 * BaseReplenishment.den4) - (withdrawals - preWithdrawals);
                                RevertCommandObjToRunTextQuery();
                            }

                            else
                                AddCashReplenishmentDateTime = replenishment.RepDatetime;
                        }
                    }
                    else
                    {
                        throw new Exception("SWAP Replenishment not found to compute balance for the machine ID " + atm.ATMId + " Current ADD Rep datetime" + BaseReplenishment.replenishmentDateTime);
                    }
                    infiniteLoopCounter++;

                }
                return closingBalance;
            }
            else
                return GetReplenishmentAmount(dt) - (ExtractDayWiseWithdrawals(dt) - ExtractDayWisePreWithdrawals(dt));
        }
        else
        {
            //problem in the following function
            if (Day == dt)
            {
                //Go for run time generation.

                cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";
                object result = cmd.ExecuteScalar();
                //Revalidate 
                #region Revalidate
                if (result != null)
                {
                    cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)", atm_id,
                                          Day.ToString("dd/MM/yyyy"));

                    object maxRepDate = cmd.ExecuteScalar();
                    if (maxRepDate != DBNull.Value)
                    {
                        decimal newBalance = GetClosingBalance(DateTime.Parse(maxRepDate.ToString()));

                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ExtractDayWiseWithdrawals";
                        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                        cmd.Parameters[0].Value = DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                        cmd.Parameters[1].Value = Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
                        cmd.Parameters[2].Value = atm_id;




                        //                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                        //                                                        from parsed_transaction
                        //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                        //                and trxn_datetime <=convert(datetime,'{2}',103)",
                        //                    atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        decimal revalidatedBalance = newBalance - decimal.Parse(cmd.ExecuteScalar().ToString());
                        if (revalidatedBalance != decimal.Parse(result.ToString()))
                        {
                            LogableTask.LogMonoActivityTask("balance revalidate", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "CCMS Balance : " + result.ToString() + " Revalidated Balance : " + revalidatedBalance.ToString() + " for day " + Day.ToString() + " for atm: " + atm.Title);
                            result = revalidatedBalance;
                        }
                        RevertCommandObjToRunTextQuery();

                    }
                }

                #endregion


                if (result == DBNull.Value || result == null)
                {
                    cmd.CommandText = string.Format(@"select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103)", atm_id, dt.ToString("dd/MM/yyyy"));
                    object lastSummaryTrxnDate = cmd.ExecuteScalar();
                    if (lastSummaryTrxnDate == DBNull.Value || lastSummaryTrxnDate == null)
                    {
                        return 0;
                    }
                    else
                    {
                        //Changes done on 30/01/2014.
                        //Rep date should be max.
                        cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime >=convert(datetime,'{1}',103) 
                                           and rep_datetime <=convert(datetime,'{2}',103)", atm_id,
                                          DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"),
                                          Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        object repDate = cmd.ExecuteScalar();
                        decimal newClosingBalance = -1;
                        if (repDate != null)
                        {
                            newClosingBalance = GetClosingBalance(DateTime.Parse(repDate.ToString()));
                            lastSummaryTrxnDate = repDate;
                        }

                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ExtractDayWiseWithdrawals";
                        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                        cmd.Parameters[0].Value = DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                        cmd.Parameters[1].Value = Day.ToString("dd/MM/yyyy") + " 23:59:59";
                        cmd.Parameters[2].Value = atm_id;

                        //                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                        //                                                        from parsed_transaction
                        //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                        //                and trxn_datetime <=convert(datetime,'{2}',103)",
                        //                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");

                        decimal totalTrxnAmount = (decimal)cmd.ExecuteScalar();
                        RevertCommandObjToRunTextQuery();
                        decimal balance = 0;
                        if (newClosingBalance == -1)
                        {
                            cmd.CommandText = string.Format(@"select closing_balance
                                        from summary 
                                        where atm_id = {0} and trxn_datetime in (  
                                        select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103))", atm_id, dt.ToString("dd/MM/yyyy"));


                            balance = (decimal)cmd.ExecuteScalar();
                        }
                        else
                        {
                            balance = newClosingBalance;
                        }

                        return balance - totalTrxnAmount;

                    }

                    //cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

                    //No closing balance row found
                }
                else
                    return GetValue(result) - totalWithdrawals;
            }
            else
            {
                //work in case of return amount when Day != dt
                cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + "',103)";
                //return GetValue(cmd.ExecuteScalar());
                object result = cmd.ExecuteScalar();

                #region Revalidate
                if (result != null)
                {
                    cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)", atm_id,
                                          dt.ToString("dd/MM/yyyy"));

                    object maxRepDate = cmd.ExecuteScalar();
                    if (maxRepDate != DBNull.Value)
                    {
                        decimal newBalance = GetClosingBalance(DateTime.Parse(maxRepDate.ToString()));



                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ExtractDayWiseWithdrawals";
                        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                        cmd.Parameters[0].Value = DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                        cmd.Parameters[1].Value = dt.ToString("dd/MM/yyyy") + " 23:59:59";
                        cmd.Parameters[2].Value = atm_id;



                        //                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                        //                                                        from parsed_transaction
                        //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                        //                and trxn_datetime <=convert(datetime,'{2}',103)",
                        //                    atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.ToString("dd/MM/yyyy") + " 23:59:59");
                        // object totalAmount = cmd.ExecuteScalar();


                        decimal revalidatedBalance = newBalance - decimal.Parse(cmd.ExecuteScalar().ToString());
                        RevertCommandObjToRunTextQuery();
                        if (revalidatedBalance != decimal.Parse(result.ToString()))
                        {
                            LogableTask.LogMonoActivityTask("balance revalidate", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "CCMS Balance : " + result.ToString() + " Revalidated Balance : " + revalidatedBalance.ToString() + " for day " + Day.ToString() + " for atm: " + atm.Title);
                            result = revalidatedBalance;
                        }

                    }
                }

                #endregion

                if (result == DBNull.Value || result == null)
                {
                    cmd.CommandText = string.Format(@"select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103)", atm_id, dt.ToString("dd/MM/yyyy"));
                    object lastSummaryTrxnDate = cmd.ExecuteScalar();
                    if (lastSummaryTrxnDate == DBNull.Value || lastSummaryTrxnDate == null)
                    {
                        return 0;
                    }
                    else
                    {
                        //Change done on 30/01/2014
                        //Rep Date should be max
                        cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime >=convert(datetime,'{1}',103) 
                                           and rep_datetime <=convert(datetime,'{2}',103)", atm_id,
                  DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"),
                  dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        object repDate = cmd.ExecuteScalar();
                        decimal newClosingBalance = -1;
                        if (repDate != null)
                        {
                            newClosingBalance = GetClosingBalance(DateTime.Parse(repDate.ToString()));
                            lastSummaryTrxnDate = repDate;
                        }

                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ExtractDayWiseWithdrawals";
                        cmd.Parameters.Add("@FromDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@ToDate", SqlDbType.VarChar);
                        cmd.Parameters.Add("@AtmId", SqlDbType.Int);
                        cmd.Parameters[0].Value = DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                        cmd.Parameters[1].Value = dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59";
                        cmd.Parameters[2].Value = atm_id;

                        //                        cmd.CommandText = string.Format(@"select sum(amount) 
                        //                                                        from parsed_transaction
                        //                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                        //                and trxn_datetime <=convert(datetime,'{2}',103)",
                        //                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        decimal totalTrxnAmount = GetValue(cmd.ExecuteScalar());
                        RevertCommandObjToRunTextQuery();


                        decimal balance = 0;
                        if (newClosingBalance == -1)
                        {

                            cmd.CommandText = string.Format(@"select closing_balance
                                        from summary 
                                        where atm_id = {0} and trxn_datetime in (  
                                        select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103))", atm_id, dt.ToString("dd/MM/yyyy"));


                            balance = (decimal)cmd.ExecuteScalar();
                        }
                        else
                            balance = newClosingBalance;

                        return balance - totalTrxnAmount;


                    }

                    //cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

                    //No closing balance row found
                }
                else
                    return GetValue(result);
            }

            //if (ClosingBalanceByDay[dt] == null)
            //{
            //    if (ClosingBalanceByDay[dt.AddDays(-1)] != null)
            //        closingBalance = (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt]);
            //    else
            //        closingBalance = (decimal)ConnectionFactory.ExecuteScalar("select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + "',103)") - (decimal)WithdrawalsByDay[dt];

            //    ClosingBalanceByDay.Add(dt, closingBalance);
            //    return closingBalance;
            //}
            //else
            //    return (decimal)ClosingBalanceByDay[dt];
        }
        //return closingBalance;
    }
    //private decimal GetClosingBalance(DateTime dt)
    //{
    //    //decimal closingBalance = 0;
    //    if (GetReplenishmentAmount(dt) > 0)
    //    {
    //        //return GetReplenishmentAmount(dt) - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt] - ((PreWithdrawalsByDay[dt] == null) ? 0 : (decimal)PreWithdrawalsByDay[dt]));
    //        return GetReplenishmentAmount(dt) - (totalWithdrawals - totalPreWithdrawals);

    //        //if (ClosingBalanceByDay[dt] == null)
    //        //{
    //        //    closingBalance = GetReplenishmentAmount(dt) - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt] - ((PreWithdrawalsByDay[dt] == null) ? 0 : (decimal)PreWithdrawalsByDay[dt]));
    //        //    ClosingBalanceByDay.Add(dt, closingBalance);
    //        //    return closingBalance;
    //        //}
    //        //else
    //        //    return (decimal)ClosingBalanceByDay[dt];
    //    }
    //    else
    //    {
    //        //problem in the following function
    //        if (Day == dt)
    //        {
    //            cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";
    //            return GetValue(cmd.ExecuteScalar()) - totalWithdrawals;
    //        }
    //        else
    //        {
    //            cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + "',103)";
    //            return GetValue(cmd.ExecuteScalar());
    //        }

    //        //if (ClosingBalanceByDay[dt] == null)
    //        //{
    //        //    if (ClosingBalanceByDay[dt.AddDays(-1)] != null)
    //        //        closingBalance = (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt]);
    //        //    else
    //        //        closingBalance = (decimal)ConnectionFactory.ExecuteScalar("select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + "',103)") - (decimal)WithdrawalsByDay[dt];

    //        //    ClosingBalanceByDay.Add(dt, closingBalance);
    //        //    return closingBalance;
    //        //}
    //        //else
    //        //    return (decimal)ClosingBalanceByDay[dt];
    //    }
    //    //return closingBalance;
    //}

    public class DepositTransaction
    {
        public int amount { get {
                return note_type * notes_count;
            } }
        public int ej_parsed_bna_transaction_id { get; set; }
        public int note_type { get; set; }
        public int notes_count { get; set; }
    }

}