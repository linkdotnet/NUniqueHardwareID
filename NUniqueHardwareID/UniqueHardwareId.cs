using System.Security.Cryptography;
using System.Text;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <inheritdoc/>
    public class UniqueHardwareId : IUniqueHardwareId
    {
        /// <inheritdoc/>
        public bool UseCPUInformation { get; set; } = true;

        /// <inheritdoc/>
        public bool UseMACAddress { get; set; } = true;

        /// <inheritdoc/>
        public bool UseVolumeInformation { get; set; } = true;

        /// <inheritdoc/>
        public string CalculateHardwareId()
        {
            return CalculateHardwareId(MD5.Create());
        }

        /// <inheritdoc/>
        public string CalculateHardwareId(HashAlgorithm hashAlgorithm)
        {
            //// No work to be done, when every option is turned off
            if ((UseCPUInformation ||  UseMACAddress || UseVolumeInformation) == false)
            {
                return null;
            }

            var plainHardware = string.Empty;

            if (UseCPUInformation)
            {
                plainHardware += CPURetriever.GetCPUInfo();
            }

            if (UseMACAddress)
            {
                plainHardware += MACRetriever.GetMACAddressFromPrimaryDevice();
            }

            if (UseVolumeInformation)
            {
                plainHardware += HardDriveId.GetSerialNumber();
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
