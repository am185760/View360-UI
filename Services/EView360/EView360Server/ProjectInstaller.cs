using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace Avanza.CCMS
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            //EventLogInstaller inst = FindEventLogInstaller(this.Installers);
            //if (inst != null)
            //{
            //    inst.Log = "NCR Managed Services";
            //};

        }
        private EventLogInstaller FindEventLogInstaller(InstallerCollection installers)
        {
            foreach (Installer inst in installers)
            {
                if (inst is EventLogInstaller)
                    return (EventLogInstaller)inst;

                if (inst.Installers != null)
                {
                    EventLogInstaller instLog = FindEventLogInstaller(inst.Installers);
                    if (instLog != null)
                        return instLog;
                };
            };

            return null;
        }


    }
}