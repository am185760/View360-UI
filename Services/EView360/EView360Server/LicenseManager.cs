using System.Reflection;
using System.Diagnostics;
using System.Data.SqlClient;
using ServicesDAL;
using System;

namespace Avanza.CCMS
{
    static class LicenseManager
    {
        static DateTime licensedCheckedAt;
        static int licensedATMsCount = 100;

        public static int MaxLicensedATMID()
        {
            SqlCommand cmd = null;
            try
            {
                cmd = ConnectionFactory.GetNewConnection(DatabaseName.Core).CreateCommand();
                cmd.Connection.Open();
                cmd.CommandText = "select max(atm_id) from  (select top " + GetLicensedATMs() + " atm_id from atm where is_active = 1 order by atm_id) a";

                object maxId = cmd.ExecuteScalar();
                int maxLicensedATMId = licensedATMsCount;
                if (maxId != DBNull.Value)
                    maxLicensedATMId = Convert.ToInt32(maxId);
                return maxLicensedATMId;

            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
            

        }
        public static int GetLicensedATMs()
        {

            if (licensedCheckedAt.AddHours(1) > DateTime.Now)
                return licensedATMsCount;

            licensedCheckedAt = DateTime.Now;

            //if (EView360Server.isComLicensingDisabled == "1")
            //{
            //    string licenseString = Encryption.Cryptic.DecryptString(EView360Server.appSettings.LicenseKey);
            //    string[] parts = licenseString.Split(';');
            //    //Days=3650;Terminals=800;IssueDate=24102020
            //    int days = int.Parse(parts[0].Split('=')[1]);
            //    int terminals = int.Parse(parts[1].Split('=')[1]);
            //    DateTime issueDate = DateTime.ParseExact(parts[2].Split('=')[1], "ddMMyyyy", null);

            //    if (issueDate.AddDays(days) > DateTime.Now)
            //    {
            //        licensedATMsCount = terminals;
            //    }
            //    else
            //        LogableTask.LogMonoActivityTask("CheckLicense", MethodBase.GetCurrentMethod(), TraceLevel.Info, "License Expired");

            //    LogableTask.LogMonoActivityTask("CheckLicense", MethodBase.GetCurrentMethod(), TraceLevel.Info, String.Format("license valid for {0} ATMs", licensedATMsCount));

            //    return licensedATMsCount;

            //}



            LogableTask task = LogableTask.NewTask("check License");
            try
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "going to get LicenseVerifier object");
                LicenseVerifier licenseVerifier = new LicenseVerifier();
                if (licenseVerifier.IsLicensed())
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "licensed version");
                    licensedATMsCount = licenseVerifier.GetLicensedATMsCount();
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, String.Format("license valid for {0} ATMs", licensedATMsCount));
                }
                else
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "trial version");
                    if (licenseVerifier.RemainingDays() >= 0)
                        licensedATMsCount = licenseVerifier.GetLicensedATMsCount();
                    else
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "tiral period expired valid for 5 atms now");
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, String.Format("license valid for {0} ATMs", licensedATMsCount));
                }
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, "License is not being verified. LicenseVerifier could not be created.");
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                licensedATMsCount = 100;
            }
            finally
            {
                task.EndTask();
            }
            return licensedATMsCount;
        }
    }
}
