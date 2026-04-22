using Encryption;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRequestor;
using System.Collections;
using System.Data.Common;
using System.Xml.Linq;

namespace DataRequestorMiddleware.Services.Admin
{
    public class AtmTreeService
    {
        public List<AtmViewModel> GetAtmsByUser(long id, ref string error)
        {
            List<AtmViewModel> atms = new();

            try
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UserId";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = id;

                string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");

                DataTable result = new();
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "GetAtmsByUserId";
                    command.CommandTimeout = 90;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddRange(new SqlParameter[] { param1 });
                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(result);
                    conn.Close();
                    da.Dispose();
                }
                if (result?.Rows?.Count > 0)
                {
                    atms = ConvertDataTableToList(result);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return atms;
        }

        public List<AtmViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<AtmViewModel> atms = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    AtmViewModel atm = new()
                    {
                        Title = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        AtmType = !DBNull.Value.Equals(row["atm_type"]) ? row["atm_type"].ToString() : string.Empty,
                        AtmId = !DBNull.Value.Equals(row["ATM_id"]) ? Convert.ToInt64(row["ATM_id"]) : 0,
                        Ip = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                        MinOperatingBalance = !DBNull.Value.Equals(row["min_operating_balance"]) ? Convert.ToInt32(row["min_operating_balance"]) : 0,
                        IsCdm = !DBNull.Value.Equals(row["is_cdm"]) ? Convert.ToBoolean(row["is_cdm"]) : false,
                        IsAtm = !DBNull.Value.Equals(row["is_atm"]) ? Convert.ToBoolean(row["is_atm"]) : false,
                        IsRecycler = !DBNull.Value.Equals(row["is_recycler"]) ? Convert.ToBoolean(row["is_recycler"]) : false,
                        RegionId = !DBNull.Value.Equals(row["region_id"]) ? Convert.ToInt64(row["region_id"]) : 0,
                        Location = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        IsHealthy = !DBNull.Value.Equals(row["is_healthy"]) ? Convert.ToBoolean(row["is_healthy"]) : false,
                        NoteSetTypeId = !DBNull.Value.Equals(row["note_set_type_id"]) ? Convert.ToInt64(row["note_set_type_id"]) : 0,
                    };
                    atms.Add(atm);
                }
            }
            return atms;
        }
    }
}
