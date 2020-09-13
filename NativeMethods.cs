using System.Runtime.InteropServices;

namespace AFT_Online_Stater
{
    public class NativeMethods
    {
        [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint FlushDNSResolverCache();
    }
}