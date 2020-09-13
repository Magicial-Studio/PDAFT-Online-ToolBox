using System.Runtime.InteropServices;

namespace PDAFT_Online_ToolBox
{
    public class NativeMethods
    {
        [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint FlushDNSResolverCache();
    }
}