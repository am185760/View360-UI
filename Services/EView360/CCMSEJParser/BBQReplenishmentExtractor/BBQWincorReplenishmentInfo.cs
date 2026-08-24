using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Data;
using System.Globalization;
using System.Configuration;
using EView360CashDAL;

namespace NCR.CCMS.Parser
{
    public class WincorReplenishmentExtractor
    {
        Regex StartRepRegex = new Regex(@"\*\d+\*\d+:\d+:\d+[ ]+SERVICEMODE[ ]ENTERED");
        //Regex RepCounterRegex = new Regex(@"(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]MACHINE NO\.:[ ]*\d+[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*ACTUAL RETRACTS[ ]*:[ ]*\d+[ ]*[ \r\n]*LAST CLEARED[ ]*:[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*\r?\n?[ ]*CARDS CAPTURED[ ]+(?<CardCapturedCount>\d+)");
        //Regex RepCounterRegex = new Regex(@"(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]MACHINE NO\.:[ ]*.+[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*ACTUAL RETRACTS[ ]*:[ ]*\d+[ ]*[ \r\n]*LAST CLEARED[ ]*:[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*\r?\n?[ ]*CARDS CAPTURED[ ]+(?<CardCapturedCount>\d+)");
        //Regex RepCounterRegex = new Regex(@"((?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]MACHINE NO\.:[ ]*.+[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+))");
        Regex RepCounterRegex = new Regex(@"(\d{1,2}:\d{1,2}:\d{1,2}[ ]+CASH COUNTERS BEFORE (SOP)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType1>\d{1,4})\*?[ ]*\r?\n?)([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType2>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType3>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType4>\d{1,4})\*?[ ]*\r?\n?)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType5>\d{1,4})\*?[ ]*\r?\n?)\r?\n?[ ]*?[ ]*RETRACTS:[ ]*\d+[ ]*[\r\n ]+(?<CashAddedTime>\d{1,2}:\d{1,2}:\d{1,2})[ ]+CASH COUNTERS AFTER (SOP)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*(?<DenominationType1>\d{1,4})[ ]*(?<NewCountType1>\d{1,4})\*?[ ]*\r?\n?)([ ]*[\*\w]+[ ]*(?<DenominationType2>\d{1,4})[ ]*(?<NewCountType2>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*(?<DenominationType3>\d{1,4})[ ]*(?<NewCountType3>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*(?<DenominationType4>\d{1,4})[ ]*(?<NewCountType4>\d{1,4})\*?[ ]*\r?\n?)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType5>\d{1,4})\*?[ ]*\r?\n?)\r?\n?[ ]*([ ]*RETRACTS[ ]*:[ ]*\d+[ ]*\r?\n?[ ]*))|((?<CashAddedTime>\d{1,2}:\d{1,2}:\d{1,2})[ ]+CASH COUNTERS AFTER (SOP)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*(?<DenominationType1>\d{1,4})[ ]*(?<NewCountType1>\d{1,4})\*?[ ]*\r?\n?)([ ]*[\*\w]+[ ]*(?<DenominationType2>\d{1,4})[ ]*(?<NewCountType2>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*(?<DenominationType3>\d{1,4})[ ]*(?<NewCountType3>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*(?<DenominationType4>\d{1,4})[ ]*(?<NewCountType4>\d{1,4})\*?[ ]*\r?\n?)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType5>\d{1,4})\*?[ ]*\r?\n?)\r?\n?[ ]*[ ]*RETRACTS[ ]*:[ ]*\d+[ ]*\r?\n?[ ]*REJECTS[ ]*:[ ]*(?<NewRejectCount>\d+)[ ]*[\r\n ]+\d{1,2}:\d{1,2}:\d{1,2}[ ]+CASH COUNTERS BEFORE (SOP)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType1>\d{1,4})\*?[ ]*\r?\n?)([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType2>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType3>\d{1,4})\*?[ ]*\r?\n?)?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType4>\d{1,4})\*?[ ]*\r?\n?)?[ ]*\r?\n?([ ]*[\*\w]+[ ]*\d{1,4}[ ]*(?<PrevCountType5>\d{1,4})\*?[ ]*\r?\n?)\r?\n?[ ]*[ ]*RETRACTS:[ ]*\d+[ ]*\r?\n?[ ]*REJECTS:[ ]*(?<OldRejectCount>\d+))");
        Match match;
        Match matchRepCounter;
        Match matchNextRepCounter;
        int StartIndex;
        int EndIndex;
        //string RepStartKeywords;
        string RepEndText;
        string TransStartText;
        byte matchCount = 0;

        ///<Summary>Edited by Ali Shah on 13th Oct, 2016
        ///Wrong Replenishment was made on future date
        //string[] TimeFormat = { "MM/dd/yy HH:mm", "dd/MM/yy HH:mm" };
        //string[] TimeFormat = { "dd/MM/yy HH:mm", "dd/MM/yyHH:mm:ss", "MM/dd/yy HH:mm", "MM/dd/yyHH:mm:ss" }; //QIIB
        string[] TimeFormat = { "MM/dd/yy HH:mm", "MM/dd/yyHH:mm:ss", "dd/MM/yy HH:mm", "MM/dd/yyHH:mm:ss" };   //Barwa

        /// <summary>
        /// Edited by Ali Shah on 27th March, 2017
        /// It is declared here to able to call from inside 'ComputeReplenishment' function
        /// as well as outside 'ComputeReplenishment' function
        /// </summary>
        AtmCounter notesUsedInTestCash = null;
        AtmCounter notesDenomination = null;

        //To resolve Low Balance or Out of Cash Alerts
        decimal minOperatingBalance = 0;
        static List<DateTime> listNormalDays = Utility.GetEvents("Normal");

        int NoOfNotesVariationInReplenishment = ConfigurationManager.AppSettings["NoOfNotesVariationInReplenishment"] != null ? int.Parse(ConfigurationManager.AppSettings["NoOfNotesVariationInReplenishment"]) : 10;

        public WincorReplenishmentExtractor()
        {
            StartIndex = -1;
            EndIndex = -1;
            RepEndText = "SERVICEMODE LEFT";
            TransStartText = "TRANSACTION START";

            /// Edited by Ali Shah on 27th March, 2017
            /// It is declared here to able to call from inside 'ComputeReplenishment' function
            /// as well as outside 'ComputeReplenishment' function
            notesUsedInTestCash = null;
        }
        public void ParseAndSaveReplenishment(ref string ejData, Task downloadTask, LogableTask task, SqlTransaction trxn)
        {
            SqlCommand cmd = null;
            AtmCompleteCounter initialCounterPosition = null;
            AtmCompleteCounter counterPositionJustAfterRep = null;
            AtmCompleteCounter finalCounterPosition = null;
            AtmCompleteCounter tempCounterPosition = null;
            string tempEj = "";
            //string ejDataUpper = ejData.ToUpper();
            try
            {
                //Edited by Ali Shah on 3rd Aug, 2016
                //Made this variable as global to get access in ExtractCashAdd function
                //bool isSwap = false;

                //Variable added by Ali Shah on 3rd June, 2016
                //To make sure that replenishment has been found then ExtractCashCount function would be executed
                bool isRepFound = false;
                LogableTask.LogMonoActivityTask("Extracting Replenishment for Wincor", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to check Replenishment without SOP in Wincor.");

                cmd = ConnectionFactory.GetNewCommand(true);
                
                initialCounterPosition = new AtmCompleteCounter();


                match = StartRepRegex.Match(ejData);
                while (match.Success)
                {
                    isRepFound = false;
                    StartIndex = match.Index;
                    matchCount = 0;
                    EvaluateEndIndex(ref ejData, StartIndex, out EndIndex, out tempEj, task);
                    matchRepCounter = RepCounterRegex.Match(tempEj);
                    while (matchRepCounter.Success && !isRepFound)
                    {
                        if (matchCount == 0)
                        {
                            StoreCountersInsideObject(ref initialCounterPosition, matchRepCounter);
                            matchCount++;
                        }
                        else
                        {
                            tempCounterPosition = new AtmCompleteCounter();
                            counterPositionJustAfterRep = new AtmCompleteCounter();
                            StoreCountersInsideObject(ref tempCounterPosition, matchRepCounter);
                            if (matchCount == 1 && tempCounterPosition != initialCounterPosition)
                            {
                                ///<Summary>
                                ///Edited by Ali Shah on 27th March, 2017
                                ///About this additional 'if' condition
                                ///To ensure there is some change in Remaining counters as well
                                ///Issue occurred when two consecutive test cash made entry in database for replenishment
                                //if ((tempCounterPosition.RemainingCounter.Type1 != initialCounterPosition.RemainingCounter.Type1) || (tempCounterPosition.RemainingCounter.Type2 != initialCounterPosition.RemainingCounter.Type2) || (tempCounterPosition.RemainingCounter.Type3 != initialCounterPosition.RemainingCounter.Type3) || (tempCounterPosition.RemainingCounter.Type4 != initialCounterPosition.RemainingCounter.Type4))
                                if ((tempCounterPosition.RemainingCounter.Type1 != initialCounterPosition.RemainingCounter.Type1) || (tempCounterPosition.RemainingCounter.Type2 != initialCounterPosition.RemainingCounter.Type2) || (tempCounterPosition.RemainingCounter.Type3 != initialCounterPosition.RemainingCounter.Type3) || (tempCounterPosition.RemainingCounter.Type4 != initialCounterPosition.RemainingCounter.Type4) || AtmCompleteCounter.IsCounterZero(counterPositionJustAfterRep.DispensedCounter))
                                {
                                    counterPositionJustAfterRep = tempCounterPosition;
                                    matchCount++;
                                    //isRepFound = true;
                                    matchNextRepCounter = matchRepCounter.NextMatch();
                                    //
                                    finalCounterPosition = new AtmCompleteCounter();
                                    while (matchNextRepCounter.Success && !isRepFound)
                                    {
                                        //StoreCountersInsideObject(ref tempCounterPosition, matchNextRepCounter);
                                        StoreCountersInsideObject(ref finalCounterPosition, matchNextRepCounter);
                                        //if (tempCounterPosition != counterPositionJustAfterRep)
                                        if (finalCounterPosition != counterPositionJustAfterRep)
                                        {
                                            //finalCounterPosition = tempCounterPosition;
                                            isRepFound = true;
                                            if (AtmCompleteCounter.IsCounterZero(finalCounterPosition.DispensedCounter))
                                                ComputeReplenishment(null, finalCounterPosition, tempEj, true, downloadTask, task, trxn);
                                            else
                                            {
                                                ///<Summary>
                                                ///It is confirmed by Talha that in Qatar, replenishment will only be done when there would be clear cash which means dispensed counters will always be zero at the time of Replenishment
                                                //ComputeReplenishment(initialCounterPosition, finalCounterPosition, tempEj, false, downloadTask, task, trxn);
                                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring as Replenishment " + ejData.Substring(match.Index, match.Length) + " as dispensed counters are not zero where as in Qatar, Clear Cash must be performed hence dispensed counters must be Zero in this case.");
                                            }

                                        }
                                        //Added by Ali Shah on 31 Aug while facing issue.
                                        matchNextRepCounter = matchNextRepCounter.NextMatch();
                                    }
                                    if (!isRepFound)
                                    {
                                        isRepFound = true;
                                        ///<Summary>
                                        ///Edited by Ali Shah on 25th April, 2018
                                        ///To correct previous code as finalCounterPosition would be always zero when there is only two print 
                                        ///counters, finalCounterPosition object will not be filled with any data.
                                        //if (AtmCompleteCounter.IsCounterZero(finalCounterPosition.DispensedCounter))
                                        //    ComputeReplenishment(null, finalCounterPosition, tempEj, true, downloadTask, task, trxn);
                                        //else
                                        //    ComputeReplenishment(initialCounterPosition, finalCounterPosition, tempEj, false, downloadTask, task, trxn);
                                        if (AtmCompleteCounter.IsCounterZero(counterPositionJustAfterRep.DispensedCounter))
                                            ComputeReplenishment(null, counterPositionJustAfterRep, tempEj, true, downloadTask, task, trxn);
                                        else
                                        {
                                            ///<Summary>
                                            ///It is confirmed by Talha that in Qatar, replenishment will only be done when there would be clear cash which means dispensed counters will always be zero at the time of Replenishment
                                            //ComputeReplenishment(initialCounterPosition, counterPositionJustAfterRep, tempEj, false, downloadTask, task, trxn);
                                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring as Replenishment " + ejData.Substring(match.Index, match.Length) + " as dispensed counters are not zero where as in Qatar, Clear Cash must be performed hence dispensed counters must be Zero in this case.");
                                        }
                                    }
                                }
                                else if (!ejData.Contains("SOP"))
                                {//3310
                                    notesUsedInTestCash = new AtmCounter();

                                    notesUsedInTestCash.Type1 = tempCounterPosition.RejectedCounter.Type1 - initialCounterPosition.RejectedCounter.Type1;
                                    notesUsedInTestCash.Type2 = tempCounterPosition.RejectedCounter.Type2 - initialCounterPosition.RejectedCounter.Type2;
                                    notesUsedInTestCash.Type3 = tempCounterPosition.RejectedCounter.Type3 - initialCounterPosition.RejectedCounter.Type3;
                                    notesUsedInTestCash.Type4 = tempCounterPosition.RejectedCounter.Type4 - initialCounterPosition.RejectedCounter.Type4;

                                    if (!AtmCompleteCounter.IsCounterZero(notesUsedInTestCash)) //Case Test Cash
                                    {
                                        EjParsedTransactions trans = EjParsedTransactions.LoadEjParsedTransactions("ATM_id = " + downloadTask.ATMId + " and trxn_datetime = Convert(datetime,'" + tempCounterPosition.CounterDateTime.ToString("dd/MM/yyyy HH:mm:ss") + "',103)");
                                        if (trans != null)  //Case if test cash transaction already inserted at same time
                                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Test Cash Transaction " + ejData.Substring(match.Index, match.Length) + " as it already exist.");
                                        else
                                        {
                                            trans = new EjParsedTransactions();
                                            trans.TrxnDatetime = tempCounterPosition.CounterDateTime;
                                            trans.NotesDispensedType1 = notesUsedInTestCash.Type1;
                                            trans.NotesDispensedType2 = notesUsedInTestCash.Type2;
                                            trans.NotesDispensedType3 = notesUsedInTestCash.Type3;
                                            trans.NotesDispensedType4 = notesUsedInTestCash.Type4;
                                            notesDenomination = GetNotesDenomination(downloadTask.ATMId);
                                            trans.Amount = CalculateAmount(notesUsedInTestCash, notesDenomination);
                                            trans.AtmId = downloadTask.ATMId;
                                            trans.TaskId = downloadTask.TaskId;
                                            trans.TransactionTypeId = CommentSaver.GetTransactionTypeId("TestCash");
                                            trans.ProcessingDatetime = DateTime.Now;
                                            trans.StartIndex = match.Index;
                                            trans.EndIndex = match.Index + match.Length;
                                            trans.Status = 0;
                                            trans.NotesRemainingType1 = tempCounterPosition.CassetteCounter.Type1;
                                            trans.NotesRemainingType1 = tempCounterPosition.CassetteCounter.Type1;
                                            trans.NotesRemainingType1 = tempCounterPosition.CassetteCounter.Type1;
                                            trans.NotesRemainingType1 = tempCounterPosition.CassetteCounter.Type1;
                                            trans.Save(trxn.Connection, trxn);

                                            initialCounterPosition = tempCounterPosition;
                                        }

                                    }
                                }
                            }
                            //matchRepCounter = matchRepCounter.NextMatch();
                        }
                        matchRepCounter = matchRepCounter.NextMatch();
                    }
                    ///<Summary>
                    ///Edited by Ali Shah on 27th April, 2018.
                    ///To handle the case when only one print counter is printed between the ServiceMode Entered and ServiceMode Left.
                    if (!isRepFound && matchCount > 0 && AtmCompleteCounter.IsCounterZero(initialCounterPosition.DispensedCounter) && !AtmCompleteCounter.IsCounterZero(initialCounterPosition.CassetteCounter))
                    {
                        ///<Summary>
                        ///Edited by Ali Shah on 09th May, 2018
                        ///Objective to validate replenishment when there is only one print counter is printed between ServiceMode Entered and ServiceMode Left.
                        ///Handling the case when the CIT did replenishment on one day and there is no transaction occurs on the ATM and the other day CIT just print counters. 
                        ///This case should be mark as one replenishment instead of two.
                        ///</Summary>
                        if (IsValidReplenishment(initialCounterPosition, downloadTask, task, trxn, cmd))
                            ComputeReplenishment(null, initialCounterPosition, tempEj, true, downloadTask, task, trxn);
                    }
                    match = match.NextMatch();
                }
                

            }


            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
        }

        private void EvaluateEndIndex(ref string ejData, int startIndex, out int endIndex, out string tempEj, LogableTask task)
        {
            int tempEndIndex = -1;

            string tempStr = ejData.Substring(startIndex);
            //string tempStrUpper = tempStr.ToUpper();
            endIndex = -1;
            tempEj = "";

            if (tempStr.Contains(RepEndText))    //ServiceMode Left
            {
                tempEndIndex = ejData.IndexOf(RepEndText, startIndex);
                tempStr = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);

                if (tempStr.Contains(TransStartText))   //Transaction Exist between ServiceMode Entered and ServiceMode Left
                {
                    tempEndIndex = ejData.IndexOf(TransStartText, startIndex);
                    tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);
                }
                else
                {
                    tempEndIndex += RepEndText.Length;  //RepEndText.Length to include text 'ServiceMode Left' 
                    tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);   
                }
            }
            else
            {
                tempEndIndex = ejData.Length - 1;   //End of File
                tempStr = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);

                if (tempStr.Contains(TransStartText.ToUpper()))   //Transaction Exist between ServiceMode Entered and ServiceMode Left
                {
                    tempEndIndex = ejData.IndexOf(TransStartText.ToUpper(), startIndex);
                    tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);
                }
                else
                    tempEj = ejData.Substring(startIndex);
            }
        }

        //private void EvaluateEndIndex(string ejData, int startIndex, out int endIndex, out string tempEj, LogableTask task)
        //{
        //    int tempEndIndex = -1;
        //    string tempStr = ejData.Substring(startIndex);
        //    string tempStrUpper = tempStr.ToUpper();
        //    endIndex = -1;
        //    tempEj = "";

        //    if (tempStr.ToUpper().Contains(RepEndText.ToUpper()))    //ServiceMode Left
        //    {
        //        tempEndIndex = ejData.ToUpper().IndexOf(RepEndText.ToUpper(), startIndex);
        //        tempStr = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);

        //        if (tempStr.ToUpper().Contains(TransStartText.ToUpper()))   //Transaction Exist between ServiceMode Entered and ServiceMode Left
        //        {
        //            tempEndIndex = ejData.ToUpper().IndexOf(TransStartText.ToUpper(), startIndex);
        //            tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);
        //        }
        //        else
        //        {
        //            tempEndIndex += RepEndText.Length;  //RepEndText.Length to include text 'ServiceMode Left' 
        //            tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);
        //        }
        //    }
        //    else
        //    {
        //        tempEndIndex = ejData.Length - 1;   //End of File
        //        tempStr = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);

        //        if (tempStr.ToUpper().Contains(TransStartText.ToUpper()))   //Transaction Exist between ServiceMode Entered and ServiceMode Left
        //        {
        //            tempEndIndex = ejData.ToUpper().IndexOf(TransStartText.ToUpper(), startIndex);
        //            tempEj = ejData.Substring(startIndex, tempEndIndex - startIndex + 1);
        //        }
        //        else
        //            tempEj = ejData.Substring(startIndex);
        //    }
        //}

        public void StoreCountersInsideObject(ref AtmCompleteCounter atmCompleteCounter, Match match)
        {
            DateTime date;
            //Edited by Ali Shah on 8th Sep, 2016
            //Datetime format was changed for Barwa Bank and it was different for QIIB
            //atmCompleteCounter.CounterDateTime = (match.Groups["PrintCountersDateTime"].Success) ? DateTime.ParseExact(match.Groups["PrintCountersDateTime"].Value, "dd/MM/yy HH:mm", null) : DateTime.Today;
            if (match.Groups["PrintCountersDateTime"].Success)
                DateTime.TryParseExact(match.Groups["PrintCountersDateTime"].Value, TimeFormat, null, DateTimeStyles.None, out date);
            else
                date = DateTime.Today;

            atmCompleteCounter.CounterDateTime = date;
            //
            atmCompleteCounter.StartIndex = match.Index;
            atmCompleteCounter.EndIndex = match.Index + match.Length;

            //Type1
            if (match.Groups["Cassette1"].Success)
                atmCompleteCounter.CassetteCounter.Type1 = int.Parse(match.Groups["Cassette1"].Value);
            if (match.Groups["Rejected1"].Success)
                atmCompleteCounter.RejectedCounter.Type1 = int.Parse(match.Groups["Rejected1"].Value);
            if (match.Groups["Remaining1"].Success)
                atmCompleteCounter.RemainingCounter.Type1 = int.Parse(match.Groups["Remaining1"].Value);
            if (match.Groups["Dispensed1"].Success)
                atmCompleteCounter.DispensedCounter.Type1 = int.Parse(match.Groups["Dispensed1"].Value);
            if (match.Groups["Total1"].Success)
                atmCompleteCounter.TotalCounter.Type1 = int.Parse(match.Groups["Total1"].Value);

            //Type2
            if (match.Groups["Cassette2"].Success)
                atmCompleteCounter.CassetteCounter.Type2 = int.Parse(match.Groups["Cassette2"].Value);
            if (match.Groups["Rejected2"].Success)
                atmCompleteCounter.RejectedCounter.Type2 = int.Parse(match.Groups["Rejected2"].Value);
            if (match.Groups["Remaining2"].Success)
                atmCompleteCounter.RemainingCounter.Type2 = int.Parse(match.Groups["Remaining2"].Value);
            if (match.Groups["Dispensed2"].Success)
                atmCompleteCounter.DispensedCounter.Type2 = int.Parse(match.Groups["Dispensed2"].Value);
            if (match.Groups["Total2"].Success)
                atmCompleteCounter.TotalCounter.Type2 = int.Parse(match.Groups["Total2"].Value);

            //Type3
            if (match.Groups["Cassette3"].Success)
                atmCompleteCounter.CassetteCounter.Type3 = int.Parse(match.Groups["Cassette3"].Value);
            if (match.Groups["Rejected3"].Success)
                atmCompleteCounter.RejectedCounter.Type3 = int.Parse(match.Groups["Rejected3"].Value);
            if (match.Groups["Remaining3"].Success)
                atmCompleteCounter.RemainingCounter.Type3 = int.Parse(match.Groups["Remaining3"].Value);
            if (match.Groups["Dispensed3"].Success)
                atmCompleteCounter.DispensedCounter.Type3 = int.Parse(match.Groups["Dispensed3"].Value);
            if (match.Groups["Total3"].Success)
                atmCompleteCounter.TotalCounter.Type3 = int.Parse(match.Groups["Total3"].Value);

            //Type4
            if (match.Groups["Cassette4"].Success)
                atmCompleteCounter.CassetteCounter.Type4 = int.Parse(match.Groups["Cassette4"].Value);
            if (match.Groups["Rejected4"].Success)
                atmCompleteCounter.RejectedCounter.Type4 = int.Parse(match.Groups["Rejected4"].Value);
            if (match.Groups["Remaining4"].Success)
                atmCompleteCounter.RemainingCounter.Type4 = int.Parse(match.Groups["Remaining4"].Value);
            if (match.Groups["Dispensed4"].Success)
                atmCompleteCounter.DispensedCounter.Type4 = int.Parse(match.Groups["Dispensed4"].Value);
            if (match.Groups["Total4"].Success)
                atmCompleteCounter.TotalCounter.Type4 = int.Parse(match.Groups["Total4"].Value);
        }

        public bool IsClearCash(string strReplenishment, AtmCompleteCounter atmCompleteCounter)
        {
            bool isClearCash = true;
            if (!strReplenishment.ToUpper().Contains("CLEAR CASH"))
                isClearCash = ((atmCompleteCounter.DispensedCounter.Type1 == 0) && (atmCompleteCounter.DispensedCounter.Type2 == 0) && (atmCompleteCounter.DispensedCounter.Type3 == 0) && (atmCompleteCounter.DispensedCounter.Type4 == 0));
            return isClearCash;
        }

        public void ComputeReplenishment(AtmCompleteCounter initialCounter, AtmCompleteCounter finalCounter, string ejData, bool isSwap, Task downloadTask, LogableTask task, SqlTransaction trxn)
        {
            SqlCommand cmd = null;
            EjParsedReplenishments parsedReplenishment = null;
            bool isRepInserted = false;
            EjNotesDispensed cashCountClear = null;
            //AtmCounter notesUsedInTestCash = null;
            //AtmCounter notesDenomination = null;

            ///<Summary>
            ///Added by Ali Shah on 28th May, 2017
            ///To handle Alerts when replenishment occurred.
            bool isOutOfCashAlertGenerated = false;
            bool isOutOfCashAlertResolved = false;
            bool isLowBalanceAlertResolved = false;
            bool isLowBalanceAlertGenerated = false;
            
            if (AtmCompleteCounter.IsCounterZero(finalCounter.CassetteCounter))
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Replenishment On " + finalCounter.CounterDateTime.ToString() + " for Task Id " + downloadTask.TaskId + ".becauseall counters are 0.");
                return;
            }

            parsedReplenishment = new EjParsedReplenishments();
            notesUsedInTestCash = new AtmCounter();
            cmd = ConnectionFactory.GetNewCommand(true);

            parsedReplenishment.RepDatetime = finalCounter.CounterDateTime;
            parsedReplenishment.ProcessingDatetime = DateTime.Now;
            parsedReplenishment.StartIndex = finalCounter.StartIndex;
            parsedReplenishment.EndIndex = finalCounter.EndIndex;
            parsedReplenishment.AtmId = downloadTask.ATMId;
            parsedReplenishment.TaskId = downloadTask.TaskId;

            //Clear Cash
            if (isSwap)
            {
                parsedReplenishment.NotesAddedType1 = finalCounter.RemainingCounter.Type1;
                parsedReplenishment.NotesAddedType2 = finalCounter.RemainingCounter.Type2;
                parsedReplenishment.NotesAddedType3 = finalCounter.RemainingCounter.Type3;
                parsedReplenishment.NotesAddedType4 = finalCounter.RemainingCounter.Type4;
                
                notesUsedInTestCash.Type1 = finalCounter.RejectedCounter.Type1;
                notesUsedInTestCash.Type2 = finalCounter.RejectedCounter.Type2;
                notesUsedInTestCash.Type3 = finalCounter.RejectedCounter.Type3;
                notesUsedInTestCash.Type4 = finalCounter.RejectedCounter.Type4;
            }
            //Add Cash
            else       
            {
                parsedReplenishment.NotesAddedType1 = finalCounter.RemainingCounter.Type1 - initialCounter.CassetteCounter.Type1;
                parsedReplenishment.NotesAddedType2 = finalCounter.RemainingCounter.Type2 - initialCounter.CassetteCounter.Type2;
                parsedReplenishment.NotesAddedType3 = finalCounter.RemainingCounter.Type3 - initialCounter.CassetteCounter.Type3;
                parsedReplenishment.NotesAddedType4 = finalCounter.RemainingCounter.Type4 - initialCounter.CassetteCounter.Type4;

                notesUsedInTestCash.Type1 = finalCounter.RejectedCounter.Type1 - initialCounter.RejectedCounter.Type1;
                notesUsedInTestCash.Type2 = finalCounter.RejectedCounter.Type2 - initialCounter.RejectedCounter.Type2;
                notesUsedInTestCash.Type3 = finalCounter.RejectedCounter.Type3 - initialCounter.RejectedCounter.Type3;
                notesUsedInTestCash.Type4 = finalCounter.RejectedCounter.Type4 - initialCounter.RejectedCounter.Type4;
            }

            //Edited by Ali Shah on 15th Oct, 2016
            //cmd.CommandText = "isRepCountersExists";
            cmd.CommandText = "isRepCountersInHourExists";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("RepDate", SqlDbType.DateTime));
            cmd.Parameters[0].Value = parsedReplenishment.RepDatetime;
            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
            cmd.Parameters[1].Value = parsedReplenishment.AtmId;
            cmd.Parameters.Add(new SqlParameter("notes1", SqlDbType.Int));
            cmd.Parameters[2].Value = parsedReplenishment.NotesAddedType1;
            cmd.Parameters.Add(new SqlParameter("notes2", SqlDbType.Int));
            cmd.Parameters[3].Value = parsedReplenishment.NotesAddedType2;
            cmd.Parameters.Add(new SqlParameter("notes3", SqlDbType.Int));
            cmd.Parameters[4].Value = parsedReplenishment.NotesAddedType3;
            cmd.Parameters.Add(new SqlParameter("notes4", SqlDbType.Int));
            cmd.Parameters[5].Value = parsedReplenishment.NotesAddedType4;

            if ((int)cmd.ExecuteScalar() > 0)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Replenishment " + finalCounter.CounterDateTime.ToString() + " for Task Id " + downloadTask.TaskId + ".because this already exists in ej_parsed_replenishment table.");
                return;
            }

            if (!AtmCompleteCounter.IsCounterZero(notesUsedInTestCash)) //Case Test Cash
            {
                EjParsedTransactions trans = EjParsedTransactions.LoadEjParsedTransactions("ATM_id = " + downloadTask.ATMId + " and trxn_datetime = Convert(datetime,'" + Convert.ToDateTime(parsedReplenishment.RepDatetime).ToString("dd/MM/yyyy HH:mm:ss") + "',103)");
                if (trans != null)  //Case if test cash transaction already inserted at same time
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Test Cash Transaction " + ejData.Substring(match.Index, match.Length) + " as it already exist.");
                else
                {
                    notesDenomination = GetNotesDenomination(downloadTask.ATMId);
                    decimal amount = CalculateAmount(notesUsedInTestCash, notesDenomination);
                    InsertTestCashAsTransaction(parsedReplenishment, amount, notesUsedInTestCash, finalCounter.CassetteCounter, downloadTask, task, trxn);
                }

            }
            parsedReplenishment.Save(trxn.Connection, trxn);
            isRepInserted = true;

            cmd.CommandText = "isReplenishmentSameInHour";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("RepDate", SqlDbType.DateTime));
            cmd.Parameters[0].Value = parsedReplenishment.RepDatetime;
            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
            cmd.Parameters[1].Value = downloadTask.ATMId;
            cmd.Parameters.Add(new SqlParameter("notes1", SqlDbType.Int));
            cmd.Parameters[2].Value = parsedReplenishment.NotesAddedType1;
            cmd.Parameters.Add(new SqlParameter("notes2", SqlDbType.Int));
            cmd.Parameters[3].Value = parsedReplenishment.NotesAddedType2;
            cmd.Parameters.Add(new SqlParameter("notes3", SqlDbType.Int));
            cmd.Parameters[4].Value = parsedReplenishment.NotesAddedType3;
            cmd.Parameters.Add(new SqlParameter("notes4", SqlDbType.Int));
            cmd.Parameters[5].Value = parsedReplenishment.NotesAddedType4;



            if ((int)cmd.ExecuteScalar() > 0)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Replenishment already extracted from counters so ignoring it for atm " + parsedReplenishment.AtmId + " for the date " + parsedReplenishment.RepDatetime + " for Task Id: " + downloadTask.TaskId);
                match = match.NextMatch();
                //isSwap = false;
                isRepInserted = false;
                return;
            }
            else
            {
                this.AddReplenishmentInCCMS(ref downloadTask, ref parsedReplenishment, ref trxn, ref isSwap);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Extracting replenishment " + this.match.ToString() + " for Task Id: " + downloadTask.TaskId);
            }

            //Replenishment replenishment = Replenishment.LoadReplenishment(string.Concat(new object[] { "atm_id = ", downloadTask.ATMId, " and rep_datetime>=convert(datetime,'", parsedReplenishment.RepDatetime.Value.ToString("dd/MM/yyyy"), "',103)  and rep_datetime<=convert(datetime,'", parsedReplenishment.RepDatetime.Value.ToString("dd/MM/yyyy"), " 23:59:59',103) " }));
            //if (replenishment == null) // This means Replenishment not inserted by EJ & Counters also so insert it
            //{
            //    //lastSavedReplenishment = this.AddReplenishmentInCCMS(ref downloadTask, ref cashAdded, ref trxn, ref isSwap);
            //    this.AddReplenishmentInCCMS(ref downloadTask, ref parsedReplenishment, ref trxn, ref isSwap);
            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "extracting replenishment " + this.match.ToString());
            //    //Added on 05/02/2015
            //    isSwap = false;
            //}
            //else
            //{

            //    if (replenishment.Reason != null)
            //    {
            //        //If it's extracted from EJ then update it.
            //        if (isSwap)
            //        {
            //            this.AddReplenishmentInCCMS(ref downloadTask, ref parsedReplenishment, ref trxn, ref isSwap);
            //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "extracting replenishment " + this.match.ToString());
            //            isSwap = false;

            //        }
            //        else
            //        {
            //            replenishment.CashAdded1 += parsedReplenishment.NotesAddedType1.Value;
            //            replenishment.CashAdded2 += parsedReplenishment.NotesAddedType2.Value;
            //            replenishment.CashAdded3 += parsedReplenishment.NotesAddedType3.Value;
            //            replenishment.CashAdded4 += parsedReplenishment.NotesAddedType4.Value;
            //            //Edited by Ali Shah on 3rd Aug, 2016
            //            replenishment.RepDatetime = parsedReplenishment.RepDatetime.Value;
            //        }
            //        replenishment.IsSwap = isSwap;
            //        replenishment.Save(trxn.Connection, trxn);
            //        //lastSavedReplenishment = replenishment;
            //        isSwap = false;
            //    }
            //}

            if (isRepInserted)
            {
                cashCountClear = new EjNotesDispensed();

                cashCountClear.ClearingDatetime = finalCounter.CounterDateTime;
                cashCountClear.NotesRemainingType1 = finalCounter.CassetteCounter.Type1;
                cashCountClear.NotesRemainingType2 = finalCounter.CassetteCounter.Type2;
                cashCountClear.NotesRemainingType3 = finalCounter.CassetteCounter.Type3;
                cashCountClear.NotesRemainingType4 = finalCounter.CassetteCounter.Type4;

                cmd.CommandText = "isEjClearingCounterExists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("DisDate", SqlDbType.DateTime));
                cmd.Parameters[0].Value = cashCountClear.ClearingDatetime;
                cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                cmd.Parameters[1].Value = downloadTask.ATMId;

                if ((int)cmd.ExecuteScalar() > 0)
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in dispensed table.");
                    return;
                }

                cashCountClear.TaskId = downloadTask.TaskId;
                cashCountClear.AtmId = downloadTask.ATMId;
                cashCountClear.Save(trxn.Connection, trxn);

                /// Added by Ali Shah on 08th Feb, 2017
                /// To update cash position just after replenishment, before it was updating 
                /// when first withdrawal transaction occurs after replenishment
                //UpdateCashPositionAfterReplenishment(cashCountClear, trxn);
                UpdateCashPositionAfterReplenishment(cashCountClear, downloadTask.TaskId, task, trxn, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);
                
                isRepInserted = false;
            }
        }

        private Replenishment AddReplenishmentInCCMS(ref Task downloadTask, ref EjParsedReplenishments cashAdded, ref SqlTransaction trxn, ref bool isSwap)
        {
            Replenishment replenishment2 = new Replenishment();
            replenishment2.AtmId = downloadTask.ATMId;
            replenishment2.RepDatetime = cashAdded.RepDatetime.Value;
            replenishment2.CashAdded1 = cashAdded.NotesAddedType1.Value;
            replenishment2.CashAdded2 = cashAdded.NotesAddedType2.Value;
            replenishment2.CashAdded3 = cashAdded.NotesAddedType3.Value;
            replenishment2.CashAdded4 = cashAdded.NotesAddedType4.Value;
            replenishment2.CashAdded5 = 0;
            replenishment2.CashAdded6 = 0;
            replenishment2.CashAdded7 = 0;
            replenishment2.RepStatus = "WincorRepMissing";
            replenishment2.IsSwap = isSwap;

            if (!isSwap)
            {
                if (replenishment2.CashAdded1 > 0 && replenishment2.CashAdded2 > 0 && replenishment2.CashAdded3 > 0 && replenishment2.CashAdded4 > 0)
                {
                    isSwap = true;
                    replenishment2.IsSwap = true;
                }
            }

            replenishment2.TaskId = downloadTask.TaskId;
            replenishment2.CashOrderId = -1;
            replenishment2.GeneratedAt = DateTime.Now;
            replenishment2.GeneratedBy = 1;
            replenishment2.Reason = cashAdded.EjParsedReplenishmentsId.ToString();
            replenishment2.Save(trxn.Connection, trxn);
            //Added on 11/11 to retain counts cleared status when custodian select ADD CASH by mistake.
            //Change done on 05/02/2015
            //Change done on 05/02/2015
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //else
            //   isSwap = false;

            return replenishment2;
        }

        private decimal CalculateAmount(AtmCounter notesDispensed, AtmCounter denomination)
        {
            decimal amount = 0;
            amount = (notesDispensed.Type1 * denomination.Type1) + (notesDispensed.Type2 * denomination.Type2) + (notesDispensed.Type3 * denomination.Type3) + (notesDispensed.Type4 * denomination.Type4);
            return amount;
        }

        private void InsertTestCashAsTransaction(EjParsedReplenishments cashAdded, decimal amount, AtmCounter notesDispensed,  AtmCounter notesRemaining, Task downloadTask, LogableTask task, SqlTransaction dbTrxn)
        {
            EjParsedTransactions parsedTrxn = null;
            try
            {
                parsedTrxn = new EjParsedTransactions();
                parsedTrxn.TrxnDatetime = cashAdded.RepDatetime;
                parsedTrxn.Amount = amount;
                parsedTrxn.NotesDispensedType1 = notesDispensed.Type1;
                parsedTrxn.NotesDispensedType2 = notesDispensed.Type2;
                parsedTrxn.NotesDispensedType3 = notesDispensed.Type3;
                parsedTrxn.NotesDispensedType4 = notesDispensed.Type4;

                parsedTrxn.AtmId = downloadTask.ATMId;
                parsedTrxn.TaskId = downloadTask.TaskId;
                parsedTrxn.TransactionTypeId = CommentSaver.GetTransactionTypeId("TestCash");
                parsedTrxn.ProcessingDatetime = DateTime.Now;
                parsedTrxn.StartIndex = cashAdded.StartIndex;
                parsedTrxn.EndIndex = cashAdded.EndIndex;
                parsedTrxn.Status = 0;
                parsedTrxn.NotesRemainingType1 = notesRemaining.Type1;
                parsedTrxn.NotesRemainingType2 = notesRemaining.Type2;
                parsedTrxn.NotesRemainingType3 = notesRemaining.Type3;
                parsedTrxn.NotesRemainingType4 = notesRemaining.Type4;

                parsedTrxn.Save(dbTrxn.Connection, dbTrxn);
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
            }
        }

        private AtmCounter GetNotesDenomination(long atmId)
        {
            AtmCounter denomination = new AtmCounter();
            /////////
            //Currently it will reflect zero counters
            ////////
            return denomination;
        }

        /// <summary>
        /// Added by Ali Shah on 08th Feb, 2017
        /// To update cash position just after replenishment, before it was updating 
        /// when first withdrawal transaction occurs after replenishment.
        /// </summary>

        private void UpdateCashPositionAfterReplenishment(EjNotesDispensed cashCountRemaining, int TaskId, LogableTask task, SqlTransaction trxn, ref bool isOutOfCashAlertResolved, ref bool isLowBalanceAlertResolved, ref bool isOutOfCashAlertGenerated, ref  bool isLowBalanceAlertGenerated)
        {
            //LogableTask task = LogableTask.NewTask();
            try
            {
                DateTime lastTrxnAt = cashCountRemaining.ClearingDatetime.Value;

                EjCashPosition cashPositionAfterReplenishment = EjCashPosition.LoadEjCashPosition("atm_id =" + cashCountRemaining.AtmId + " and last_trxn_at >=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + "',103) " +
                    " and last_trxn_at <=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + " 23:59:59',103)");

                if (cashPositionAfterReplenishment != null)
                {

                    if (cashCountRemaining.ClearingDatetime.Value < cashPositionAfterReplenishment.LastTrxnAt)
                    {
                        LogableTask.LogMonoActivityTask("Ignore Trxn", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Cash position is not updated bcoz we have trxn of future date: " + cashPositionAfterReplenishment.LastTrxnAt);
                        return;
                    }

                    if (cashCountRemaining.NotesRemainingType1.HasValue)
                        cashPositionAfterReplenishment.Cassette1Notes = cashCountRemaining.NotesRemainingType1;
                    else
                        cashPositionAfterReplenishment.Cassette1Notes = 0;

                    if (cashCountRemaining.NotesRemainingType2.HasValue)
                        cashPositionAfterReplenishment.Cassette2Notes = cashCountRemaining.NotesRemainingType2;
                    else
                        cashPositionAfterReplenishment.Cassette2Notes = 0;

                    if (cashCountRemaining.NotesRemainingType3.HasValue)
                        cashPositionAfterReplenishment.Cassette3Notes = cashCountRemaining.NotesRemainingType3;
                    else
                        cashPositionAfterReplenishment.Cassette3Notes = 0;

                    if (cashCountRemaining.NotesRemainingType4.HasValue)
                        cashPositionAfterReplenishment.Cassette4Notes = cashCountRemaining.NotesRemainingType4;
                    else
                        cashPositionAfterReplenishment.Cassette4Notes = 0;

                    cashPositionAfterReplenishment.Cassette5Notes = 0;
                    cashPositionAfterReplenishment.Cassette6Notes = 0;
                    cashPositionAfterReplenishment.Cassette7Notes = 0;

                    cashPositionAfterReplenishment.TaskId = cashCountRemaining.TaskId.Value;
                    //cashPositionAfterReplenishment.Save(trxn.Connection, trxn);
                    cashPositionAfterReplenishment.Save();
                    EJToCounterMapper.EJToCounterMapper.EjCashPositionMigrator(cashPositionAfterReplenishment, trxn);
                }
                else // If there's no cash position for current day.
                {
                    DateTime? lastAtmTrxnAt;
                    cashPositionAfterReplenishment = new EjCashPosition();
                    cashPositionAfterReplenishment.AtmId = cashCountRemaining.AtmId.Value;

                    if (cashCountRemaining.NotesRemainingType1.HasValue)
                        cashPositionAfterReplenishment.Cassette1Notes = cashCountRemaining.NotesRemainingType1;
                    else
                        cashPositionAfterReplenishment.Cassette1Notes = 0;

                    if (cashCountRemaining.NotesRemainingType2.HasValue)
                        cashPositionAfterReplenishment.Cassette2Notes = cashCountRemaining.NotesRemainingType2;
                    else
                        cashPositionAfterReplenishment.Cassette2Notes = 0;

                    if (cashCountRemaining.NotesRemainingType3.HasValue)
                        cashPositionAfterReplenishment.Cassette3Notes = cashCountRemaining.NotesRemainingType3;
                    else
                        cashPositionAfterReplenishment.Cassette3Notes = 0;

                    if (cashCountRemaining.NotesRemainingType4.HasValue)
                        cashPositionAfterReplenishment.Cassette4Notes = cashCountRemaining.NotesRemainingType4;
                    else
                        cashPositionAfterReplenishment.Cassette4Notes = 0;

                    cashPositionAfterReplenishment.Cassette5Notes = 0;
                    cashPositionAfterReplenishment.Cassette6Notes = 0;
                    cashPositionAfterReplenishment.Cassette7Notes = 0;

                    ///<Summary>
                    ///Handling the case to get last transaction date when there is no cash position for today
                    ///And even when there is no cash position on any day, it will insert the replenishment time.
                    //cashPositionAfterReplenishment.LastTrxnAt = lastTrxnAt;
                    object result = ConnectionFactory.ExecuteScalar("Select MAX(last_trxn_at) from ej_cash_position with(nolock) where atm_id = " + cashCountRemaining.AtmId + " and last_trxn_at <= CONVERT(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy HH:mm:ss") + "', 103)");
                    lastAtmTrxnAt = (DateTime?)(result == DBNull.Value ? null : result);
                    cashPositionAfterReplenishment.LastTrxnAt = lastAtmTrxnAt != null ? lastAtmTrxnAt.Value : lastTrxnAt;

                    cashPositionAfterReplenishment.TaskId = cashCountRemaining.TaskId.Value;
                    //cashPositionAfterReplenishment.Save(trxn.Connection, trxn);
                    cashPositionAfterReplenishment.Save();
                    EJToCounterMapper.EJToCounterMapper.EjCashPositionMigrator(cashPositionAfterReplenishment, trxn);

                    #region ToResolveAlerts
                    decimal currentBalance = 0;
                    Atm atm = null;
                    if (cashCountRemaining.AtmId != null)
                    {
                        atm = Atm.LoadAtmByPk(cashCountRemaining.AtmId.Value);

                        NoteSetType noteSetType = NoteSetType.LoadNoteSetType("note_set_type_id =" + atm.NoteSetTypeId);

                        currentBalance = cashPositionAfterReplenishment.Cassette1Notes.Value * noteSetType.DenominationType1.Value
                        + cashPositionAfterReplenishment.Cassette2Notes.Value * noteSetType.DenominationType2.Value
                        + cashPositionAfterReplenishment.Cassette3Notes.Value * noteSetType.DenominationType3.Value
                        + cashPositionAfterReplenishment.Cassette4Notes.Value * noteSetType.DenominationType4.Value
                        + cashPositionAfterReplenishment.Cassette5Notes.Value * noteSetType.DenominationType5.Value
                        + cashPositionAfterReplenishment.Cassette6Notes.Value * noteSetType.DenominationType6.Value
                        + cashPositionAfterReplenishment.Cassette7Notes.Value * noteSetType.DenominationType7.Value;

                        minOperatingBalance = GetATMMinOperatingBalance(atm, cashPositionAfterReplenishment.LastTrxnAt);

                        ResolveAlerts(cashPositionAfterReplenishment, atm, TaskId, task, trxn, currentBalance, minOperatingBalance, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);

                    }
                    #endregion
                }
            }
            finally
            {
                try
                {
                    //task.EndTask();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("ReplenishmentInfo", ex.Message + " " + ex.StackTrace);
                }

            }
        }


        private void ResolveAlerts(EjCashPosition cashPosition, Atm atm, int TaskId, LogableTask task, SqlTransaction trxn, decimal currentBalance, decimal minOperatingBalance, ref bool isOutOfCashAlertResolved, ref bool isLowBalanceAlertResolved, ref bool isOutOfCashAlertGenerated, ref  bool isLowBalanceAlertGenerated)
        {
            bool isAlertGenEnabled = true;

            if ((int)ConnectionFactory.ExecuteScalar(" select count(*) from Cash_Position with (nolock) where atm_id =" + atm.ATMId + " and last_trxn_at > convert(datetime,'" + cashPosition.LastTrxnAt.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ", trxn) > 0)
                isAlertGenEnabled = false;

            if (currentBalance < minOperatingBalance && currentBalance > atm.OutOfCashThreshold)
            {
                if (isAlertGenEnabled)
                {
                    if (!isLowBalanceAlertGenerated)
                    {
                        string msg = cashPosition.Cassette1Notes.Value + "," +
                              cashPosition.Cassette2Notes.Value + "," + cashPosition.Cassette3Notes.Value + "," + cashPosition.Cassette4Notes.Value + "," +
                                  cashPosition.Cassette5Notes.Value + "," + cashPosition.Cassette6Notes.Value + "," + cashPosition.Cassette7Notes.Value + "," + currentBalance + "," + minOperatingBalance;
                        Utility.GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.MinOperatingBalance, msg, trxn, Event_Type.Alert, TaskId, null, null);
                        isLowBalanceAlertResolved = false;
                        isLowBalanceAlertGenerated = true;
                    }
                }
            }

            else if (currentBalance <= 0 || currentBalance <= atm.OutOfCashThreshold)
            {
                if (isAlertGenEnabled)
                {
                    if (!isOutOfCashAlertGenerated)
                    {
                        //Delete low balance alert before adding out of cash alert.
                        AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                        if (atmAlert != null)
                        {
                            atmAlert.Delete();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert deleted for atm_id = " + atm.ATMId);
                            CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                            if (ccmsIntAlert != null)
                            {
                                ccmsIntAlert.Delete();
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert deleted from ccms integrated alert for atm_id = " + atm.ATMId);
                            }
                        }


                        string msg = cashPosition.Cassette1Notes.Value + "," +
                           cashPosition.Cassette2Notes.Value + "," + cashPosition.Cassette3Notes.Value + "," + cashPosition.Cassette4Notes.Value + "," +
                               cashPosition.Cassette5Notes.Value + "," + cashPosition.Cassette6Notes.Value + "," + cashPosition.Cassette7Notes.Value + "," + currentBalance;
                        Utility.GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.ATMOutOfCash, msg, trxn, Event_Type.Alert, TaskId, null, null);
                        isOutOfCashAlertResolved = false;
                        isOutOfCashAlertGenerated = true;
                    }
                    //GenerateCCMSEvent(
                    //            EventType.ATMOutOfCash.ToString(),
                    //            EventType.ATMOutOfCash.ToString(),
                    //            Event_Type.Warning.ToString(),
                    //            ATMID.ToString(),
                    //            EntityType.ATM.ToString(),
                    //            Actors.ATM.ToString(),
                    //            Actors.CCMS.ToString(),
                    //            trxn, null);
                }
            }

            if (currentBalance > minOperatingBalance && isAlertGenEnabled)
            {
                if (!isLowBalanceAlertResolved)
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch low balance alert for atm_id = " + atm.ATMId);
                    AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                    if (atmAlert != null)
                    {
                        atmAlert.ResolveAt = DateTime.Now;
                        atmAlert.Save(trxn.Connection, trxn);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert resolved for atm_id = " + atm.ATMId);
                        CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                        if (ccmsIntAlert != null)
                        {
                            ccmsIntAlert.ResolvedAt = DateTime.Now;
                            ccmsIntAlert.Save(trxn.Connection, trxn);
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                        }
                        isLowBalanceAlertResolved = true;
                        isLowBalanceAlertGenerated = false;
                    }
                    else
                    {
                        isLowBalanceAlertResolved = true;//No need to look in database as there is no alert
                        isLowBalanceAlertGenerated = false;
                    }
                }
            }

            if (currentBalance > atm.OutOfCashThreshold && isAlertGenEnabled)
            {
                if (!isOutOfCashAlertResolved)
                {
                    AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.ATMOutOfCash + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                    if (atmAlert != null)
                    {
                        atmAlert.ResolveAt = DateTime.Now;
                        atmAlert.Save(trxn.Connection, trxn);
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert resolved for atm_id = " + atm.ATMId);
                        CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                        if (ccmsIntAlert != null)
                        {
                            ccmsIntAlert.ResolvedAt = DateTime.Now;
                            ccmsIntAlert.Save(trxn.Connection, trxn);
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                        }
                        isOutOfCashAlertResolved = true;
                        isOutOfCashAlertGenerated = false;
                    }
                    else
                    {
                        isOutOfCashAlertResolved = true;
                        isOutOfCashAlertGenerated = false;
                    }
                }
            }
        }

        decimal GetATMMinOperatingBalance(Atm atm, DateTime Day)
        {
            // decimal minOperatingBalance = 0;
            ///<Summary>
            ///Edited by Ali Shah on 26th April, 2018
            ///Changes occurred in else clause of this function.
            ///To handle error due to null value, this error was throwing when ATM's Min Operating Balance was not  Set.
            ///</Summary>
            

            if (listNormalDays.Contains(Day.Date))
            {
                if (atm.MinOperatingBalanceNormalDays.HasValue)
                    minOperatingBalance = atm.MinOperatingBalanceNormalDays.Value;
                else
                    //minOperatingBalance = atm.MinOperatingBalance.Value;
                    minOperatingBalance = atm.MinOperatingBalance.HasValue ? atm.MinOperatingBalance.Value : 0;
            }
            else
            {
                //Salary day...
                if (atm.MinOperatingBalanceSalaryDays.HasValue)
                    minOperatingBalance = atm.MinOperatingBalanceSalaryDays.Value;
                else
                    //minOperatingBalance = atm.MinOperatingBalance.Value;
                    minOperatingBalance = atm.MinOperatingBalance.HasValue ? atm.MinOperatingBalance.Value : 0;
            }
            return minOperatingBalance;

        }

        private bool IsValidReplenishment(AtmCompleteCounter initialCounterPosition, Task downloadTask, LogableTask task, SqlTransaction trxn, SqlCommand cmd)
        {
            bool isValidReplenishment = false;
            cmd.CommandText = "isWithdrawalsAfterRepExists";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("PrintCounterDateTime", SqlDbType.DateTime));
            cmd.Parameters[0].Value = initialCounterPosition.CounterDateTime;
            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
            cmd.Parameters[1].Value = downloadTask.ATMId;
            cmd.Parameters.Add(new SqlParameter("notes1", SqlDbType.Int));
            cmd.Parameters[2].Value = initialCounterPosition.RemainingCounter.Type1;
            cmd.Parameters.Add(new SqlParameter("notes2", SqlDbType.Int));
            cmd.Parameters[3].Value = initialCounterPosition.RemainingCounter.Type2;
            cmd.Parameters.Add(new SqlParameter("notes3", SqlDbType.Int));
            cmd.Parameters[4].Value = initialCounterPosition.RemainingCounter.Type3;
            cmd.Parameters.Add(new SqlParameter("notes4", SqlDbType.Int));
            cmd.Parameters[5].Value = initialCounterPosition.RemainingCounter.Type4;
            cmd.Parameters.Add(new SqlParameter("NoOfNotesInVariation", SqlDbType.Int));
            cmd.Parameters[6].Value = NoOfNotesVariationInReplenishment;

            //if ((int)cmd.ExecuteScalar() > 0)
            if ((bool)cmd.ExecuteScalar())
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Valid Replenishment at:  " + initialCounterPosition.CounterDateTime.ToString("dd/MM/yyyy HH:mm:ss") + " where Atm_Id: " + downloadTask.ATMId + " and Task Id: " + downloadTask.TaskId);
                isValidReplenishment = true;
            }
            return isValidReplenishment;
        }

        //private void UpdateCashPositionAfterReplenishment(EjNotesDispensed cashCountRemaining, SqlTransaction trxn)
        //{
        //    LogableTask task = LogableTask.NewTask();
        //    try
        //    {
        //        DateTime lastTrxnAt = cashCountRemaining.ClearingDatetime.Value;

        //        EjCashPosition cashPositionAfterReplenishment = EjCashPosition.LoadEjCashPosition("atm_id =" + cashCountRemaining.AtmId + " and last_trxn_at >=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + "',103) " +
        //            " and last_trxn_at <=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + " 23:59:59',103)");

        //        if (cashPositionAfterReplenishment != null)
        //        {

        //            if (cashCountRemaining.ClearingDatetime.Value < cashPositionAfterReplenishment.LastTrxnAt)
        //            {
        //                LogableTask.LogMonoActivityTask("Ignore Trxn", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Cash position is not updated bcoz we have trxn of future date: " + cashPositionAfterReplenishment.LastTrxnAt);
        //                return;
        //            }

        //            if (cashCountRemaining.NotesRemainingType1.HasValue)
        //                cashPositionAfterReplenishment.Cassette1Notes = cashCountRemaining.NotesRemainingType1;
        //            else
        //                cashPositionAfterReplenishment.Cassette1Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType2.HasValue)
        //                cashPositionAfterReplenishment.Cassette2Notes = cashCountRemaining.NotesRemainingType2;
        //            else
        //                cashPositionAfterReplenishment.Cassette2Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType3.HasValue)
        //                cashPositionAfterReplenishment.Cassette3Notes = cashCountRemaining.NotesRemainingType3;
        //            else
        //                cashPositionAfterReplenishment.Cassette3Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType4.HasValue)
        //                cashPositionAfterReplenishment.Cassette4Notes = cashCountRemaining.NotesRemainingType4;
        //            else
        //                cashPositionAfterReplenishment.Cassette4Notes = 0;

        //            cashPositionAfterReplenishment.Cassette5Notes = 0;
        //            cashPositionAfterReplenishment.Cassette6Notes = 0;
        //            cashPositionAfterReplenishment.Cassette7Notes = 0;

        //            cashPositionAfterReplenishment.TaskId = cashCountRemaining.TaskId.Value;
        //            cashPositionAfterReplenishment.Save(trxn.Connection, trxn);
        //            EJToCounterMapper.EJToCounterMapper.EjCashPositionMigrator(cashPositionAfterReplenishment, trxn);
        //        }
        //        else // If there's no cash position for current day.
        //        {
        //            DateTime? lastAtmTrxnAt;
        //            cashPositionAfterReplenishment = new EjCashPosition();
        //            cashPositionAfterReplenishment.AtmId = cashCountRemaining.AtmId.Value;

        //            if (cashCountRemaining.NotesRemainingType1.HasValue)
        //                cashPositionAfterReplenishment.Cassette1Notes = cashCountRemaining.NotesRemainingType1;
        //            else
        //                cashPositionAfterReplenishment.Cassette1Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType2.HasValue)
        //                cashPositionAfterReplenishment.Cassette2Notes = cashCountRemaining.NotesRemainingType2;
        //            else
        //                cashPositionAfterReplenishment.Cassette2Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType3.HasValue)
        //                cashPositionAfterReplenishment.Cassette3Notes = cashCountRemaining.NotesRemainingType3;
        //            else
        //                cashPositionAfterReplenishment.Cassette3Notes = 0;

        //            if (cashCountRemaining.NotesRemainingType4.HasValue)
        //                cashPositionAfterReplenishment.Cassette4Notes = cashCountRemaining.NotesRemainingType4;
        //            else
        //                cashPositionAfterReplenishment.Cassette4Notes = 0;

        //            cashPositionAfterReplenishment.Cassette5Notes = 0;
        //            cashPositionAfterReplenishment.Cassette6Notes = 0;
        //            cashPositionAfterReplenishment.Cassette7Notes = 0;

        //            ///<Summary>
        //            ///Handling the case to get last transaction date when there is no cash position for today
        //            ///And even when there is no cash position on any day, it will insert the replenishment time.
        //            //cashPositionAfterReplenishment.LastTrxnAt = lastTrxnAt;
        //            object result = ConnectionFactory.ExecuteScalar("Select MAX(last_trxn_at) from ej_cash_position where atm_id = " + cashCountRemaining.AtmId + " and last_trxn_at <= CONVERT(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy HH:mm:ss") + "', 103)");
        //            lastAtmTrxnAt = (DateTime?)(result == DBNull.Value ? null : result);
        //            cashPositionAfterReplenishment.LastTrxnAt = lastAtmTrxnAt != null ? lastAtmTrxnAt.Value : lastTrxnAt;

        //            cashPositionAfterReplenishment.TaskId = cashCountRemaining.TaskId.Value;
        //            cashPositionAfterReplenishment.Save(trxn.Connection, trxn);
        //            EJToCounterMapper.EJToCounterMapper.EjCashPositionMigrator(cashPositionAfterReplenishment, trxn);
        //        }
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            //task.EndTask();
        //        }
        //        catch (Exception ex)
        //        {
        //            EventLog.WriteEntry("ReplenishmentInfo", ex.Message + " " + ex.StackTrace);
        //        }

        //    }
        //}
    }
}
