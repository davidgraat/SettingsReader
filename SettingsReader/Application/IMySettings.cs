using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingsReader.Application
{
    public interface IMySettings
    {
        string EnvironmentName { get; set; }

        string VariableToOverride { get; set; }
    }
}
