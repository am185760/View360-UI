using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServicesDAL;
using System.Configuration;

namespace Avanza.CCMS.Parser
{

    public class TestCash
    {
        public DateTime TestCashDateTime = new DateTime(1900, 1, 1);

        public int LastRemaining1 = 0;
        public int LastRemaining2 = 0;
        public int LastRemaining3 = 0;
        public int LastRemaining4 = 0;
        public int LastRemaining5 = 0;
        public int LastRemaining6 = 0;
        public int LastRemaining7 = 0;

        public int CurrentPurged1 = 0;
        public int CurrentPurged2 = 0;
        public int CurrentPurged3 = 0;
        public int CurrentPurged4 = 0;
        public int CurrentPurged5 = 0;
        public int CurrentPurged6 = 0;
        public int CurrentPurged7 = 0;

        public override string ToString()
        {
            //10/24/2010 17:43:05|TestCash|98|399|0|198|0|0|0|1|1|0|1|0|0|0

            return TestCashDateTime.ToString("MM/dd/yyyy HH:mm:ss") + "|TestCash|" + LastRemaining1.ToString() + "|" +
                LastRemaining2.ToString() + "|" + LastRemaining3.ToString() + "|" + LastRemaining4.ToString() + "|" +
                LastRemaining5.ToString() + "|" + LastRemaining6.ToString() + "|" + LastRemaining7.ToString() + "|" +
                CurrentPurged1.ToString() + "|" + CurrentPurged2.ToString() + "|" + CurrentPurged3.ToString() + "|" +
                CurrentPurged4.ToString() + "|" + CurrentPurged5.ToString() + "|" + CurrentPurged6.ToString() + "|" +
                CurrentPurged7.ToString();



        }
        public TestCash(string testCashChunk)
        {
            int index = 0;
            string[] parts = testCashChunk.Split('|');
            TestCashDateTime = DateTime.ParseExact(parts[index++], "MM/dd/yyyy HH:mm:ss", null);
            index++;
            LastRemaining1 = int.Parse(parts[index++]);
            LastRemaining2 = int.Parse(parts[index++]);
            LastRemaining3 = int.Parse(parts[index++]);
            LastRemaining4 = int.Parse(parts[index++]);
            LastRemaining5 = int.Parse(parts[index++]);
            LastRemaining6 = int.Parse(parts[index++]);
            LastRemaining7 = int.Parse(parts[index++]);


            CurrentPurged1 = int.Parse(parts[index++]);
            CurrentPurged2 = int.Parse(parts[index++]);
            CurrentPurged3 = int.Parse(parts[index++]);
            CurrentPurged4 = int.Parse(parts[index++]);
            CurrentPurged5 = int.Parse(parts[index++]);
            CurrentPurged6 = int.Parse(parts[index++]);
            CurrentPurged7 = int.Parse(parts[index++]);
        }








    }
    public class Parser
    {
        //Added on 2nd jul 2016.
        string disableForcefulRepExtraction = ConfigurationManager.AppSettings["disableForcefulRepExtraction"];
        //int denomMapping[] = {6401,6403,6404,14598,14599,14601};
        string[] denominationMapping = ConfigurationManager.AppSettings["denominationMapping"].Split(',');

        //string lastReplenishment = null;
        decimal minOperatingBalance = 0;
        public long ATMID = 0;

        //static List<DateTime> listNormalDays = Utility.GetEvents("Normal");
        //        private const string Version = "CCMS Parser 1.0  [ReleaseDate: May 25, 2010]";
        //        private const int CassetteCount = 7;
        //        private const string ParsingExpression = @"(?<Timestamp>[\d/: ]+)\|(?<Entry>(?:(?<EntryType>CashWithdrawal)\|(?<DispensedAmount>[\d]+)(?:\|(?<RemainingNotes>[\d]+)){7}(?:\|(?<DispensedNotes>[\d]+)){7}(?:\|(?<PurgedNotes>[\d]+)){7}(?:\|(?<Denomination>[\d]+)){7})|(?:(?<EntryType>CountsCleared)(?:\|(?<RemainingNotes>[\d]+)){7}(?:\|(?<DispensedNotes>[\d]+)){7}(?:\|(?<PurgedNotes>[\d]+)){7}(?:\|(?<Denomination>[\d]+)){7})|(?:(?<EntryType>AddCash)(?:\|(?<RemainingNotes>[\d]+)){7}(?:\|(?<AddedNotes>[\d]+)){7}(?:\|(?<Denomination>[\d]+)){7})|(?:(?<EntryType>CountsSet)\|(?<OrderId>[\d]+)(?:\|(?<RemainingNotes>[\d]+)){7}(?:\|(?<Denomination>[\d]+)){7})|(?:(?<EntryType>Replenishment)\|(?<Mode>[\w]+)\|(?<StartTime>[\d]+)\|(?<EndTime>[\d]+)\|(?<RemainingAmount>[\d]+)\|(?<DispensedAmount>[\d]+)\|(?<PurgedAmount>[\d]+)\|(?<ReplenishedAmount>[\d]+)))\r\n";

        //        public static void ParseAndSave(SqlConnection Connection, int ATMId, string FileData, int task_id)
        //        {
        //            Regex regex;
        //            MatchCollection matches;
        //            EntryTypes type;
        //            SqlTransaction transaction;
        //           // SqlCommand command;
        //            int[] lastdispensed;
        //            int[] lastpurged;
        //            int[] added;
        //            int? cashOrderID = null;
        //            lastdispensed = new int[CassetteCount];
        //            lastpurged = new int[CassetteCount];
        //            added = new int[CassetteCount];
        //            //Logger.StepInContext(string.Format("ParseAndSave::ATMId[{0}]", ATMId));
        //            regex = new Regex(ParsingExpression);
        //            transaction = Connection.BeginTransaction();
        //            //command = new SqlCommand("", Connection, transaction);
        //            string lastTrxn = null;
        //            matches = regex.Matches(FileData);

        //            foreach (Match match in matches)
        //            {

        //                type = (EntryTypes)Enum.Parse(typeof(EntryTypes), match.Groups["EntryType"].Value);
        //                switch (type)
        //                {
        //                    case EntryTypes.CashWithdrawal:

        //                        ParsedTransaction parsedTransaction = new ParsedTransaction();
        //                        parsedTransaction.AtmId = ATMId;
        //                        parsedTransaction.Amount = int.Parse(match.Groups["DispensedAmount"].Value);
        //                        parsedTransaction.TrxnDatetime = DateTime.ParseExact(match.Groups["Timestamp"].Value, "MM/dd/yyyy HH:mm:ss", null);
        //                        parsedTransaction.CashPurged1 = int.Parse(match.Groups["PurgedNotes"].Captures[0].Value);
        //                        parsedTransaction.CashPurged2 = int.Parse(match.Groups["PurgedNotes"].Captures[1].Value);
        //                        parsedTransaction.CashPurged3 = int.Parse(match.Groups["PurgedNotes"].Captures[2].Value);
        //                        parsedTransaction.CashPurged4 = int.Parse(match.Groups["PurgedNotes"].Captures[3].Value);
        //                        parsedTransaction.CashPurged5 = int.Parse(match.Groups["PurgedNotes"].Captures[4].Value);
        //                        parsedTransaction.CashPurged6 = int.Parse(match.Groups["PurgedNotes"].Captures[5].Value);
        //                        parsedTransaction.CashPurged7 = int.Parse(match.Groups["PurgedNotes"].Captures[6].Value);
        //                        parsedTransaction.TaskId = task_id;
        //                        parsedTransaction.Save(transaction.Connection, transaction);


        //                        //                        command.CommandText = string.Format(@"INSERT INTO parsed_transaction
        //                        //                            (atm_id, amount, trxn_datetime, cash_purged1, cash_purged2, cash_purged3, cash_purged4, 
        //                        //cash_purged5, cash_purged6, cash_purged7) VALUES({0}, {1}, CONVERT(DATETIME, '{2}', 120), {3}, {4}, {5}, {6},{7},{8},{9})", 
        //                        //                             ATMId, int.Parse(match.Groups["DispensedAmount"].Value), DateTime.ParseExact(match.Groups["Timestamp"].Value, 
        //                        //                             "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss"), 
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[0].Value), 
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[1].Value), 
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[2].Value), 
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[3].Value), 
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[4].Value),
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[5].Value),
        //                        //                             int.Parse(match.Groups["PurgedNotes"].Captures[6].Value));

        //                        //                        command.ExecuteNonQuery();
        //                        lastTrxn = match.Value;
        //                        break;

        //                    case EntryTypes.CountsCleared:
        //                        for (int i = 0; i < CassetteCount; i++)
        //                        {
        //                            lastdispensed[i] = int.Parse(match.Groups["DispensedNotes"].Captures[i].Value);
        //                            lastpurged[i] = int.Parse(match.Groups["PurgedNotes"].Captures[i].Value);
        //                            added[i] = 0;
        //                        }
        //                        break;

        //                    case EntryTypes.CountsSet:
        //                        cashOrderID =  int.Parse(match.Groups["OrderId"].Value);
        //                        for (int i = 0; i < CassetteCount; i++)
        //                        {
        //                            added[i] += int.Parse(match.Groups["RemainingNotes"].Captures[i].Value);
        //                        }
        //                        break;

        //                    case EntryTypes.AddCash:
        //                        for (int i = 0; i < CassetteCount; i++)
        //                        {
        //                            added[i] += int.Parse(match.Groups["AddedNotes"].Captures[i].Value);
        //                        }
        //                        break;

        //                    case EntryTypes.Replenishment:

        //                        Dispensed dispensed = new Dispensed();
        //                        dispensed.AtmId = ATMId;
        //                        dispensed.CashDispensed1 = lastdispensed[0];
        //                        dispensed.CashDispensed2 = lastdispensed[1];
        //                        dispensed.CashDispensed3 = lastdispensed[2];
        //                        dispensed.CashDispensed4 = lastdispensed[3];
        //                        dispensed.CashDispensed5 = lastdispensed[4];
        //                        dispensed.CashDispensed6 = lastdispensed[5];
        //                        dispensed.CashDispensed7 = lastdispensed[6];

        //                        dispensed.CashPurged1 = lastpurged[0];
        //                        dispensed.CashPurged2 = lastpurged[1];
        //                        dispensed.CashPurged3 = lastpurged[2];
        //                        dispensed.CashPurged4 = lastpurged[3];
        //                        dispensed.CashPurged5 = lastpurged[4];
        //                        dispensed.CashPurged6 = lastpurged[5];
        //                        dispensed.CashPurged7 = lastpurged[6];
        //                        dispensed.TaskId = task_id;
        //                        dispensed.ClearingDatetime = DateTime.ParseExact(match.Groups["Timestamp"].Value, "MM/dd/yyyy HH:mm:ss", null);
        //                        dispensed.Save(transaction.Connection, transaction);

        ////                        command.CommandText = string.Format(@"
        ////INSERT INTO dispensed(atm_id, cash_dispensed1, cash_dispensed2, cash_dispensed3, cash_dispensed4, cash_purged1, cash_purged2, cash_purged3,
        ////cash_purged4, clearing_datetime,cash_dispensed5,cash_dispensed6,cash_dispensed7,cash_purged5,cash_purged6,cash_purged7) 
        ////VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, CONVERT(DATETIME, '{9}', 120),{10},{11},{12},{13},{14},{15},{16})", 
        ////     ATMId, lastdispensed[0], lastdispensed[1], lastdispensed[2], lastdispensed[3], lastpurged[0], lastpurged[1], lastpurged[2], lastpurged[3], 
        ////  DateTime.ParseExact(match.Groups["Timestamp"].Value, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss"),
        ////  lastdispensed[4], lastdispensed[5], lastdispensed[6], lastpurged[4], lastpurged[5], lastpurged[6], task_id);




        //                        //command.ExecuteNonQuery();
        //                        Replenishment replenishment = new Replenishment();
        //                        replenishment.AtmId = ATMId;
        //                        replenishment.CashAdded1 = added[0];
        //                        replenishment.CashAdded2 = added[1];
        //                        replenishment.CashAdded3 = added[2];
        //                        replenishment.CashAdded4 = added[3];
        //                        replenishment.CashAdded5 = added[4];
        //                        replenishment.CashAdded6 = added[5];
        //                        replenishment.CashAdded7 = added[6];
        //                        replenishment.TaskId = task_id;
        //                        replenishment.CashOrderId = cashOrderID;
        //                        replenishment.RepDatetime = DateTime.ParseExact(match.Groups["Timestamp"].Value, "MM/dd/yyyy HH:mm:ss", null);
        //                        replenishment.RepStatus = match.Groups["Mode"].Value;
        //                        replenishment.Save(transaction.Connection, transaction);


        ////                        command.CommandText = string.Format(@"INSERT INTO replenishment(
        ////atm_id, cash_added1, cash_added2, cash_added3, cash_added4, rep_datetime, rep_status,cash_added5,cash_added6,cash_added7,task_id)
        ////VALUES({0}, {1}, {2}, {3}, {4}, CONVERT(DATETIME, '{5}', 120), '{6}',{7},{8},{9},{10})", 
        ////     ATMId, added[0], added[1], added[2], added[3], DateTime.ParseExact(match.Groups["Timestamp"].Value, "MM/dd/yyyy HH:mm:ss", 
        ////     CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss"), match.Groups["Mode"].Value, added[4], added[5], added[6], task_id);

        ////                        command.ExecuteNonQuery();


        //                        //lastdispensed = new int[CassetteCount];
        //                        //lastpurged = new int[CassetteCount];
        //                        //added = new int[CassetteCount];


        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }

        //            if (lastTrxn != null)
        //            {
        //                string[] parts = lastTrxn.Split('|');
        //                CashPosition cashPosition = CashPosition.LoadCashPosition("atm_id=" + ATMId);

        //                if (cashPosition == null)
        //                {
        //                    cashPosition = new CashPosition();
        //                    cashPosition.AtmId = ATMId;
        //                    cashPosition.LastTrxnAt = DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null);
        //                    cashPosition.Cassette1Notes = int.Parse(parts[3]) - int.Parse(parts[10]) - int.Parse(parts[17]);
        //                    cashPosition.Cassette2Notes = int.Parse(parts[4]) - int.Parse(parts[11]) - int.Parse(parts[18]);
        //                    cashPosition.Cassette3Notes = int.Parse(parts[5]) - int.Parse(parts[12]) - int.Parse(parts[19]);
        //                    cashPosition.Cassette4Notes = int.Parse(parts[6]) - int.Parse(parts[13]) - int.Parse(parts[20]);
        //                    cashPosition.Cassette5Notes = int.Parse(parts[7]) - int.Parse(parts[14]) - int.Parse(parts[21]);
        //                    cashPosition.Cassette6Notes = int.Parse(parts[8]) - int.Parse(parts[15]) - int.Parse(parts[22]);
        //                    cashPosition.Cassette7Notes = int.Parse(parts[9]) - int.Parse(parts[16]) - int.Parse(parts[23]);
        //                    cashPosition.TaskId = task_id;
        //                    cashPosition.Save(transaction.Connection, transaction);
        //                }
        //                else
        //                {
        //                    cashPosition.LastTrxnAt = DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null);
        //                    cashPosition.Cassette1Notes = int.Parse(parts[3]) - int.Parse(parts[10]) - int.Parse(parts[17]);
        //                    cashPosition.Cassette2Notes = int.Parse(parts[4]) - int.Parse(parts[11]) - int.Parse(parts[18]);
        //                    cashPosition.Cassette3Notes = int.Parse(parts[5]) - int.Parse(parts[12]) - int.Parse(parts[19]);
        //                    cashPosition.Cassette4Notes = int.Parse(parts[6]) - int.Parse(parts[13]) - int.Parse(parts[20]);
        //                    cashPosition.Cassette5Notes = int.Parse(parts[7]) - int.Parse(parts[14]) - int.Parse(parts[21]);
        //                    cashPosition.Cassette6Notes = int.Parse(parts[8]) - int.Parse(parts[15]) - int.Parse(parts[22]);
        //                    cashPosition.Cassette7Notes = int.Parse(parts[9]) - int.Parse(parts[16]) - int.Parse(parts[23]);
        //                    cashPosition.TaskId = task_id;
        //                    cashPosition.Save(transaction.Connection, transaction);
        //                }
        //                //update cash position

        //            }
        //            transaction.Commit();
        //        }


        private string GetDenominationDetail(string denominationDetail, int denomType1, int denomType2, int denomType3, int denomType4, int denomType5, int denomType6)
        {
            string[] detailParts = denominationDetail.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Hashtable ht = new Hashtable();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < detailParts.Length - 1; i++)
            {
                string[] detailSubParts = detailParts[i].Split('*');

                if (!ht.Contains(detailSubParts[0]))
                    ht.Add(detailSubParts[0], detailSubParts[1]);

                int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                if (int.Parse(denominationMapping[idx]) == 1)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType1;
                else if (int.Parse(denominationMapping[idx]) == 2)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType2;
                else if (int.Parse(denominationMapping[idx]) == 3)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType3;
                else if (int.Parse(denominationMapping[idx]) == 4)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType4;
                else if (int.Parse(denominationMapping[idx]) == 5)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType5;
                else if (int.Parse(denominationMapping[idx]) == 6)
                    ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + denomType6;
            }
            decimal total = 0;
            for (int i = 0; i < denominationMapping.Length; i++)
            {
                if (ht.ContainsKey(denominationMapping[i]))
                {
                    builder.Append(denominationMapping[i] + "*" + ht[denominationMapping[i]] + "\r\n");
                    total += int.Parse(denominationMapping[i]) * int.Parse(ht[denominationMapping[i]].ToString());
                }
            }
            builder.Append("=" + total);
            return builder.ToString();
        }
        private Replenishment SaveReplenishment(string[] subParts, SqlTransaction trxn, int taskID, int atmID, bool isSwap)
        {

            int j = 0;
            Replenishment replenishment = new Replenishment();
            replenishment.AtmId = atmID;
            replenishment.RepDatetime = DateTime.ParseExact(subParts[j++], "MM/dd/yyyy HH:mm:ss", null);
            j++;
            replenishment.CashAdded1 = int.Parse(subParts[j++]);
            replenishment.CashAdded2 = int.Parse(subParts[j++]);
            replenishment.CashAdded3 = int.Parse(subParts[j++]);
            replenishment.CashAdded4 = int.Parse(subParts[j++]);
            replenishment.CashAdded5 = int.Parse(subParts[j++]);
            replenishment.CashAdded6 = int.Parse(subParts[j++]);
            replenishment.CashAdded7 = int.Parse(subParts[j++]);
            replenishment.RepStatus = "Dummy";
            replenishment.TaskId = taskID;
            replenishment.IsSwap = isSwap;
            replenishment.Save();

            // 
            SaveReplenishmentPurgedCounts(subParts, trxn, taskID, j, replenishment);
            return replenishment;
        }

        private void SaveReplenishmentPurgedCounts(string[] subParts, SqlTransaction trxn,
            int taskID, int j, Replenishment replenishment)
        {
            TestCashPurgedNotes testCashPurgedNotes = new TestCashPurgedNotes();
            testCashPurgedNotes.ReplenishmentId = replenishment.ReplenishmentId;
            testCashPurgedNotes.TaskId = taskID;
            testCashPurgedNotes.TestCashDatetime = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);//replenishment.RepDatetime;
            testCashPurgedNotes.CashPurged1 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged2 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged3 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged4 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged5 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged6 = int.Parse(subParts[j++]);
            testCashPurgedNotes.CashPurged7 = int.Parse(subParts[j++]);
            testCashPurgedNotes.AtmId = ATMID;
            testCashPurgedNotes.Save();

        }

        DataTable ExecuteStoredProcedure(string storedProcedureName, string whereClause, int functionID, SqlTransaction trxn)
        {
            SqlCommand cmd = null;

            if (trxn != null)
            {
                cmd = trxn.Connection.CreateCommand();
                cmd.Transaction = trxn;
            }
            else
                cmd = ConnectionFactory.GetNewCommand(false, DatabaseName.Cash);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
            cmd.CommandTimeout = 300;
            cmd.Parameters.Add("whereClause", SqlDbType.VarChar);
            cmd.Parameters[0].Value = whereClause;

            if (functionID > 0)
            {
                cmd.Parameters.Add("functionID", SqlDbType.Int);
                //cmd.Parameters.Add("functionID", functionID);
                cmd.Parameters[1].Value = functionID;

            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }



        private bool CheckForDuplicates(string storedProcedureName, string criteria)
        {
            bool isExists = false;
            DataTable result = ExecuteStoredProcedure(storedProcedureName, criteria, 2, null);
            if (result != null)
            {
                if (int.Parse(result.Rows[0][0].ToString()) > 0)
                    isExists = true;
            }
            return isExists;
        }

        public void ParseAndSave(SqlTransaction trxn, long ATMId, string counterFile, long taskID)
        {

            bool isReplenishmentExpected = false;
            LogableTask task = LogableTask.NewTask("Parsing");
            ParsedTransaction parsedTransaction = null;
            
            Replenishment replenishment = null;
            
            //CpmCountsCleared cpmCountsCleared = null;
            //ParsedCpmCounter parsedCpmCounter = null;
            BnaCountsCleared bnaCountsCleared = null;
            ParsedBnaCounter parsedBnaCounter = null;
            TestCashPurgedNotes testCashPurgedNotes = null;

            List<ParsedTransaction> listParsedTrxns = new List<ParsedTransaction>();
            
            // 24_07_26 commented by Jabbar - Rep to be save by EjParser only // List<Replenishment> listReplenishment = new List<Replenishment>();

            //List<CpmCountsCleared> listCpmCountsCleared = new List<CpmCountsCleared>();
            //List<ParsedCpmCounter> listparsedCpmCounter = new List<ParsedCpmCounter>();
            List<BnaCountsCleared> listBNACountsCleared = new List<BnaCountsCleared>();
            List<ParsedBnaCounter> listParsedBnaCounter = new List<ParsedBnaCounter>();
            List<TestCashPurgedNotes> listTestCashPurgedNotes = new List<TestCashPurgedNotes>();


            List<ParserPostProcessingTask> testCashPostProcessingQueue = new List<ParserPostProcessingTask>();
            List<ParserPostProcessingTask> parsedTrxnsPostProcessingQueue = new List<ParserPostProcessingTask>();
            List<ParserPostProcessingTask> replenishmentPostProcessingQueue = new List<ParserPostProcessingTask>();

            List<ParserPostProcessingTask> cpmCountsClearedQueue = new List<ParserPostProcessingTask>();
            List<ParserPostProcessingTask> bnaCountsClearedQueue = new List<ParserPostProcessingTask>();
            List<ParserPostProcessingTask> depositPositionQueue = new List<ParserPostProcessingTask>();


            ATMID = ATMId;
            string[] parts = null, subParts = null;
            decimal dispensedAmount = 0;
            parts = counterFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //bool isOutOfCashAlertGenerated = false;
            //bool isOutOfCashAlertResolved = false;
            //bool isLowBalanceAlertResolved = false;
            //bool isLowBalanceAlertGenerated = false;
            int j = 0;
            int k = 0;
            //bool replenishmentExpected = false;
            //bool isADDCashFoundFirstTime = false;
            int sumOfAlreadyExistingNotes = 0;
            string currentCassetteStatus = null;
            string currentBNAStatus = null;
            string currentCPMStatus = null;
            int[] notesAdded = new int[7];
            bool isSwap = false;
            // string currentEntry = null;
            DateTime lastProcessedRecordDateTime = DateTime.Now;
            Atm ATM = Atm.LoadAtmByPk(ATMID);
            AppSetting appSetting = AppSetting.LoadAppSetting("1=1");

            NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(ATM.NoteSetTypeId);
            int[] denominations = { noteSetType.DenominationType1.Value,noteSetType.DenominationType2.Value,noteSetType.DenominationType3.Value,
                        noteSetType.DenominationType4.Value,0,0,0};
            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    subParts = parts[i].Replace('\0', ' ').Trim().Split('|');

                    if (subParts[1] == "BillDispenserSummary" || subParts[1] == "DepositSummary" || subParts[1] == "DepositSummaryAfterModeChanged" ||
                        subParts[1] == "EODBalance" || subParts[1] == "BillEODBalance" || subParts[1] == "BNAEODBalance")
                    {

                        //CcmsAtmLog ccmsAtmLog = new CcmsAtmLog();

                        //ccmsAtmLog.TaskId = taskID;
                        //ccmsAtmLog.ProcessingDatetime = DateTime.Now;
                        //ccmsAtmLog.AtmId = taskID;
                        //ccmsAtmLog.EventName = subParts[1];
                        //ccmsAtmLog.EventInfo = parts[i];
                        //ccmsAtmLog.Save();
                    }
                    //if (subParts[1] != "AddCash" && isReplenishmentExpected)
                    //{
                    //    if (disableForcefulRepExtraction == "1")
                    //    {
                    //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because disableForcefulRepExtraction is set to 1");
                    //        continue;
                    //    }



                    //    if (CheckForDuplicates("GetReplenishmentRow", string.Format("rep_datetime>=convert(datetime,'{0}:00:00',101) and rep_datetime<=convert(datetime,'{2}:59:59',101)  and atm_id={1} and cash_added1={3} and cash_added2={4} and cash_added3={5} and cash_added4={6}",
                    //              DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).AddMinutes(-20).ToString("MM/dd/yyyy HH"), ATMID, DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("MM/dd/yyyy HH"), notesAdded[0], notesAdded[1], notesAdded[2], notesAdded[3])))
                    //    {
                    //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Replenishment table");
                    //        continue;
                    //    }


                    //    if (notesAdded[0] <= 0 && notesAdded[1] <= 0 && notesAdded[2] <= 0 && notesAdded[3] <= 0)
                    //    {
                    //        LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Ignoring this replenishment reported by agent" + parts[i]);
                    //        continue;
                    //    }



                    //    replenishment = new Replenishment();
                    //    replenishment.AtmId = ATMID;
                    //    replenishment.RepDatetime = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                    //   // replenishment.CashAdded1 = int.Parse(subParts[j++]);


                    //    replenishment.CashAdded1 = notesAdded[0];
                    //    replenishment.CashAdded1 = MakeNumberDivisibleBy50(replenishment.CashAdded1);

                    //    replenishment.CashAdded2 = notesAdded[1];
                    //    replenishment.CashAdded2 = MakeNumberDivisibleBy50(replenishment.CashAdded2);

                    //    replenishment.CashAdded3 = notesAdded[2];
                    //    replenishment.CashAdded3 = MakeNumberDivisibleBy50(replenishment.CashAdded3);

                    //    replenishment.CashAdded4 = notesAdded[3];
                    //    replenishment.CashAdded4 = MakeNumberDivisibleBy50(replenishment.CashAdded4);



                    //    replenishment.RepStatus = isSwap?"OrderMissing":"AddCash";
                    //    replenishment.TaskId = taskID;
                    //    replenishment.CashOrderId = -1;
                    //    //Handling Rep Status...
                    //    //replenishment.IsSwap = false;

                    //    if (ATM.IsSwapDefaultReplenishment.Value)
                    //    {
                    //        replenishment.IsSwap = true;
                    //        //Change done on 15/12 for QIB.
                    //        //if (replenishment.RepStatus.Contains("Add"))
                    //        //    replenishment.IsSwap = false;
                    //    }
                    //    else
                    //    {
                    //        if (replenishment.RepStatus.Contains("Add"))
                    //        {
                    //            //replenishment.IsSwap = false;
                    //            replenishment.IsSwap = isSwap;
                    //            //Read swap / test decision based on server side..
                    //            ///server side will ensure it bases on ADD CASH LINE
                    //        }
                    //        else
                    //        {
                    //            if (replenishment.RepStatus == "Reboot" || replenishment.RepStatus == "ReplenishmentWithoutTestCash")
                    //            {
                    //                //         isSuspected = true;
                    //                if (subParts[subParts.Length - 1] == "Add")
                    //                    replenishment.IsSwap = false;
                    //                else
                    //                    replenishment.IsSwap = true;
                    //            }
                    //            else
                    //                replenishment.IsSwap = true;
                    //        }
                    //    }
                    //    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //    //Change done for CIB on 05/02/2015
                    //    //If notes are added in all cassettes this means its swap...
                    //    //***********************************************************************************************************************//
                    //    if (!replenishment.IsSwap)
                    //    {
                    //        if (replenishment.CashAdded1 > 0 && replenishment.CashAdded2 > 0 && replenishment.CashAdded3 > 0 && replenishment.CashAdded4 > 0)
                    //            replenishment.IsSwap = true;
                    //    }
                    //    //***********************************************************************************************************************//
                    //    decimal replenishedAmount = (decimal)(replenishment.CashAdded1 * ATM.Cassette1Denomination +
                    //        replenishment.CashAdded2 * ATM.Cassette2Denomination +
                    //        replenishment.CashAdded3 * ATM.Cassette3Denomination +
                    //        replenishment.CashAdded4 * ATM.Cassette4Denomination +
                    //        replenishment.CashAdded5 * ATM.Cassette5Denomination +
                    //        replenishment.CashAdded6 * ATM.Cassette6Denomination +
                    //        replenishment.CashAdded7 * ATM.Cassette7Denomination);


                    //    replenishment.GeneratedAt = DateTime.Now;
                    //    replenishment.GeneratedBy = 1;
                    //    replenishment.IsUpdated = false;

                    //    listReplenishment.Add(replenishment);

                    //    ParserPostProcessingTask parserPostProcessingTask = new DAL.ParserPostProcessingTask();
                    //    parserPostProcessingTask.AtmId = ATM.ATMId;
                    //    parserPostProcessingTask.CreationTime = DateTime.Now;
                    //    parserPostProcessingTask.EntityId = replenishment.ReplenishmentId;
                    //    parserPostProcessingTask.EventInfo = parts[i];
                    //    parserPostProcessingTask.EventOccuredAt = replenishment.RepDatetime;
                    //    parserPostProcessingTask.EventType = subParts[1];
                    //    parserPostProcessingTask.TaskId = taskID;
                    //    //parserPostProcessingTask.Save();
                    //    replenishmentPostProcessingQueue.Add(parserPostProcessingTask);
                    //    isReplenishmentExpected = false;
                    //}//

                    #region CPMMismatch
                    if (subParts[1] == "CPMMismatch")
                    {
                        int lastPkt1Count = int.Parse(subParts[4]);
                        int lastPkt2Count = int.Parse(subParts[5]);
                        int lastPkt3Count = int.Parse(subParts[6]);
                        int currentPkt1Count = int.Parse(subParts[7]);
                        int currentPkt2Count = int.Parse(subParts[8]);
                        int currentPkt3Count = int.Parse(subParts[9]);

                        if (lastPkt1Count < 0)
                            lastPkt1Count = 0;

                        if (lastPkt2Count < 0)
                            lastPkt2Count = 0;

                        if (lastPkt3Count < 0)
                            lastPkt3Count = 0;

                        if (currentPkt1Count < 0)
                            currentPkt1Count = 0;

                        if (currentPkt2Count < 0)
                            currentPkt2Count = 0;

                        if (currentPkt3Count < 0)
                            currentPkt3Count = 0;

                        if (currentPkt1Count == 0 && currentPkt2Count == 0 && currentPkt3Count == 0)
                        {
                            if (lastPkt1Count > 0 || lastPkt2Count > 0 || lastPkt3Count > 0)
                            {
                                if (CheckForDuplicates("GetCpmCountsCleared", string.Format("counts_cleared_at=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID)))
                                {
                                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Cpm_Counts_Cleared table");
                                    continue;
                                }

                                DepositPosition depositPosition = DepositPosition.LoadDepositPosition("atm_id=" + ATMID);
                                if (depositPosition == null)
                                    depositPosition = new DepositPosition();

                                //depositPosition.LastCpmDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                                depositPosition.AtmId = ATMId;
                                depositPosition.Bin1 = 0;
                                depositPosition.Bin2 = 0;
                                depositPosition.Bin3 = 0;
                                depositPosition.Bin4 = 0;

                                //"04/07/2011 19:43:03|ChequeDeposit|0|2|0|0|1|0
                                depositPosition.Save(trxn.Connection, trxn);
                                //cpmCountsCleared = new CpmCountsCleared();
                                //cpmCountsCleared.AtmId = ATMId;
                                //cpmCountsCleared.CountsClearedAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                                //cpmCountsCleared.RecordedAt = DateTime.Now;
                                //listCpmCountsCleared.Add(cpmCountsCleared);
                                //cpmCountsCleared.Save(trxn.Connection, trxn);


                            }

                        }
                        else if (currentPkt1Count > lastPkt1Count || currentPkt2Count > lastPkt2Count || currentPkt3Count > lastPkt3Count)
                        {

                            if (CheckForDuplicates("GetParsedCpmCounter", string.Format("deposit_at=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID)))
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Cpm_Counter table");
                                continue;
                            }
                            //parsedCpmCounter = new ParsedCpmCounter();
                            //parsedCpmCounter.DepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                            //j = 5;

                            //if (currentPkt1Count > lastPkt1Count)
                            //    parsedCpmCounter.Bin1 = currentPkt1Count - lastPkt1Count;
                            //else
                            //    parsedCpmCounter.Bin1 = 0;

                            //if (currentPkt2Count > lastPkt2Count)
                            //    parsedCpmCounter.Bin2 = currentPkt2Count - lastPkt2Count;
                            //else
                            //    parsedCpmCounter.Bin2 = 0;

                            //if (currentPkt3Count > lastPkt3Count)
                            //    parsedCpmCounter.Bin3 = currentPkt3Count - lastPkt3Count;
                            //else
                            //    parsedCpmCounter.Bin3 = 0;

                            //parsedCpmCounter.Bin4 = 0;
                            //parsedCpmCounter.AtmId = ATMID;
                            //parsedCpmCounter.TaskId = taskID;
                            ////parsedCpmCounter.Save(trxn.Connection, trxn);
                            //listparsedCpmCounter.Add(parsedCpmCounter);
                            //currentCPMStatus = subParts[0] + "|ChequeDeposit|0|0|0|" + parsedCpmCounter.Bin1 + "|" + parsedCpmCounter.Bin2 + "|" + parsedCpmCounter.Bin3;
                            ////07/02/2012 11:44:50|ChequeDeposit|0|0|0|1|0|0

                        }
                    }
                    #endregion
                    #region CPMCountsCleared
                    else if (subParts[1] == "CPMCountsCleared")
                    {
                        if (CheckForDuplicates("GetCpmCountsCleared", string.Format("counts_cleared_at=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID)))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Cpm_Counts_Cleared table");
                            continue;
                        }


                        DepositPosition depositPosition = DepositPosition.LoadDepositPosition("atm_id=" + ATMID);
                        if (depositPosition == null)
                            depositPosition = new DepositPosition();

                        //depositPosition.LastCpmDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                        depositPosition.AtmId = ATMId;
                        depositPosition.Bin1 = 0;
                        depositPosition.Bin2 = 0;
                        depositPosition.Bin3 = 0;
                        depositPosition.Bin4 = 0;

                        //"04/07/2011 19:43:03|ChequeDeposit|0|2|0|0|1|0
                        depositPosition.Save(trxn.Connection, trxn);
                        //cpmCountsCleared = new CpmCountsCleared();
                        //cpmCountsCleared.AtmId = ATMId;
                        //cpmCountsCleared.CountsClearedAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                        //cpmCountsCleared.RecordedAt = DateTime.Now;
                        ////cpmCountsCleared.Save(trxn.Connection, trxn);
                        //listCpmCountsCleared.Add(cpmCountsCleared);



                        //ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                        //parserPostProcessingTask.AtmId = ATM.ATMId;
                        //parserPostProcessingTask.CreationTime = DateTime.Now;
                        ////parserPostProcessingTask.EntityId = testCashPurgedNotes.TestCashPurgedNotesId;
                        //parserPostProcessingTask.EventInfo = parts[i];
                        //parserPostProcessingTask.EventOccuredAt = cpmCountsCleared.CountsClearedAt;
                        //parserPostProcessingTask.EventType = subParts[1];
                        //parserPostProcessingTask.TaskId = taskID;
                        //cpmCountsClearedQueue.Add(parserPostProcessingTask);
                        ////AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=17 and atm_id=" + ATMID + " and resolve_at is null");
                        //if (atmAlert != null)
                        //{
                        //    atmAlert.ResolveAt = DateTime.Now;
                        //    atmAlert.Save(trxn.Connection, trxn);
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "CPM Threshold alert resolved from atm = " + ATMID);
                        //}
                    }
                    #endregion
                    #region BNACountsCleared

                    else if (subParts[1] == "BNACountsCleared" || subParts[1] == "BillCountsCleared")
                    {
                        if (CheckForDuplicates("GetBnaCountsCleared", string.Format("counts_cleared_at>=convert(datetime,'{0}:00',101) and counts_cleared_at<=convert(datetime,'{0}:59',101) and atm_id={1}", DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("MM/dd/yyyy HH:mm"), ATMID)))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in BNA_Counts_Cleared table");
                            continue;
                        }
                        //if (appSetting.IsDuplicateCheckingEnabled.Value)
                        //{

                        //    BnaCountsCleared existingBNACountsCleared = BnaCountsCleared.LoadBnaCountsCleared(
                        //     );

                        //    if (existingBNACountsCleared != null)
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in BNA_Counts_Cleared table");
                        //        continue;
                        //    }

                        //}
                        DepositPosition depositPosition = DepositPosition.LoadDepositPosition("atm_id=" + ATMID);
                        if (depositPosition == null)
                            depositPosition = new DepositPosition();

                        depositPosition.AtmId = ATMId;
                        depositPosition.Cassette1Deposit = 0;
                        depositPosition.Cassette2Deposit = 0;
                        depositPosition.Cassette3Deposit = 0;
                        depositPosition.Cassette4Deposit = 0;
                        depositPosition.Cassette1DepositValue = "";
                        depositPosition.Cassette2DepositValue = "";
                        depositPosition.Cassette3DepositValue = "";
                        depositPosition.Cassette4DepositValue = "";
                        depositPosition.PurgeDepositValue = "";

                        depositPosition.PurgeDeposit = 0;

                        depositPosition.Save();

                        bnaCountsCleared = new BnaCountsCleared();
                        bnaCountsCleared.AtmId = ATMId;
                        bnaCountsCleared.CountsClearedAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                        bnaCountsCleared.RecordedAt = DateTime.Now;
                        bnaCountsCleared.TaskId = taskID;
                        listBNACountsCleared.Add(bnaCountsCleared);
                        //bnaCountsCleared.Save(trxn.Connection, trxn);

                        ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                        parserPostProcessingTask.AtmId = ATM.ATMId;
                        parserPostProcessingTask.CreationTime = DateTime.Now;
                        //parserPostProcessingTask.EntityId = testCashPurgedNotes.TestCashPurgedNotesId;
                        parserPostProcessingTask.EventInfo = parts[i];
                        parserPostProcessingTask.EventOccuredAt = bnaCountsCleared.CountsClearedAt;
                        parserPostProcessingTask.EventType = subParts[1];
                        parserPostProcessingTask.TaskId = taskID;
                        bnaCountsClearedQueue.Add(parserPostProcessingTask);


                        //AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=18 and atm_id=" + ATMID + " and resolve_at is null");
                        //if (atmAlert != null)
                        //{
                        //    atmAlert.ResolveAt = DateTime.Now;
                        //    atmAlert.Save(trxn.Connection, trxn);
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "BNA Threshold alert resolved from atm = " + ATMID);
                        //}


                    }
                    #endregion
                    #region CashDeposit
                    else if (subParts[1] == "CashDeposit" || subParts[1] == "CashDepositWithRetract")
                    {
                        if (CheckForDuplicates("GetParsedBnaCounter", string.Format("last_deposit_at>=convert(datetime,'{0}:00',101) and last_deposit_at<=convert(datetime,'{0}:59',101)  and atm_id={1}", DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("MM/dd/yyyy HH:mm"), ATMID)))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Bna_Counter table");
                            continue;
                        }

                        //if (appSetting.IsDuplicateCheckingEnabled.Value)
                        //{
                        //    ParsedBnaCounter existingBNACounter = ParsedBnaCounter.LoadParsedBnaCounter(
                        //    );

                        //    if (existingBNACounter != null)
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Bna_Counter table");
                        //        continue;
                        //    }
                        //}

                        parsedBnaCounter = new ParsedBnaCounter();
                        StringBuilder builderDenominationDetail = new StringBuilder();
                        parsedBnaCounter.LastDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);

                        j = 252;
                        #region BNA Cassette 1

                        parsedBnaCounter.Cassette1Counter1 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter2 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter3 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter4 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter5 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter6 = int.Parse(subParts[j++]);

                        if (denominationMapping.Length > 1)
                            parsedBnaCounter.Cassette1DenominationDetail =
                            denominationMapping[0] + "*" + parsedBnaCounter.Cassette1Counter1 + "<br>" +
                            denominationMapping[1] + "*" + parsedBnaCounter.Cassette1Counter2 + "<br>" +
                            denominationMapping[2] + "*" + parsedBnaCounter.Cassette1Counter3 + "<br>" +
                            denominationMapping[3] + "*" + parsedBnaCounter.Cassette1Counter4 + "<br>" +
                            denominationMapping[4] + "*" + parsedBnaCounter.Cassette1Counter5 + "<br>" +
                            denominationMapping[5] + "*" + parsedBnaCounter.Cassette1Counter6 + "<br>" +
                            "=" + (int.Parse(denominationMapping[0]) * parsedBnaCounter.Cassette1Counter1 +
                                    int.Parse(denominationMapping[1]) * parsedBnaCounter.Cassette1Counter2 +
                                    int.Parse(denominationMapping[2]) * parsedBnaCounter.Cassette1Counter3 +
                                    int.Parse(denominationMapping[3]) * parsedBnaCounter.Cassette1Counter4 +
                                    int.Parse(denominationMapping[4]) * parsedBnaCounter.Cassette1Counter5 +
                                    int.Parse(denominationMapping[5]) * parsedBnaCounter.Cassette1Counter6).ToString();


                        parsedBnaCounter.Cassette1Counter7 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter8 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter9 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter10 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter11 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter12 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter13 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter14 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter15 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter16 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter17 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter18 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter19 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter20 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter21 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter22 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter23 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter24 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter25 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter26 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter27 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter28 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter29 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter30 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter31 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter32 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter33 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter34 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter35 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter36 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter37 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter38 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter39 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter40 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter41 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter42 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter43 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter44 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter45 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter46 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter47 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter48 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter49 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette1Counter50 = int.Parse(subParts[j++]);

                        #endregion
                        #region BNA Cassette 2






                        builderDenominationDetail = new StringBuilder();
                        parsedBnaCounter.Cassette2Counter1 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette2Counter2 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette2Counter3 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette2Counter4 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette2Counter5 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette2Counter6 = int.Parse(subParts[j++]);


                        if (denominationMapping.Length > 1)
                            parsedBnaCounter.Cassette2DenominationDetail =
                                denominationMapping[0] + "*" + parsedBnaCounter.Cassette2Counter1 + "<br>" +
                                denominationMapping[1] + "*" + parsedBnaCounter.Cassette2Counter2 + "<br>" +
                                denominationMapping[2] + "*" + parsedBnaCounter.Cassette2Counter3 + "<br>" +
                                denominationMapping[3] + "*" + parsedBnaCounter.Cassette2Counter4 + "<br>" +
                                denominationMapping[4] + "*" + parsedBnaCounter.Cassette2Counter5 + "<br>" +
                                denominationMapping[5] + "*" + parsedBnaCounter.Cassette2Counter6 + "<br>" +
                                "=" + (int.Parse(denominationMapping[0]) * parsedBnaCounter.Cassette2Counter1 +
                                        int.Parse(denominationMapping[1]) * parsedBnaCounter.Cassette2Counter2 +
                                        int.Parse(denominationMapping[2]) * parsedBnaCounter.Cassette2Counter3 +
                                        int.Parse(denominationMapping[3]) * parsedBnaCounter.Cassette2Counter4 +
                                        int.Parse(denominationMapping[4]) * parsedBnaCounter.Cassette2Counter5 +
                                        int.Parse(denominationMapping[5]) * parsedBnaCounter.Cassette2Counter6).ToString();

                        parsedBnaCounter.Cassette2Counter7 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter8 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter9 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter10 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter11 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter12 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter13 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter14 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter15 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter16 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter17 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter18 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter19 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter20 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter21 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter22 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter23 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter24 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter25 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter26 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter27 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter28 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter29 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter30 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter31 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter32 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter33 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter34 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter35 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter36 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter37 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter38 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter39 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter40 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter41 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter42 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter43 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter44 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter45 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter46 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter47 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter48 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter49 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette2Counter50 = int.Parse(subParts[j++]);

                        #endregion

                        #region BNA Cassette 3
                        builderDenominationDetail = new StringBuilder();

                        parsedBnaCounter.Cassette3Counter1 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette3Counter2 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette3Counter3 = int.Parse(subParts[j++]);

                        parsedBnaCounter.Cassette3Counter4 = int.Parse(subParts[j++]);

                        parsedBnaCounter.Cassette3Counter5 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette3Counter6 = int.Parse(subParts[j++]);

                        if (denominationMapping.Length > 1)
                            parsedBnaCounter.Cassette3DenominationDetail =
                                  denominationMapping[0] + "*" + parsedBnaCounter.Cassette3Counter1 + "<br>" +
                                  denominationMapping[1] + "*" + parsedBnaCounter.Cassette3Counter2 + "<br>" +
                                  denominationMapping[2] + "*" + parsedBnaCounter.Cassette3Counter3 + "<br>" +
                                  denominationMapping[3] + "*" + parsedBnaCounter.Cassette3Counter4 + "<br>" +
                                  denominationMapping[4] + "*" + parsedBnaCounter.Cassette3Counter5 + "<br>" +
                                  denominationMapping[5] + "*" + parsedBnaCounter.Cassette3Counter6 + "<br>" +
                                  "=" + (int.Parse(denominationMapping[0]) * parsedBnaCounter.Cassette3Counter1 +
                                          int.Parse(denominationMapping[1]) * parsedBnaCounter.Cassette3Counter2 +
                                          int.Parse(denominationMapping[2]) * parsedBnaCounter.Cassette3Counter3 +
                                          int.Parse(denominationMapping[3]) * parsedBnaCounter.Cassette3Counter4 +
                                          int.Parse(denominationMapping[4]) * parsedBnaCounter.Cassette3Counter5 +
                                          int.Parse(denominationMapping[5]) * parsedBnaCounter.Cassette3Counter6).ToString();

                        parsedBnaCounter.Cassette3Counter7 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter8 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter9 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter10 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter11 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter12 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter13 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter14 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter15 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter16 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter17 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter18 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter19 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter20 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter21 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter22 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter23 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter24 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter25 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter26 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter27 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter28 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter29 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter30 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter31 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter32 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter33 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter34 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter35 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter36 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter37 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter38 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter39 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter40 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter41 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter42 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter43 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter44 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter45 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter46 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter47 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter48 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter49 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette3Counter50 = int.Parse(subParts[j++]);

                        #endregion


                        #region BNA Cassette 4
                        builderDenominationDetail = new StringBuilder();

                        parsedBnaCounter.Cassette4Counter1 = int.Parse(subParts[j++]);

                        parsedBnaCounter.Cassette4Counter2 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette4Counter3 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette4Counter4 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette4Counter5 = int.Parse(subParts[j++]);


                        parsedBnaCounter.Cassette4Counter6 = int.Parse(subParts[j++]);

                        if (denominationMapping.Length > 1)

                            parsedBnaCounter.Cassette4DenominationDetail =
                           denominationMapping[0] + "*" + parsedBnaCounter.Cassette4Counter1 + "<br>" +
                           denominationMapping[1] + "*" + parsedBnaCounter.Cassette4Counter2 + "<br>" +
                           denominationMapping[2] + "*" + parsedBnaCounter.Cassette4Counter3 + "<br>" +
                           denominationMapping[3] + "*" + parsedBnaCounter.Cassette4Counter4 + "<br>" +
                           denominationMapping[4] + "*" + parsedBnaCounter.Cassette4Counter5 + "<br>" +
                           denominationMapping[5] + "*" + parsedBnaCounter.Cassette4Counter6 + "<br>" +
                           "=" + (int.Parse(denominationMapping[0]) * parsedBnaCounter.Cassette4Counter1 +
                                   int.Parse(denominationMapping[1]) * parsedBnaCounter.Cassette4Counter2 +
                                   int.Parse(denominationMapping[2]) * parsedBnaCounter.Cassette4Counter3 +
                                   int.Parse(denominationMapping[3]) * parsedBnaCounter.Cassette4Counter4 +
                                   int.Parse(denominationMapping[4]) * parsedBnaCounter.Cassette4Counter5 +
                                   int.Parse(denominationMapping[5]) * parsedBnaCounter.Cassette4Counter6).ToString();

                        parsedBnaCounter.Cassette4Counter7 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter8 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter9 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter10 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter11 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter12 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter13 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter14 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter15 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter16 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter17 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter18 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter19 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter20 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter21 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter22 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter23 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter24 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter25 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter26 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter27 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter28 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter29 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter30 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter31 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter32 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter33 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter34 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter35 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter36 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter37 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter38 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter39 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter40 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter41 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter42 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter43 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter44 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter45 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter46 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter47 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter48 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter49 = int.Parse(subParts[j++]);
                        parsedBnaCounter.Cassette4Counter50 = int.Parse(subParts[j++]);

                        #endregion


                        #region BNA Purge Bin
                        builderDenominationDetail = new StringBuilder();

                        parsedBnaCounter.PurgeCounter1 = int.Parse(subParts[j++]);


                        parsedBnaCounter.PurgeCounter2 = int.Parse(subParts[j++]);


                        parsedBnaCounter.PurgeCounter3 = int.Parse(subParts[j++]);


                        parsedBnaCounter.PurgeCounter4 = int.Parse(subParts[j++]);


                        parsedBnaCounter.PurgeCounter5 = int.Parse(subParts[j++]);


                        parsedBnaCounter.PurgeCounter6 = int.Parse(subParts[j++]);

                        if (denominationMapping.Length > 1)

                            parsedBnaCounter.PurgeDenominationDetail =
                            denominationMapping[0] + "*" + parsedBnaCounter.PurgeCounter1 + "<br>" +
                            denominationMapping[1] + "*" + parsedBnaCounter.PurgeCounter2 + "<br>" +
                            denominationMapping[2] + "*" + parsedBnaCounter.PurgeCounter3 + "<br>" +
                            denominationMapping[3] + "*" + parsedBnaCounter.PurgeCounter4 + "<br>" +
                            denominationMapping[4] + "*" + parsedBnaCounter.PurgeCounter5 + "<br>" +
                            denominationMapping[5] + "*" + parsedBnaCounter.PurgeCounter6 + "<br>" +
                            "=" + (int.Parse(denominationMapping[0]) * parsedBnaCounter.PurgeCounter1 +
                                    int.Parse(denominationMapping[1]) * parsedBnaCounter.PurgeCounter2 +
                                    int.Parse(denominationMapping[2]) * parsedBnaCounter.PurgeCounter3 +
                                    int.Parse(denominationMapping[3]) * parsedBnaCounter.PurgeCounter4 +
                                    int.Parse(denominationMapping[4]) * parsedBnaCounter.PurgeCounter5 +
                                    int.Parse(denominationMapping[5]) * parsedBnaCounter.PurgeCounter6).ToString();

                        parsedBnaCounter.PurgeCounter7 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter8 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter9 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter10 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter11 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter12 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter13 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter14 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter15 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter16 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter17 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter18 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter19 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter20 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter21 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter22 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter23 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter24 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter25 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter26 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter27 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter28 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter29 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter30 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter31 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter32 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter33 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter34 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter35 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter36 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter37 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter38 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter39 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter40 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter41 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter42 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter43 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter44 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter45 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter46 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter47 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter48 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter49 = int.Parse(subParts[j++]);
                        parsedBnaCounter.PurgeCounter50 = int.Parse(subParts[j++]);

                        #endregion
                        //
                        try
                        {
                            int len = subParts.Length - 1;

                            parsedBnaCounter.DenominationType1 = int.Parse(subParts[len - 32]);
                            parsedBnaCounter.DenominationType1Deposited = int.Parse(subParts[len - 30]);
                            parsedBnaCounter.DenominationType1Remaining = int.Parse(subParts[len - 31]);

                            parsedBnaCounter.DenominationType2 = int.Parse(subParts[len - 24]);
                            parsedBnaCounter.DenominationType2Deposited = int.Parse(subParts[len - 22]);
                            parsedBnaCounter.DenominationType2Remaining = int.Parse(subParts[len - 23]);

                            parsedBnaCounter.DenominationType3 = int.Parse(subParts[len - 16]);
                            parsedBnaCounter.DenominationType3Deposited = int.Parse(subParts[len - 14]);
                            parsedBnaCounter.DenominationType3Remaining = int.Parse(subParts[len - 15]);

                            parsedBnaCounter.DenominationType4 = int.Parse(subParts[len - 8]);
                            parsedBnaCounter.DenominationType4Deposited = int.Parse(subParts[len - 6]);
                            parsedBnaCounter.DenominationType4Remaining = int.Parse(subParts[len - 7]);

                            // parsedBnaCounter.
                        }
                        catch (Exception ex)
                        {

                        }
                        parsedBnaCounter.AtmId = ATMID;
                        parsedBnaCounter.TaskId = taskID;
                        //parsedBnaCounter.Save(trxn.Connection, trxn);
                        listParsedBnaCounter.Add(parsedBnaCounter);
                        currentBNAStatus = parts[i];
                    }
                    #endregion
                    #region ChequeDeposit
                    else if (subParts[1] == "ChequeDeposit")
                    {
                        //if (appSetting.IsDuplicateCheckingEnabled.Value)
                        //{
                        //    ParsedCpmCounter existingCPMCounter = ParsedCpmCounter.LoadParsedCpmCounter(
                        //         string.Format("deposit_at=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID));
                        //    if (existingCPMCounter != null)
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Cpm_Counter table");
                        //        continue;
                        //    }
                        //}

                        if (CheckForDuplicates("GetParsedCpmCounter", string.Format("deposit_at=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID)))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Cpm_Counter table");
                            continue;
                        }


                        //parsedCpmCounter = new ParsedCpmCounter();
                        //parsedCpmCounter.DepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                        //j = 5;
                        //parsedCpmCounter.Bin1 = int.Parse(subParts[j++]);
                        //parsedCpmCounter.Bin2 = int.Parse(subParts[j++]);
                        //parsedCpmCounter.Bin3 = int.Parse(subParts[j++]);
                        ////Added on 20/11/2014 
                        /////////////////////////////////
                        //if (parsedCpmCounter.Bin1 < 0)
                        //    parsedCpmCounter.Bin1 = 0;

                        //if (parsedCpmCounter.Bin2 < 0)
                        //    parsedCpmCounter.Bin2 = 0;

                        //if (parsedCpmCounter.Bin3 < 0)
                        //    parsedCpmCounter.Bin3 = 0;
                        ////////////////////////////////

                        //parsedCpmCounter.Bin4 = 0;
                        //parsedCpmCounter.AtmId = ATMID;
                        //parsedCpmCounter.TaskId = taskID;
                        ////parsedCpmCounter.Save(trxn.Connection, trxn);
                        //listparsedCpmCounter.Add(parsedCpmCounter);
                        //currentCPMStatus = parts[i];
                    }
                    #endregion
                    #region TestCash
                    else if (subParts[1] == "TestCash")
                    {
                        //if (appSetting.IsDuplicateCheckingEnabled.Value)
                        //{
                        //    TestCashPurgedNotes existingTestCashPurgedNotes = TestCashPurgedNotes.LoadTestCashPurgedNotes(
                        //        );
                        //    if (existingTestCashPurgedNotes != null)
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Test_Cash_Purged_Notes table");
                        //        continue;
                        //    }
                        //}
                        if (CheckForDuplicates("GetTestCashPurgedNotes", string.Format("test_cash_datetime=convert(datetime,'{0}',101) and atm_id={1}", subParts[0], ATMID)))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Test_Cash_Purged_Notes table");
                            continue;
                        }



                        testCashPurgedNotes = new TestCashPurgedNotes();
                        j = 9;
                        testCashPurgedNotes.ReplenishmentId = -1;//replenishment.ReplenishmentId;
                        testCashPurgedNotes.TaskId = taskID;
                        testCashPurgedNotes.TestCashDatetime = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);//replenishment.RepDatetime;
                        testCashPurgedNotes.CashPurged1 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged2 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged3 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged4 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged5 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged6 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.CashPurged7 = int.Parse(subParts[j++]);
                        testCashPurgedNotes.AtmId = ATMID;
                        //testCashPurgedNotes.Save(trxn.Connection, trxn);
                        //currentCassetteStatus = parts[i];
                        listTestCashPurgedNotes.Add(testCashPurgedNotes);
                        //          UpdateCashPosition(parts[i], ATM, noteSetType, trxn, taskID, null, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);

                        ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                        parserPostProcessingTask.AtmId = ATM.ATMId;
                        parserPostProcessingTask.CreationTime = DateTime.Now;
                        parserPostProcessingTask.EntityId = testCashPurgedNotes.TestCashPurgedNotesId;
                        parserPostProcessingTask.EventInfo = parts[i];
                        parserPostProcessingTask.EventOccuredAt = testCashPurgedNotes.TestCashDatetime.AddSeconds(-1);
                        parserPostProcessingTask.EventType = subParts[1];
                        parserPostProcessingTask.TaskId = taskID;
                        testCashPostProcessingQueue.Add(parserPostProcessingTask);
                        //parserPostProcessingTask.Save();

                        //Commented on 13/12/2013...counters will be updated on next withdrawal..
                        //Added on 24/03/2012
                        //*****Update replenishment counters.TO RESOLVE NDC COUNTER POOL ISSUE.
                        //if (replenishmentSaved)
                        //{

                        //    Replenishment lastReplenishment = Replenishment.LoadReplenishment(
                        //     string.Format("rep_datetime in (select  max(rep_datetime) from replenishment where  " +
                        //                                   " atm_id ={1} and rep_datetime<convert(datetime,'{0}',101)) and atm_id={1}", subParts[0], ATMID));


                        //    //Replenishment lastReplenishment =
                        //    //    Replenishment.LoadReplenishment(string.Format("rep_datetime>=convert(datetime,'{0}',103)" +
                        //    //    " and rep_datetime<=convert(datetime,'{0} 23:59:59',103) and atm_id={1}",
                        //    //    DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"), ATMID));
                        //    if (lastReplenishment != null)
                        //    {
                        //        //LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose,
                        //        //    "Rep ID = " + lastReplenishment.ReplenishmentId + " type1 = " + lastReplenishment.CashAdded1 +
                        //        //    " type2= " + lastReplenishment.CashAdded2 + " type2= " + lastReplenishment.CashAdded3 +
                        //        //    " type4= " + lastReplenishment.CashAdded4);


                        //        if (lastReplenishment.CashAdded1 <= 0)
                        //            lastReplenishment.CashAdded1 = MakeNumberDivisibleBy50(int.Parse(subParts[2]));
                        //        if (lastReplenishment.CashAdded2 <= 0)
                        //            lastReplenishment.CashAdded2 = MakeNumberDivisibleBy50(int.Parse(subParts[3]));
                        //        if (lastReplenishment.CashAdded3 <= 0)
                        //            lastReplenishment.CashAdded3 = MakeNumberDivisibleBy50(int.Parse(subParts[4]));
                        //        if (lastReplenishment.CashAdded4 <= 0)
                        //            lastReplenishment.CashAdded4 = MakeNumberDivisibleBy50(int.Parse(subParts[5]));
                        //        if (lastReplenishment.CashAdded5 <= 0)
                        //            lastReplenishment.CashAdded5 = MakeNumberDivisibleBy50(int.Parse(subParts[6]));
                        //        if (lastReplenishment.CashAdded6 <= 0)
                        //            lastReplenishment.CashAdded6 = MakeNumberDivisibleBy50(int.Parse(subParts[7]));
                        //        if (lastReplenishment.CashAdded7 <= 0)
                        //            lastReplenishment.CashAdded7 = MakeNumberDivisibleBy50(int.Parse(subParts[8]));

                        //        lastReplenishment.Save(trxn.Connection,trxn);
                        //    }
                        //}
                        //*******************************************************************
                        //

                        //////for emitac...
                        //   List<CcmsAtmReplenishmentResidualDetail> listResidualdDetail = new List<CcmsAtmReplenishmentResidualDetail>();
                        //   CcmsAtmReplenishmentResidualDetail ccmsAtmReplenishmentResidualDetail = null;
                        //   CcmsAtmLedger ccmsATMLedger = new CcmsAtmLedger();

                        //   List<CcmsAtmLedgerDetail> list = new List<CcmsAtmLedgerDetail>();
                        //   CcmsAtmLedgerDetail ccmsATMLedgerDetail = null;
                        //   amount = 0;
                        //   residualAmount = 0;
                        //   for (k = 0; k < denominations.Length; k++)
                        //   {
                        //       if (denominations[k] != string.Empty)
                        //       {
                        //           ccmsATMLedgerDetail = new CcmsAtmLedgerDetail();
                        //           ccmsAtmReplenishmentResidualDetail = new CcmsAtmReplenishmentResidualDetail();

                        //           ccmsATMLedgerDetail.DenominationName = denominations[k];
                        //           ccmsATMLedgerDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];
                        //           ccmsAtmReplenishmentResidualDetail.DenominationName = denominations[k];
                        //           ccmsAtmReplenishmentResidualDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];



                        //           if (k == 0)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[9]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[2]);
                        //           }
                        //           else if (k == 1)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[10]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[3]);
                        //           }
                        //           else if (k == 2)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[11]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[4]);
                        //           }
                        //           else if (k == 3)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[12]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[5]);
                        //           }
                        //           else if (k == 4)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[13]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[6]);
                        //           }
                        //           else if (k == 5)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[14]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[7]);
                        //           }

                        //           else if (k == 6)
                        //           {
                        //               ccmsATMLedgerDetail.Quantity = long.Parse(subParts[15]);
                        //               ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[8]);
                        //           }
                        //           amount += (decimal)(ccmsATMLedgerDetail.Quantity * int.Parse(denominations[k].Substring(3)));

                        //           list.Add(ccmsATMLedgerDetail);
                        //           listResidualdDetail.Add(ccmsAtmReplenishmentResidualDetail);
                        //       }
                        //   }

                        //   ccmsATMLedger.AtmId = ATMID;
                        //   ccmsATMLedger.AtmLogId = ccmsATMLog.Id;
                        //   ccmsATMLedger.TransactionDate = testCashPurgedNotes.TestCashDatetime;
                        //   ccmsATMLedger.TransactionType = "Cr";
                        //   ccmsATMLedger.Balance = amount;
                        //   ccmsATMLedger.TaskId = taskID;
                        //   ccmsATMLedger.ProcessingDatetime = DateTime.Now;

                        //   ccmsATMLedger.Mode = ccmsATMLog.EventMode;
                        //   ccmsATMLedger.Type = subParts[1];
                        //   ccmsATMLedger.Save(trxn.Connection,trxn);
                        //   for (int l = 0; l < list.Count; l++)
                        //   {
                        //       list[l].AtmLedgerId = ccmsATMLedger.Id;
                        //       list[l].Save(trxn.Connection,trxn);
                        //       listResidualdDetail[l].AtmLedgerId = ccmsATMLedger.Id;
                        //       listResidualdDetail[l].Save(trxn.Connection,trxn);

                        //   }
                    }
                    #endregion
                    #region cashWithdrals Parsing

                    else if (subParts[1] == "CashWithdrawal" || subParts[1] == "BillCashWithdrawal")
                    {
                        j = 0;
                        parsedTransaction = new ParsedTransaction();
                        parsedTransaction.TrxnDatetime = DateTime.ParseExact(subParts[j++], "MM/dd/yyyy HH:mm:ss", null);
                        j++; j++;
                        parsedTransaction.CashRemaining1 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining2 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining3 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining4 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining5 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining6 = int.Parse(subParts[j++]);
                        parsedTransaction.CashRemaining7 = int.Parse(subParts[j++]);


                        parsedTransaction.CashDispensed1 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed2 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed3 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed4 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed5 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed6 = int.Parse(subParts[j++]);
                        parsedTransaction.CashDispensed7 = int.Parse(subParts[j++]);


                        parsedTransaction.CashPurged1 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged2 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged3 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged4 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged5 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged6 = int.Parse(subParts[j++]);
                        parsedTransaction.CashPurged7 = int.Parse(subParts[j++]);
                        if (subParts[subParts.Length - 1] == "Y")
                            parsedTransaction.IsAutoGenerated = true;
                        else
                            parsedTransaction.IsAutoGenerated = false;
                        parsedTransaction.TaskId = taskID;
                        parsedTransaction.AtmId = ATMId;




                        dispensedAmount = (decimal)(parsedTransaction.CashDispensed1 * ATM.Cassette1Denomination
                        + parsedTransaction.CashDispensed2 * ATM.Cassette2Denomination
                        + parsedTransaction.CashDispensed3 * ATM.Cassette3Denomination
                        + parsedTransaction.CashDispensed4 * ATM.Cassette4Denomination
                        + parsedTransaction.CashDispensed5 * ATM.Cassette5Denomination
                        + parsedTransaction.CashDispensed6 * ATM.Cassette6Denomination
                        + parsedTransaction.CashDispensed7 * ATM.Cassette7Denomination);
                        parsedTransaction.Amount = dispensedAmount;
                        //Change done on 25/03/2014
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //if (parsedTransaction.Amount == 0 &&
                        //    parsedTransaction.CashDispensed1 == 0 && parsedTransaction.CashDispensed2 == 0 &&
                        //    parsedTransaction.CashDispensed3 == 0 && parsedTransaction.CashDispensed4 == 0 &&
                        //    parsedTransaction.CashPurged1 == 0 && parsedTransaction.CashPurged2 == 0 &&
                        //    parsedTransaction.CashPurged3 == 0 && parsedTransaction.CashPurged4 == 0)
                        //    tempParsedTransaction = parsedTransaction;


                        //Chane done on 25/05..Now processing temp trxn object.
                        //if (tempParsedTransaction != null && (i == (parts.Length - 1) && currentEntry != "Replenishment" && !replenishmentExpected))
                        //{
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing Replenishments that are repored as withdrawals.");

                        //    replenishmentEntry = string.Format("{0}|Replenishment|OrderMissingForceFully|{1}|{2}|-1|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}",
                        //      subParts[0], DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("yyyyMMddHHmmss"), DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("yyyyMMddHHmmss"),
                        //      0, 0, 0, 0, 0, 0, 0,
                        //      0, 0, 0, 0, 0, 0, 0,
                        //      0, 0, 0, 0, 0, 0, 0,
                        //      MakeNumberDivisibleBy50(tempParsedTransaction.CashRemaining1 < 100 ? 0 : tempParsedTransaction.CashRemaining1),
                        //      MakeNumberDivisibleBy50(tempParsedTransaction.CashRemaining2 < 100 ? 0 : tempParsedTransaction.CashRemaining2),
                        //      MakeNumberDivisibleBy50(tempParsedTransaction.CashRemaining3 < 100 ? 0 : tempParsedTransaction.CashRemaining3),
                        //      MakeNumberDivisibleBy50(tempParsedTransaction.CashRemaining4 < 100 ? 0 : tempParsedTransaction.CashRemaining4),
                        //      0, 0, 0, "Swap");


                        //    int newCounterFileLength = parts.Length + 1;
                        //    string[] newCounterFileContent = new string[newCounterFileLength];
                        //    int t = 0;

                        //    for (t = 0; t <= i; t++)
                        //        newCounterFileContent[t] = parts[t];
                        //    newCounterFileContent[t] = replenishmentEntry;
                        //    for (; t < parts.Length; t++)
                        //        newCounterFileContent[t + 1] = parts[t];

                        //    //parts.CopyTo(newCounterFileContent, 0);
                        //    //newCounterFileContent[newCounterFileLength - 1] = replenishmentEntry;
                        //    parts = newCounterFileContent;
                        //    tempParsedTransaction = null;
                        //    continue;
                        //}



                        if (subParts[1] == "BillCashWithdrawal")
                        {
                            parsedTransaction.IsBillDispenser = true;
                            bool initialValuesLookValid = parsedTransaction.Amount != 0 && (parsedTransaction.CashRemaining1 != 0 || parsedTransaction.CashRemaining2 != 0 || parsedTransaction.CashRemaining3 != 0 || parsedTransaction.CashRemaining4 != 0);

                            if (!initialValuesLookValid)
                            {
                                int len = subParts.Length - 1;                                
                                Hashtable ht = new Hashtable();

                                int[] denomATM = {
                            int.Parse(subParts[j++]),int.Parse(subParts[j++]),int.Parse(subParts[j++]),int.Parse(subParts[j++]),
                            int.Parse(subParts[j++]),int.Parse(subParts[j++]),int.Parse(subParts[j++])
                            };

                                int[] purgedATM = {
                           parsedTransaction.CashPurged1, parsedTransaction.CashPurged2,parsedTransaction.CashPurged3,parsedTransaction.CashPurged4,
                           parsedTransaction.CashPurged5,parsedTransaction.CashPurged6,parsedTransaction.CashPurged7
                            };
                                int[] dispensedATM = {
                            parsedTransaction.CashDispensed1,parsedTransaction.CashDispensed2,parsedTransaction.CashDispensed3,parsedTransaction.CashDispensed4,
                            parsedTransaction.CashDispensed5,parsedTransaction.CashDispensed6,parsedTransaction.CashDispensed7
                            };
                                int[] remainingATM = {
                            parsedTransaction.CashRemaining1,parsedTransaction.CashRemaining2,parsedTransaction.CashRemaining3,parsedTransaction.CashRemaining4,
                            parsedTransaction.CashRemaining5,parsedTransaction.CashRemaining6,parsedTransaction.CashRemaining7
                            };


                                int[] adjustedDenomDispensed = new int[7];
                                int[] adjustedDenomRemaining = new int[7];
                                int[] adjustedDenomPurged = new int[7];

                                for (int l = 0; l < 7; l++)
                                {
                                    int idx = Array.IndexOf(denominations, denomATM[l]);
                                    if (idx > -1)
                                    {
                                        adjustedDenomDispensed[idx] = dispensedATM[l] + purgedATM[l];
                                        adjustedDenomRemaining[idx] = remainingATM[l];
                                        adjustedDenomPurged[idx] = purgedATM[l];
                                    }
                                }

                                parsedTransaction.CashDispensed1 = adjustedDenomDispensed[0];
                                parsedTransaction.CashDispensed2 = adjustedDenomDispensed[1];
                                parsedTransaction.CashDispensed3 = adjustedDenomDispensed[2];
                                parsedTransaction.CashDispensed4 = adjustedDenomDispensed[3];
                                parsedTransaction.CashDispensed5 = adjustedDenomDispensed[4];
                                parsedTransaction.CashDispensed6 = adjustedDenomDispensed[5];
                                parsedTransaction.CashDispensed7 = adjustedDenomDispensed[6];

                                parsedTransaction.CashRemaining1 = adjustedDenomRemaining[0];
                                parsedTransaction.CashRemaining2 = adjustedDenomRemaining[1];
                                parsedTransaction.CashRemaining3 = adjustedDenomRemaining[2];
                                parsedTransaction.CashRemaining4 = adjustedDenomRemaining[3];
                                parsedTransaction.CashRemaining5 = adjustedDenomRemaining[4];
                                parsedTransaction.CashRemaining6 = adjustedDenomRemaining[5];
                                parsedTransaction.CashRemaining7 = adjustedDenomRemaining[6];

                                parsedTransaction.CashPurged1 = adjustedDenomPurged[0];
                                parsedTransaction.CashPurged2 = adjustedDenomPurged[1];
                                parsedTransaction.CashPurged3 = adjustedDenomPurged[2];
                                parsedTransaction.CashPurged4 = adjustedDenomPurged[3];
                                parsedTransaction.CashPurged5 = adjustedDenomPurged[4];
                                parsedTransaction.CashPurged6 = adjustedDenomPurged[5];
                                parsedTransaction.CashPurged7 = adjustedDenomPurged[6];



                                parsedTransaction.Amount = (decimal)(denominations[0] * adjustedDenomDispensed[0]
                           + denominations[1] * adjustedDenomDispensed[1]
                           + denominations[2] * adjustedDenomDispensed[2]
                           + denominations[3] * adjustedDenomDispensed[3]
                           + denominations[4] * adjustedDenomDispensed[4]
                           + denominations[5] * adjustedDenomDispensed[5]
                           + denominations[6] * adjustedDenomDispensed[6]);
                            
                            }
                        }
                        else
                            parsedTransaction.IsBillDispenser = false;

                        if (parsedTransaction.TrxnDatetime.Hour == 13 && parsedTransaction.TrxnDatetime.Minute == 21
                            && parsedTransaction.TrxnDatetime.Second == 50)
                        {
                            int b = 0;
                        }
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        DataTable dtExistingParsedTransaction = ExecuteStoredProcedure("GetParsedTransaction",
              string.Format("trxn_datetime>=convert(datetime,'{0}',101) and trxn_datetime<=convert(datetime,'{3}',101) and atm_id={1} and amount={2}",
                           parsedTransaction.TrxnDatetime.AddSeconds(-60).ToString("MM/dd/yyyy HH:mm:ss"), ATMID, parsedTransaction.Amount, parsedTransaction.TrxnDatetime.AddSeconds(75).ToString("MM/dd/yyyy HH:mm:ss")), 2, null);



                        //ParsedTransaction existingParsedTransaction = ParsedTransaction.LoadParsedTransaction(
                        //   );


                        if (dtExistingParsedTransaction.Rows.Count > 0)
                        {
                            if (int.Parse(dtExistingParsedTransaction.Rows[0][0].ToString()) > 0)
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Parsed_Transaction table");
                                continue;
                            }
                        }



                        //***********************************************************************************************************
                        //Handle replenishment Issues here....
                        //***********************************************************************************************************
                        //                        Replenishment existingReplenishment = Replenishment.LoadReplenishment(
                        //     );

                        /*
                        DataTable dtExistingReplenishment = ExecuteStoredProcedure("GetReplenishmentRow",
                      string.Format("rep_datetime in (select  max(rep_datetime) from replenishment where  " +
                                                            " atm_id ={1} and rep_datetime<convert(datetime,'{0}',101)) and atm_id={1} and is_updated=0", subParts[0], ATMID), 1, null);



                        //bool repUpdated = false;
                        if (dtExistingReplenishment.Rows.Count > 0)
                        {
                            //Changes done on 21/5/2015
                            if (ATM.Type1MinNotesThresholdValue.HasValue)
                            {
                                if (ATM.Type1MinNotesThresholdValue > 0)
                                {
                                    if ((decimal)parsedTransaction.CashRemaining1 <= ATM.Type1MinNotesThresholdValue)
                                    {
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4)
                                        , false, Event_Type.Information, taskID, false);
                                    }
                                    else
                                        //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = "+(int)EnumAlertType.Type1MinNotesThresholdReached+" and resolve_at is null and atm_id="+ATM.ATMId, trxn);
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                }
                            }
                            if (ATM.Type2MinNotesThresholdValue.HasValue)
                            {
                                if (ATM.Type2MinNotesThresholdValue > 0)
                                {
                                    if ((decimal)parsedTransaction.CashRemaining2 <= ATM.Type2MinNotesThresholdValue)
                                    {
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                    }
                                    else
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                    //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type2MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                }
                            }
                            if (ATM.Type3MinNotesThresholdValue.HasValue)
                            {
                                if (ATM.Type3MinNotesThresholdValue > 0)
                                {
                                    if ((decimal)parsedTransaction.CashRemaining3 <= ATM.Type3MinNotesThresholdValue)
                                    {
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                    }
                                    else
                                        //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type3MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                }
                            }
                            if (ATM.Type4MinNotesThresholdValue.HasValue)
                            {
                                if (ATM.Type4MinNotesThresholdValue > 0)
                                {
                                    if ((decimal)parsedTransaction.CashRemaining4 <= ATM.Type4MinNotesThresholdValue)
                                    {
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                    }
                                    else
                                        // ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type4MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);

                                }

                            }
                            //Changes done on 13/01/2014 to generate alerts in case of type 1 reaches below threshold value.
                            if (ATM.Type1MinNotesThreshold.HasValue)
                            {
                                if (ATM.Type1MinNotesThreshold > 0)
                                {
                                    if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added1"].ToString()) != 0)
                                    {
                                        if ((decimal)parsedTransaction.CashRemaining1 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added1"].ToString()) * 100 <= ATM.Type1MinNotesThreshold)
                                        {
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                            (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                            parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                            parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                            parsedTransaction.CashRemaining4 * noteSetType.DenominationType4)
                                            , false, Event_Type.Information, taskID, false);
                                        }
                                        else
                                            //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = "+(int)EnumAlertType.Type1MinNotesThresholdReached+" and resolve_at is null and atm_id="+ATM.ATMId, trxn);
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                    }
                                }
                            }
                            if (ATM.Type2MinNotesThreshold.HasValue)
                            {
                                if (ATM.Type1MinNotesThreshold > 0)
                                {
                                    if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added2"].ToString()) != 0)
                                    {
                                        if ((decimal)parsedTransaction.CashRemaining2 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added2"].ToString()) * 100 <= ATM.Type2MinNotesThreshold)
                                        {
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                            (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                            parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                            parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                            parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                        }
                                        else
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                    }
                                    //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type2MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                }
                            }
                            if (ATM.Type3MinNotesThreshold.HasValue)
                            {
                                if (ATM.Type3MinNotesThreshold > 0)
                                {
                                    if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added3"].ToString()) != 0)
                                    {
                                        if ((decimal)parsedTransaction.CashRemaining3 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added3"].ToString()) * 100 <= ATM.Type3MinNotesThreshold)
                                        {
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                            (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                            parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                            parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                            parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                        }
                                        else
                                            //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type3MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                    }
                                }
                            }
                            if (ATM.Type4MinNotesThreshold.HasValue)
                            {
                                if (ATM.Type4MinNotesThreshold > 0)
                                {
                                    if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added4"].ToString()) != 0)
                                    {
                                        if ((decimal)parsedTransaction.CashRemaining4 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added4"].ToString()) * 100 <= ATM.Type4MinNotesThreshold)
                                        {
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                            (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                            parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                            parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                            parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                                        }
                                        else
                                            // ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type4MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                                    }
                                }
                            }

                        }
                        */

                        if (parsedTransaction.CashRemaining1 == 0 &&
                            parsedTransaction.CashRemaining2 == 0 && parsedTransaction.CashRemaining3 == 0 &&
                            parsedTransaction.CashRemaining4 == 0)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + "remaining counters are 0");
                            continue;
                        }

                        if (parsedTransaction.Amount == 0)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + "amount is 0");
                            continue;
                        }
                        parsedTransaction.ProcessingDatetime = DateTime.Now;
                        //parsedTransaction.Save(trxn.Connection, trxn);
                        if (ATM.AtmType.ToLower().Contains("brm"))
                            parsedTransaction.IsBillDispenser = true;


                        listParsedTrxns.Add(parsedTransaction);

                        currentCassetteStatus = parts[i];

                        //if (subParts[1] != "BillCashWithdrawal")
                        //{
                        ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                        parserPostProcessingTask.AtmId = ATM.ATMId;
                        parserPostProcessingTask.CreationTime = DateTime.Now;
                        parserPostProcessingTask.EntityId = parsedTransaction.ParsedTransactionId;
                        parserPostProcessingTask.EventInfo = parts[i];
                        parserPostProcessingTask.EventOccuredAt = parsedTransaction.TrxnDatetime;
                        parserPostProcessingTask.EventType = subParts[1];
                        parserPostProcessingTask.TaskId = taskID;
                        //parserPostProcessingTask.Save();
                        parsedTrxnsPostProcessingQueue.Add(parserPostProcessingTask);
                        //UpdateCashPosition(parts[i], ATM, noteSetType, trxn, taskID, parsedTransaction, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);
                        //}

                        //////for emitac...
                        //CcmsAtmLedger ccmsATMLedger = new CcmsAtmLedger();

                        //List<CcmsAtmLedgerDetail> list = new List<CcmsAtmLedgerDetail>();
                        //CcmsAtmLedgerDetail ccmsATMLedgerDetail = null;
                        //amount = 0;

                        //for (k = 0; k < denominations.Length; k++)
                        //{
                        //    if (denominations[k] != string.Empty)
                        //    {
                        //        ccmsATMLedgerDetail = new CcmsAtmLedgerDetail();
                        //        ccmsATMLedgerDetail.DenominationName = denominations[k];
                        //        ccmsATMLedgerDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];
                        //        if (k == 0)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed1;
                        //        else if (k == 1)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed2;
                        //        else if (k == 2)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed3;
                        //        else if (k == 3)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed4;
                        //        else if (k == 4)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed5;
                        //        else if (k == 5)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed6;
                        //        else if (k == 6)
                        //            ccmsATMLedgerDetail.Quantity = parsedTransaction.CashDispensed7;
                        //        amount += (decimal)(ccmsATMLedgerDetail.Quantity * int.Parse(denominations[k].Substring(3)));
                        //        list.Add(ccmsATMLedgerDetail);
                        //    }
                        //}

                        //ccmsATMLedger.AtmId = ATMID;
                        //ccmsATMLedger.AtmLogId = ccmsATMLog.Id;
                        //ccmsATMLedger.TransactionDate = parsedTransaction.TrxnDatetime;
                        //ccmsATMLedger.TransactionType = "Dr";
                        //ccmsATMLedger.Balance = amount;
                        //ccmsATMLedger.Mode = ccmsATMLog.EventMode;
                        //ccmsATMLedger.Type = subParts[1];
                        //ccmsATMLedger.TaskId = taskID;
                        //ccmsATMLedger.ProcessingDatetime = DateTime.Now;
                        //ccmsATMLedger.Save(trxn.Connection,trxn);

                        //for (int l = 0; l < list.Count; l++)
                        //{
                        //    list[l].AtmLedgerId = ccmsATMLedger.Id;
                        //    list[l].Save(trxn.Connection,trxn);
                        //}

                        //ccmsATMLedger.Balance = 



                        //////for emitac...

                    }


                    #endregion

                    #region AddCash
                    else if (subParts[1] == "CountsCleared")
                    {
                        isSwap = true;
                        sumOfAlreadyExistingNotes = 0;
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "counts cleared.So its a swap");
                        for (int g = 0; g < 7; g++)
                            notesAdded[g] = 0;

                        //ParserPostProcessingTask parserPostProcessingTask = new DAL.ParserPostProcessingTask();
                        //parserPostProcessingTask.AtmId = ATM.ATMId;
                        //parserPostProcessingTask.CreationTime = DateTime.Now;
                        ////parserPostProcessingTask.EntityId = listparsedCpmCounter[listparsedCpmCounter.Count - 1].ParsedCpmCounterId;
                        //parserPostProcessingTask.EventInfo = parts[i];
                        //parserPostProcessingTask.EventOccuredAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null); 
                        //parserPostProcessingTask.EventType = "CountsCleared";
                        //parserPostProcessingTask.TaskId = taskID;
                        //parserPostProcessingTask.Save(trxn.Connection, trxn);

                        continue;
                    }
                    else if (subParts[1] == "AddCash")
                    {
                        isReplenishmentExpected = true;
                        bool isAnyPositiveCounterFound = false;
                        //If there is any negative counter present this means its a clear cash entry....
                        for (int n = 0; n < 7; n++)
                        {
                            if (int.Parse(subParts[n + 9]) > 0)
                            {
                                isAnyPositiveCounterFound = true;
                                break;
                            }
                        }
                        if (!isAnyPositiveCounterFound)
                            continue;

                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Add Cash Detected..So replenishment is expected");


                        //replenishmentExpected = true;
                        //if (isADDCashFoundFirstTime)
                        //{
                        bool isAllCountersDivisibleByZero = true;
                        for (int n = 2; n < 7; n++)
                        {
                            sumOfAlreadyExistingNotes += int.Parse(subParts[n]);
                            if (int.Parse(subParts[n]) % 10 != 0)
                                isAllCountersDivisibleByZero = false;

                        }
                        if (sumOfAlreadyExistingNotes == 0 || isAllCountersDivisibleByZero)
                            isSwap = true;
                        else
                            isSwap = false;
                        //isADDCashFoundFirstTime = false;
                        //}
                        //Expecting a replenishment activity;
                        //Record Counts cleared entry
                        notesAdded = new int[7];
                        for (int n = 0; n < 7; n++)
                        {
                            if (isSwap)
                                notesAdded[n] = int.Parse(subParts[n + 2]) + int.Parse(subParts[n + 9]);
                            else
                            {
                                if (int.Parse(subParts[n + 9]) > 0)
                                    notesAdded[n] = int.Parse(subParts[n + 2]) + int.Parse(subParts[n + 9]);
                            }
                        }
                        continue;
                    }
                    #endregion




                    #region Replenishment
                    else if (subParts[1] == "Replenishment" || subParts[1] == "BillReplenishment") //replenishment started.
                    {
                        isReplenishmentExpected = false;
                        if (disableForcefulRepExtraction == "1")
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because disableForcefulRepExtraction is set to 1");
                            continue;
                        }
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //Changes done on 8 Jan 2014 to ignore replenishments if its not reported on same day.
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //12/18/2013 16:02:57|Replenishment|AddCash|20131218155201|20131218160257|-1|596|681|643|1069|0|0|0|3|18|56|402|0|0|0|1|1|1|29|0|0|0|0|0|0|1000|0|0|0
                        //This can happen when custodian forgets to do test cash and on next day and after some time do test cash and system generates replenishemtn entry..
                        //But what about the replenishment that we have extracted as ReplenishmentWithoutTestCash....
                        //This should be remain in the system and other will be ignored..


                        //DateTime repStartTime = DateTime.ParseExact(subParts[3], "yyyyMMddHHmmss", null);
                        //DateTime repEndTime = DateTime.ParseExact(subParts[4], "yyyyMMddHHmmss", null);

                        //if (repStartTime.Date != repEndTime.Date)
                        //{
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because start and end time of replenishment is different ");
                        //    continue;
                        //}

                        //20120723071315|20120724230529
                        DateTime repStartDate = DateTime.ParseExact(subParts[3], "yyyyMMddHHmmss", null);
                        DateTime repEndDate = DateTime.ParseExact(subParts[4], "yyyyMMddHHmmss", null);

                        if (repStartDate.Date != repEndDate.Date)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because replenishment start date != replenishment end date ");
                            continue;
                        }

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        bool isSuspected = false;
                        //replenishmentExpected = false;//Replenishment found so not extract replenishment itself..

                        if (CheckForDuplicates("GetReplenishmentRow", string.Format("rep_datetime>=convert(datetime,'{0}:00:00',101) and rep_datetime<=convert(datetime,'{2}:59:59',101)  and atm_id={1} and cash_added1={3} and cash_added2={4} and cash_added3={5} and cash_added4={6}",
                                  DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).AddMinutes(-20).ToString("MM/dd/yyyy HH"), ATMID, DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("MM/dd/yyyy HH"), subParts[27], subParts[28], subParts[29], subParts[30])))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring " + parts[i] + ".because this already exists in Replenishment table");
                            continue;
                        }


                        if (int.Parse(subParts[27]) <= 0 && int.Parse(subParts[28]) <= 0 && int.Parse(subParts[29]) <= 0 && int.Parse(subParts[30]) <= 0
                             && int.Parse(subParts[31]) <= 0 && int.Parse(subParts[32]) <= 0 && int.Parse(subParts[33]) <= 0)
                        {
                            LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Ignoring this replenishment reported by agent" + parts[i]);
                            continue;
                        }

                        j = 27;

                        //DataTable dtLastReplenishment = ExecuteStoredProcedure("GetReplenishmentRow",
                        //    string.Format(" rep_datetime in (select max(rep_Datetime) from replenishment where rep_datetime>=convert(datetime,'{0}',103)" +
                        //    " and rep_datetime<convert(datetime,'{2}',103) and atm_id={1}) and atm_id={1}",
                        //    DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"), ATMID,
                        //    DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss")), 1, null);


                        //Replenishment lastReplenishment =
                        //    Replenishment.LoadReplenishment();


                        replenishment = new Replenishment();
                        replenishment.AtmId = ATMID;
                        replenishment.RepDatetime = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                        replenishment.CashAdded1 = int.Parse(subParts[j++]);
                        if (replenishment.CashAdded1 <= 0 || (notesAdded[0] > replenishment.CashAdded1 && isSwap))
                        {
                            LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose,
                                    " type1 <=0 so updating replenishment with notes added counter " + replenishment.CashAdded1 + " updating with " + notesAdded[0]);

                            replenishment.CashAdded1 = notesAdded[0];
                        }
                        //Make it divisible by 50 
                        replenishment.CashAdded1 = replenishment.CashAdded1;

                        replenishment.CashAdded2 = int.Parse(subParts[j++]);
                        if (replenishment.CashAdded2 <= 0 || (notesAdded[1] > replenishment.CashAdded2 && isSwap))
                        {
                            LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose,
                                        " type2 <=0 so updating replenishment with notes added counter " + replenishment.CashAdded2 + " updating with " + notesAdded[1]);
                            replenishment.CashAdded2 = notesAdded[1];
                        }
                        //Make it divisible by 50 
                        replenishment.CashAdded2 = replenishment.CashAdded2;

                        replenishment.CashAdded3 = int.Parse(subParts[j++]);
                        if (replenishment.CashAdded3 <= 0 || (notesAdded[2] > replenishment.CashAdded3 && isSwap))
                        {
                            LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose,
                           " type3 <=0 so updating replenishment with notes added counter " + replenishment.CashAdded3 + " updating with " + notesAdded[2]);
                            replenishment.CashAdded3 = notesAdded[2];
                        }
                        //Make it divisible by 50 
                        replenishment.CashAdded3 = replenishment.CashAdded3;

                        replenishment.CashAdded4 = int.Parse(subParts[j++]);
                        if (replenishment.CashAdded4 <= 0 || (notesAdded[3] > replenishment.CashAdded4 && isSwap))
                        {
                            LogableTask.LogMonoActivityTask("CheckRep", MethodBase.GetCurrentMethod(), TraceLevel.Verbose,
                            " type4 <=0 so updating replenishment with notes added counter " + replenishment.CashAdded4 + " updating with " + notesAdded[3]);
                            replenishment.CashAdded4 = notesAdded[3];
                        }
                        //Make it divisible by 50 
                        replenishment.CashAdded4 = replenishment.CashAdded4;

                        //replenishment.CashAdded5 = int.Parse(subParts[j++]);
                        //if (replenishment.CashAdded5 <= 0)
                        //    replenishment.CashAdded5 = notesAdded[4];
                        ////Make it divisible by 50 
                        //replenishment.CashAdded5 = MakeNumberDivisibleBy50(replenishment.CashAdded5);

                        //replenishment.CashAdded6 = int.Parse(subParts[j++]);
                        //if (replenishment.CashAdded6 <= 0)
                        //    replenishment.CashAdded6 = notesAdded[5];
                        //replenishment.CashAdded6 = MakeNumberDivisibleBy50(replenishment.CashAdded6);

                        //replenishment.CashAdded7 = int.Parse(subParts[j++]);
                        //if (replenishment.CashAdded7 <= 0)
                        //    replenishment.CashAdded7 = notesAdded[6];
                        //replenishment.CashAdded7 = MakeNumberDivisibleBy50(replenishment.CashAdded7);

                        replenishment.RepStatus = subParts[2];
                        replenishment.TaskId = taskID;
                        replenishment.CashOrderId = int.Parse(subParts[5]);
                        //Handling Rep Status...
                        //replenishment.IsSwap = false;

                        if (subParts[1] == "BillReplenishment")
                            replenishment.IsBillDispenser = true;
                        else
                            replenishment.IsBillDispenser = false;

                        if (ATM.IsSwapDefaultReplenishment.Value)
                        {
                            replenishment.IsSwap = true;
                            //Change done on 15/12 for QIB.
                            //if (replenishment.RepStatus.Contains("Add"))
                            //    replenishment.IsSwap = false;
                        }
                        else
                        {
                            if (replenishment.RepStatus.Contains("Add"))
                            {
                                //replenishment.IsSwap = false;
                                replenishment.IsSwap = isSwap;
                                //Read swap / test decision based on server side..
                                ///server side will ensure it bases on ADD CASH LINE
                            }
                            else
                            {
                                if (replenishment.RepStatus == "Reboot" || replenishment.RepStatus == "ReplenishmentWithoutTestCash")
                                {
                                    isSuspected = true;
                                    if (subParts[subParts.Length - 1] == "Add")
                                        replenishment.IsSwap = false;
                                    else
                                        replenishment.IsSwap = true;
                                }
                                else
                                    replenishment.IsSwap = true;
                            }
                        }
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //Change done for CIB on 05/02/2015
                        //If notes are added in all cassettes this means its swap...
                        //***********************************************************************************************************************//
                        if (!replenishment.IsSwap)
                        {
                            if (replenishment.CashAdded1 > 0 && replenishment.CashAdded2 > 0 && replenishment.CashAdded3 > 0 && replenishment.CashAdded4 > 0)
                                replenishment.IsSwap = true;
                        }
                        //***********************************************************************************************************************//
                        decimal replenishedAmount = (decimal)(replenishment.CashAdded1 * ATM.Cassette1Denomination +
                            replenishment.CashAdded2 * ATM.Cassette2Denomination +
                            replenishment.CashAdded3 * ATM.Cassette3Denomination +
                            replenishment.CashAdded4 * ATM.Cassette4Denomination +
                            replenishment.CashAdded5 * ATM.Cassette5Denomination +
                            replenishment.CashAdded6 * ATM.Cassette6Denomination +
                            replenishment.CashAdded7 * ATM.Cassette7Denomination);



                        /*bool isAlertGenEnabled = true;
                        DataTable dtReplenishmentRow = ExecuteStoredProcedure("GetReplenishmentRow",
                            "  atm_id =" + ATM.ATMId + " and rep_datetime >= convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ", 2, null);
                        if (dtReplenishmentRow.Rows.Count > 0)
                        {
                            if (int.Parse(dtReplenishmentRow.Rows[0][0].ToString()) > 0)
                                isAlertGenEnabled = false;
                        }
                        */
                        //if ((int)ConnectionFactory.ExecuteScalar(" select count(*) from replenishment with (nolock) , trxn) > 0)
                        //    //if ((int)ConnectionFactory.ExecuteScalar(" select count(*) from Cash_Position where atm_id =" + atm.ATMId + " and last_trxn_at >=convert(datetime,'" + lastTrxnAt.AddDays(1).ToString("dd/MM/yyyy") + "',103) ") > 0)
                        //    isAlertGenEnabled = false;


                        /*
                        if (replenishment.IsSwap && isAlertGenEnabled)
                        {
                            //Resolve Purge Bin Alerts.
                            //                            ExecuteStoredProcedure("UpdateAlert", "alert_type_id=" + (int)EnumAlertType.PurgeBinThresholdReached + " and atm_id=" + ATM.ATMId + " and resolve_at is null", -1, trxn);

                            //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch purge bin alert for atm_id = " + ATM.ATMId);

                            AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.PurgeBinThresholdReached + " and atm_id=" + ATM.ATMId + " and resolve_at is null");
                            if (atmAlert != null)
                            {
                                atmAlert.ResolveAt = DateTime.Now;
                                atmAlert.Save(trxn.Connection, trxn);
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert resolved for atm_id = " + ATM.ATMId);

                                CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                                if (ccmsIntAlert != null)
                                {
                                    ccmsIntAlert.ResolvedAt = DateTime.Now;
                                    ccmsIntAlert.Save(trxn.Connection, trxn);
                                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert from ccms integrated alert resolved for atm_id = " + ATM.ATMId);
                                }
                            }
                        }*/
                        //Change done by IK on 6-Sep-2015
                        //////////////////////////////////////////////////////////////////////////////////////////
                        //   minOperatingBalance = GetATMMinOperatingBalance(ATM, replenishment.RepDatetime);
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //if (replenishedAmount > minOperatingBalance && isAlertGenEnabled)
                        //{
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch low balance alert for atm_id = " + ATM.ATMId);
                        //    ExecuteStoredProcedure("UpdateAlert", "alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + ATM.ATMId + " and resolve_at is null", -1, trxn);


                        //    //AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + ATM.ATMId + " and resolve_at is null");
                        //    //if (atmAlert != null)
                        //    //{
                        //    //    atmAlert.ResolveAt = DateTime.Now;
                        //    //    atmAlert.Save(trxn.Connection, trxn);
                        //    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert resolved for atm_id = " + ATM.ATMId);
                        //    //    CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                        //    //    if (ccmsIntAlert != null)
                        //    //    {
                        //    //        ccmsIntAlert.ResolvedAt = DateTime.Now;
                        //    //        ccmsIntAlert.Save(trxn.Connection, trxn);
                        //    //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert from ccms integrated alert resolved for atm_id = " + ATM.ATMId);
                        //    //    }
                        //    //}

                        //}

                        //if (replenishedAmount > ATM.OutOfCashThreshold && isAlertGenEnabled)
                        //{
                        //    ExecuteStoredProcedure("UpdateAlert", "alert_type_id=" + (int)EnumAlertType.ATMOutOfCash + " and atm_id=" + ATM.ATMId + " and resolve_at is null", -1, trxn);

                        //    //AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.ATMOutOfCash + " and atm_id=" + ATM.ATMId + " and resolve_at is null");
                        //    //if (atmAlert != null)
                        //    //{
                        //    //    atmAlert.ResolveAt = DateTime.Now;
                        //    //    atmAlert.Save(trxn.Connection, trxn);
                        //    //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert resolved for atm_id = " + ATM.ATMId);
                        //    //    CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                        //    //    if (ccmsIntAlert != null)
                        //    //    {
                        //    //        ccmsIntAlert.ResolvedAt = DateTime.Now;
                        //    //        ccmsIntAlert.Save(trxn.Connection, trxn);
                        //    //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert from ccms integrated alert resolved for atm_id = " + ATM.ATMId);
                        //    //    }
                        //    //}

                        //}


                        //if (lastReplenishment != null)
                        //{//if counters are same or difference in rep time is <= 30 minutes..
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Last Replenishment extracted counters are " + lastReplenishment.CashAdded1 + " " + lastReplenishment.CashAdded2 + " " + lastReplenishment.CashAdded3 + " " + lastReplenishment.CashAdded4);
                        //    if (lastReplenishment.CashAdded1 == replenishment.CashAdded1 &&
                        //         lastReplenishment.CashAdded2 == replenishment.CashAdded2 &&
                        //             lastReplenishment.CashAdded3 == replenishment.CashAdded3 &&
                        //                 lastReplenishment.CashAdded4 == replenishment.CashAdded4 &&
                        //                     lastReplenishment.CashAdded5 == replenishment.CashAdded5 &&
                        //                         lastReplenishment.CashAdded6 == replenishment.CashAdded6 &&
                        //                             lastReplenishment.CashAdded7 == replenishment.CashAdded7 &&
                        //                             Math.Abs((lastReplenishment.RepDatetime - replenishment.RepDatetime).TotalMinutes) <= int.Parse(appSetting.RepTimeDiff)
                        //        || (Math.Abs((lastReplenishment.RepDatetime - replenishment.RepDatetime).TotalMinutes) <= int.Parse(appSetting.RepTimeDiff))

                        //        )
                        //    {
                        //        //ConnectionFactory.ExecuteQuery("insert into replenishmentHistory select * from replenishment where replenishment_id = " + lastReplenishment.ReplenishmentId, trxn);
                        //        replenishment.RepDatetime = lastReplenishment.RepDatetime; // Time is overwrite to fetch correct withdrawals entry to update replenishment counters
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Last replenishment deleted");
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, string.Format("Counter [{0}],[{1}],[{2}],[{3}]", lastReplenishment.CashAdded1, lastReplenishment.CashAdded2, lastReplenishment.CashAdded3, lastReplenishment.CashAdded4));
                        //        lastReplenishment.Delete(trxn.Connection, trxn);

                        //        AtmAlert.AtmAlertReader atmAlertReader = AtmAlert.ExecuteReader("entity_id=" + lastReplenishment.ReplenishmentId);
                        //        while (atmAlertReader.Read())
                        //        {
                        //            CcmsIntegratedAlert ccmsIntalert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlertReader.CurrentAtmAlert.AtmAlertId);
                        //            if (ccmsIntalert != null)
                        //            {
                        //                ccmsIntalert.Delete(trxn.Connection, trxn);
                        //                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert in ccms_integrated_alert also deleted");
                        //            }
                        //            atmAlertReader.CurrentAtmAlert.Delete(trxn);
                        //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " associated replenishments alert also deleted");
                        //        }
                        //        atmAlertReader.Close();
                        //    }

                        //}

                        replenishment.GeneratedAt = DateTime.Now;
                        replenishment.GeneratedBy = 1;
                        replenishment.IsUpdated = false;
                        //replenishment.Save(trxn.Connection, trxn);

                        // 24_07_26 commented by Jabbar - Rep to be save by EjParser only
                        //listReplenishment.Add(replenishment);
                        
                        
                        //ATM.IsDffGenerationHalt = false;
                        //ATM.Save(trxn.Connection, trxn);

                        /*
                        if (isSuspected)
                            GenerateTerminalAlert(ATMID, (int)EnumAlertType.SuspiciousReplenishment, string.Format("Replenishment with {0} status detected ", replenishment.RepStatus), trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");
                        else
                            GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.ReplenishmentAtATM, "Repenishment At ATM", trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");
                        */
                        /*
                        if (replenishment.IsSwap)
                            ExecuteStoredProcedure("UpdateCashPosition",
                                " atm_id =" + ATMID + " and last_trxn_at >=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                                " and last_trxn_at <=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)", -1, trxn);

                        */
                        ////replenishmentSaved = true;
                        //CashPosition currentCashPosition = CashPosition.LoadCashPosition(");

                        //if (currentCashPosition != null)
                        //{
                        //    if (replenishment.IsSwap)
                        //    {
                        //        currentCashPosition.PurgeCassette1Notes = 0;
                        //        currentCashPosition.PurgeCassette2Notes = 0;
                        //        currentCashPosition.PurgeCassette3Notes = 0;
                        //        currentCashPosition.PurgeCassette4Notes = 0;
                        //        currentCashPosition.PurgeCassette5Notes = 0;
                        //        currentCashPosition.PurgeCassette6Notes = 0;
                        //        currentCashPosition.PurgeCassette7Notes = 0;
                        //    }
                        //    currentCashPosition.Save(trxn.Connection, trxn);
                        //}

                        //////for emitac...


                        //CcmsAtmLedger ccmsATMLedger = new CcmsAtmLedger();

                        //if (replenishment.CashOrderId > 0)
                        //{
                        //    CashOrders cashOrders = CashOrders.LoadCashOrdersByPk(replenishment.CashOrderId.Value);
                        //    if (cashOrders != null)
                        //        ccmsATMLog.OrderNumber = cashOrders.OrderNumber;
                        //    else
                        //        ccmsATMLog.OrderNumber = "-1";
                        //}
                        //else
                        //    ccmsATMLog.OrderNumber = "-1";


                        //ccmsATMLog.OrderNumber = ccmsATMLedger.OrderNumber;
                        //  ccmsATMLog.Save(trxn.Connection,trxn);
                        //if (appSetting.IsLedgerAutoCreated)
                        //{
                        //    List<CcmsVaultLedgerDetail> listVaultLedgerDetail = new List<CcmsVaultLedgerDetail>();
                        //    List<CcmsVaultLedgerDetail> listAddCountsVaultLedgerDetail = new List<CcmsVaultLedgerDetail>();
                        //    //List<CcmsAtmLedgerDetail> list = new List<CcmsAtmLedgerDetail>();
                        //    //List<CcmsAtmReplenishmentDispenseDetail> listDispensedDetail = new List<CcmsAtmReplenishmentDispenseDetail>();
                        //    //List<CcmsAtmReplenishmentResidualDetail> listResidualdDetail = new List<CcmsAtmReplenishmentResidualDetail>();
                        //    //List<CcmsAtmReplenishmentPurgeDetail> listPurgeDetail = new List<CcmsAtmReplenishmentPurgeDetail>();
                        //    CcmsVaultLedgerDetail ccmsVaultLedgerDetail = null;
                        //    CcmsVaultLedgerDetail ccmsAddCountsVaultLedgerDetail = null;
                        //    CcmsVaultNoteType ccmsVaultNoteType = null;
                        //    //CcmsAtmLedgerDetail ccmsATMLedgerDetail = null;
                        //    //CcmsAtmReplenishmentDispenseDetail ccmsAtmReplenishmentDispenseDetail = null;
                        //    //CcmsAtmReplenishmentResidualDetail ccmsAtmReplenishmentResidualDetail = null;
                        //    //CcmsAtmReplenishmentPurgeDetail ccmsAtmReplenishmentPurgeDetail = null;

                        //    amount = 0;
                        //    residualAmount = 0;
                        //    VaultAtm vaultAtm = VaultAtm.LoadVaultAtm("atm_id =" + ATM.ATMId);


                        //    for (k = 0; k < denominations.Length; k++)
                        //    {
                        //        if (denominations[k] != string.Empty)
                        //        {
                        //            if (vaultAtm != null)
                        //            {
                        //                //ccmsVaultLedgerDetail = new CcmsVaultLedgerDetail();
                        //                ccmsVaultNoteType = CcmsVaultNoteType.LoadCcmsVaultNoteType("vault_id = " + vaultAtm.VaultId + " and denomination_name='" + denominations[k] + "'");
                        //                ccmsVaultLedgerDetail = new CcmsVaultLedgerDetail();
                        //                ccmsAddCountsVaultLedgerDetail = new CcmsVaultLedgerDetail();
                        //                ccmsVaultLedgerDetail.VaultNoteTypeId = ccmsVaultNoteType.Id;
                        //                ccmsAddCountsVaultLedgerDetail.VaultNoteTypeId = ccmsVaultNoteType.Id;
                        //            }
                        //            //ccmsATMLedgerDetail = new CcmsAtmLedgerDetail();
                        //            //ccmsAtmReplenishmentDispenseDetail = new CcmsAtmReplenishmentDispenseDetail();
                        //            //ccmsAtmReplenishmentResidualDetail = new CcmsAtmReplenishmentResidualDetail();
                        //            //ccmsAtmReplenishmentPurgeDetail = new CcmsAtmReplenishmentPurgeDetail();


                        //            //ccmsATMLedgerDetail.DenominationName = denominations[k];
                        //            //ccmsATMLedgerDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];

                        //            //ccmsAtmReplenishmentDispenseDetail.DenominationName = denominations[k];
                        //            //ccmsAtmReplenishmentDispenseDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];

                        //            //ccmsAtmReplenishmentResidualDetail.DenominationName = denominations[k];
                        //            //ccmsAtmReplenishmentResidualDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];

                        //            //ccmsAtmReplenishmentPurgeDetail.DenominationName = denominations[k];
                        //            //ccmsAtmReplenishmentPurgeDetail.NoteSetItemId = (long)htNoteSetItem[denominations[k]];




                        //            if (k == 0)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[6]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[20]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[6]) + int.Parse(subParts[20]);
                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[27]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[6]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[13]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[20]);


                        //            }
                        //            else if (k == 1)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[7]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[21]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[7]) + int.Parse(subParts[21]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[28]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[7]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[14]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[21]);
                        //            }
                        //            else if (k == 2)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[8]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[22]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[8]) + int.Parse(subParts[22]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[29]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[8]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[15]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[22]);

                        //            }
                        //            else if (k == 3)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[9]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[23]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[9]) + int.Parse(subParts[23]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[30]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[9]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[16]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[23]);
                        //            }
                        //            else if (k == 4)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[10]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[24]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[10]) + int.Parse(subParts[24]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[31]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[10]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[17]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[24]);
                        //            }
                        //            else if (k == 5)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[11]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[25]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[11]) + int.Parse(subParts[25]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[32]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[11]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[18]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[25]);
                        //            }
                        //            else if (k == 6)
                        //            {
                        //                residualAmount += (decimal)(long.Parse(subParts[12]) * int.Parse(denominations[k].Substring(3)));
                        //                residualAmount += (decimal)(long.Parse(subParts[26]) * int.Parse(denominations[k].Substring(3)));
                        //                if (ccmsVaultLedgerDetail != null)
                        //                    ccmsVaultLedgerDetail.Quantity = int.Parse(subParts[12]) + int.Parse(subParts[26]);

                        //                if (ccmsAddCountsVaultLedgerDetail != null)
                        //                    ccmsAddCountsVaultLedgerDetail.Quantity = int.Parse(subParts[33]);
                        //                //ccmsAtmReplenishmentResidualDetail.Quantity = long.Parse(subParts[12]);
                        //                //ccmsAtmReplenishmentDispenseDetail.Quantity = long.Parse(subParts[19]);
                        //                //ccmsAtmReplenishmentPurgeDetail.Quantity = long.Parse(subParts[26]);
                        //            }
                        //            if (ccmsAddCountsVaultLedgerDetail != null)
                        //                amount += (decimal)(ccmsAddCountsVaultLedgerDetail.Quantity * int.Parse(denominations[k].Substring(3)));
                        //            //residualAmount += (decimal)(ccmsAtmReplenishmentResidualDetail.Quantity * int.Parse(denominations[k].Substring(3)));
                        //            //list.Add(ccmsATMLedgerDetail);
                        //            //listDispensedDetail.Add(ccmsAtmReplenishmentDispenseDetail);
                        //            //listPurgeDetail.Add(ccmsAtmReplenishmentPurgeDetail);
                        //            //listResidualdDetail.Add(ccmsAtmReplenishmentResidualDetail);
                        //            listVaultLedgerDetail.Add(ccmsVaultLedgerDetail);
                        //            listAddCountsVaultLedgerDetail.Add(ccmsAddCountsVaultLedgerDetail);
                        //        }
                        //    }
                        //    //int vaultLedgerId = 0;
                        //    if (vaultAtm != null)
                        //    {
                        //        VaultInfo vaultInfo = CreateVaultLedger(vaultAtm.VaultId, residualAmount, vaultAtm.AtmId, "Cr", "Amount " + residualAmount + " Returned from replenishment", "Inbound", trxn);
                        //        for (int l = 0; l < listVaultLedgerDetail.Count; l++)
                        //            CreateVaultLedgerDetail(vaultInfo, listVaultLedgerDetail[l].Quantity, listVaultLedgerDetail[l].VaultNoteTypeId, "Cr", trxn);


                        //        VaultInfo tempVaultInfo = CreateTempVaultLedger(vaultAtm.VaultId, residualAmount, vaultAtm.AtmId, "Cr", "Amount " + residualAmount + " Returned from replenishment", "Inbound", trxn);
                        //        for (int l = 0; l < listVaultLedgerDetail.Count; l++)
                        //            CreateTempVaultLedgerDetail(tempVaultInfo, listVaultLedgerDetail[l].Quantity, listVaultLedgerDetail[l].VaultNoteTypeId, "Cr", trxn);

                        //        //                            ConnectionFactory.ExecuteQuery(string.Format(@"insert into ccms_temp_vault_ledger(
                        //        //                                                  [transaction_date] ,[description] ,[transaction_type] ,[ledger_amount] ,[balance] ,[posted_by]
                        //        //                                                  ,[vault_id] ,[vault_transaction_type] ,[cheque_id] ,[atm_id]) 
                        //        //                                                    select [transaction_date] ,[description] ,[transaction_type] ,[ledger_amount] ,[balance] ,[posted_by]
                        //        //                                                  ,[vault_id] ,[vault_transaction_type] ,[cheque_id] ,[atm_id] from ccms_vault_ledger
                        //        //                                                   where id = {0}; insert into ccms_temp_vault_ledger_detail(
                        //        //                                                   [ledger_id],[quantity] ,[vault_note_type_id],balance) 
                        //        //                                                    select scope_identity(),[quantity] ,[vault_note_type_id],balance from ccms_vault_ledger_detail
                        //        //                                                    where ledger_id = {0}", vaultInfo.newVaultId), trxn);

                        //        vaultInfo = CreateVaultLedger(vaultAtm.VaultId, amount, vaultAtm.AtmId, "Dr", "Amount " + amount + " deducted from vault", "Outbound", trxn);
                        //        for (int l = 0; l < listAddCountsVaultLedgerDetail.Count; l++)
                        //        {
                        //            CreateVaultLedgerDetail(vaultInfo, listAddCountsVaultLedgerDetail[l].Quantity, listAddCountsVaultLedgerDetail[l].VaultNoteTypeId, "Dr", trxn);
                        //            //listAddCountsVaultLedgerDetail[l].LedgerId = vaultInfo.newVaultId;
                        //            //listAddCountsVaultLedgerDetail[l].Save(trxn.Connection,trxn);
                        //        }
                        //        if (replenishment.CashOrderId > 0)
                        //        {
                        //            CcmsTempVaultLedger ccmsTempVaultLedger = CcmsTempVaultLedger.LoadCcmsTempVaultLedger("order_id=" + replenishment.CashOrderId);
                        //            if (ccmsTempVaultLedger != null)
                        //            {           //100,000    50,000
                        //                if (amount != ccmsTempVaultLedger.LedgerAmount)
                        //                {
                        //                    decimal diff = ccmsTempVaultLedger.LedgerAmount - amount;
                        //                    if (diff > 0) //+ve do credit entry 
                        //                    {
                        //                        tempVaultInfo = CreateTempVaultLedger(vaultAtm.VaultId, Math.Abs(diff), vaultAtm.AtmId, "Cr", "Amount " + Math.Abs(diff) + " Adjustment entry because CIT replenished with less counters", "Adjustment Credit", trxn);
                        //                        for (int l = 0; l < listAddCountsVaultLedgerDetail.Count; l++)
                        //                            CreateTempVaultLedgerDetail(tempVaultInfo, listAddCountsVaultLedgerDetail[l].Quantity, listAddCountsVaultLedgerDetail[l].VaultNoteTypeId, "Cr", trxn, ccmsTempVaultLedger.Id);
                        //                    }
                        //                    else // do debit
                        //                    {
                        //                        tempVaultInfo = CreateTempVaultLedger(vaultAtm.VaultId, Math.Abs(diff), vaultAtm.AtmId, "Dr", "Amount " + Math.Abs(diff) + " Adjustment entry because CIT replenished with more counters", "Adjustment Debit", trxn);
                        //                        for (int l = 0; l < listAddCountsVaultLedgerDetail.Count; l++)
                        //                            CreateTempVaultLedgerDetail(tempVaultInfo, listAddCountsVaultLedgerDetail[l].Quantity, listAddCountsVaultLedgerDetail[l].VaultNoteTypeId, "Dr", trxn, ccmsTempVaultLedger.Id);
                        //                    }
                        //                }
                        //            }
                        //        }


                        //    }
                        //}
                        //ccmsATMLedger.AtmId = ATMID;
                        //ccmsATMLedger.AtmLogId = ccmsATMLog.Id;
                        //ccmsATMLedger.TransactionDate = replenishment.RepDatetime;
                        //ccmsATMLedger.TransactionType = "Cr";
                        //ccmsATMLedger.Balance = amount;
                        //ccmsATMLedger.Mode = ccmsATMLog.EventMode;
                        //ccmsATMLedger.Type = subParts[1];
                        //ccmsATMLedger.TaskId = taskID;
                        //ccmsATMLedger.ProcessingDatetime = DateTime.Now;
                        //ccmsATMLedger.Save(trxn.Connection,trxn);

                        //for (int l = 0; l < list.Count; l++)
                        //{
                        //    list[l].AtmLedgerId = ccmsATMLedger.Id;
                        //    list[l].Save(trxn.Connection,trxn);
                        //    listDispensedDetail[l].AtmLedgerId = ccmsATMLedger.Id;
                        //    listDispensedDetail[l].Save(trxn.Connection,trxn);
                        //    listPurgeDetail[l].AtmLedgerId = ccmsATMLedger.Id;
                        //    listPurgeDetail[l].Save(trxn.Connection,trxn);
                        //    listResidualdDetail[l].AtmLedgerId = ccmsATMLedger.Id;
                        //    listResidualdDetail[l].Save(trxn.Connection,trxn);

                        //}

                        //GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.ReplenishmentAtATM, "Repenishment At ATM", trxn, Event_Type.Information, taskID);
                        //GenerateCCMSEvent(
                        //        EventType.ReplenishmentAtATM.ToString(),
                        //        EventType.ReplenishmentAtATM.ToString(),
                        //        Event_Type.Information.ToString(),
                        //        ccmsATMLedger.OrderNumber.ToString(),
                        //        EntityType.Order.ToString(),
                        //        Actors.ATM.ToString(),
                        //        Actors.CCMS.ToString(),
                        //        trxn, ccmsATMLedger.Id.ToString());

                        //Generate Event if ATM counters mismatch...
                        /*
                        CashOrders cashOrder = (replenishment.CashOrderId > 0 ?
                            CashOrders.LoadCashOrdersByPk(replenishment.CashOrderId.Value) :
                            //CashOrders.LoadCashOrders("atm_id=" + replenishment.AtmId + " and cash_order_datetime in  " +
                            //" (select max(cash_order_datetime)  " +
                            //" from cash_orders where atm_id=" + replenishment.AtmId +
                            //    " and replenishment_datetime>=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                            //    " and replenishment_datetime<=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) "));
                             CashOrders.LoadCashOrders("atm_id=" + replenishment.AtmId +
                                " and replenishment_datetime>=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                                " and replenishment_datetime<=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103) "));




                        //if (cashOrder == null)
                        //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order not found for atm : " + replenishment.AtmId
                        //         + " for the date " + replenishment.RepDatetime.ToString());

                        //if (replenishment.CashOrderId > 0)
                        //{
                        //  CashOrders cashOrder = CashOrders.LoadCashOrdersByPk(replenishment.CashOrderId.Value);
                        if (cashOrder != null)
                        {
                            replenishment.CashOrderId = cashOrder.CashOrderId;
                            //if (replenishment.CashAdded1 != cashOrder.Cassette1SuggestedNotes ||
                            //    replenishment.CashAdded2 != cashOrder.Cassette2SuggestedNotes ||
                            //    replenishment.CashAdded3 != cashOrder.Cassette3SuggestedNotes ||
                            //    replenishment.CashAdded4 != cashOrder.Cassette4SuggestedNotes ||
                            //    replenishment.CashAdded5 != cashOrder.Cassette5SuggestedNotes ||
                            //    replenishment.CashAdded6 != cashOrder.Cassette6SuggestedNotes ||
                            //    replenishment.CashAdded7 != cashOrder.Cassette7SuggestedNotes)
                            //{
                            //    //GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.SuspiciousReplenishment, replenishment.CashAdded1 +
                            //    //    "|" + replenishment.CashAdded2 + "|" + replenishment.CashAdded3 + "|" + replenishment.CashAdded4 + "|" +
                            //    //    replenishment.CashAdded5 + "|" + replenishment.CashAdded6 + "|" + replenishment.CashAdded7 + "|" +
                            //    //    cashOrder.Cassette1SuggestedNotes + "|" + cashOrder.Cassette2SuggestedNotes + "|" +
                            //    //    cashOrder.Cassette3SuggestedNotes + "|" + cashOrder.Cassette4SuggestedNotes + "|" +
                            //    //    cashOrder.Cassette5SuggestedNotes + "|" + cashOrder.Cassette6SuggestedNotes + "|" +
                            //    //    cashOrder.Cassette7SuggestedNotes

                            //}

                            //            , trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");
                            //        //GenerateCCMSEvent(EventType.SuspiciousReplenishment.ToString(),
                            //        //    EventType.SuspiciousReplenishment.ToString(), Event_Type.Warning.ToString(), cashOrder.OrderNumber, EntityType.Order.ToString(), Actors.ATM.ToString(), Actors.CCMS.ToString(), trxn, null);
                            //    }
                            //    // GenerateTerminalAlert(ATMID, (int)EnumAlertType.ATMCounterMismatch, "ATM Counter Mismatched", trxn);
                            int remainingNotesInCassette1 = cashOrder.Cassette1SuggestedNotes.Value - replenishment.CashAdded1;
                            int remainingNotesInCassette2 = cashOrder.Cassette2SuggestedNotes.Value - replenishment.CashAdded2;
                            int remainingNotesInCassette3 = cashOrder.Cassette3SuggestedNotes.Value - replenishment.CashAdded3;
                            int remainingNotesInCassette4 = cashOrder.Cassette4SuggestedNotes.Value - replenishment.CashAdded4;
                            int remainingNotesInCassette5 = cashOrder.Cassette5SuggestedNotes.Value - replenishment.CashAdded5;
                            int remainingNotesInCassette6 = cashOrder.Cassette6SuggestedNotes.Value - replenishment.CashAdded6;
                            int remainingNotesInCassette7 = cashOrder.Cassette7SuggestedNotes.Value - replenishment.CashAdded7;

                            cashOrder.Cassette1RemainingNotes = (remainingNotesInCassette1 != cashOrder.Cassette1RemainingNotes ? remainingNotesInCassette1 : cashOrder.Cassette1RemainingNotes);
                            cashOrder.Cassette2RemainingNotes = (remainingNotesInCassette2 != cashOrder.Cassette2RemainingNotes ? remainingNotesInCassette2 : cashOrder.Cassette2RemainingNotes);
                            cashOrder.Cassette3RemainingNotes = (remainingNotesInCassette3 != cashOrder.Cassette3RemainingNotes ? remainingNotesInCassette3 : cashOrder.Cassette3RemainingNotes);
                            cashOrder.Cassette4RemainingNotes = (remainingNotesInCassette4 != cashOrder.Cassette4RemainingNotes ? remainingNotesInCassette4 : cashOrder.Cassette4RemainingNotes);
                            cashOrder.Cassette5RemainingNotes = (remainingNotesInCassette5 != cashOrder.Cassette5RemainingNotes ? remainingNotesInCassette5 : cashOrder.Cassette5RemainingNotes);
                            cashOrder.Cassette6RemainingNotes = (remainingNotesInCassette6 != cashOrder.Cassette6RemainingNotes ? remainingNotesInCassette6 : cashOrder.Cassette6RemainingNotes);
                            cashOrder.Cassette7RemainingNotes = (remainingNotesInCassette7 != cashOrder.Cassette7RemainingNotes ? remainingNotesInCassette7 : cashOrder.Cassette7RemainingNotes);
                            cashOrder.LastReplenishmentAt = replenishment.RepDatetime;
                            cashOrder.Save(trxn.Connection, trxn);

                            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order updated for atm : " + replenishment.AtmId);


                            //CashOrderMonitoring cashOrderMonitoring = CashOrderMonitoring.LoadCashOrderMonitoring("current_order_id=" + cashOrder.CashOrderId);
                            CashOrderMonitoring cashOrderMonitoring = (cashOrder.CashOrderId > 0 ?
                                CashOrderMonitoring.LoadCashOrderMonitoring("current_order_id=" + cashOrder.CashOrderId)
                                : CashOrderMonitoring.LoadCashOrderMonitoring("atm_id=" + replenishment.AtmId +
                                " and replenishment_datetime>=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                                " and replenishment_datetime<=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) "));

                            //    if (cashOrderMonitoring == null)
                            //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order monitoring not found for atm : " + replenishment.AtmId
                            //             + " for the date " + replenishment.RepDatetime.ToString());

                            if (cashOrderMonitoring != null)
                            {
                                cashOrderMonitoring.CurrentOrderRemainingAmount = (decimal)(cashOrder.Cassette1RemainingNotes * noteSetType.DenominationType1 +
                                    cashOrder.Cassette2RemainingNotes * noteSetType.DenominationType2 + cashOrder.Cassette3RemainingNotes * noteSetType.DenominationType3 +
                                    cashOrder.Cassette4RemainingNotes * noteSetType.DenominationType4 + cashOrder.Cassette5RemainingNotes * noteSetType.DenominationType5 +
                                    cashOrder.Cassette6RemainingNotes * noteSetType.DenominationType6 + cashOrder.Cassette7RemainingNotes * noteSetType.DenominationType7);
                                cashOrderMonitoring.CurrentOrderExecutedAt = replenishment.RepDatetime;
                                cashOrderMonitoring.Save(trxn.Connection, trxn);
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order monitoring updated for atm : " + replenishment.AtmId);
                            }


                        }
                        */
                        //}
                        //                        }
                        //Generate event if ATM residual does not match with CCMS residual.

                        //                        SqlConnection conn = ConnectionFactory.GetNewConnection();
                        //                        try
                        //                        {
                        //                            conn.Open();
                        //                            SqlCommand cmd = conn.CreateCommand();
                        //                            cmd.CommandText = @"select replenishment_id 
                        //                                        from replenishment where rep_datetime in 
                        //                                        (select max(rep_datetime) from replenishment where atm_id = " + ATMID + " and rep_datetime < convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103))";
                        //                            object result = cmd.ExecuteScalar();
                        //                            if (result != null)
                        //                            {
                        //                                Replenishment secondLastReplenishment = Replenishment.LoadReplenishmentByPk(int.Parse(result.ToString()));

                        //                                cmd.CommandText = @"select sum(cash_dispensed1)*note_set_type.denomination_type_1+
                        //                                                           sum(cash_dispensed2)*note_set_type.denomination_type_2+
                        //                                                           sum(cash_dispensed3)*note_set_type.denomination_type_3+
                        //                                                           sum(cash_dispensed4)*note_set_type.denomination_type_4+
                        //                                                           sum(cash_dispensed5)*note_set_type.denomination_type_5+
                        //                                                           sum(cash_dispensed6)*note_set_type.denomination_type_6+
                        //                                                           sum(cash_dispensed7)*note_set_type.denomination_type_7
                        //                                            from parsed_transaction inner join atm 
                        //                                            on parsed_transaction.atm_id = atm.atm_id 
                        //                                            inner join note_set_type 
                        //                                            on atm.note_set_type_id = note_set_type.note_set_type_id 
                        //                                            where atm.atm_id = " + ATMID +
                        //                                                    "and trxn_datetime>=convert(datetime,'" + secondLastReplenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) " +
                        //                                                    " and trxn_datetime<=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) " +
                        //                                                   " group by note_set_type.denomination_type_1,note_set_type.denomination_type_2,note_set_type.denomination_type_3, " +
                        //                                                    " note_set_type.denomination_type_4, note_set_type.denomination_type_5,note_set_type.denomination_type_6,note_set_type.denomination_type_7";

                        //                                object disAmount = cmd.ExecuteScalar();
                        //                                if (disAmount != null)
                        //                                {
                        //                                    decimal dbResidual = (decimal)(secondLastReplenishment.CashAdded1 * noteSetType.DenominationType1 +
                        //                                        secondLastReplenishment.CashAdded2 * noteSetType.DenominationType2 +
                        //                                        secondLastReplenishment.CashAdded3 * noteSetType.DenominationType3 +
                        //                                        secondLastReplenishment.CashAdded4 * noteSetType.DenominationType4 +
                        //                                        secondLastReplenishment.CashAdded5 * noteSetType.DenominationType5 +
                        //                                        secondLastReplenishment.CashAdded6 * noteSetType.DenominationType6 +
                        //                                        secondLastReplenishment.CashAdded7 * noteSetType.DenominationType7) - decimal.Parse(disAmount.ToString());



                        //                                    if (residualAmount != dbResidual)
                        //                                    {
                        //                                        //if (secondLastReplenishment.CashOrderId > -1)
                        //                                        // {
                        //                                        //            cashOrder = (secondLastReplenishment.CashOrderId > 0 ?
                        //                                        //CashOrders.LoadCashOrdersByPk(secondLastReplenishment.CashOrderId.Value) :
                        //                                        //CashOrders.LoadCashOrders("cash_order_datetime in  " +
                        //                                        //" (select max(cash_order_datetime)  " +
                        //                                        //" from cash_orders where atm_id=" + replenishment.AtmId +
                        //                                        //    " and cash_order_datetime>=convert(datetime,'" + secondLastReplenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                        //                                        //    " and cash_order_datetime<=convert(datetime,'" + secondLastReplenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) "));


                        //                                        //cashOrder = CashOrders.LoadCashOrdersByPk(secondLastReplenishment.CashOrderId.Value);
                        //                                        // if (cashOrder != null)
                        //                                        //{
                        //                                        GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.ATMResidualMismatch, residualAmount + "|" + dbResidual + "|" + replenishment.ReplenishmentId + "|" + secondLastReplenishment.ReplenishmentId, trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");
                        //                                        //GenerateCCMSEvent(EventType.ATMResidualMismatch.ToString(),
                        //                                        //    EventType.ATMResidualMismatch.ToString(), Event_Type.Warning.ToString(), cashOrder.OrderNumber, EntityType.Order.ToString(), Actors.ATM.ToString(), Actors.CCMS.ToString(), trxn, null);
                        //                                        //}
                        //                                        // }

                        //                                    }
                        //                                }
                        //                                else
                        //                                {
                        //                                    //if (secondLastReplenishment.CashOrderId > -1)
                        //                                    //{
                        //                                    //cashOrder = CashOrders.LoadCashOrdersByPk(secondLastReplenishment.CashOrderId.Value);
                        //                                    //        cashOrder = (secondLastReplenishment.CashOrderId > 0 ?
                        //                                    //CashOrders.LoadCashOrdersByPk(secondLastReplenishment.CashOrderId.Value) :
                        //                                    //CashOrders.LoadCashOrders("cash_order_datetime in  " +
                        //                                    //" (select max(cash_order_datetime)  " +
                        //                                    //" from cash_orders where atm_id=" + replenishment.AtmId +
                        //                                    //    " and cash_order_datetime>=convert(datetime,'" + secondLastReplenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                        //                                    //    " and cash_order_datetime<=convert(datetime,'" + secondLastReplenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) "));

                        //                                    //        if (cashOrder != null)
                        //                                    //        {
                        //                                    //            GenerateCCMSEvent(EventType.ATMResidualMismatch.ToString(),
                        //                                    //                EventType.ATMResidualMismatch.ToString(), Event_Type.Warning.ToString(), cashOrder.OrderNumber, EntityType.Order.ToString(), Actors.ATM.ToString(), Actors.CCMS.ToString(), trxn, null);
                        //                                    //            GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.ATMResidualMismatch, "ATM Residual Mismatch", trxn, Event_Type.Information, taskID, null, null);
                        //                                    //        }
                        //                                    //}
                        //                                }
                        //                            }


                        //                        }
                        //                        finally
                        //                        {
                        //                            conn.Close();
                        //                        }

                        //////for emitac...



                        //currentCassetteStatus = parts[i];
                        //UpdateCashPosition(parts[i], ATM, noteSetType, trxn, taskID, null, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);
                        ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                        parserPostProcessingTask.AtmId = ATM.ATMId;
                        parserPostProcessingTask.CreationTime = DateTime.Now;
                        parserPostProcessingTask.EntityId = replenishment.ReplenishmentId;
                        parserPostProcessingTask.EventInfo = parts[i];
                        parserPostProcessingTask.EventOccuredAt = replenishment.RepDatetime;
                        parserPostProcessingTask.EventType = subParts[1];
                        parserPostProcessingTask.TaskId = taskID;
                        //parserPostProcessingTask.Save();
                        replenishmentPostProcessingQueue.Add(parserPostProcessingTask);
                        // 
                        //SaveReplenishmentPurgedCounts(subParts, trxn, taskID, j, replenishment);


                        //This means now i am in supervisory mode.
                        //Now the objective is to find where this supervisory activity ends;

                    }
                    #endregion
                }

                DataTable dt = null;

                if (parsedTransaction != null)
                {
                    dt = parsedTransaction.BulkSave(listParsedTrxns);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        parsedTrxnsPostProcessingQueue[i].EntityId = int.Parse(dt.Rows[i]["parsed_transaction_id"].ToString());
                        parsedTrxnsPostProcessingQueue[i].Save(DatabaseName.Cash);
                    }
                }
                if (parsedBnaCounter != null)
                    parsedBnaCounter.BulkSave(listParsedBnaCounter);

                //if (parsedCpmCounter != null)
                //    parsedCpmCounter.BulkSave(listparsedCpmCounter, trxn);

                // 24_07_26 commented by Jabbar - Rep to be save by EjParser only
                //if (replenishment != null)
                //{
                //    dt = replenishment.BulkSave(listReplenishment);
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        replenishmentPostProcessingQueue[i].EntityId = int.Parse(dt.Rows[i]["replenishment_id"].ToString());
                //        replenishmentPostProcessingQueue[i].Save(DatabaseName.Cash);
                //    }
                //}

                //if (cpmCountsCleared != null)
                //{
                //    dt = cpmCountsCleared.BulkSave(listCpmCountsCleared, trxn);
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        cpmCountsClearedQueue[i].EntityId = int.Parse(dt.Rows[i]["cpm_counts_cleared_id"].ToString());
                //        cpmCountsClearedQueue[i].Save(trxn.Connection, trxn, DatabaseName.Cash);
                //    }

                //}
                if (bnaCountsCleared != null)
                {
                    dt = bnaCountsCleared.BulkSave(listBNACountsCleared);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bnaCountsClearedQueue[i].EntityId = int.Parse(dt.Rows[i]["bna_counts_cleared_id"].ToString());
                        bnaCountsClearedQueue[i].Save(DatabaseName.Cash);
                    }
                }
                if (testCashPurgedNotes != null)
                {
                    dt = testCashPurgedNotes.BulkSave(listTestCashPurgedNotes);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        testCashPostProcessingQueue[i].EntityId = int.Parse(dt.Rows[i]["test_cash_purged_notes_id"].ToString());
                        testCashPostProcessingQueue[i].Save(DatabaseName.Cash);
                    }

                }
                //if (currentCPMStatus != null)
                //{
                //    ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                //    parserPostProcessingTask.AtmId = ATM.ATMId;
                //    parserPostProcessingTask.CreationTime = DateTime.Now;
                //    parserPostProcessingTask.EntityId = listparsedCpmCounter[listparsedCpmCounter.Count - 1].ParsedCpmCounterId;
                //    parserPostProcessingTask.EventInfo = currentCPMStatus;
                //    parserPostProcessingTask.EventOccuredAt = listparsedCpmCounter[listparsedCpmCounter.Count - 1].DepositAt;
                //    parserPostProcessingTask.EventType = "ChequeDepositSummary";
                //    parserPostProcessingTask.TaskId = taskID;
                //    parserPostProcessingTask.Save(trxn.Connection, trxn);
                //}
                if (currentBNAStatus != null)
                {
                    ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                    parserPostProcessingTask.AtmId = ATM.ATMId;
                    parserPostProcessingTask.CreationTime = DateTime.Now;
                    parserPostProcessingTask.EntityId = listParsedBnaCounter[listParsedBnaCounter.Count - 1].ParsedBnaCounterId;
                    parserPostProcessingTask.EventInfo = currentBNAStatus;
                    parserPostProcessingTask.EventOccuredAt = listParsedBnaCounter[listParsedBnaCounter.Count - 1].LastDepositAt;
                    parserPostProcessingTask.EventType = "CashDepositSummary";
                    parserPostProcessingTask.TaskId = taskID;
                    parserPostProcessingTask.Save(DatabaseName.Cash);
                }

            }

            finally
            {
                try
                {
                    task.EndTask();
                }
                catch (Exception ex)
                {
                }
            }


            //if (currentCassetteStatus != null)
            //{
            //    UpdateCashPosition(currentCassetteStatus, ATM, noteSetType, trxn, taskID);
            //}

            //update cash position





            //            trxn.Commit();

        }



    }
}
