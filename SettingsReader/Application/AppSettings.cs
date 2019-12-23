using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingsReader.Application
{
    public interface IAppSettings
    {
        string Variable1 { get; set; }
        EvariantSettings EvariantSettings { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string Variable1 { get; set; }
        public EvariantSettings EvariantSettings { get; set; }
    }

    public class EvariantSettings
    {
        public string TokenUri { get; set; }
    }
}
