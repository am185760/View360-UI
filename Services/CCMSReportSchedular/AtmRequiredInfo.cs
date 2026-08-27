using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCMSReportSchedular
{
    public class AtmRequiredInfo
    {
        int atm_Id;
        string title;
        int region_id;
        string ip;
        string region_name;

        public int Atm_Id
        {
            get
            {
                return atm_Id;
            }
            set
            {
                atm_Id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public int Region_id
        {
            get
            {
                return region_id;
            }
            set
            {
                region_id = value;
            }
        }

        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public string RegionName
        {
            get
            {
                return region_name;
            }
            set
            {
                region_name = value;
            }
        }
    }
}
