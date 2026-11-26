using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EV360AtmsHandler
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
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
