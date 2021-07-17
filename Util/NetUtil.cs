using System;
using System.Net;
using System.Net.Sockets;

namespace RCTool_Server.Util
{
    public static class NetUtil
    {
        public static string GetIPAddressFromTcpClient(TcpClient client)
        {
            try
            {
                var ip = (client.Client.RemoteEndPoint as IPEndPoint)?.Address?.ToString();
                var port = (client.Client.RemoteEndPoint as IPEndPoint)?.Port;
                var id = ip + ":" + port;
                return id;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public static string GetIPAddressFromSocket(Socket socket)
        {
            try
            {
                var ip = (socket.RemoteEndPoint as IPEndPoint)?.Address?.ToString();
                var port = (socket.RemoteEndPoint as IPEndPoint)?.Port;
                var id = ip + ":" + port;
                return id;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }
    }
}
