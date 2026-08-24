using ServicesDAL;
using System;
using System.Data;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class DepositSummaryProcessor
    {
        public void Run(DataTable dtDeposit)
        {
            string currentCPMStatus = null;
            string currentBNAStatus = null;
            string[] subParts = null;
            int j = 0, k = 0;

            for (int l = 0; l < dtDeposit.Rows.Count; l++)
            {
                LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + dtDeposit.Rows[l]["Parser_Post_Processing_Task_Id"] + " type:" + dtDeposit.Rows[l]["Event_Type"]);

                try
                {
                    int taskID = int.Parse(dtDeposit.Rows[l]["task_id"].ToString());
                    Atm atm = Atm.LoadAtm("atm_id ="+int.Parse(dtDeposit.Rows[l]["atm_id"].ToString()));
                    long atmID = atm.ATMId;

                    if (dtDeposit.Rows[l]["event_type"].ToString() == "ChequeDepositSummary")
                        currentCPMStatus = dtDeposit.Rows[l]["event_info"].ToString();
                    else
                        currentBNAStatus = dtDeposit.Rows[l]["event_info"].ToString();

                    k = 0;
                    decimal total = 0;
                    if (currentCPMStatus != null || currentBNAStatus != null)
                    {
                        //atmID = int.Parse(dtDeposit.Rows[l]["atm_id"].ToString());
                        //taskID = int.Parse(dtDeposit.Rows[l]["task_id"].ToString());
                        DepositPosition depositPosition = DepositPosition.LoadDepositPosition("atm_id=" + dtDeposit.Rows[l]["atm_id"]);
                        if (depositPosition == null)
                        {
                            depositPosition = new DepositPosition();

                            if (currentCPMStatus != null)
                            {
                                subParts = currentCPMStatus.Split('|');
                                j = 2;
                                k = 5;
                                depositPosition.Bin1 = int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin2 = int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin3 = int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin4 = 0;
                                depositPosition.LastCpmDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                            }
                            //else
                            //{
                            //    depositPosition.Bin1 = 0;
                            //    depositPosition.Bin2 = 0;
                            //    depositPosition.Bin3 = 0;
                            //    depositPosition.Bin4 = 0;
                            //}

                            if (currentBNAStatus != null)
                            {
                                subParts = currentBNAStatus.Split('|');
                                depositPosition.Cassette1Deposit = 0;
                                depositPosition.Cassette2Deposit = 0;
                                depositPosition.Cassette3Deposit = 0;
                                depositPosition.Cassette4Deposit = 0;
                                depositPosition.PurgeDeposit = 0;

                                depositPosition.Cassette1DepositValue = "";
                                depositPosition.Cassette2DepositValue = "";
                                depositPosition.Cassette3DepositValue = "";
                                depositPosition.Cassette4DepositValue = "";
                                depositPosition.PurgeDepositValue = "";


                                depositPosition.LastBnaDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);

                                j = 2;
                                k = 252;
                                total = 0;
                                depositPosition.Cassette1DepositValue = "";


                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette1Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                    //{
                                    //    depositPosition.Cassette1DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                    //    total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                    //}
                                    j++;
                                    k++;
                                }
                                //depositPosition.Cassette1DepositValue += "=" + total;



                                //GetDenominationDetail(depositPosition.Cassette1DepositValue, parsedBnaCounter.Cassette1Counter1.Value, parsedBnaCounter.Cassette1Counter2.Value, parsedBnaCounter.Cassette1Counter3.Value,
                                //    parsedBnaCounter.Cassette1Counter4.Value, parsedBnaCounter.Cassette1Counter5.Value, parsedBnaCounter.Cassette1Counter6.Value);

                                //string[] detailParts = depositPosition.Cassette1DepositValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                //Hashtable ht = new Hashtable();
                                //StringBuilder builder = new StringBuilder();
                                //for (int i = 0; i < detailParts.Length - 1; i++)
                                //{
                                //    string[] detailSubParts = detailParts[i].Split('*');
                                //    //1*100
                                //    //500*300

                                //    if (!ht.Contains(detailSubParts[0]))
                                //        ht.Add(detailSubParts[0], detailSubParts[1]);


                                //    int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    if (int.Parse(denominationMapping[idx]) == 1)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter1;
                                //    else if (int.Parse(denominationMapping[idx]) == 2)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter2;
                                //    else if (int.Parse(denominationMapping[idx]) == 3)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter3;
                                //    else if (int.Parse(denominationMapping[idx]) == 4)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter4;
                                //    else if (int.Parse(denominationMapping[idx]) == 5)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter5;
                                //    else if (int.Parse(denominationMapping[idx]) == 6)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter6;
                                //    //}
                                //    //else
                                //    //{
                                //    //    ht.Add(detailSubParts[0], detailSubParts[1]);

                                //    //int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    //if (int.Parse(denominationMapping[idx]) == 1)
                                //    //else if (int.Parse(denominationMapping[idx]) == 2)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter2);
                                //    //else if (int.Parse(denominationMapping[idx]) == 3)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter3);
                                //    //else if (int.Parse(denominationMapping[idx]) == 4)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter4);
                                //    //else if (int.Parse(denominationMapping[idx]) == 5)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter5);
                                //    //else if (int.Parse(denominationMapping[idx]) == 6)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter6);
                                //    // }
                                //}
                                //decimal total = 0;
                                //for (int i = 0; i < denominationMapping.Length; i++)
                                //{
                                //    if (ht.ContainsKey(denominationMapping[i]))
                                //    {
                                //        builder.Append(denominationMapping[i] + "*" + ht[denominationMapping[i]] + "\r\n");
                                //        total += int.Parse(denominationMapping[i]) * int.Parse(ht[denominationMapping[i]].ToString());
                                //    }
                                //}
                                //builder.Append("=" + total);
                                //depositPosition.Cassette1DepositValue = builder.ToString();

                                total = 0;
                                depositPosition.Cassette2DepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette2Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);

                                    //if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                    //{
                                    //    depositPosition.Cassette2DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                    //    total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));
                                    //}
                                    j++;
                                    k++;
                                }
                                //depositPosition.Cassette2DepositValue += "=" + total;
                                //depositPosition.Cassette2DepositValue = GetDenominationDetail(depositPosition.Cassette2DepositValue, parsedBnaCounter.Cassette2Counter1.Value, parsedBnaCounter.Cassette2Counter2.Value, parsedBnaCounter.Cassette2Counter3.Value,
                                // parsedBnaCounter.Cassette2Counter4.Value, parsedBnaCounter.Cassette2Counter5.Value, parsedBnaCounter.Cassette2Counter6.Value);


                                ////detailParts = depositPosition.Cassette2DepositValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                //ht = new Hashtable();
                                //builder = new StringBuilder();
                                //for (int i = 0; i < detailParts.Length - 1; i++)
                                //{
                                //    string[] detailSubParts = detailParts[i].Split('*');
                                //    //1*100
                                //    //500*300

                                //    if (!ht.Contains(detailSubParts[0]))
                                //        ht.Add(detailSubParts[0], detailSubParts[1]);

                                //    //if (ht.Contains(detailSubParts[0]))
                                //    //{
                                //    int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    if (int.Parse(denominationMapping[idx]) == 1)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter1;
                                //    else if (int.Parse(denominationMapping[idx]) == 2)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter2;
                                //    else if (int.Parse(denominationMapping[idx]) == 3)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter3;
                                //    else if (int.Parse(denominationMapping[idx]) == 4)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter4;
                                //    else if (int.Parse(denominationMapping[idx]) == 5)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter5;
                                //    else if (int.Parse(denominationMapping[idx]) == 6)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter6;
                                //    //}
                                //    //else
                                //    //{
                                //    //    ht.Add(detailSubParts[0], detailSubParts[1]);


                                //    //int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    //if (int.Parse(denominationMapping[idx]) == 1)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter1);
                                //    //else if (int.Parse(denominationMapping[idx]) == 2)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter2);
                                //    //else if (int.Parse(denominationMapping[idx]) == 3)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter3);
                                //    //else if (int.Parse(denominationMapping[idx]) == 4)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter4);
                                //    //else if (int.Parse(denominationMapping[idx]) == 5)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter5);
                                //    //else if (int.Parse(denominationMapping[idx]) == 6)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter6);
                                //    //}
                                //}
                                //total = 0;
                                //for (int i = 0; i < denominationMapping.Length; i++)
                                //{
                                //    if (ht.ContainsKey(denominationMapping[i]))
                                //    {
                                //        builder.Append(denominationMapping[i] + "*" + ht[denominationMapping[i]] + "\r\n");
                                //        total += int.Parse(denominationMapping[i]) * int.Parse(ht[denominationMapping[i]].ToString());
                                //    }
                                //}
                                //builder.Append("=" + total);
                                //depositPosition.Cassette2DepositValue = builder.ToString();


                                total = 0;
                                depositPosition.Cassette3DepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette3Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                    //{
                                    //    depositPosition.Cassette3DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                    //    total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                    //}

                                    j++;
                                    k++;
                                }
                                //depositPosition.Cassette3DepositValue += "=" + total;
                                //  depositPosition.Cassette3DepositValue = GetDenominationDetail(depositPosition.Cassette3DepositValue, parsedBnaCounter.Cassette3Counter1.Value, parsedBnaCounter.Cassette3Counter2.Value, parsedBnaCounter.Cassette3Counter3.Value,
                                //parsedBnaCounter.Cassette3Counter4.Value, parsedBnaCounter.Cassette3Counter5.Value, parsedBnaCounter.Cassette3Counter6.Value);
                                total = 0;
                                depositPosition.Cassette4DepositValue = "";

                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette4Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //    depositPosition.Cassette4DepositValue = GetDenominationDetail(depositPosition.Cassette4DepositValue, parsedBnaCounter.Cassette4Counter1.Value, parsedBnaCounter.Cassette4Counter2.Value, parsedBnaCounter.Cassette4Counter3.Value,
                                    //parsedBnaCounter.Cassette4Counter4.Value, parsedBnaCounter.Cassette4Counter5.Value, parsedBnaCounter.Cassette4Counter6.Value);
                                    //if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                    //{
                                    //    depositPosition.Cassette4DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                    //    total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                    //}
                                    j++;
                                    k++;
                                }
                                //depositPosition.Cassette4DepositValue += "=" + total;
                                //total = 0;
                                //depositPosition.PurgeDepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.PurgeDeposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //        depositPosition.PurgeDepositValue = GetDenominationDetail(depositPosition.PurgeDepositValue, parsedBnaCounter.PurgeCounter1.Value, parsedBnaCounter.PurgeCounter2.Value, parsedBnaCounter.PurgeCounter3.Value,
                                    //parsedBnaCounter.PurgeCounter4.Value, parsedBnaCounter.PurgeCounter5.Value, parsedBnaCounter.PurgeCounter6.Value);
                                    //if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                    //{
                                    //    depositPosition.PurgeDepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                    //    total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                    //}
                                    j++;
                                    k++;
                                }
                                //depositPosition.PurgeDepositValue += "=" + total;



                            }
                            //else
                            //{
                            //    depositPosition.Cassette1Deposit = 0;
                            //    depositPosition.Cassette2Deposit = 0;
                            //    depositPosition.Cassette3Deposit = 0;
                            //    depositPosition.Cassette4Deposit = 0;
                            //    depositPosition.PurgeDeposit = 0;

                            //}

                            depositPosition.AtmId = atmID;
                            depositPosition.Save();


                        }
                        else
                        {
                            if (currentCPMStatus != null)
                            {
                                depositPosition.Bin1 = 0;
                                depositPosition.Bin2 = 0;
                                depositPosition.Bin3 = 0;
                                depositPosition.Bin4 = 0;

                                j = 2;
                                k = 5;
                                subParts = currentCPMStatus.Split('|');
                                depositPosition.Bin1 += int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin2 += int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin3 += int.Parse(subParts[j++]) + int.Parse(subParts[k++]);
                                depositPosition.Bin4 = 0;
                                depositPosition.LastCpmDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);
                            }
                            if (currentBNAStatus != null)
                            {
                                depositPosition.Cassette1Deposit = 0;
                                depositPosition.Cassette2Deposit = 0;
                                depositPosition.Cassette3Deposit = 0;
                                depositPosition.Cassette4Deposit = 0;
                                depositPosition.PurgeDeposit = 0;

                                subParts = currentBNAStatus.Split('|');
                                depositPosition.LastBnaDepositAt = DateTime.ParseExact(subParts[0], "MM/dd/yyyy HH:mm:ss", null);

                                j = 2;
                                k = 252;
                                total = 0;
                                depositPosition.Cassette1DepositValue = "";

                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette1Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    if (EV360BusinessRulesProcessor.denominationMapping.Length > 0)
                                    {
                                        if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                        {
                                            depositPosition.Cassette1DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                            total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                        }
                                    }
                                    j++;
                                    k++;
                                }
                                depositPosition.Cassette1DepositValue += "=" + total;



                                //GetDenominationDetail(depositPosition.Cassette1DepositValue, parsedBnaCounter.Cassette1Counter1.Value, parsedBnaCounter.Cassette1Counter2.Value, parsedBnaCounter.Cassette1Counter3.Value,
                                //    parsedBnaCounter.Cassette1Counter4.Value, parsedBnaCounter.Cassette1Counter5.Value, parsedBnaCounter.Cassette1Counter6.Value);

                                //string[] detailParts = depositPosition.Cassette1DepositValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                //Hashtable ht = new Hashtable();
                                //StringBuilder builder = new StringBuilder();
                                //for (int i = 0; i < detailParts.Length - 1; i++)
                                //{
                                //    string[] detailSubParts = detailParts[i].Split('*');
                                //    //1*100
                                //    //500*300

                                //    if (!ht.Contains(detailSubParts[0]))
                                //        ht.Add(detailSubParts[0], detailSubParts[1]);


                                //    int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    if (int.Parse(denominationMapping[idx]) == 1)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter1;
                                //    else if (int.Parse(denominationMapping[idx]) == 2)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter2;
                                //    else if (int.Parse(denominationMapping[idx]) == 3)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter3;
                                //    else if (int.Parse(denominationMapping[idx]) == 4)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter4;
                                //    else if (int.Parse(denominationMapping[idx]) == 5)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter5;
                                //    else if (int.Parse(denominationMapping[idx]) == 6)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette1Counter6;
                                //    //}
                                //    //else
                                //    //{
                                //    //    ht.Add(detailSubParts[0], detailSubParts[1]);

                                //    //int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    //if (int.Parse(denominationMapping[idx]) == 1)
                                //    //else if (int.Parse(denominationMapping[idx]) == 2)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter2);
                                //    //else if (int.Parse(denominationMapping[idx]) == 3)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter3);
                                //    //else if (int.Parse(denominationMapping[idx]) == 4)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter4);
                                //    //else if (int.Parse(denominationMapping[idx]) == 5)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter5);
                                //    //else if (int.Parse(denominationMapping[idx]) == 6)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter6);
                                //    // }
                                //}
                                //decimal total = 0;
                                //for (int i = 0; i < denominationMapping.Length; i++)
                                //{
                                //    if (ht.ContainsKey(denominationMapping[i]))
                                //    {
                                //        builder.Append(denominationMapping[i] + "*" + ht[denominationMapping[i]] + "\r\n");
                                //        total += int.Parse(denominationMapping[i]) * int.Parse(ht[denominationMapping[i]].ToString());
                                //    }
                                //}
                                //builder.Append("=" + total);
                                //depositPosition.Cassette1DepositValue = builder.ToString();

                                total = 0;
                                depositPosition.Cassette2DepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette2Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    if (EV360BusinessRulesProcessor.denominationMapping.Length > 0)
                                    {
                                        if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                        {
                                            depositPosition.Cassette2DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                            total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));
                                        }
                                    }
                                    j++;
                                    k++;
                                }
                                depositPosition.Cassette2DepositValue += "=" + total;
                                //depositPosition.Cassette2DepositValue = GetDenominationDetail(depositPosition.Cassette2DepositValue, parsedBnaCounter.Cassette2Counter1.Value, parsedBnaCounter.Cassette2Counter2.Value, parsedBnaCounter.Cassette2Counter3.Value,
                                // parsedBnaCounter.Cassette2Counter4.Value, parsedBnaCounter.Cassette2Counter5.Value, parsedBnaCounter.Cassette2Counter6.Value);


                                ////detailParts = depositPosition.Cassette2DepositValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                //ht = new Hashtable();
                                //builder = new StringBuilder();
                                //for (int i = 0; i < detailParts.Length - 1; i++)
                                //{
                                //    string[] detailSubParts = detailParts[i].Split('*');
                                //    //1*100
                                //    //500*300

                                //    if (!ht.Contains(detailSubParts[0]))
                                //        ht.Add(detailSubParts[0], detailSubParts[1]);

                                //    //if (ht.Contains(detailSubParts[0]))
                                //    //{
                                //    int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    if (int.Parse(denominationMapping[idx]) == 1)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter1;
                                //    else if (int.Parse(denominationMapping[idx]) == 2)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter2;
                                //    else if (int.Parse(denominationMapping[idx]) == 3)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter3;
                                //    else if (int.Parse(denominationMapping[idx]) == 4)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter4;
                                //    else if (int.Parse(denominationMapping[idx]) == 5)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter5;
                                //    else if (int.Parse(denominationMapping[idx]) == 6)
                                //        ht[detailSubParts[0]] = int.Parse(detailSubParts[1]) + parsedBnaCounter.Cassette2Counter6;
                                //    //}
                                //    //else
                                //    //{
                                //    //    ht.Add(detailSubParts[0], detailSubParts[1]);


                                //    //int idx = Array.IndexOf(denominationMapping, detailSubParts[0]);
                                //    //if (int.Parse(denominationMapping[idx]) == 1)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter1);
                                //    //else if (int.Parse(denominationMapping[idx]) == 2)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter2);
                                //    //else if (int.Parse(denominationMapping[idx]) == 3)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter3);
                                //    //else if (int.Parse(denominationMapping[idx]) == 4)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter4);
                                //    //else if (int.Parse(denominationMapping[idx]) == 5)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter5);
                                //    //else if (int.Parse(denominationMapping[idx]) == 6)
                                //    //    ht.Add(detailSubParts[0], parsedBnaCounter.Cassette1Counter6);
                                //    //}
                                //}
                                //total = 0;
                                //for (int i = 0; i < denominationMapping.Length; i++)
                                //{
                                //    if (ht.ContainsKey(denominationMapping[i]))
                                //    {
                                //        builder.Append(denominationMapping[i] + "*" + ht[denominationMapping[i]] + "\r\n");
                                //        total += int.Parse(denominationMapping[i]) * int.Parse(ht[denominationMapping[i]].ToString());
                                //    }
                                //}
                                //builder.Append("=" + total);
                                //depositPosition.Cassette2DepositValue = builder.ToString();



                                total = 0;
                                depositPosition.Cassette3DepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette3Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    if (EV360BusinessRulesProcessor.denominationMapping.Length > 0)
                                    {
                                        if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                        {
                                            depositPosition.Cassette3DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                            total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                        }
                                    }

                                    j++;
                                    k++;
                                }
                                depositPosition.Cassette3DepositValue += "=" + total;
                                //  depositPosition.Cassette3DepositValue = GetDenominationDetail(depositPosition.Cassette3DepositValue, parsedBnaCounter.Cassette3Counter1.Value, parsedBnaCounter.Cassette3Counter2.Value, parsedBnaCounter.Cassette3Counter3.Value,
                                //parsedBnaCounter.Cassette3Counter4.Value, parsedBnaCounter.Cassette3Counter5.Value, parsedBnaCounter.Cassette3Counter6.Value);
                                total = 0;
                                depositPosition.Cassette4DepositValue = "";

                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.Cassette4Deposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //    depositPosition.Cassette4DepositValue = GetDenominationDetail(depositPosition.Cassette4DepositValue, parsedBnaCounter.Cassette4Counter1.Value, parsedBnaCounter.Cassette4Counter2.Value, parsedBnaCounter.Cassette4Counter3.Value,
                                    //parsedBnaCounter.Cassette4Counter4.Value, parsedBnaCounter.Cassette4Counter5.Value, parsedBnaCounter.Cassette4Counter6.Value);
                                    if (EV360BusinessRulesProcessor.denominationMapping.Length > 0)
                                    {
                                        if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                        {
                                            depositPosition.Cassette4DepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                            total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                        }
                                    }
                                    j++;
                                    k++;
                                }
                                depositPosition.Cassette4DepositValue += "=" + total;

                                total = 0;
                                depositPosition.PurgeDepositValue = "";
                                for (int i = 0; i < 50; i++)
                                {
                                    depositPosition.PurgeDeposit += int.Parse(subParts[j]) + int.Parse(subParts[k]);
                                    //        depositPosition.PurgeDepositValue = GetDenominationDetail(depositPosition.PurgeDepositValue, parsedBnaCounter.PurgeCounter1.Value, parsedBnaCounter.PurgeCounter2.Value, parsedBnaCounter.PurgeCounter3.Value,
                                    //parsedBnaCounter.PurgeCounter4.Value, parsedBnaCounter.PurgeCounter5.Value, parsedBnaCounter.PurgeCounter6.Value);
                                    if (EV360BusinessRulesProcessor.denominationMapping.Length > 0)
                                    {
                                        if (i < EV360BusinessRulesProcessor.denominationMapping.Length)
                                        {
                                            depositPosition.PurgeDepositValue += EV360BusinessRulesProcessor.denominationMapping[i] + "*" + (int.Parse(subParts[j]) + int.Parse(subParts[k])).ToString() + "<br>";
                                            total += int.Parse(EV360BusinessRulesProcessor.denominationMapping[i]) * (int.Parse(subParts[j]) + int.Parse(subParts[k]));

                                        }
                                    }
                                    j++;
                                    k++;
                                }
                                depositPosition.PurgeDepositValue += "=" + total;



                            }

                            depositPosition.Save();
                        }
                        //Atm atm = Atm.LoadAtmByPk(atmID);
                         

                    }

                    //cmd = ConnectionFactory.GetNewCommand(true);
                    //trxn = cmd.Connection.BeginTransaction();
                    //ExecuteStoredProcedure("UpdateAlert", "alert_type_id=18 and atm_id=" + dtDeposit.Rows[l]["atm_id"] + " and resolve_at is null", -1, trxn);
                    //processedIds.Append("'" + dtDeposit.Rows[l]["parser_post_processing_task_id"].ToString() + "',");
                    EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", dtDeposit.Rows[l]["parser_post_processing_task_id"].ToString(), null);
                }

                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex);

                }
            }
        }
    }

}