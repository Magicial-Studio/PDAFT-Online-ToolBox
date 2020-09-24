using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace PDAFT_Online_ToolBox
{
    public class NativeMethods
    {
        [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint FlushDNSResolverCache();
    }
}