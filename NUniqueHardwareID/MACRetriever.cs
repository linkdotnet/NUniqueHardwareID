using System.Linq;
using System.Net.NetworkInformation;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <summary>
    /// Gets the MAC-Address from the primary device
    /// </summary>
    internal static class MACRetriever
    {
        /// <summary>
        /// Gets the MAC-Address as a string
        /// </summary>
        /// <returns>Returns the MAC-Address from the first active device, which is not the loopback device</returns>
        public static string GetMACAddressFromPrimaryDevice()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            var allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .ToList();

            return allNetworkInterfaces.Any() 
                ? allNetworkInterfaces.First().GetPhysicalAddress().ToString()
                : null;
        }
    }
}
