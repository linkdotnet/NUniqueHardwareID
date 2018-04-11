using System.Security.Cryptography;
using System.Text;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <inheritdoc/>
    public class UniqueHardwareId : IUniqueHardwareId
    {
        /// <inheritdoc/>
        public bool ShouldUseCPUInfo { get; set; } = true;

        /// <inheritdoc/>
        public bool ShouldUseMACAddress { get; set; } = true;

        /// <inheritdoc/>
        public string CalculateHardwareId()
        {
            return CalculateHardwareId(MD5.Create());
        }
        
        public string CalculateHardwareId(HashAlgorithm hashAlgorithm)
        {
            //// No work to be done, when every option is turned off
            if ((ShouldUseCPUInfo ||  ShouldUseMACAddress) == false)
            {
                return null;
            }

            var plainHardware = string.Empty;

            if (ShouldUseCPUInfo)
            {
                plainHardware += CPURetriever.GetCPUInfo();
            }

            if (ShouldUseMACAddress)
            {
                plainHardware += MACRetriever.GetMACAddressFromPrimaryDevice();
            }
            
            return GetHashString(plainHardware, hashAlgorithm);
        }

        /// <summary>
        /// Returns the hash as a string for a given inputstring
        /// </summary>
        private static string GetHashString(string inputString, HashAlgorithm hashAlgorithm)
        {
            var sb = new StringBuilder();
            foreach (var b in hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
