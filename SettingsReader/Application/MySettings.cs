using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingsReader.Application
{
    public class MySettings: IMySettings
    {
        public string EnvironmentName { get; set; }

        public string VariableToOverride { get; set; }
    }
}
