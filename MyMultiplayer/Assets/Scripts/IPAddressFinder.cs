using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public static class IPAddressFinder
{
    public static string GetLocalIPv4Address()
    {
        // Check if any network connection is available
        if (!NetworkInterface.GetIsNetworkAvailable())
        {
            return "No network available";
        }

        // Get the host entry for the current computer
        var host = Dns.GetHostEntry(Dns.GetHostName());

        // Find the most suitable IPv4 address
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                // This is a robust check to ensure we get a valid local IP
                return ip.ToString();
            }
        }
        return "Local IP not found";
    }
}
