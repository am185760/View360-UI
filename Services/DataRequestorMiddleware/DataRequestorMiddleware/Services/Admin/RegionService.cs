using Encryption;
using EView360Models.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EView360Models.Core;

namespace DataRequestorMiddleware.Services.Admin
{
    public class RegionService
    {
        public List<Region> GetRegions(ref string error)
        {
            List<Region> regions = new();

            try
            {
                string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
                connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");

                DataTable result = new();
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetRegions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    conn.Close();
                    da.Dispose();
                }
                if (result?.Rows?.Count > 0)
                {
                    regions = ConvertDataTableToList(result);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return regions;
        }

        public List<Region> ConvertDataTableToList(DataTable dataTable)
        {
            List<Region> regions = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Region region = new()
                    {
                        RegionName = !DBNull.Value.Equals(row["region_name"]) ? row["region_name"].ToString() : string.Empty,
                        RegionId = !DBNull.Value.Equals(row["region_id"]) ? Convert.ToInt64(row["region_id"]) : 0,
                        ParentRegionId = !DBNull.Value.Equals(row["parent_region_id"]) ? Convert.ToInt64(row["parent_region_id"]) : null
                    };
                    regions.Add(region);
                }
            }
            return regions;
        }
    }
}
