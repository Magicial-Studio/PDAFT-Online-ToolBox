using System.Net;
using System.Net.Sockets;

namespace PDAFT_Online_ToolBox
{
    public class Utils
    {
        public static IPEndPoint BestLocalEndPoint(IPEndPoint remoteIPEndPoint)
        {
            Socket testSocket = new Socket(remoteIPEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            testSocket.Connect(remoteIPEndPoint);
            return (IPEndPoint) testSocket.LocalEndPoint;
        }
    }
}