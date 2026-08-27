using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Avanza.CCMS.DAL;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data;
using Avanza.iSuite.DAL;
using Avanza.CCMS;


public class DFFVersion2Helper
{
    public string title;
    public DateTime dt;
    public bool dateModified = false;
    public bool readFromCashPosition = false;
    public string closingBalanceFromCashPosition;
    public string rejectedCounters;
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

    int totalAmount = 0;
    int totalCount = 0;
    public bool isSwap = false;
    public int GetTotalAmount()
    {
        return totalAmount;
    }
    public int GetTotalCount()
    {
        return totalCount;
    }


    public Replenishment(int CashAdded1, int CashAdded2, int CashAdded3, int CashAdded4,
        int CashAdded5, int CashAdded6, int CashAdded7,
                        int Denomination1, int Denomination2, int Denomination3, int Denomination4,
        int Denomination5, int Denomination6, int Denomination7, bool isSwap)
    {
        this.cashAdded1 = CashAdded1;
        this.cashAdded2 = CashAdded2;
        this.cashAdded3 = CashAdded3;
        this.cashAdded4 = CashAdded4;
        this.isSwap = isSwap;
        totalCount = CashAdded1 + CashAdded2 + CashAdded3 + CashAdded4 + CashAdded5 + CashAdded6 + CashAdded7;
        totalAmount = CashAdded1 * Denomination1 + CashAdded2 * Denomination2 + CashAdded3 * Denomination3 +
                CashAdded4 * Denomination4 + CashAdded5 * Denomination5 + CashAdded6 * Denomination6 + CashAdded7 * Denomination7;
    }
}
public class CMS
{
    string field8 = null;
    int footerCount = 0;
    decimal rejectedCountsForRepDay = 0;
    Atm atm = null;
    DateTime tempDay;
    bool dateModified = false;
    SqlTransaction trxn = null;
    StringBuilder builder = new StringBuilder();
    System.Collections.Hashtable ReplenishmentByDay;
    SqlCommand cmd = null;
    NoteSetType noteSetType = null;
    int atmCount = 0;
    public List<DFFVersion2Helper> listDFFHelper = null;
    public DFFVersion2Helper dFFVersion2Helper = null;
    decimal totalWithdrawals = 0;
    decimal totalPreWithdrawals = 0;
    public void Initialize()
    {
        builder = new StringBuilder();

    }

    DateTime Day;
    int atm_id;
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
        purgedNotes[0] = cassette1PurgedCount;
        purgedNotes[1] = cassette2PurgedCount;
        purgedNotes[2] = cassette3PurgedCount;
        purgedNotes[3] = cassette4PurgedCount;
        purgedNotes[4] = cassette5PurgedCount;
        purgedNotes[5] = cassette6PurgedCount;
        purgedNotes[6] = cassette7PurgedCount;

        return amt;


    }
    public void StartGeneration(LogableTask task, int atm_id)
    {
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing Atm having Id : " + atm_id);
        ReplenishmentByDay = new System.Collections.Hashtable(51);
        totalWithdrawals = 0;
        totalPreWithdrawals = 0;
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise withdrawals");
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ExtractDayWiseWithdrawals();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "day wise withdrawals extracted");
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise replenishment");
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ExtractDayWiseReplenishment();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "day wise replenishment extracted");
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to extract day wise pre-withdrawals");
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ExtractDayWisePreWithdrawals();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "day wise pre-withdrawals extracted");
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Generating output for Atm having Id :" + atm_id);
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ConstructOutput(cmd.Connection, trxn);
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Output Generated for Atm having Id :" + atm_id);

    }
    public bool BuildSummary(LogableTask task, List<int> reqATMs)
    {
        listDFFHelper = new List<DFFVersion2Helper>();
        footerCount = 0;
        List<int> AtmIds = new List<int>();
        SqlDataReader reader = null;
        cmd = ConnectionFactory.GetNewCommand(true);
        cmd.CommandText = "delete summary where trxn_datetime =convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)";
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, cmd.ExecuteNonQuery() + " Row(s) deleted from summary table for the Day " + Day.ToString("dd/MM/yyyy"));
        cmd.CommandText = string.Format(@"select distinct atm_id 
                            from parsed_transaction 
                            where trxn_datetime >=convert(datetime,'{0}',103) 
                            and trxn_datetime<=convert(datetime,'{1}',103)",
                            Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
        reader = cmd.ExecuteReader();
        int id = -1;
        while (reader.Read())
        {
            id = reader.GetInt32(0);
            if (reqATMs.Contains(id))
                AtmIds.Add(id);
        }
        reader.Close();
        //done to catch at least replenishment data if trxns are missing.
        cmd.CommandText = string.Format(@"select distinct atm_id 
                            from replenishment 
                            where rep_datetime >=convert(datetime,'{0}',103) 
                            and rep_datetime<=convert(datetime,'{1}',103)",
                                  Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            id = reader.GetInt32(0);
            if (reqATMs.Contains(id))
            {
                if (!AtmIds.Contains(id))
                    AtmIds.Add(id);
            }

        }
        reader.Close();

        atmCount = reqATMs.Count;
        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "ATMs in queue:" + reqATMs.Count);

        try
        {

            trxn = cmd.Connection.BeginTransaction();
            cmd.Transaction = trxn;
            for (int i = 0; i < AtmIds.Count; i++)
            {

                dateModified = false;
                atm_id = AtmIds[i];
                atm = Atm.LoadAtmByPk(atm_id);
                if (atm == null) throw new Exception("atm defination is absent" + atm_id);

                if (!atm.IsActive)
                {
                    task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Inactive ATM found so ignoring it:" + atm.Title);
                    continue;
                }

                if (atm.ExcludeDff.HasValue)
                {
                    if (atm.ExcludeDff.Value)
                    {
                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Excluding DFF flag is set so ignoring it:" + atm.Title);
                        continue;
                    }
                }


                noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                if (noteSetType == null)
                    throw new Exception("Note Set Type does not exists" + atm_id);
                footerCount++;
                dFFVersion2Helper = new DFFVersion2Helper();
                dFFVersion2Helper.title = atm.Title;
                StartGeneration(task, atm_id);
                listDFFHelper.Add(dFFVersion2Helper);
            }

            for (int i = 0; i < reqATMs.Count; i++)
            {
                if (!AtmIds.Contains(reqATMs[i]))
                {
                    dateModified = false;
                    atm_id = reqATMs[i];
                    atm = Atm.LoadAtmByPk(atm_id);
                    if (atm == null) throw new Exception("atm defination is absent" + atm_id);
                    if (!atm.IsActive)
                    {
                        task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Inactive ATM found so ignoring it:" + atm.Title);
                        continue;
                    }

                    if (atm.ExcludeDff.HasValue)
                    {
                        if (atm.ExcludeDff.Value)
                        {
                            task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Excluding DFF flag is set so ignoring it:" + atm.Title);
                            continue;
                        }
                    }

                    noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                    if (noteSetType == null)
                        throw new Exception("Note Set Type does not exists" + atm_id);
                    footerCount++;
                    dFFVersion2Helper = new DFFVersion2Helper();
                    dFFVersion2Helper.title = atm.Title;
                    ConstructFakeOutput(task);
                    listDFFHelper.Add(dFFVersion2Helper);
                }
            }

            trxn.Commit();

        }
        catch (Exception ex)
        {
            if (trxn != null)
                trxn.Rollback();
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
    private string GetReplenishmentAmountInTermsOfNotes(DateTime dt)
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
            return replenishment.cashAdded1 + "|" +
                replenishment.cashAdded2 + "|" +
                replenishment.cashAdded3 + "|" +
                replenishment.cashAdded4 + "|" +
                replenishment.cashAdded5 + "|" +
                replenishment.cashAdded6 + "|" +
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
            return replenishment.GetTotalAmount();

        }
        else
        {
            //    replenishment = replenishmentsForOneDay[replenishmentsForOneDay.Count-1];
            ///   return replenishment.GetTotalAmount();


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
            }

            else if (!replenishmentType.Contains(1)) //add
            {
                foreach (Replenishment rep in replenishmentsForOneDay)
                    replenishmentAmount += rep.GetTotalAmount();

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
        }
        return replenishmentAmount;

    }
    private void ExtractDayWiseReplenishment()
    {
        List<Replenishment> replenishmentList = new List<Replenishment>();

        Avanza.CCMS.DAL.Replenishment.ReplenishmentReader reader = Avanza.CCMS.DAL.Replenishment.ExecuteReader("atm_id =" + atm_id + " and rep_datetime>=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 00:00:00',103) and rep_datetime<=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103)");
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
                                    noteSetType.DenominationType7.Value, reader.CurrentReplenishment.IsSwap);
                replenishmentList.Add(replenishment);
            }
            reader.Close();
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
        ReplenishmentByDay = new Hashtable();
        Avanza.CCMS.DAL.Replenishment.ReplenishmentReader reader = Avanza.CCMS.DAL.Replenishment.ExecuteReader("atm_id =" + atm_id + " and rep_datetime>=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + " 00:00:00',103) and rep_datetime<=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + " 23:59:59',103)");
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
                                    noteSetType.DenominationType7.Value, reader.CurrentReplenishment.IsSwap);
                replenishmentList.Add(replenishment);
            }
            reader.Close();
            if (replenishmentList.Count > 0)
                ReplenishmentByDay.Add(dt, replenishmentList);
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
    public string FormatToDFFVersion2()
    {
        try
        {
            StringBuilder DFFVersion2Builder = new StringBuilder();
            string[] parts = builder.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listCurrencies = null;
            List<int> listCurrenciesIndexes = null;
            List<int> todayClosingBalance = null;
            string yesterdayClosingBalance = null;
            string[] yesterdayClosingBalanceParts = null;
            string replenishment = null;
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
            int dispensableNotes = 0;
            int dispensableNotesSum = 0;
            int temp = 0;
            string[] closingBalancePartsFromCashPosition = null;


            DFFVersion2Builder.Append("CASHP_ID\tCRNCY_ID\tDENOM_ID\tDATE\tOPEN_BAL\tNORM_DEL\tNORM_RTR\tUNPL_DEL\tUNPL_RTR\tWTHDRWLS\tPRE_WDRW\tDEPOSITS\tCLOS_BAL\tBAL_DISP\tBAL_ESCR\tBAL_UNAV\tOPR_STAT\tEXCLD_FL\tCASSETTE\r\n");
            foreach (string part in parts)
            {
                string field2 = part.Substring(8, 8);
                atm = Atm.LoadAtm("title='" + field2 + "'");
                if (atm == null)
                    continue;

                dFFVersion2Helper = GetHelper(atm.Title);
                Day = dFFVersion2Helper.dt;
                atm_id = atm.ATMId;
                listCurrencies = new List<string>();
                listCurrenciesIndexes = new List<int>();
                todayClosingBalance = new List<int>();
                if (dFFVersion2Helper.closingBalanceFromCashPosition != null)
                    closingBalancePartsFromCashPosition = dFFVersion2Helper.closingBalanceFromCashPosition.Split('|');
                //yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));
                //yesterdayClosingBalanceParts = yesterdayClosingBalance.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                ExtractDayWiseReplenishment(Day);

                replenishment = GetReplenishmentAmountInTermsOfNotes(Day);
                //if (replenishment == null) replenishment = "0|0|0|0|0|0|0";
                replenishmentParts = replenishment.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                prewithdrawals = ExtractDayWisePreWithdrawalsInTermsOfNotes(Day);
                //if (prewithdrawals == null) prewithdrawals = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
                prewithdrawalsParts = prewithdrawals.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                withdrawals = ExtractDayWiseWithdrawalsInTermsOfNotes(Day);
                //if (withdrawals == null) withdrawals = "0|0|0|0|0|0|0|0|0|0|0|0|0|0";
                withdrawalsParts = withdrawals.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                int swapReturnAmount = 0;
                rejectedCounter = GetRejectedCountDueToTestCash(Day);
                rejectedCounterParts = rejectedCounter.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                replenishmentDay = false;
                //this will change helper object
                yesterdayClosingBalance = GetClosingBalanceInTermsOfNotes(Day.AddDays(-1));
                yesterdayClosingBalanceParts = yesterdayClosingBalance.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < replenishmentParts.Length; j++)
                {
                    if (replenishmentParts[j] != "0")
                    {
                        replenishmentDay = true;
                    }
                }

                noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                if (noteSetType.DenominationType1Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType1Title);
                    listCurrenciesIndexes.Add(0);
                }
                if (noteSetType.DenominationType2Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType2Title);
                    listCurrenciesIndexes.Add(1);
                }
                if (noteSetType.DenominationType3Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType3Title);
                    listCurrenciesIndexes.Add(2);
                }

                if (noteSetType.DenominationType4Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType4Title);
                    listCurrenciesIndexes.Add(3);
                }
                if (noteSetType.DenominationType5Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType5Title);
                    listCurrenciesIndexes.Add(4);
                }
                if (noteSetType.DenominationType6Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType6Title);
                    listCurrenciesIndexes.Add(5);
                }
                if (noteSetType.DenominationType7Title.Length != 0)
                {
                    listCurrencies.Add(noteSetType.DenominationType7Title);
                    listCurrenciesIndexes.Add(6);
                }
                string subString = null;
                iYesterdayClosingBalance = 0;
                iReplenishment = 0;
                iPrewithdrawals = 0;
                iWithdrawals = 0;
                iSwapReturnAmount = 0;
                iRejectedCounter = 0;
                dispensableNotes = 0;
                dispensableNotesSum = 0;
                for (int i = 0; i < listCurrencies.Count; i++)
                {

                    int denominationValue = int.Parse(listCurrencies[i].Substring(3));
                    subString = field2.Substring(3);
                    if (subString.Length > 8)
                        DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4, 8) + "\t");
                    else
                        DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4) + "\t");

                    DFFVersion2Builder.Append(listCurrencies[i].Substring(0, 3) + "\t");
                    DFFVersion2Builder.Append(listCurrencies[i] + "\t");
                    DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + "\t");
                    temp = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) * denominationValue;
                    if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;
                    DFFVersion2Builder.Append(temp + "\t");
                    iYesterdayClosingBalance += temp;// int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) * denominationValue;

                    temp = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) * denominationValue;
                    if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;
                    DFFVersion2Builder.Append(temp + "\t");
                    iReplenishment += temp;// int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) * denominationValue;

                    if (replenishmentDay)
                        swapReturnAmount = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) - int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]);

                    temp = swapReturnAmount * denominationValue;
                    if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;
                    DFFVersion2Builder.Append(temp + "\t");
                    iSwapReturnAmount += temp;// swapReturnAmount* denominationValue;
                    DFFVersion2Builder.Append("0\t0\t");
                    temp = int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) * denominationValue;
                    if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;
                    DFFVersion2Builder.Append(temp + "\t");
                    iWithdrawals += temp;// int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) * denominationValue;
                    temp = int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]) * denominationValue;
                    if (temp < 0 || dFFVersion2Helper.dateModified) temp = 0;

                    DFFVersion2Builder.Append(temp + "\t");
                    iPrewithdrawals += temp;
                    DFFVersion2Builder.Append("0\t");
                    DFFVersion2Builder.Append("CLOSINGBALANCE\t");

                    int notesConsumed = int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) + int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) + int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]);
                    if (replenishmentDay)
                    {
                        dispensableNotes = int.Parse(replenishmentParts[listCurrenciesIndexes[i]]) - (int.Parse(withdrawalsParts[listCurrenciesIndexes[i]]) - int.Parse(prewithdrawalsParts[listCurrenciesIndexes[i]]));
                        // exclude rejected counters.
                        dispensableNotes -= int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) + int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]);
                    }
                    else
                        dispensableNotes = int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[i]]) - notesConsumed;

                    if (dFFVersion2Helper.readFromCashPosition)
                        dispensableNotes = int.Parse(closingBalancePartsFromCashPosition[listCurrenciesIndexes[i]]);

                    temp = dispensableNotes * denominationValue;
                    if (temp < 0) temp = 0;

                    DFFVersion2Builder.Append(temp + "\t");
                    dispensableNotesSum += temp;
                    DFFVersion2Builder.Append("0\t");
                    int temp1 = 0;
                    if (dFFVersion2Helper.readFromCashPosition)
                        temp1 = int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue;

                    else
                        temp1 = int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue +
                           +int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]) * denominationValue;

                    if (temp1 < 0) temp1 = 0;

                    DFFVersion2Builder.Append(temp1 + "\t");
                    iRejectedCounter += temp1;

                    temp = temp + temp1;// int.Parse(withdrawalsParts[listCurrenciesIndexes[i] + 7]) * denominationValue +
                    //int.Parse(rejectedCounterParts[listCurrenciesIndexes[i]]) * denominationValue + dispensableNotes * denominationValue;
                    if (temp < 0) temp = 0;
                    DFFVersion2Builder.Replace("CLOSINGBALANCE", temp.ToString());

                    //bool isAnyCassetteEmpty = false;
                    //for (int j = 0; j < listCurrenciesIndexes.Count; j++)
                    //    if (int.Parse(yesterdayClosingBalanceParts[listCurrenciesIndexes[j]]) == 0)

                    //        isAnyCassetteEmpty = true;
                    //if (!isAnyCassetteEmpty)
                    if (dispensableNotes > 0)
                        DFFVersion2Builder.Append("0\t0\t");
                    else
                        DFFVersion2Builder.Append("1\t1\t");
                    DFFVersion2Builder.Append("\r\n");

                }

                subString = field2.Substring(3);
                if (subString.Length > 8)
                    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4, 8) + "\t");
                else
                    DFFVersion2Builder.Append(field2.Substring(0, 3) + "A" + field2.Substring(4) + "\t");

                DFFVersion2Builder.Append(listCurrencies[0].Substring(0, 3) + "\t");
                DFFVersion2Builder.Append("\t");
                DFFVersion2Builder.Append(Day.ToString("ddMMyyyy") + "\t");
                DFFVersion2Builder.Append(iYesterdayClosingBalance + "\t");
                DFFVersion2Builder.Append(iReplenishment + "\t");
                DFFVersion2Builder.Append(iSwapReturnAmount + "\t");
                DFFVersion2Builder.Append("0\t");
                DFFVersion2Builder.Append("0\t");
                DFFVersion2Builder.Append(iWithdrawals + "\t");
                DFFVersion2Builder.Append(iPrewithdrawals + "\t");
                DFFVersion2Builder.Append("0\t");
                DFFVersion2Builder.Append(dispensableNotesSum + iRejectedCounter + "\t");
                DFFVersion2Builder.Append(dispensableNotesSum + "\t");
                DFFVersion2Builder.Append("0\t");
                DFFVersion2Builder.Append(iRejectedCounter + "\t");
                DFFVersion2Builder.Append("\r\n");

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

        EjStatus existingEjStatus = EjStatus.LoadEjStatus("atm_id = " + atm_id + " and ejDateTime=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)");

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


        }
        else
        {
            cmd.CommandText = "select max(trxn_datetime) from parsed_transaction where atm_id = " + atm_id + " and trxn_datetime<=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";
            object lastMaxTrxnDateTime = cmd.ExecuteScalar();
            if (lastMaxTrxnDateTime != DBNull.Value)
            {
                cmd.CommandText = "select max(rep_datetime) from replenishment where atm_id = " + atm_id + " and rep_datetime<=convert(datetime,'" + Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";
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
                StartGeneration(task, atm_id);
                Day = tempDay;
                task.Log(System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Warning, string.Format("Summary data generated successfully for atm[{0}]", atm_id));
            }
            else
            {
                cmd.CommandText = @"select cassette1_remaining_notes,cassette2_remaining_notes,cassette3_remaining_notes,cassette4_remaining_notes,cassette5_remaining_notes,
                                    cassette6_remaining_notes,cassette7_remaining_notes,
                                    cassette1_dispensed_notes,cassette2_dispensed_notes,cassette3_dispensed_notes,cassette4_dispensed_notes,cassette5_dispensed_notes,
                                    cassette6_dispensed_notes,cassette7_dispensed_notes,
                                    cassette1_purged_notes,cassette2_purged_notes,cassette3_purged_notes,cassette4_purged_notes,cassette5_purged_notes,
                                    cassette6_purged_notes,cassette7_purged_notes from dispenser_end_of_day_balance 
                                    where counter_file_datetime =convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) "
                                    + " and atm_id = " + atm_id;
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

        }

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

        cmd.CommandText = @"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
                isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0)
                           from parsed_transaction where atm_id = " + atm_id +
                " and trxn_datetime>= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103)  " +
                " and  trxn_datetime<= convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103) ";


        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);


        if (dt.Rows.Count > 0)
        {
            //for (int i = 0; i < 6; i++)
            //    if (int.Parse(dt.Rows[0][i].ToString()) < 0)
            //        dt.Rows[0][i] = 0;

            return noteSetType.DenominationType1.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][0].ToString()) * noteSetType.DenominationType1.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[0]) +
            noteSetType.DenominationType2.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][1].ToString()) * noteSetType.DenominationType2.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[1]) +
            noteSetType.DenominationType3.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][2].ToString()) * noteSetType.DenominationType3.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[2]) +
            noteSetType.DenominationType4.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][3].ToString()) * noteSetType.DenominationType4.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[3]) +
            noteSetType.DenominationType5.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][4].ToString()) * noteSetType.DenominationType5.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[4]) +
            noteSetType.DenominationType6.Value.ToString().PadLeft(6, '0') + (int.Parse(dt.Rows[0][5].ToString()) * noteSetType.DenominationType6.Value).ToString().PadLeft(9, '0') + GetDenominationState(parts[5]);

        }
        else
            return "0";
        //DispensedRegex.Match(
    }
    private void ConstructOutput(SqlConnection conn, SqlTransaction trxn)
    {
        int[] purgedCounters = null;
        decimal closingBalance = 0;
        string field1 = "00000000";
        string field2 = atm.Title;
        string field3 = null;
        string field4 = null;
        string field5 = null;
        string field6 = null;
        string field7 = null;
        string last = "0";
        dFFVersion2Helper.dt = Day;

        if (!dateModified)
            field3 = ((int)GetReplenishmentAmount(Day)).ToString().PadLeft(9, '0');
        else
            field3 = "0".PadLeft(9, '0');


        if (!dateModified)
        {
            decimal returnAmount = GetReturnAmount(Day);
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
            field5 = "0".PadLeft(9, '0');

        //string field6 = (GetClosingBalance(Day.AddDays(-1)) + totalPreWithdrawals).ToString().PadLeft(9, '0');
        //int consumptionBetweenTwoRep = (int)(GetWithdrawals() + totalPreWithdrawals);
        //if (consumptionBetweenTwoRep < 0)
        //    consumptionBetweenTwoRep = 0;

        //string field6 = consumptionBetweenTwoRep.ToString().PadLeft(9, '0');
        if (!dateModified)
            field6 = totalPreWithdrawals.ToString().PadLeft(9, '0');
        else
            field6 = "0".PadLeft(9, '0');


        //if (!dateModified)
        //{
        closingBalance = GetClosingBalance(Day);
        bool readFromCashPosition = false;
        CashPosition cashPosition = null;
        //GetRejectedCountForDay(Day);
        if (closingBalance <= 0) // if yesterday closing balance is 0 since we don't have cash positions.
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
                readFromCashPosition = true;
                dFFVersion2Helper.readFromCashPosition = true;

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
        string[] parts = null;
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
            closingBalanceNotes = GetClosingBalanceInTermsOfNotes(Day);
            //dFFVersion2Helper.closingBalanceNotes = closingBalanceNotes;
            parts = closingBalanceNotes.Split('|');
        }

        for (int i = 0; i < 6; i++)
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
        summary.AtmId = atm_id;
        summary.ClosingBalance = closingBalance;
        summary.PreWithdrawals = totalPreWithdrawals;
        summary.Withdrawals = totalWithdrawals;
        summary.ReplenishmentAmount = int.Parse(field3);
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




        if (dateModified)
            summary.TrxnDatetime = new DateTime(tempDay.Year, tempDay.Month, tempDay.Day);// DateTime.Parse(tempDay.ToString("dd/MM/yyyy"));
        else
            summary.TrxnDatetime = new DateTime(Day.Year, Day.Month, Day.Day);//.ToString("dd/MM/yyyy")); 

        AppSetting appSetting = AppSetting.LoadAppSetting("1=1");

        if (cashPosition == null)
            cashPosition = CashPosition.LoadCashPosition("atm_id =" + atm_id + " and last_trxn_at >=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + "',103) " +
                    " and last_trxn_at <=convert(datetime,'" + Day.ToString("dd/MM/yyyy") + " 23:59:59',103)");

        if (cashPosition != null)
        {
            if (purgedCounters == null)
                purgedCounters = new int[7];
            GetRejectedCountForDay(Day, purgedCounters);

            if ((cashPosition.Cassette1Notes + purgedCounters[0] != summary.CashRemaining1)
                || (cashPosition.Cassette2Notes + purgedCounters[1] != summary.CashRemaining2)
                || (cashPosition.Cassette3Notes + purgedCounters[2] != summary.CashRemaining3)
            || (cashPosition.Cassette4Notes + purgedCounters[3] != summary.CashRemaining4)
            || (cashPosition.Cassette5Notes + purgedCounters[4] != summary.CashRemaining5)
            || (cashPosition.Cassette6Notes + purgedCounters[5] != summary.CashRemaining6)
            || (cashPosition.Cassette7Notes + purgedCounters[6] != summary.CashRemaining7))

                try
                {
                    AlertManager.GenerateTerminalAlert(atm_id, (int)EnumAlertType.DFFSuspect, "Discrepency found in computing closing balance and balance found from ATM current position,Date of cash position " + cashPosition.LastTrxnAt.ToString(), trxn, appSetting.AlertExpirationTime.Value, appSetting.MaxTries);
                }

                catch (Exception ex)
                {

                    try
                    {
                        EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace);
                    }
                    catch
                    {
                    }

                }

        }



        decimal yesterdayClosingBalance = GetClosingBalance(Day.AddDays(-1));
        if (yesterdayClosingBalance < summary.Withdrawals)
        {
            try
            {

                AlertManager.GenerateTerminalAlert(atm_id, (int)EnumAlertType.DFFSuspect, "Opening balance" + yesterdayClosingBalance
                    + " is less than withdrawals " + summary.Withdrawals

                    , trxn, appSetting.AlertExpirationTime.Value, appSetting.MaxTries);
            }
            catch (Exception ex)
            {

                try
                {
                    EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace);
                }
                catch
                {
                }

            }

        }

        summary.Save(conn, trxn);




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



    private string ExtractDayWiseWithdrawalsInTermsOfNotes(DateTime trxnDate)
    {
        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
                            from parsed_transaction
                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2}',103)",
                            atm_id, trxnDate.ToString("dd/MM/yyyy"), trxnDate.ToString("dd/MM/yyyy") + " 23:59:59");

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        int row = 0, col = 0;
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

        //totalWithdrawals = GetValue(cmd.ExecuteScalar());
    }




    private decimal ExtractDayWiseWithdrawals(DateTime dt)
    {
        cmd.CommandText = string.Format(@"select sum(amount)
                            from parsed_transaction
                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2}',103)",
                            atm_id, dt.ToString("dd/MM/yyyy"), dt.ToString("dd/MM/yyyy") + " 23:59:59");
        return GetValue(cmd.ExecuteScalar());
    }


    private void ExtractDayWiseWithdrawals()
    {
        cmd.CommandText = string.Format(@"select sum(amount)
                            from parsed_transaction
                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2}',103)",
                            atm_id, Day.ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
        totalWithdrawals = GetValue(cmd.ExecuteScalar());
    }

    private decimal GetLastReportedBalance() { return 0; }





    private string ExtractDayWisePreWithdrawalsInTermsOfNotes(DateTime trxnDate)
    {
        if (ReplenishmentByDay[Day] == null)
            totalPreWithdrawals = 0;
        else
        {

            cmd.CommandText = string.Format(@"select min(rep_datetime)
                                from replenishment
                                where atm_id = {0} and rep_datetime >=convert(datetime,'{1} 00:00:00',103) 
and rep_datetime <=convert(datetime,'{1} 23:59:59',103) ",
                                atm_id, trxnDate.ToString("dd/MM/yyyy"));
            DateTime replenishmentDateTime = (DateTime)cmd.ExecuteScalar();

            cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0),isnull(sum(cash_dispensed2),0),isnull(sum(cash_dispensed3),0),
isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0),
isnull(sum(cash_purged1),0),isnull(sum(cash_purged2),0),isnull(sum(cash_purged3),0),
isnull(sum(cash_purged4),0),isnull(sum(cash_purged5),0),isnull(sum(cash_purged6),0),isnull(sum(cash_purged7),0)
                            from parsed_transaction
                            where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                            and trxn_datetime <=convert(datetime,'{2}',103)",
                    atm_id, trxnDate.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int row = 0, col = 0;
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
        int[] data = null;
        //decimal closingBalance = 0;
        //ExtractDayWiseReplenishment(dt);
        if (GetReplenishmentAmount(dt) > 0)
        {
            //return GetReplenishmentAmount(dt) - ((WithdmsrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt] - ((PreWithdrawalsByDay[dt] == null) ? 0 : (decimal)PreWithdrawalsByDay[dt]));
            string GetReplenishmentNotes = GetReplenishmentAmountInTermsOfNotes(dt);
            string GetWithdrawalsNotes = ExtractDayWiseWithdrawalsInTermsOfNotes(dt);
            string GetPreWithdrawals = ExtractDayWisePreWithdrawalsInTermsOfNotes(dt);

            //dFFVersion2Helper.replenishmentNotes = GetReplenishmentNotes;
            //dFFVersion2Helper.prewithdrawalNotes = GetPreWithdrawals;
            //dFFVersion2Helper.withdrawalNotes = GetWithdrawalsNotes;

            string[] repParts = GetReplenishmentNotes.Split('|');
            string[] withdrawalParts = GetWithdrawalsNotes.Split('|');
            string[] preWithdrawalsParts = GetPreWithdrawals.Split('|');
            //int withdrawalsNotes = 0,preWithdrawalsNotes=0,replenishmentNotes=0;
            int[] result = new int[7];
            int i = 0;
            for (i = 0; i < 7; i++)
            {
                result[i] = int.Parse(repParts[i]) - (int.Parse(withdrawalParts[i]) - int.Parse(preWithdrawalsParts[i]));
            }
            i = 0;

            //dFFVersion2Helper.closingBalanceNotes= result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" +
            //    result[i++] + "|" + result[i++];
            return result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" + result[i++] + "|" +
                result[i++] + "|" + result[i++];


            //      return GetReplenishmentAmount(dt) - (totalWithdrawals - totalPreWithdrawals);

            //if (ClosingBalanceByDay[dt] == null)
            //{
            //    closingBalance = GetReplenishmentAmount(dt) - ((WithdrawalsByDay[dt] == null) ? 0 : (decimal)WithdrawalsByDay[dt] - ((PreWithdrawalsByDay[dt] == null) ? 0 : (decimal)PreWithdrawalsByDay[dt]));
            //    ClosingBalanceByDay.Add(dt, closingBalance);
            //    return closingBalance;
            //}
            //else
            //    return (decimal)ClosingBalanceByDay[dt];
        }
        else
        {
            //problem in the following function
            if (Day == dt)
            {
                cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";
                object result = cmd.ExecuteScalar();


                #region Revalidate
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("cash_remaining1", typeof(int));
                dt3.Columns.Add("cash_remaining2", typeof(int));
                dt3.Columns.Add("cash_remaining3", typeof(int));
                dt3.Columns.Add("cash_remaining4", typeof(int));
                dt3.Columns.Add("cash_remaining5", typeof(int));
                dt3.Columns.Add("cash_remaining6", typeof(int));
                dt3.Columns.Add("cash_remaining7", typeof(int));

                if (result != null)
                {
                    cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)", atm_id,
                                          Day.ToString("dd/MM/yyyy"));

                    object maxRepDate = cmd.ExecuteScalar();
                    if (maxRepDate != DBNull.Value)
                    {
                        string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(maxRepDate.ToString())).Split('|');
                        DataRow dr = dt3.NewRow();
                        for (int i = 0; i < 7; i++)
                            dr[i] = parts[i];
                        dt3.Rows.Add(dr);


                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");


                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt4 = new DataTable();
                        adapter.Fill(dt4);
                        data = new int[7];
                        data[0] = int.Parse(dt3.Rows[0][0].ToString()) - int.Parse(dt4.Rows[0][0].ToString());
                        data[1] = int.Parse(dt3.Rows[0][1].ToString()) - int.Parse(dt4.Rows[0][1].ToString());
                        data[2] = int.Parse(dt3.Rows[0][2].ToString()) - int.Parse(dt4.Rows[0][2].ToString());
                        data[3] = int.Parse(dt3.Rows[0][3].ToString()) - int.Parse(dt4.Rows[0][3].ToString());
                        data[4] = int.Parse(dt3.Rows[0][4].ToString()) - int.Parse(dt4.Rows[0][4].ToString());
                        data[5] = int.Parse(dt3.Rows[0][5].ToString()) - int.Parse(dt4.Rows[0][5].ToString());
                        data[6] = int.Parse(dt3.Rows[0][6].ToString()) - int.Parse(dt4.Rows[0][6].ToString());





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

                        return "0|0|0|0|0|0|0";
                    }
                    else
                    {
                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("cash_remaining1", typeof(int));
                        dt2.Columns.Add("cash_remaining2", typeof(int));
                        dt2.Columns.Add("cash_remaining3", typeof(int));
                        dt2.Columns.Add("cash_remaining4", typeof(int));
                        dt2.Columns.Add("cash_remaining5", typeof(int));
                        dt2.Columns.Add("cash_remaining6", typeof(int));
                        dt2.Columns.Add("cash_remaining7", typeof(int));
                        cmd.CommandText = string.Format(@"select rep_datetime 
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime >=convert(datetime,'{1}',103) 
                                           and rep_datetime <=convert(datetime,'{2}',103)", atm_id,
                                          DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"),
                                          Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        object repDate = cmd.ExecuteScalar();
                        decimal newClosingBalance = -1;
                        if (repDate != null)
                        {
                            string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString())).Split('|');
                            DataRow dr = dt2.NewRow();
                            for (int i = 0; i < 7; i++)
                                dr[i] = parts[i];
                            dt2.Rows.Add(dr);

                            newClosingBalance = 0;// GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString()));
                            lastSummaryTrxnDate = repDate;
                        }


                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");


                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        adapter.Fill(dt1);
                        //int row = 0, col = 0;
                        //return dt.Rows[row][col++] + "|" +
                        //dt.Rows[row][col++] + "|"
                        //+ dt.Rows[row][col++] + "|"
                        //+ dt.Rows[row][col++] + "|"
                        //+ dt.Rows[row][col++] + "|"
                        //+ dt.Rows[row][col++] + "|"
                        //+ dt.Rows[row][col++] + "|"+


                        //decimal totalTrxnAmount = (decimal)cmd.ExecuteScalar();
                        //decimal balance = 0;
                        if (newClosingBalance == -1)
                        {
                            cmd.CommandText = string.Format(@"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),
isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0)
                                        from summary 
                                        where atm_id = {0} and trxn_datetime in (  
                                        select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103))", atm_id, dt.ToString("dd/MM/yyyy"));


                            adapter = new SqlDataAdapter(cmd);
                            dt2 = new DataTable();
                            adapter.Fill(dt2);
                        }
                        int row = 0;

                        return (int.Parse(dt2.Rows[row][0].ToString()) - int.Parse(dt1.Rows[row][0].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][1].ToString()) - int.Parse(dt1.Rows[row][1].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][2].ToString()) - int.Parse(dt1.Rows[row][2].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][3].ToString()) - int.Parse(dt1.Rows[row][3].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][4].ToString()) - int.Parse(dt1.Rows[row][4].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][5].ToString()) - int.Parse(dt1.Rows[row][5].ToString())) + "|" +
                            (int.Parse(dt2.Rows[row][6].ToString()) - int.Parse(dt1.Rows[row][6].ToString()));


                        //decimal balance = (decimal)cmd.ExecuteScalar();
                        //--return (balance - totalTrxnAmount).ToString();
                        //return "0|0|0|0|0|0|0";

                    }

                    //cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

                    //No closing balance row found
                }
                else
                //return GetValue(cmd.ExecuteScalar()) - totalWithdrawals;
                {

                    if (data == null)
                    {
                        cmd.CommandText = @"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),
                    
                                        isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0) from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.AddDays(-1).ToString("dd/MM/yyyy") + "',103)";

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

                    }
                    string[] parts = ExtractDayWiseWithdrawalsInTermsOfNotes(Day).Split('|');


                    return (data[0] - int.Parse(parts[0].ToString())) + "|" +
                        (data[1] - int.Parse(parts[1].ToString())) + "|" +
                        (data[2] - int.Parse(parts[2].ToString())) + "|" +
                        (data[3] - int.Parse(parts[3].ToString())) + "|" +

                        (data[4] - int.Parse(parts[4].ToString())) + "|" +
                        (data[5] - int.Parse(parts[5].ToString())) + "|" +
                        (data[6] - int.Parse(parts[6].ToString()));


                }
            }
            else
            {
                //work in case of return amount when Day != dt
                cmd.CommandText = "select closing_balance from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + "',103)";
                //return GetValue(cmd.ExecuteScalar());
                object result = cmd.ExecuteScalar();

                #region Revalidate
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("cash_remaining1", typeof(int));
                dt3.Columns.Add("cash_remaining2", typeof(int));
                dt3.Columns.Add("cash_remaining3", typeof(int));
                dt3.Columns.Add("cash_remaining4", typeof(int));
                dt3.Columns.Add("cash_remaining5", typeof(int));
                dt3.Columns.Add("cash_remaining6", typeof(int));
                dt3.Columns.Add("cash_remaining7", typeof(int));

                if (result != null)
                {
                    cmd.CommandText = string.Format(@"select max(rep_datetime)
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)", atm_id,
                                          dt.ToString("dd/MM/yyyy"));

                    object maxRepDate = cmd.ExecuteScalar();
                    if (maxRepDate != DBNull.Value)
                    {
                        string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(maxRepDate.ToString())).Split('|');
                        DataRow dr = dt3.NewRow();
                        for (int i = 0; i < 7; i++)
                            dr[i] = parts[i];
                        dt3.Rows.Add(dr);


                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.ToString("dd/MM/yyyy") + " 23:59:59");


                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt4 = new DataTable();
                        adapter.Fill(dt4);
                        data = new int[7];
                        data[0] = int.Parse(dt3.Rows[0][0].ToString()) - int.Parse(dt4.Rows[0][0].ToString());
                        data[1] = int.Parse(dt3.Rows[0][1].ToString()) - int.Parse(dt4.Rows[0][1].ToString());
                        data[2] = int.Parse(dt3.Rows[0][2].ToString()) - int.Parse(dt4.Rows[0][2].ToString());
                        data[3] = int.Parse(dt3.Rows[0][3].ToString()) - int.Parse(dt4.Rows[0][3].ToString());
                        data[4] = int.Parse(dt3.Rows[0][4].ToString()) - int.Parse(dt4.Rows[0][4].ToString());
                        data[5] = int.Parse(dt3.Rows[0][5].ToString()) - int.Parse(dt4.Rows[0][5].ToString());
                        data[6] = int.Parse(dt3.Rows[0][6].ToString()) - int.Parse(dt4.Rows[0][6].ToString());





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
                        //   return 0;
                        //dFFVersion2Helper.closingBalanceNotes = 
                        return "0|0|0|0|0|0|0";
                    }
                    else
                    {


                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("cash_remaining1", typeof(int));
                        dt2.Columns.Add("cash_remaining2", typeof(int));
                        dt2.Columns.Add("cash_remaining3", typeof(int));
                        dt2.Columns.Add("cash_remaining4", typeof(int));
                        dt2.Columns.Add("cash_remaining5", typeof(int));
                        dt2.Columns.Add("cash_remaining6", typeof(int));
                        dt2.Columns.Add("cash_remaining7", typeof(int));

                        cmd.CommandText = string.Format(@"select rep_datetime 
                                           from replenishment 
                                           where atm_id = {0} and rep_datetime >=convert(datetime,'{1}',103) 
                                           and rep_datetime <=convert(datetime,'{2}',103)", atm_id,
                                          DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"),
                                          dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        object repDate = cmd.ExecuteScalar();
                        decimal newClosingBalance = -1;
                        if (repDate != null)
                        {
                            string[] parts = GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString())).Split('|');
                            for (int i = 0; i < 7; i++)
                                dt2.Rows[0][i] = parts[i];
                            newClosingBalance = 0;
                            //GetClosingBalanceInTermsOfNotes(DateTime.Parse(repDate.ToString()));
                            lastSummaryTrxnDate = repDate;
                        }






                        cmd.CommandText = string.Format(@"select isnull(sum(cash_dispensed1),0), isnull(sum(cash_dispensed2),0),
isnull(sum(cash_dispensed3),0),isnull(sum(cash_dispensed4),0),isnull(sum(cash_dispensed5),0),isnull(sum(cash_dispensed6),0),isnull(sum(cash_dispensed7),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        adapter.Fill(dt1);




                        //        decimal totalTrxnAmount = GetValue(cmd.ExecuteScalar());
                        if (newClosingBalance == -1)
                        {

                            cmd.CommandText = string.Format(@"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),
isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0)
                                        from summary 
                                        where atm_id = {0} and trxn_datetime in (  
                                        select max(trxn_datetime)
                                        from summary 
                                        where atm_id = {0} 
                                        and trxn_datetime <convert(datetime,'{1}',103))", atm_id, dt.ToString("dd/MM/yyyy"));


                            adapter = new SqlDataAdapter(cmd);
                            dt2 = new DataTable();
                            adapter.Fill(dt2);
                        }
                        int row = 0;

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
                }
                else
                {
                    //return GetValue(cmd.ExecuteScalar());

                    if (data == null)
                    {
                        cmd.CommandText = @"select isnull(cash_remaining1,0),isnull(cash_remaining2,0),
                                            isnull(cash_remaining3,0),isnull(cash_remaining4,0),isnull(cash_remaining5,0),isnull(cash_remaining6,0),isnull(cash_remaining7,0) from summary where atm_id=" + atm_id + " and trxn_datetime=convert(datetime,'" + dt.ToString("dd/MM/yyyy") + "',103)";


                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt2 = new DataTable();
                        adapter.Fill(dt2);
                        int row = 0, col = 0;
                        //dFFVersion2Helper.closingBalanceNotes = 
                        //return dt2.Rows[row][col++] + "|" +
                        //dt2.Rows[row][col++] + "|"
                        //+ dt2.Rows[row][col++] + "|"
                        //+ dt2.Rows[row][col++] + "|"
                        //+ dt2.Rows[row][col++] + "|"
                        //+ dt2.Rows[row][col++] + "|"
                        //+ dt2.Rows[row][col++];
                        data = new int[7];
                        data[0] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[1] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[2] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[3] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[4] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[5] = int.Parse(dt2.Rows[row][col++].ToString());
                        data[6] = int.Parse(dt2.Rows[row][col++].ToString());


                    }

                    return data[0].ToString() + "|" + data[1].ToString() + "|" + data[2].ToString() + "|" + data[3].ToString() + "|" + data[4].ToString() +
                        "|" + data[5].ToString() + "|" + data[6].ToString();


                    // return "0|0|0|0|0|0|0";
                }
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
    private void ExtractDayWisePreWithdrawals()
    {
        if (ReplenishmentByDay[Day] == null)
            totalPreWithdrawals = 0;
        else
        {

            cmd.CommandText = string.Format(@"select min(rep_datetime)
                                from replenishment
                                where atm_id = {0} and rep_datetime >=convert(datetime,'{1} 00:00:00',103) 
and rep_datetime <=convert(datetime,'{1} 23:59:59',103) ",
                                atm_id, Day.ToString("dd/MM/yyyy"));
            DateTime replenishmentDateTime = (DateTime)cmd.ExecuteScalar();
            cmd.CommandText = string.Format(@"select sum(amount)
                                 from parsed_transaction
                                 where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) " +
                               " and trxn_datetime <=convert(datetime,'{2}',103)", atm_id, Day.ToString("dd/MM/yyyy"), replenishmentDateTime.ToString("dd/MM/yyyy HH:mm:ss"));

            totalPreWithdrawals = GetValue(cmd.ExecuteScalar());
            ///rejectedCountsForRepDay = GetRejectedCountForRepDay(replenishmentDateTime);


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
    private decimal GetReturnAmount(DateTime dt)
    {
        if (ReplenishmentByDay[dt] == null)
            return 0;

        else
            //    return (decimal)ClosingBalanceByDay[dt.AddDays(-1)] - totalPreWithdrawals;
            return GetClosingBalance(dt.AddDays(-1)) - totalPreWithdrawals;


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
        //decimal closingBalance = 0;
        if (ReplenishmentByDay[dt] == null)
            ExtractDayWiseReplenishment(dt);
        if (GetReplenishmentAmount(dt) > 0)
        {
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
                                           where atm_id = {0} and rep_datetime < convert(datetime,'{1}',103)",atm_id,
                                          Day.ToString("dd/MM/yyyy"));

                    object maxRepDate = cmd.ExecuteScalar();
                    if (maxRepDate != DBNull.Value)
                    {
                        decimal newBalance = GetClosingBalance(DateTime.Parse(maxRepDate.ToString()));

                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                    atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");

                        decimal revalidatedBalance = newBalance - decimal.Parse(cmd.ExecuteScalar().ToString());
                        if (revalidatedBalance != decimal.Parse(result.ToString()))
                        {

                            LogableTask.LogMonoActivityTask("balance revalidate", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "CCMS Balance : " + result.ToString() + " Revalidated Balance : " + revalidatedBalance.ToString()+ " for day " + Day.ToString() + " for atm: " + atm.Title);
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
                        cmd.CommandText = string.Format(@"select rep_datetime 
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


                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), Day.ToString("dd/MM/yyyy") + " 23:59:59");
                        decimal totalTrxnAmount = (decimal)cmd.ExecuteScalar();
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

                        cmd.CommandText = string.Format(@"select isnull(sum(amount),0)
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                    atm_id, DateTime.Parse(maxRepDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.ToString("dd/MM/yyyy") + " 23:59:59");
                        // object totalAmount = cmd.ExecuteScalar();


                        decimal revalidatedBalance = newBalance - decimal.Parse(cmd.ExecuteScalar().ToString());
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

                        cmd.CommandText = string.Format(@"select rep_datetime 
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



                        cmd.CommandText = string.Format(@"select sum(amount) 
                                                        from parsed_transaction
                where atm_id ={0} and trxn_datetime >= convert(datetime,'{1}',103) 
                and trxn_datetime <=convert(datetime,'{2}',103)",
                atm_id, DateTime.Parse(lastSummaryTrxnDate.ToString()).AddDays(1).ToString("dd/MM/yyyy"), dt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59");
                        decimal totalTrxnAmount = GetValue(cmd.ExecuteScalar());


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




}
