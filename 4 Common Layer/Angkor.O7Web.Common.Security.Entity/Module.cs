// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Common;

namespace Angkor.O7Web.Common.Security.Entity
{
    public class Module : O7Entity
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Url { get; set; }
    }
}